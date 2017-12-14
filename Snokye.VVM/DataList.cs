//#define debug

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Snokye.Controls;
using Snokye.Utility;
using System.Data.SqlClient;

namespace Snokye.VVM
{
    public partial class DataList : Form, ISupportInitialize
    {
        private List<DataGridView> _allGridView;

        public long SelectedID { get; protected set; }

        public string Sentence_From { get; set; }

        private string Sentence_Where { get; set; }

        private string Sentence_OrderBy { get; set; }

        private string Sentence_Select { get; set; }

        public SqlDatabase database;//TODO:

        public DataList()
        {
            InitializeComponent();
#if DEBUG
            database = new SqlDatabase("data source=.;initial catalog=SalesmenSettlementDev;persist security info=True;user id=sa;password=123456;MultipleActiveResultSets=True;");
#else
            database = new SqlDatabase();
#endif
        }

        /// <summary>
        /// 必须在派生类中实现
        /// </summary>
        protected virtual KeyValuePair<string, SqlParameter[]>? GetFilter()
        {
            throw new NotImplementedException();
        }

        //从数据库查询数据
        public void Query(int pageIndex = 1)
        {
            //# SQL生成
            KeyValuePair<string, SqlParameter[]>? filter = GetFilter();
            string filterString = filter.HasValue && !filter.Value.Key.IsNullOrWhiteSpace() ? filter.Value.Key : "";

            string orderBy = Sentence_OrderBy.IsNullOrWhiteSpace() ? "" : ("ORDER BY " + Sentence_OrderBy);
            string where = filterString.IsNullOrWhiteSpace() ? "" : "WHERE " + filterString;
            string and = filterString.IsNullOrWhiteSpace() ? "" : ("AND " + filterString);
            string sql = @"
SELECT TOP {0}              --pageSize
{1}                         --setence_select
FROM {2}                    --setence_from
WHERE [ID] NOT IN (
--
SELECT TOP {3} [ID]         --(pageIndex-1)*pageSize
FROM {2}                    --setence_from
{4}                         --where
{5}                         --orderby
--
)
{6}                         --and
{5}";
            sql = sql.FormatWith(PagingControl.PageSize, Sentence_Select, Sentence_From, (pageIndex - 1) * PagingControl.PageSize, where, orderBy, and);
#if DEBUG
            Console.WriteLine(sql);
#endif
            DataTable dt = database.GetDataTable(sql, filter.HasValue ? filter.Value.Value : null);
            pagingControl1.Init(dt.Rows.Count);
            _allGridView.ForEach(d => d.DataSource = dt);
        }

        private void Dgv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //仅选中时才发生
            if (_allGridView.Count > 1 && sender is DataGridView dgv && dgv.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn col && col.Name.StartsWith("AutoCheckBoxColumn") && (bool)dgv[e.ColumnIndex, e.RowIndex].Value)
            {
                //其它行设置为不选择
                var query = from d in _allGridView
                            from c in d.Columns.OfType<DataGridViewCheckBoxColumn>()
                            where c.Name.StartsWith("AutoCheckBoxColumn")
                            from r in d.Rows.OfType<DataGridViewRow>()
                            where r.Index != e.RowIndex
                            select d[c.Index, r.Index];

                foreach (var item in query)
                    item.Value = false;

                //选中其它表格行
                query = from d in _allGridView
                        where d != dgv
                        from c in d.Columns.OfType<DataGridViewCheckBoxColumn>()
                        where c.Name.StartsWith("AutoCheckBoxColumn")
                        from r in d.Rows.OfType<DataGridViewRow>()
                        where r.Index == e.RowIndex
                        select d[c.Index, r.Index];

                foreach (var item in query)
                    if (!true.Equals(item.Value))
                        item.Value = true;
            }
        }

        private void bSelect_Click(object sender, EventArgs e)
        {
            var query = from d in _allGridView
                        from c in d.Columns.OfType<DataGridViewCheckBoxColumn>()
                        where c.Name.StartsWith("AutoCheckBoxColumn")
                        from r in d.Rows.OfType<DataGridViewRow>()
                        where Equals(d[c.Index, r.Index].Value, true)
                        select new { DataGridView = d, RowIndex = r.Index };
            var obj = query.FirstOrDefault();

            if (obj == null)
            {
                Msgbox.Warning("请先选择数据。");
                return;
            }

            object idValue = (from c in obj.DataGridView.Columns.OfType<DataGridViewColumn>()
                              where string.Equals(c.Name, "ID", StringComparison.CurrentCultureIgnoreCase)
                              select obj.DataGridView[c.Index, obj.RowIndex].Value).FirstOrDefault();

            if (idValue.IsNullOrDbNull() || !long.TryParse(idValue.ToString(), out long id))
                throw new Exception("没有找到选择行的ID值。");

            SelectedID = id;
            DialogResult = DialogResult.OK;
            Close();
        }

        public void BeginInit() { }

        public void EndInit()
        {
            if (DesignMode)
                return;

            //所有表格
            _allGridView = this.FindChildControl(c => c is DataGridView).OfType<DataGridView>().ToList();

            //isSelectMode
            if (Modal)
            {
                int i = 1;
                panelSelect.Visible = true;
                foreach (DataGridView dgv in _allGridView)
                {
                    DataGridViewCheckBoxColumn c = new DataGridViewCheckBoxColumn
                    {
                        Name = "AutoCheckBoxColumn" + i++,
                        HeaderText = "选择",
                        ValueType = typeof(bool),
                        AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader,
                        SortMode = DataGridViewColumnSortMode.NotSortable,
                        DisplayIndex = 0,
                        ReadOnly = false,
                        Frozen = true,
                    };
                    dgv.Columns.Insert(0, c);
                    dgv.CellValueChanged += Dgv_CellValueChanged;
                }
            }

            //FetchSelectSentence
            var query = from dgv in _allGridView
                        from col in dgv.Columns.OfType<DataGridViewColumn>()
                        where !col.DataPropertyName.IsNullOrWhiteSpace()
                        select col.DataPropertyName;

            List<string> fields = new List<string>();

            foreach (string col in query.Distinct())
            {
                fields.Add("[{0}] AS '{1}'".FormatWith(col.Replace(".", "].["), col));
            }

            Sentence_Select = string.Join(", ", fields.ToArray());

            //关联表格的操作状态
            if (_allGridView.Count > 1)
            {
                DataGridView dgv = _allGridView[0];

                for (int i = 1; i < _allGridView.Count; i++)
                {
                    DataGridView tmp = _allGridView[i];
                    dgv.SyncSelectedRowIndex(tmp);
                    dgv.SyncRowHeight(tmp);
                    dgv.SyncVerticalScroll(tmp);
                }
            }

            pagingControl1.CurrentPageChanged += Query;

            _allGridView.ForEach(d => d.Sorted += D_Sorted);
        }

        private void D_Sorted(object sender, EventArgs e)
        {
            if (sender is DataGridView d)
            {
                if (d.SortedColumn.SortMode != DataGridViewColumnSortMode.NotSortable)
                {
                    DataGridViewColumn col = d.SortedColumn;
                    var order = d.SortOrder;
                    Sentence_OrderBy = "[{0}]{1}".FormatWith(col.DataPropertyName.Replace(".", "].["), (order == System.Windows.Forms.SortOrder.Ascending ? "" : " DESC"));
                    Query();
                    col.HeaderCell.SortGlyphDirection = order;

                    throw new NotImplementedException();//TODO:
                }
            }
        }

        private void bFilter_Click(object sender, EventArgs e)
        {
            Query();
        }
    }
}
