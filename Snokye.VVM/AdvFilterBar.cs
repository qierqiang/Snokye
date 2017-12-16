using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Snokye.Utility;

namespace Snokye.VVM
{
    public partial class AdvFilterBar : UserControl
    {
        public static readonly DataTable OperatorsTable;

        static AdvFilterBar()
        {
            OperatorsTable = new DataTable();
            OperatorsTable.Columns.Add("Text");
            OperatorsTable.Columns.Add("Value");
            OperatorsTable.Rows.Add("等于", "=");
            OperatorsTable.Rows.Add("包含", "LIKE");
            OperatorsTable.Rows.Add("大于", ">");
            OperatorsTable.Rows.Add("小于", "<");
        }

        private Control _valueEditor;

        public Control ValueEditor { get => _valueEditor; }

        public object DataSource { get => cmbField.DataSource; set => cmbField.DataSource = value; }

        public AdvFilterBar()
        {
            InitializeComponent();
            DataTable dt = OperatorsTable.Clone();

            foreach (DataRow r in OperatorsTable.Rows)
                dt.Rows.Add(r.ItemArray);

            cmbOperator.DataSource = dt;
        }

        public KeyValuePair<string, SqlParameter>? GetFilter()
        {
            if (_valueEditor == null)
                return null;

            object value = GetValueEditorValue();

            if (value == null)
                return null;

            string parmName = "@" + Name + cmbField.SelectedValue.ToString().Replace(".", "");
            object parmValue = GetValueEditorValue();
            string filter = '[' + cmbField.SelectedValue.ToString().Replace(".", "].[") + "] " + cmbOperator.SelectedValue + " " + parmName;

            if (Equals(cmbOperator.SelectedValue, "LIKE"))
                parmValue = string.Format("%{0}%", parmValue);

            if (cNot.Checked)
                filter = string.Format("NOT ({0})", filter);

            return new KeyValuePair<string, SqlParameter>(filter, new SqlParameter(parmName, parmValue));
        }

        private void CreateValueEditor(TypeCode typeCode)
        {
            switch (typeCode)
            {
                case TypeCode.Empty:
                case TypeCode.Object:
                case TypeCode.DBNull:
                case TypeCode.String:
                case TypeCode.Char:
                default:
                    CreateTextBox(typeCode);
                    break;

                case TypeCode.Boolean:
                    CreateRadioButton(typeCode);
                    break;

                case TypeCode.SByte:
                case TypeCode.Byte:
                case TypeCode.Int16:
                case TypeCode.UInt16:
                case TypeCode.Int32:
                case TypeCode.UInt32:
                case TypeCode.Int64:
                case TypeCode.UInt64:
                case TypeCode.Single:
                case TypeCode.Double:
                case TypeCode.Decimal:
                    CreateNumericUpDown(typeCode);
                    break;

                case TypeCode.DateTime:
                    CreateDateTimePicker(typeCode);
                    break;
            }
            _valueEditor = Controls["valueEditor"];
        }

        private void CreateTextBox(TypeCode typeCode)
        {
            TextBox textBox = new TextBox
            {
                Anchor = AnchorStyles.Top,
                Location = new Point(260, 3),
                Name = "valueEditor",
                Size = new Size(140, 21),
                MaxLength = 100,
                Parent = this,
            };
            if (typeCode == TypeCode.Char)
                textBox.MaxLength = 1;
        }
        private void CreateRadioButton(TypeCode typeCode)
        {
            RadioButton radio = new RadioButton
            {
                Anchor = AnchorStyles.Top,
                AutoSize = true,
                Location = new Point(260, 3),
                Name = "valueEditor",
                Text = "是",
                UseVisualStyleBackColor = true,
                Parent = this,
            };
            RadioButton radio1 = new RadioButton
            {
                Anchor = AnchorStyles.Top,
                AutoSize = true,
                Location = new Point(300, 3),
                Name = "valueEditor1",
                Text = "否",
                UseVisualStyleBackColor = true,
                Parent = this,
            };
        }
        private void CreateNumericUpDown(TypeCode typeCode)
        {
            NumericUpDown numeric = new NumericUpDown
            {
                Anchor = AnchorStyles.Top,
                Location = new Point(260, 3),
                Name = "valueEditor",
                Size = new Size(140, 21),
                TextAlign = HorizontalAlignment.Right,
                Parent = this,
            };
            switch (typeCode)
            {
                case TypeCode.SByte:
                    numeric.Minimum = sbyte.MinValue;
                    numeric.Maximum = sbyte.MaxValue;
                    numeric.DecimalPlaces = 0;
                    break;
                case TypeCode.Byte:
                    numeric.Minimum = byte.MinValue;
                    numeric.Maximum = byte.MaxValue;
                    numeric.DecimalPlaces = 0;
                    break;
                case TypeCode.Int16:
                    numeric.Minimum = Int16.MinValue;
                    numeric.Maximum = Int16.MaxValue;
                    numeric.DecimalPlaces = 0;
                    break;
                case TypeCode.UInt16:
                    numeric.Minimum = UInt16.MinValue;
                    numeric.Maximum = UInt16.MaxValue;
                    numeric.DecimalPlaces = 0;
                    break;
                case TypeCode.Int32:
                    numeric.Minimum = Int32.MinValue;
                    numeric.Maximum = Int32.MaxValue;
                    numeric.DecimalPlaces = 0;
                    break;
                case TypeCode.UInt32:
                    numeric.Minimum = UInt32.MinValue;
                    numeric.Maximum = UInt32.MaxValue;
                    numeric.DecimalPlaces = 0;
                    break;
                case TypeCode.Int64:
                    numeric.Minimum = Int64.MinValue;
                    numeric.Maximum = Int64.MaxValue;
                    numeric.DecimalPlaces = 0;
                    break;
                case TypeCode.UInt64:
                    numeric.Minimum = UInt64.MinValue;
                    numeric.Maximum = UInt64.MaxValue;
                    numeric.DecimalPlaces = 0;
                    break;

                case TypeCode.Single:
                case TypeCode.Double:
                case TypeCode.Decimal:
                    numeric.DecimalPlaces = 4;
                    break;
            }
        }
        private void CreateDateTimePicker(TypeCode typeCode)
        {
            DateTimePicker dtp = new DateTimePicker
            {
                Anchor = AnchorStyles.Top,
                Location = new Point(260, 3),
                Name = "valueEditor",
                Size = new Size(140, 21),
                Format = DateTimePickerFormat.Custom,
                CustomFormat = "yyyy-MM-dd",
                Parent = this,
            };
        }

        private void FilterOperator()
        {
            DataTable table = ((DataTable)cmbOperator.DataSource);

            if (_valueEditor is DateTimePicker p)
            {
                table.DefaultView.RowFilter = "Value != 'LIKE'";
            }
            else if (_valueEditor is RadioButton r)
            {
                table.DefaultView.RowFilter = "Value = '='";
            }
            else if (_valueEditor is NumericUpDown n)
            {
                table.DefaultView.RowFilter = "Value != 'LIKE'";
            }
            else if (_valueEditor is TextBox t)
            {
                table.DefaultView.RowFilter = "";
            }
        }
        protected internal object GetValueEditorValue()
        {
            if (_valueEditor is DateTimePicker p)
            {
                return p.Value.Date;
            }
            else if (_valueEditor is RadioButton r)
            {
                if (r.Checked) return true;
                if (((RadioButton)Controls[r.Name + 1]).Checked) return false;
                return null;
            }
            else if (_valueEditor is NumericUpDown n)
            {
                return n.Value;
            }
            else if (_valueEditor is TextBox t)
            {
                return t.Text.Trim().Length == 0 ? null : t.Text;
            }
            else
            {
                return null;
            }
        }

        private void cmbField_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_valueEditor != null)
            {
                Controls.Remove(_valueEditor);
                _valueEditor = null;
            }

            if (cmbField.SelectedItem is DataRowView r && r["ValueType"] is Type t)
            {
                TypeCode typeCode = Type.GetTypeCode(t);
                CreateValueEditor(typeCode);
                FilterOperator();
            }
        }

        private void bDelete_Click(object sender, EventArgs e)
        {
            if (Parent != null)
                Parent.Controls.Remove(this);
        }
    }
}
