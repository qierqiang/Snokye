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
        public ExampleBillEditForm(VMExampleBill bill, EditFormPurpose formPurpose)
            : base(bill, "演示表单", formPurpose)
        {
            InitializeComponent();
        }
    }
}
