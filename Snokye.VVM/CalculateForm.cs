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
    public partial class CalculateForm : Form
    {
        private DataList _listForm;
        private DataTable _fieldsTable;

        public CalculateForm(DataList listForm)
        {
            _listForm = listForm;

            var query = from dgv in _listForm.AllGridView
                        from col in dgv.Columns.OfType<DataGridViewColumn>()
                        where !col.DataPropertyName.IsNullOrWhiteSpace() &&
                              !col.Name.StartsWith("STATICCOL") &&
                              col.ValueType.IsNumericType()
                        select new object[] { col.HeaderText, col.DataPropertyName };
            _fieldsTable = new DataTable();
            _fieldsTable.Columns.Add("Text");
            _fieldsTable.Columns.Add("Value");

            foreach (var item in query)
                _fieldsTable.Rows.Add(item);

            InitializeComponent();

            cmbFields.DataSource = _fieldsTable;
        }

        private void cmbFields_SelectedIndexChanged(object sender, EventArgs e)
        {
            //# SQL生成
            string where1 = _listForm.Out_Where.HasValue ? (_listForm.Out_Where.Value.Key.IsNullOrWhiteSpace() ? "" : _listForm.Out_Where.Value.Key) : "";
            string where2 = _listForm.Sentence_Where.HasValue ? (_listForm.Sentence_Where.Value.Key.IsNullOrWhiteSpace() ? "" : _listForm.Sentence_Where.Value.Key) : "";
            string where = null;
            if (where1 == "" && where2 != "") where = where2;
            if (where1 != "" && where2 == "") where = where1;
            if (where1 != "" && where2 != "") where = string.Format("({0}) AND ({1})", where1, where2);
            where = where.IsNullOrWhiteSpace() ? "" : "WHERE " + where;
            string sql = string.Format("SELECT SUM({2}) FROM {0} {1}", _listForm.Sentence_From, where, '[' + cmbFields.SelectedValue.ToString().Replace(".", "].[") + ']');

            List<SqlParameter> parms = new List<SqlParameter>();
            if (_listForm.Out_Where.HasValue && _listForm.Out_Where.Value.Value != null && _listForm.Out_Where.Value.Value.Length > 0)
                parms.AddRange(_listForm.Out_Where.Value.Value);
            if (_listForm.Sentence_Where.HasValue && _listForm.Sentence_Where.Value.Value != null && _listForm.Sentence_Where.Value.Value.Length > 0)
                parms.AddRange(_listForm.Sentence_Where.Value.Value);
            SqlParameter[] parameters = parms.ToArray();

            decimal value = decimal.Round(Convert.ToDecimal(_listForm.Database.ExecuteScalar(sql, parameters)), 4);
            txtValue.Text = value.ToString();
        }
    }
}
