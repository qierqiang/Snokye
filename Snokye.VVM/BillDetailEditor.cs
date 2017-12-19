using Snokye.Controls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Snokye.Utility;

namespace Snokye.VVM
{
    public class BillDetailEditor : GridViewer //where T : ViewModelBase
    {
        private EditFormPurpose _formPurpose;

        public IList ViewModelList { get; private set; }

        /// <summary>
        /// 运行时不可调用无参构造！！！
        /// </summary>
        public BillDetailEditor() { }

        public BillDetailEditor(IList viewModelList, EditFormPurpose formPurpose)
        {
            RowHeadersWidth = 40;
            ReadOnly = false;
            ViewModelList = viewModelList;
            _formPurpose = formPurpose;
            DataError += BillDetailEditor_DataError;
            CellEndEdit += BillDetailEditor_CellEndEdit;

            CreateColumns();
            DataSource = viewModelList;
        }

        private void CreateColumns()
        {
            SuspendLayout();

            var query = from p in ViewModelList[0].GetType().GetProperties()
                        let a = p.GetAttribute<AutoGenColumnAttribute>()
                        where a != null
                        select new { Attribute = a, PropertyInfo = p };

            foreach (var item in query)
            {
                DataGridViewColumn col = (DataGridViewColumn)Activator.CreateInstance(item.Attribute.ColumnType);
                col.Name = item.PropertyInfo.Name;
                col.DataPropertyName = item.PropertyInfo.Name;
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
                col.HeaderText = item.Attribute.DisplayName;
                col.Width = item.Attribute.DefaultWidth;
                col.FillWeight = item.Attribute.DefaultWidth;
                switch (_formPurpose)
                {
                    case EditFormPurpose.Create:
                        col.ReadOnly = item.Attribute.ReadOnlyWhenCreate;
                        break;
                    case EditFormPurpose.Modify:
                        col.ReadOnly = item.Attribute.ReadOnlyWhenModify;
                        break;
                    default:
                        col.ReadOnly = true;
                        break;
                }

                if (col is DataGridViewButtonColumn bc)
                {
                    bc.FlatStyle = FlatStyle.Flat;
                    bc.Tag = item.Attribute.SelectFormType;
                }

                Columns.Add(col);

                ResumeLayout();
            }
        }

        private void BillDetailEditor_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            Rows[e.RowIndex].ErrorText = e.Exception.Message;
            e.ThrowException = false;
        }

        private void BillDetailEditor_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Rows[e.RowIndex].ErrorText = null;
        }
    }
}
