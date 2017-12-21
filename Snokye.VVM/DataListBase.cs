using Snokye.Controls;
using Snokye.Utility;
using Snokye.VVM.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using CD = Snokye.VVM.ColumnDefinition;

namespace Snokye.VVM
{
    public partial class DataListBase : Form, ISupportInitialize
    {
        public const string ID_ColumnName = "STATICCOL_ID";

        #region 布局相关

        /// <summary>
        /// 所有运行时创建出来的GridViewer
        /// </summary>
        [Browsable(false)]
        public List<DataGridView> AllGridView { get; set; }

        [Browsable(false)]
        public List<FilterControlBase> AllFilters { get; set; }

        /// <summary>
        /// 所有的列定义
        /// </summary>
        [Browsable(false)]
        public List<ColumnDefinition> ColumnDefinitions { get; set; }

        /// <summary>
        /// 所有在窗口上显示的过滤条件定义
        /// </summary>
        [Browsable(false)]
        public List<FilterDefinition> FilterDefinitions { get; set; }

        //ctor & inti
        public DataListBase() : this(null, null, null, "列表") { }

        public DataListBase(Type viewModelType, Type editFormType, Type viewFormType, string title)
        {
            InitializeComponent();
            Text = title;
            tslTitle.Text = title;
            ViewModelType = viewModelType;
            EditFormType = editFormType;
            ViewFormType = viewFormType;
            _database = new SqlDatabase();
        }

        /// <summary>
        /// 初始化时应当要先设置Sentence_From、Out_Where、SortColumn、SortDirection、ColumnDefinition、FilterDefinition
        /// </summary>
        public virtual void BeginInit()
        {
            ColumnDefinitions = new List<CD>
            {
                new CD(typeof(DataGridViewTextBoxColumn), "ID",   null, "ID", ID_ColumnName, visible:false),
            };
            FilterDefinitions = new List<FilterDefinition>();
        }

        public virtual void EndInit()
        {
            //==============================================
            //              创建过滤条件
            //==============================================
            AllFilters = new List<FilterControlBase>();

            foreach (FilterDefinition fd in FilterDefinitions)
            {
                FilterControlBase fc = (FilterControlBase)Activator.CreateInstance(fd.FilterControlType, true);
                fc.DataPropertyName = fd.DataPropertyName;
                fc.Title = fd.Title;
                if (!fd.FilterOperator.IsNullOrWhiteSpace()) fc.FilterOperator = fd.FilterOperator;
                fc.Parent = pFilters;
                AllFilters.Add(fc);
            }
            //==============================================
            //                  创建表格
            //==============================================

            //空白组默认设置为页面标题
            ColumnDefinitions.ForEach(c => { if (c.GroupName.IsNullOrWhiteSpace()) c.GroupName = Text; });

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
            AllGridView = this.FindChildControl(c => c is DataGridView).OfType<DataGridView>().ToList();

            //==============================================
            //               生成Select语句
            //==============================================
            var query = from dgv in AllGridView
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
            if (AllGridView.Count > 1)
            {
                DataGridView dgv = AllGridView[0];

                for (int i = 1; i < AllGridView.Count; i++)
                {
                    DataGridView tmp = AllGridView[i];
                    dgv.SyncSelectedRowIndex(tmp);
                    dgv.SyncRowHeight(tmp);
                    dgv.SyncVerticalScroll(tmp);
                }
            }

            //==============================================
            //                  注册表格事件
            //==============================================
            //注册事件
            AllGridView.ForEach(d =>
            {
                d.ColumnHeaderMouseClick += ColumnHeaderMouseClick;
                d.SelectionChanged += SelectionChanged;
                d.CellDoubleClick += CellDoubleClick;
            });
        }

        private void DataList_Load(object sender, EventArgs e)
        {
            //==============================================
            //              设置为数据选择窗口
            //==============================================
            if (!DesignMode && Modal)
            {
                int i = 1;
                panelSelect.Visible = true;
                foreach (var item in toolStrip1.Items.OfType<ToolStripItem>())
                {
                    if (item != tslTitle)
                        item.Visible = false;
                }
                //foreach (DataGridView dgv in AllGridView)
                //{
                //    dgv.ReadOnly = false;

                //    foreach (DataGridViewColumn col in dgv.Columns)
                //        col.ReadOnly = true;

                //    DataGridViewCheckBoxColumn c = new DataGridViewCheckBoxColumn
                //    {
                //        Name = "AutoCheckBoxColumn" + i++,
                //        HeaderText = "选择",
                //        ValueType = typeof(bool),
                //        AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader,
                //        SortMode = DataGridViewColumnSortMode.NotSortable,
                //        DisplayIndex = 0,
                //        ReadOnly = false,
                //        Frozen = true,
                //    };
                //    dgv.Columns.Insert(0, c);
                //    dgv.CellValueChanged += Dgv_CellValueChanged;
                //}
            }
            else
            {
                //==============================================
                //              设置窗口按钮
                //==============================================
                if (ViewModelType == null)
                {
                    foreach (var item in toolStrip1.Items.OfType<ToolStripItem>())
                    {
                        if (item != tslTitle)
                            item.Visible = false;
                    }
                }
                else
                {
                    if (EditFormType == null)
                    {
                        bNew.Visible = false;
                        bEdit.Visible = false;
                    }
                    if (ViewFormType == null)
                    {
                        bView.Visible = false;
                    }
                }
            }
            //==============================================
            //      从数据库加载列的ValueType等属性
            //==============================================
            if (!DesignMode)
            {
                PageIndex = 1;
                Sentence_Where = new KeyValuePair<string, SqlParameter[]>("1>1", null);
                Query();
            }
        }

        #endregion

        #region 加载数据相关

        private SqlDatabase _database;
        private KeyValuePair<string, SqlParameter[]>? _refreshParamters;

        [Browsable(false)]
        public SqlDatabase Database { get => _database; }

        [Browsable(false)]
        public string Sentence_Select { get; set; } //EndInit后有值
        public string Sentence_From { get; set; } //EndInit后有值
        [Browsable(false)]
        public KeyValuePair<string, SqlParameter[]>? Out_Where { get; set; } //EndInit后有值

        [Browsable(false)]
        public KeyValuePair<string, SqlParameter[]>? Sentence_Where { get; set; }
        [Browsable(false)]
        public string Sentence_OrderBy { get; set; }
        [Browsable(false)]
        public string Sentence_SortOrder { get; set; }
        [Browsable(false)]
        public int PageIndex { get; set; }

        protected virtual KeyValuePair<string, SqlParameter[]>? GetFilter()
        {
            var query = from fc in AllFilters
                        let f = fc.GetFilter()
                        where f.HasValue && !f.Value.Key.IsNullOrWhiteSpace()
                        select f.Value;

            if (!query.Any())
                return null;

            string filter = "(" + string.Join(") AND (", query.Select(f => f.Key).ToArray()) + ")";
            SqlParameter[] parms = (from f in query from ff in f.Value select ff).ToArray();
            return new KeyValuePair<string, SqlParameter[]>(filter, parms);
        }

        //从数据库查询数据
        public void Query()
        {
            //# SQL生成
            string where1 = Out_Where.HasValue ? (Out_Where.Value.Key.IsNullOrWhiteSpace() ? "" : Out_Where.Value.Key) : "";
            string where2 = Sentence_Where.HasValue ? (Sentence_Where.Value.Key.IsNullOrWhiteSpace() ? "" : Sentence_Where.Value.Key) : "";
            string where = null;
            if (where1 == "" && where2 != "") where = where2;
            if (where1 != "" && where2 == "") where = where1;
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
                int totalCount = (int)_database.ExecuteScalar(sql, parameters);
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
            _refreshParamters = new KeyValuePair<string, SqlParameter[]>(sql, parameters);

            this.BackWork(
                () =>
                {
                    return _database.GetDataTable(sql, parameters);
                },
                dt =>
                {
                    foreach (DataGridView d in AllGridView)
                    {
                        d.DataSource = dt;
                        //显示排序状态
                        if (!Sentence_OrderBy.IsNullOrWhiteSpace())
                        {
                            foreach (DataGridViewColumn c in d.Columns.OfType<DataGridViewColumn>().Where(c => "[" + c.DataPropertyName.Replace(".", "].[") + "]" == Sentence_OrderBy))
                            {
                                c.HeaderCell.SortGlyphDirection = Sentence_SortOrder == "DESC" ? System.Windows.Forms.SortOrder.Descending : System.Windows.Forms.SortOrder.Ascending;
                            }
                        }
                    }
                }
            );
        }

        #endregion

        #region 表格事件

        //private void Dgv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        //{
        //    //仅选中时才发生
        //    if (AllGridView.Count > 0 && sender is DataGridView dgv && dgv.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn col && col.Name.StartsWith("AutoCheckBoxColumn") && (bool)dgv[e.ColumnIndex, e.RowIndex].Value)
        //    {
        //        //其它行设置为不选择
        //        var query = from d in AllGridView
        //                    from c in d.Columns.OfType<DataGridViewCheckBoxColumn>()
        //                    where c.Name.StartsWith("AutoCheckBoxColumn")
        //                    from r in d.Rows.OfType<DataGridViewRow>()
        //                    where r.Index != e.RowIndex
        //                    select d[c.Index, r.Index];

        //        foreach (var item in query)
        //            item.Value = false;

        //        //选中其它表格行
        //        query = from d in AllGridView
        //                where d != dgv
        //                from c in d.Columns.OfType<DataGridViewCheckBoxColumn>()
        //                where c.Name.StartsWith("AutoCheckBoxColumn")
        //                from r in d.Rows.OfType<DataGridViewRow>()
        //                where r.Index == e.RowIndex
        //                select d[c.Index, r.Index];

        //        foreach (var item in query)
        //            if (!true.Equals(item.Value))
        //                item.Value = true;
        //    }
        //}

        private void ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (sender is DataGridView d && d.DataSource != null)
            {
                DataGridViewColumn c = d.Columns[e.ColumnIndex];

                if (c.SortMode != DataGridViewColumnSortMode.NotSortable && !c.DataPropertyName.IsNullOrWhiteSpace())
                {
                    Sentence_OrderBy = "[" + c.DataPropertyName.Replace(".", "].[") + "]";

                    if (string.Equals(Sentence_SortOrder, "DESC", StringComparison.CurrentCultureIgnoreCase))
                        Sentence_SortOrder = "";
                    else
                        Sentence_SortOrder = "DESC";

                    //pageindex, orderby, sortorder   !do NOT change 'sentence_where'!
                    PageIndex = 1;
                    Query();
                }
            }
        }

        private void SelectionChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > -1 && e.RowIndex > -1 && ((DataGridView)sender).CurrentCell != null)
            {
                bSelect_Click(bSelect, EventArgs.Empty);
            }
        }

        #endregion

        #region 返回值相关

        //[Browsable(false)]
        //public long SelectedID { get; protected set; }

        [Browsable(false)]
        public EntityObject SelectedEntity { get; protected set; }

        [Browsable(false)]
        public string EntityType { get; private set; }

        public DataListBase(string entityType, string title) : this(null, null, null, title)
        {
            EntityType = entityType;
        }

        private void bSelect_Click(object sender, EventArgs e)
        {
            //var query = from d in AllGridView
            //            from c in d.Columns.OfType<DataGridViewCheckBoxColumn>()
            //            where c.Name.StartsWith("AutoCheckBoxColumn")
            //            from r in d.Rows.OfType<DataGridViewRow>()
            //            where Equals(d[c.Index, r.Index].Value, true)
            //            select new { DataGridView = d, RowIndex = r.Index };

            var query = from d in AllGridView
                        where d.CurrentCell != null
                        from c in d.Columns.OfType<DataGridViewColumn>()
                        where string.Equals(c.Name, ID_ColumnName, StringComparison.CurrentCultureIgnoreCase)
                        select d[c.Index, d.CurrentCell.RowIndex].Value;
            var obj = query.FirstOrDefault();

            if (obj.IsNullOrDbNull() || !long.TryParse(obj.ToString(), out long id))
            {
                Msgbox.Warning("请先选择数据。");
                return;
            }

            //object idValue = (from c in obj.DataGridView.Columns.OfType<DataGridViewColumn>()
            //                  where string.Equals(c.Name, ID_ColumnName, StringComparison.CurrentCultureIgnoreCase)
            //                  select obj.DataGridView[c.Index, obj.RowIndex].Value).FirstOrDefault();

            //if (idValue.IsNullOrDbNull() || !long.TryParse(idValue.ToString(), out long id))
            //    throw new Exception("没有找到选择行的ID值。");

            //SelectedID = id;
            using (SnokyeContainer c = new SnokyeContainer())
            {
                //ObjectQuery set = (ObjectQuery)c.GetPropertyValue(EntityType);
                //var queryEntity = from e in set
                //                  where e
                EntityKey key = new EntityKey(c.DefaultContainerName + "." + EntityType + "Set", "Id", id);
                SelectedEntity = c.GetObjectByKey(key) as EntityObject;
                DialogResult = DialogResult.OK;
            }
            Close();
        }

        #endregion

        #region Command相关

        public Type ViewModelType { get; set; }

        public Type EditFormType { get; set; }

        public Type ViewFormType { get; set; }

        public virtual void ExecuteCommand(FormCommand operation)
        {
            GetType().GetMethod(operation.ToString(), BindingFlags.Instance | BindingFlags.NonPublic)?.Invoke(this, null);
        }

        internal void New()
        {
            CheckViewModelAndFormType();
            var vm = CreateViewModel();

            AutoEditForm form = (AutoEditForm)Activator.CreateInstance(EditFormType, vm, "新增 - " + Text, EditFormPurpose.Create);

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                ExecuteCommand(FormCommand.RefreshData);
            }
        }
        internal void Edit()
        {
            CheckViewModelAndFormType();
            long id = GetSelectedID();

            if (id > 0)
            {
                var vm = CreateViewModel(id);
                AutoEditForm form = (AutoEditForm)Activator.CreateInstance(EditFormType, vm, "修改 - " + Text, EditFormPurpose.Modify);

                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    ExecuteCommand(FormCommand.RefreshData);
                }
            }
        }
        internal void View()
        {
            CheckViewModelAndFormType();
            long id = GetSelectedID();

            if (id > 0)
            {
                var vm = CreateViewModel(id);
                AutoEditForm form = (AutoEditForm)Activator.CreateInstance(EditFormType, vm, "查看 - " + Text, EditFormPurpose.View);

                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    ExecuteCommand(FormCommand.RefreshData);
                }
            }
        }
        internal void Disable() { }
        internal void Delete() { }
        internal void Import() { }
        internal void Export() { }
        internal void Sum() { new CalculateForm(this).ShowDialog(this); }
        internal void Filter()
        {
            //pageindex, orderby, sortorder, where
            PageIndex = 1;
            Sentence_OrderBy = null;
            Sentence_SortOrder = null;
            Sentence_Where = GetFilter();
            Query();
        }
        internal void AdvFilter()
        {
            var form = new AdvFilterForm(this);

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                PageIndex = 1;
                Sentence_OrderBy = null;
                Sentence_SortOrder = null;
                Sentence_Where = form.Result;
                Query();
            }
        }
        internal void RefreshData()
        {
            if (_refreshParamters.HasValue)
            {
                this.BackWork(
                    () => _database.GetDataTable(_refreshParamters.Value.Key, _refreshParamters.Value.Value),
                    dt => AllGridView.ForEach(d => d.DataSource = dt)
                );
            }
        }
        internal void CloseForm() { Close(); }
        internal void Submit() { }
        internal void Print() { }
        internal void Check() { }
        internal void UnCheck() { }

        private MappedViewModelBase CreateViewModel(long id = -1)
        {
            MappedViewModelBase vm = (MappedViewModelBase)Activator.CreateInstance(ViewModelType);
            vm.LoadByID(id);
            vm = ViewModelProxy.Proxy(vm);
            return vm;
        }

        private void CheckViewModelAndFormType()
        {
            if (ViewModelType == null || EditFormType == null || ViewFormType == null)
                throw new Exception("缺少必要的参数：ViewModelType/EditFormType");
        }

        private long GetSelectedID()
        {
            var queryId = from dgv in AllGridView
                          where dgv.CurrentCell != null && dgv.Columns.Contains(ID_ColumnName)
                          select Convert.ToInt64(dgv[ID_ColumnName, dgv.CurrentCell.RowIndex].Value);

            return queryId.FirstOrDefault();
        }
        #endregion

        private void New_Click(object sender, EventArgs e) => ExecuteCommand(FormCommand.New);
        private void Edit_Click(object sender, EventArgs e) => ExecuteCommand(FormCommand.Edit);
        private void View_Click(object sender, EventArgs e) => ExecuteCommand(FormCommand.View);
        private void Disable_Click(object sender, EventArgs e) => ExecuteCommand(FormCommand.Disable);
        private void Delete_Click(object sender, EventArgs e) => ExecuteCommand(FormCommand.Delete);
        private void Export_Click(object sender, EventArgs e) => ExecuteCommand(FormCommand.Export);
        private void Calculator_Click(object sender, EventArgs e) => ExecuteCommand(FormCommand.Sum);
        private void Close_Click(object sender, EventArgs e) => ExecuteCommand(FormCommand.CloseForm);
        private void Filter_Click(object sender, EventArgs e) => ExecuteCommand(FormCommand.Filter);
        private void AdvFilter_Click(object sender, EventArgs e) => ExecuteCommand(FormCommand.AdvFilter);
        private void RefreshData_Click(object sender, EventArgs e) => ExecuteCommand(FormCommand.RefreshData);
    }
}