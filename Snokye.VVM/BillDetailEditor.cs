using Snokye.Controls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Snokye.Utility;
using System.Reflection;
using System.Drawing;
using Snokye.VVM.Model;
using System.ComponentModel;
using System.Data.Objects.DataClasses;

namespace Snokye.VVM
{
    public class BillDetailEditor : GridViewer
    {
        public event Action<int, int, EntityObject> EntitySelected;

        private EditFormPurpose _formPurpose;

        public IBindingList ViewModelList { get; private set; }

        [Browsable(false)]
        public ViewModelBase BillViewModel { get; private set; }

        /// <summary>
        /// 运行时不可调用无参构造！！！
        /// </summary>
        public BillDetailEditor() { }

        public BillDetailEditor(ViewModelBase billViewModel, EditFormPurpose formPurpose)
        {
            //if (!billViewModel.GetType().Is(typeof(IBillViewModel))) throw new Exception(billViewModel.GetType().FullName + "不是有效的IBillViewModel！");
            ViewModelList = (IBindingList)((IBillViewModel)billViewModel).GetDetails();
            _formPurpose = formPurpose;

            RowHeadersWidth = 40;
            ReadOnly = false;
            BillViewModel = billViewModel;
            AutoGenerateColumns = false;
            DataError += BillDetailEditor_DataError;
            CellEndEdit += BillDetailEditor_CellEndEdit;
            CellContentClick += BillDetailEditor_CellContentClick;

            CreateColumns();
            DataSource = ViewModelList;
        }

        private void BillDetailEditor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Columns[e.ColumnIndex] is DataGridViewButtonColumn col &&
                Rows[e.RowIndex].DataBoundItem is MappedViewModelBase mvm &&
                col.Tag is Type type &&
                type.Is(typeof(DataListBase)))
            {
                PropertyInfo p = mvm.GetRealType().GetProperty(Columns[e.ColumnIndex].DataPropertyName);

                if (p != null && mvm.PropertyMappedEntity.ContainsKey(p.Name))
                {
                    EntityObject entity = mvm.PropertyMappedEntity[p.Name];

                    if (entity != null)
                    {
                        string entityType = entity.GetType().Name;
                        DataListBase f = (DataListBase)Activator.CreateInstance(type, entityType);
                        if (f.ShowDialog(this.GetParentForm()) == DialogResult.OK)
                        {
                            EntityObject eo = f.SelectedEntity;
                            mvm.ChangeMappedEntity(Columns[e.ColumnIndex].DataPropertyName, eo);
                            mvm.UpdateEntityMappedValue(eo);

                            //事件
                            EntitySelected?.Invoke(e.RowIndex, e.ColumnIndex, eo);
                            InvalidateRow(e.RowIndex);
                        }

                    }
                }

            }
        }

        private void CreateColumns()
        {
            SuspendLayout();

            var query = from p in ((IBillViewModel)BillViewModel).GetDetailModelType().GetProperties()
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
