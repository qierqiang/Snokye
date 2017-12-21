using Snokye.VVM.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Snokye.VVM
{
    public partial class ExampleBillEditForm : AutoEditBillForm
    {
        public ExampleBillEditForm(VMExampleBill bill, string title = "演示表单", EditFormPurpose formPurpose = EditFormPurpose.Create)
            : base(bill, title, formPurpose)
        {
            InitializeComponent();
            _detailEditor.ModelSelected += _detailEditor_ModelSelected;
        }

        private void _detailEditor_ModelSelected(int rowIndex, int colIndex, MappedViewModelBase modelBase)
        {

        }
    }
}
