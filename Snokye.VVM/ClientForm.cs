using System;
using System.Drawing;
using System.Windows.Forms;
using Snokye.Utility;
using Snokye.Controls;
using Snokye.VVM;
using System.Reflection;

namespace Snokye.VVM
{
    public partial class ClientForm : Form
    {
        private int childFormNumber = 0;

        public ClientForm()
        {
            if (new LoginForm().ShowDialog() != DialogResult.OK)
            {
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
            ClientInfo.ClientForm = this;
            InitializeComponent();
            Text = AppConfig.Instance.AppName;
            LoadIcon();
#if DEBUG
            WindowState = FormWindowState.Normal;
            StartPosition = FormStartPosition.CenterScreen;
            Size = new Size(1024, 700);
            MaximizeBox = false;
            MaximumSize = Size;

#else
            FormState.LoadFormState(this, "ClientForm", null);
#endif
        }

        private void LoadIcon()
        {
            try
            {
                Icon ico = new Icon(AppDomain.CurrentDomain.BaseDirectory + "ico.ico");
                Icon = ico;
            }
            catch
            {
                ShowIcon = false;
            }
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "窗口 " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            UserManage f = new UserManage();
            f.MdiParent = this;
            f.Show();
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "文本文件(*.txt)|*.txt|所有文件(*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {


            //LoadWindowState();
            Dashboard childForm = new Dashboard();
            childForm.MdiParent = this;
            childForm.Show();
            childForm.WindowState = FormWindowState.Maximized;
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog(this);
        }

        private void ClientForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormState.SaveFormState(this, "ClientForm", null);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutBox().ShowDialog(this);
        }

        private void changePwdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VMChangePwd model = new VMChangePwd();
            model.ID = ClientInfo.CurrentUser.Id;
            model = ViewModelProxy.Proxy(model);

            OpenDialogForm(typeof(ChangePasswordForm), "修改密码", model);
        }

        public Form OpenMDIForm(Type formType)
        {
            if (Activator.CreateInstance(formType) is Form frm)
            {
                frm.ShowInTaskbar = true;
                frm.MdiParent = this;
                //frm.Icon == Icon.de
                frm.Show();
                return frm;
            }

            return null;
        }

        public DialogResult OpenDialogForm(Type formType, string title, ViewModelBase viewModel = null)
        {
            Form frm;

            if (viewModel == null)
            {
                frm = Activator.CreateInstance(formType, title) as Form;
            }
            else
            {
                frm = Activator.CreateInstance(formType, viewModel, title) as Form;
            }
            if (frm != null)
            {
                //加载布局
                FormState.LoadFormState(frm, title, viewModel);
                //添加保存布局事件
                frm.ShowIcon = false;
                frm.ShowInTaskbar = false;
                MinimumSize = new Size(820, 200);
                frm.Closed += (object sender, EventArgs e) => { FormState.SaveFormState(frm, title, viewModel); };
                return frm.ShowDialog(this);
            }

            return DialogResult.None;
        }
    }
}
