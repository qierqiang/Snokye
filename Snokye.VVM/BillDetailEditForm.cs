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

        public BillDetailEditForm(ViewModelBase viewModel, string title, EditFormPurpose formPurpose) : base(viewModel, title, formPurpose)
        {
            InitializeComponent();
        }
    }
}
