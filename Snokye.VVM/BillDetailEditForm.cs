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
    public partial class BillDetailEditForm : AutoEditForm
    {
        public ViewModelBase Result { get; set; }

        public BillDetailEditForm()
        {
            InitializeComponent();
        }

        public BillDetailEditForm(ViewModelBase viewModel) : base(viewModel, "编辑明细")
        {
            InitializeComponent();
        }

        //protected override void SubmitForm(object sender, EventArgs e)
        //{
        //    base.SubmitForm(sender, e);
        //}
    }
}
