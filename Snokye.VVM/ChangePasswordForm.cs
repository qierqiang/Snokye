using Snokye.Controls;
using Snokye.VVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Snokye.VVM
{
    public partial class ChangePasswordForm : AutoEditForm
    {
        public ChangePasswordForm(VMChangePwd viewModel, string title) : base(viewModel, "修改密码")
        {
            viewModel.Submitted += OnSubmitted;
        }

        private void OnSubmitted()
        {
            Msgbox.Information("密码已经修改成功，请牢记新密码。");
            Close();
        }
    }
}
