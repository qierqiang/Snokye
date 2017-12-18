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
    public partial class AutoEditForm : Form, ISupportInitialize
    {
        /*实现步骤
         * 1. ctor
         * 2. beginInit
         * 3. set property values
         * 4. endInit
         * 4.1   create editGroup
         */

        #region 1. ctor

        public AutoEditForm()
        {
            InitializeComponent();
            Text = tslTitle.Text;
            FormPurpose = EditFormPurpose.Create;
        }

        public AutoEditForm(ViewModelBase model, string title, EditFormPurpose purpose) : this()
        {
            ViewModel = model;
            Title = title;
            FormPurpose = purpose;
        }

        public string Title
        {
            get => tslTitle.Text;
            private set
            {
                tslTitle.Text = value;
                Text = value;
            }
        }

        public ViewModelBase ViewModel { get; private set; }

        [Browsable(false)]
        public EditFormPurpose FormPurpose { get; private set; }

        #endregion

        #region 2. biginInit

        public void BeginInit() { }

        #endregion

        #region 4. endInit

        public event Func<PropertyInfo, bool> FilterProperty;

        private void CreateAutoEditGrup()
        {
            if (ViewModel == null)
                return;

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
                //创建组控件！！！需要Init
                AutoEditGroup group = new AutoEditGroup(ViewModel, item.Key, FormPurpose, item.Value);
                group.BeginInit();
                group.Dock = DockStyle.Top;
                group.EndInit();
                group.Parent = this;
                group.BringToFront();
            }
        }

        public void EndInit()
        {
            CreateAutoEditGrup();
        }

        #endregion

        protected virtual void ValidateFialed(string propertyName, string msg)
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

        protected virtual void ClosingForm(object sender, FormClosingEventArgs e)
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

        public static T CreateInstance<T>(ViewModelBase vm, string title, EditFormPurpose formPurpose) where T : AutoEditForm
        {
            T frm = (T)Activator.CreateInstance(typeof(T), vm, title, formPurpose);
            frm.BeginInit();
            frm.EndInit();
            return frm;
        }
        public static AutoEditForm CreateInstance(Type formType, ViewModelBase vm, string title, EditFormPurpose formPurpose)
        {
            if (!formType.IsSubclassOf(typeof(AutoEditForm)))
                throw new ArgumentException(formType.ToString() + "不是有效的AutoEditForm类型。", nameof(formType));

            AutoEditForm frm = (AutoEditForm)Activator.CreateInstance(formType, vm, title, formPurpose);
            frm.BeginInit();
            frm.EndInit();
            return frm;
        }
    }
}
