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
using cd = Snokye.VVM.ColumnDefinition;
using SalesmenSettlement.Forms;

namespace Snokye.VVM
{
    public partial class DataList : Form, ISupportInitialize
    {
        private SqlDatabase database
        #region
#if DEBUG
             = new SqlDatabase("data source=.;initial catalog=SalesmenSettlementDev;persist security info=True;user id=sa;password=123456;MultipleActiveResultSets=True;");
#else
            = new SqlDatabase();
#endif
        #endregion

        #region 布局相关
        protected List<DataGridView> _allGridView;

        public List<ColumnDefinition> ColumnDefinitions { get; set; }

        /// <summary>
        /// 页面标题
        /// </summary>
        public string Title { get => tslTitle.Text; set => tslTitle.Text = value; }

        //ctor & inti
        public DataList()
        {
            InitializeComponent();
            Text = Title;
        }

        /// <summary>
        /// 初始化时应当要先设置Sentence_From、Out_Where、SortColumn、SortDirection、ColumnDefinition
        /// </summary>
        public virtual void BeginInit()
        {
            ColumnDefinitions = new List<ColumnDefinition>
            {
                new cd(typeof(DataGridViewTextBoxColumn), "ID", null, "ID", "ID", visible:false)
            };
        }

        public virtual void EndInit()
        {
            //==============================================
            //                  创建表格
            //==============================================

            //空白组默认设置为页面标题
            ColumnDefinitions.ForEach(c => { if (c.GroupName.IsNullOrWhiteSpace()) c.GroupName = Title; });

            //创建Tab页
            tabContainer.TabPages.Clear();
            var queryGroups = ColumnDefinitions.Select(c => c.GroupName).Distinct().ToArray();

            foreach (string g in queryGroups)
            {
                tabContainer.TabPages.Add(g);
                //创建表格
                GridViewer dgv = new GridViewer();

                //添加列
                foreach (var col in ColumnDefinitions.Where(c => c.GroupName == g))
                {
                    dgv.CreateColumn(col.ColumnType, col.Title, col.DataPropertyName, col.Name, col.Width, col.SortMode, col.SortOrder, col.Visible, col.Index, col.Frozen);
                }
                dgv.Dock = DockStyle.Fill;
                dgv.Parent = tabContainer.TabPages[tabContainer.TabCount - 1];

                //TODO: 暂不支持排序
            }

            //只有一个表格则不显示TabControl
            if (tabContainer.TabPages.Count == 1)
            {
                Control dgv = tabContainer.TabPages[0].Controls[0];
                dgv.Parent = this;
                Controls.Remove(tabContainer);
                tabContainer = null; //dispose
                dgv.BringToFront();
            }

            //所有表格
            _allGridView = this.FindChildControl(c => c is DataGridView).OfType<DataGridView>().ToList();


            //==============================================
            //              设置为数据选择窗口
            //==============================================
            if (!DesignMode && Modal)
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


            //==============================================
            //               生成Select语句
            //==============================================
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

            //==============================================
            //          关联表格的选择及滚动
            //==============================================
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

            //==============================================
            //                  注册表格事件
            //==============================================
            //注册事件
            if (!DesignMode)
            {
                _allGridView.ForEach(d => d.Sorted += D_Sorted);
            }
        }


        #endregion

        public string Sentence_Select { get; set; } //EndInit后有值
        public string Sentence_From { get; set; } //EndInit后有值
        public KeyValuePair<string, SqlParameter[]>? Out_Where { get; set; } //EndInit后有值

        public KeyValuePair<string, SqlParameter[]>? Sentence_Where { get; set; }
        public string Sentence_OrderBy { get; set; }
        public string Sentence_SortOrder { get; set; }
        public int PageIndex { get; set; }

        /// <summary>
        /// 必须在派生类中实现
        /// </summary>
        [Obsolete]
        protected virtual KeyValuePair<string, SqlParameter[]>? GetFilter()
        {
            throw new NotImplementedException();
        }

        //从数据库查询数据
        public void Query()
        {
            //# SQL生成
            string where1 = Out_Where.HasValue ? (Out_Where.Value.Key.IsNullOrWhiteSpace() ? "" : Out_Where.Value.Key) : "";
            string where2 = Sentence_Where.HasValue ? (Sentence_Where.Value.Key.IsNullOrWhiteSpace() ? "" : Sentence_Where.Value.Key) : "";
            string where = null;
            if (where1 == "" && where2 != "") where = where1;
            if (where1 != "" && where2 == "") where = where2;
            if (where1 != "" && where2 != "") where = string.Format("({0}) AND ({1})", where1, where2);
            string orderBy = Sentence_OrderBy.IsNullOrWhiteSpace() ? "" : ("ORDER BY " + Sentence_OrderBy);
            if (orderBy != "" && !Sentence_SortOrder.IsNullOrWhiteSpace()) orderBy = orderBy + " " + Sentence_SortOrder;
            string and = where.IsNullOrWhiteSpace() ? "" : "AND " + where;
            where = where.IsNullOrWhiteSpace() ? "" : "WHERE " + where;
            string sql = string.Format("SELECT COUNT(1) FROM {0} {1}", Sentence_From, where);

            List<SqlParameter> parms = new List<SqlParameter>();
            if (Out_Where.HasValue && Out_Where.Value.Value != null && Out_Where.Value.Value.Length > 0)
                parms.AddRange(Out_Where.Value.Value);
            if (Sentence_Where.HasValue && Sentence_Where.Value.Value != null && Sentence_Where.Value.Value.Length > 0)
                parms.AddRange(Sentence_Where.Value.Value);
            SqlParameter[] parameters = parms.ToArray();

            //查出总记录数
            if (PageIndex < 2)
            {
                int totalCount = (int)database.ExecuteScalar(sql, parameters);
                pagingControl1.Init(totalCount);
            }
            sql = @"
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
            sql = sql.FormatWith(PagingControl.PageSize, Sentence_Select, Sentence_From, (PageIndex - 1) * PagingControl.PageSize, where, orderBy, and);

            this.BackWork(() => database.GetDataTable(sql, parameters), dt => _allGridView.ForEach(d => d.DataSource = dt));
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
            /*
             * prepare query
             *  pageIndex
             *  orderby
             *  sortOrder
             *  where
             */
            PageIndex = 1;
            Sentence_OrderBy = null;
            Sentence_SortOrder = null;
            Sentence_Where = GetFilter();
            Query();
        }

        #region 返回值相关

        public long SelectedID { get; protected set; }

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

        #endregion
    }
}
