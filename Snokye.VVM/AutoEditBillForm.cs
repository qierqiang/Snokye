using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Snokye.Utility;
using Snokye.Controls;

namespace Snokye.VVM
{
    public partial class AutoEditBillForm : AutoEditForm
    {
        private ToolStripSeparator _separator;
        private ToolStripButton _bAddRow;
        private ToolStripButton _bRemove;
        protected BillDetailEditor _detailEditor;
        protected IBillViewModel _billModel;

        //ctor
        /// <summary>
        /// 运行时不可调用无参构造！！！
        /// </summary>
        public AutoEditBillForm()
        {
            InitializeComponent();
        }

        public AutoEditBillForm(ViewModelBase vm, string title, EditFormPurpose formPurpose)
            : base(vm, title, formPurpose)
        {
            //if (!vm.GetType().Is(typeof(IBillViewModel))) throw new Exception(vm.GetType().FullName + "不是有效的IBillViewModel！");
            _billModel = (IBillViewModel)vm;

            _separator = new ToolStripSeparator();
            _bAddRow = new ToolStripButton("添加明细(&A)", Properties.Resources.icons8_加_40, OnAddRow, "bAddRow") { TextImageRelation = TextImageRelation.ImageAboveText };
            _bRemove = new ToolStripButton("删除明细(&R)", Properties.Resources.icons8_减去_40, OnRemove, "bRemove") { TextImageRelation = TextImageRelation.ImageAboveText };
            toolStrip1.Items.Insert(1, _bRemove);
            toolStrip1.Items.Insert(1, _bAddRow);
            toolStrip1.Items.Insert(1, _separator);
            ShowGroupHeader = false;

            InitializeComponent();

            CreateDetailEditor();
        }

        private void CreateDetailEditor()
        {
            SuspendLayout();

            int minHeigh = toolStrip1.Height;
            Controls.OfType<AutoEditGroup>().ToList().ForEach(g => minHeigh += g.Height);
            AutoScrollMinSize = new Size(0, Math.Min(Screen.GetWorkingArea(this).Height, minHeigh + 200));

            BillDetailEditor billDetailEditor = new BillDetailEditor(ViewModel, FormPurpose)
            {
                Dock = DockStyle.Fill,
                Parent = tabPageDefualt,
            };
            _detailEditor = billDetailEditor;

            ResumeLayout();
        }

        private void OnAddRow(object sender, EventArgs e) => _billModel.NewDetail();
        private void OnRemove(object sender, EventArgs e)
        {
            if (_detailEditor.CurrentCell != null)
            {
                _billModel.GetDetails().RemoveAt(_detailEditor.CurrentCell.RowIndex);
            }
        }

        public override void ExecuteCommand(FormCommand operation)
        {
            if (_detailEditor.IsCurrentRowDirty && !_detailEditor.EndEdit())
                return;

            base.ExecuteCommand(operation);
        }
    }
}
