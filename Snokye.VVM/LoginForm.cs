using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Snokye.Utility;
using Snokye.Controls;
using Snokye.VVM;
using System.Reflection;

namespace Snokye.VVM
{
    public partial class LoginForm : Form
    {
        private VMLoginForm _vm;

        public LoginForm()
        {
            InitializeComponent();

            //InitViewModel
            _vm = new VMLoginForm();
            _vm = ViewModelProxy.Proxy(_vm);
            _vm.ValidateFailed = ValidateFialed;

            DataBind();
        }

        public void DataBind()
        {
            cmbUserName.DataSource = _vm.UserHistory;
            cmbUserName.DataBindings.Add(new Binding("Text", _vm, "UserName", false, DataSourceUpdateMode.OnPropertyChanged));
            txtPwd.DataBindings.Add(new Binding("Text", _vm, "Password", false, DataSourceUpdateMode.OnPropertyChanged));
            cClearLogin.DataBindings.Add(new Binding("Checked", _vm, "ClearLogin", false, DataSourceUpdateMode.OnPropertyChanged));
            cRememberPwd.DataBindings.Add(new Binding("Checked", _vm, "RememberPwd", false, DataSourceUpdateMode.OnPropertyChanged));
        }

        private void ValidateFialed(string vmProperty, string msg)
        {
            errorProvider1.Clear();

            if (vmProperty == "Password")
            {
                errorProvider1.SetError(txtPwd, msg);
                txtPwd.Focus();
            }
            else
            {
                errorProvider1.SetError(cmbUserName, msg);
                cmbUserName.Focus();
            }
        }

        private void bLogin_Click(object sender, EventArgs e)
        {
            if (_vm.Submit())
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
