using System.Windows.Forms;
using Snokye.Utility;
using Snokye.Controls;

namespace Snokye.VVM
{
    public partial class ChangePasswordForm : EditFormBase
    {
        public ChangePasswordForm(int userID)
        {
            InitializeComponent();
        }

        public override void DataBind()
        {
            base.DataBind();
        }

        public override bool ValidateForm()
        {
            return base.ValidateForm();
        }

        public override bool Submit()
        {
            return base.Submit();
        }

        public ///////TODO:

        class ViewModel : ViewModelBase
        {
            public long ID { get; set; }

            [AutoGenControl(typeof(TextBox), "原密码", beginNewRow: true)]
            public string OldPassword { get; set; }

            [AutoGenControl(typeof(TextBox), "新密码", beginNewRow: true)]
            public string NewPassword { get; set; }

            [AutoGenControl(typeof(TextBox), "重复", beginNewRow: true)]
            public string RepPassword { get; set; }
        }
    }
}
