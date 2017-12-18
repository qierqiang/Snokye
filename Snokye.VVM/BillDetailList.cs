using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Snokye.VVM
{
    public partial class BillDetailList : UserControl
    {
        private Type _viewModelType;

        private ToolStripSeparator _separator;
        private ToolStripButton _bAddRow;
        private ToolStripButton _bRemove;

        public IList<ViewModelBase> DataSource { get => (IList<ViewModelBase>)gridViewer1.DataSource; set => gridViewer1.DataSource = value; }

        public string Title { get => tabContainer.TabPages[0].Text; set => tabContainer.TabPages[0].Text = value; }

        public BillDetailList()
        {
            InitializeComponent();
            _separator = new ToolStripSeparator();
            _bAddRow = new ToolStripButton("添加明细(&A)", Properties.Resources.icons8_加_40, OnAddRow, "bAddRow");
            _bRemove = new ToolStripButton("删除明细(&A)", Properties.Resources.icons8_减去_40, OnRemove, "bRemove");
        }

        public BillDetailList(Type viewModelType, string title) : this()
        {
            _viewModelType = viewModelType;
        }

        protected override void OnParentChanged(EventArgs e)
        {
            if (ParentForm is AutoEditBillForm bf)
            {
                bf.toolStrip1.Items.Remove(_bRemove);
                bf.toolStrip1.Items.Remove(_bAddRow);
                bf.toolStrip1.Items.Remove(_separator);
            }

            base.OnParentChanged(e);

            if (ParentForm is AutoEditBillForm bf1)
            {
                bf1.toolStrip1.Items.Insert(1, _bRemove);
                bf1.toolStrip1.Items.Insert(1, _bAddRow);
                bf1.toolStrip1.Items.Insert(1, _separator);
            }
        }

        public virtual void OnAddRow(object sender, EventArgs e)
        {
            ViewModelBase vm = (ViewModelBase)Activator.CreateInstance(_viewModelType);
            vm = ViewModelProxy.Proxy(vm);
            BillDetailEditForm form = new BillDetailEditForm(vm, "新增 - " + Title, EditFormPurpose.Create);

            if (form.ShowDialog(ParentForm) == DialogResult.OK)
            {
                DataSource.Add(form.Result);
            }
        }

        public virtual void OnRemove(object sender, EventArgs e)
        {
            gridViewer1.Rows.Remove(gridViewer1.CurrentCell.OwningRow);
        }
    }
}
