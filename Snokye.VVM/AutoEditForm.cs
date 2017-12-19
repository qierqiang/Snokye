using Snokye.Controls;
using Snokye.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Proxies;
using System.Windows.Forms;

namespace Snokye.VVM
{
    public partial class AutoEditForm : Form
    {
        public event Func<PropertyInfo, bool> FilterProperty;

        // properties
        [Browsable(false)]
        public ViewModelBase ViewModel { get; private set; }

        [Browsable(false)]
        public EditFormPurpose FormPurpose { get; private set; }

        // ctor
        /// <summary>
        /// 运行时不可调用无参构造！！！
        /// </summary>
        public AutoEditForm()
        {
            InitializeComponent();
        }

        public AutoEditForm(ViewModelBase model, string title, EditFormPurpose purpose)
        {
            InitializeComponent();
            SuspendLayout();
            ViewModel = model;
            tslTitle.Text = title;
            Text = title;
            FormPurpose = purpose;
            CreateAutoEditGrup();
            ResumeLayout();
        }

        // private
        private void CreateAutoEditGrup()
        {
            if (ViewModel == null)
                return;

            ViewModel.ValidateFailed += ValidateFialed;

            //查找组
            PropertyInfo[] properties = ViewModel.GetRealType().GetProperties().OfType<PropertyInfo>().Where(p => FilterProperty == null ? true : FilterProperty(p)).ToArray();
            Dictionary<string, List<PropertyInfo>> groupDictionary = new Dictionary<string, List<PropertyInfo>>();

            foreach (PropertyInfo p in properties)
            {
                AutoGenControlAttribute a = p.GetAttribute<AutoGenControlAttribute>();

                if (a != null)
                {
                    string groupName = a.GroupName ?? "";

                    if (groupDictionary.ContainsKey(groupName))
                    {
                        List<PropertyInfo> list = groupDictionary[groupName];
                        list.Add(p);
                    }
                    else
                    {
                        groupDictionary.Add(groupName, new List<PropertyInfo> { p });
                    }
                }
            }

            foreach (var item in groupDictionary)
            {
                AutoEditGroup group = new AutoEditGroup(ViewModel, item.Key, FormPurpose, item.Value)
                {
                    Dock = DockStyle.Top,
                    Parent = this,
                };
                group.BringToFront();
            }
        }

        private void ValidateFialed(string propertyName, string msg)
        {
            var query = from p in ViewModel.GetRealType().GetProperties()
                        where p.Name == propertyName
                        from a in p.GetCustomAttributes(typeof(AutoGenControlAttribute), true).OfType<AutoGenControlAttribute>()
                        select this.FindFirstChildControl(c => c.Name == a.EditorType.Name.LowerFirstLetter() + "_" + p.Name);
            Control ctrl = query.FirstOrDefault();

            if (ctrl != null)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(ctrl, msg);
                ctrl.Focus();
            }
        }

        private void ClosingForm(object sender, FormClosingEventArgs e)
        {
            if (ViewModel != null && ViewModel.GetIsModified() && !Msgbox.DontSaveConfirm())
                e.Cancel = true;
        }

        private void SubmitForm(object sender, EventArgs e) => ExecuteCommand(FormCommand.Submit);

        private void Close_Click(object sender, EventArgs e) => ExecuteCommand(FormCommand.CloseForm);

        public virtual void ExecuteCommand(FormCommand operation)
        {
            GetType().GetMethod(operation.ToString(), BindingFlags.Instance | BindingFlags.NonPublic)?.Invoke(this, null);
        }

        // commands
        internal void CloseForm() { Close(); }
        internal void Submit()
        {
            if (ViewModel != null && ViewModel.Submit())
            {
                ViewModel.AfterSubmit();
                errorProvider1.Clear();
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
