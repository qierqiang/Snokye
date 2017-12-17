using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Snokye.Utility;

namespace Snokye.VVM
{
    public partial class AdvFilterForm : Form
    {
        private DataListBase _listForm;
        private DataTable _dataSource;
        int _filterCount = 1;

        public KeyValuePair<string, SqlParameter[]>? Result { get; set; }

        public AdvFilterForm(DataListBase listForm)
        {
            //GetFiledsTable
            _listForm = listForm;
            var query = from dgv in _listForm.AllGridView
                        from col in dgv.Columns.OfType<DataGridViewColumn>()
                        where !col.DataPropertyName.IsNullOrWhiteSpace() && !col.Name.StartsWith("STATICCOL")
                        select new object[] { col.HeaderText, col.DataPropertyName, col.ValueType };
            _dataSource = new DataTable();
            _dataSource.Columns.Add("Text");
            _dataSource.Columns.Add("Value");
            _dataSource.Columns.Add("ValueType", typeof(Type));

            foreach (var item in query)
                _dataSource.Rows.Add(item);

            InitializeComponent();

            flowLayoutPanel1.Controls.Clear();
            bAdd_Click(this, EventArgs.Empty);
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            AdvFilterBar bar = new AdvFilterBar
            {
                Name = "bf" + _filterCount++,
                DataSource = _dataSource,
                Parent = this.flowLayoutPanel1,
            };
        }

        private void bOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            var query = from bar in flowLayoutPanel1.Controls.OfType<AdvFilterBar>()
                        let f = bar.GetFilter()
                        where f.HasValue
                        select f.Value;

            if (!query.Any())
            {
                Result = null;
                return;
            }

            string filter = '(' + string.Join(") AND (", query.Select(f => f.Key).ToArray()) + ')';
            var parms = query.Select(f => f.Value).ToArray();
            Result = new KeyValuePair<string, SqlParameter[]>(filter, parms);
            #region 保存过滤
#if !DEBUG
            try
            {
#endif
            var queryFilter = from bar in flowLayoutPanel1.Controls.OfType<AdvFilterBar>()
                              where bar.GetFilter().HasValue
                              select new FilterProfile
                              {
                                  SelectedField = bar.cmbField.SelectedValue.ToString(),
                                  NotChecked = bar.cNot.Checked,
                                  SelectedOperator = bar.cmbOperator.SelectedValue.ToString(),
                                  ValueObject = bar.GetValueEditorValue(),
                              };
            LocalUserProfile.Save(ClientInfo.CurrentUser.UserName, _listForm.GetType().FullName + "_AdvFilter", queryFilter.ToArray());
#if !DEBUG
            }
            catch { }
#endif
            #endregion
        }

        private void AdvFilterForm_Load(object sender, EventArgs e)
        {
            #region 加载保存的过滤
#if !DEBUG
            try
            {
#endif

            FilterProfile[] profile = LocalUserProfile.GetProfile<FilterProfile[]>(ClientInfo.CurrentUser.UserName, _listForm.GetType().FullName + "_AdvFilter");

            if (profile != null)
            {
                flowLayoutPanel1.Controls.Clear();

                foreach (FilterProfile p in profile)
                {
                    AdvFilterBar bar = new AdvFilterBar
                    {
                        Name = "bf" + _filterCount++,
                        DataSource = _dataSource,
                    };
                    bar.Load += (object s, EventArgs ea) =>
                    {
                        AdvFilterBar b = (AdvFilterBar)s;
                        b.cmbField.SelectedValue = p.SelectedField;
                        b.cNot.Checked = p.NotChecked;
                        b.cmbOperator.SelectedValue = p.SelectedOperator;

                        if (b.ValueEditor is DateTimePicker dtp)
                        {
                            dtp.Value = Convert.ToDateTime(p.ValueObject);
                        }
                        else if (b.ValueEditor is RadioButton r)
                        {
                            if (Convert.ToBoolean(p.ValueObject))
                                r.Checked = true;
                            else
                                ((RadioButton)b.Controls[r.Name + 1]).Checked = true;
                        }
                        else if (b.ValueEditor is NumericUpDown n)
                        {
                            n.Value = Convert.ToDecimal(p.ValueObject);
                        }
                        else if (b.ValueEditor is TextBox t)
                        {
                            t.Text = p.ValueObject.ToString();
                        }
                    };

                    this.flowLayoutPanel1.Controls.Add(bar);
                }
            }
#if !DEBUG
            }
            catch { }
#endif
            #endregion
        }

        public class FilterProfile
        {
            public string SelectedField { get; set; }
            public bool NotChecked { get; set; }
            public string SelectedOperator { get; set; }
            public object ValueObject { get; set; }
        }
    }
}
