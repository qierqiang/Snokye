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
        //events
        public event EventHandler DataSourceChanged;
        public event FilteringPropertiesEventHandler FilteringProperties;

        //fields
        ViewModelBase _dataSource;

        //properties
        public string ViewModelTypeFullName { get; set; }

        [Browsable(false)]
        public virtual ViewModelBase DataSource
        {
            get => _dataSource;
            set
            {
                if (_dataSource != value)
                {
                    //移除验证事件 
                    if (_dataSource != null && _dataSource.ValidateFailed != null)
                        _dataSource.ValidateFailed -= ValidateFialed;

                    _dataSource = value;

                    //附加验证事件 
                    if (_dataSource != null)
                        _dataSource.ValidateFailed += ValidateFialed;

                    OnDataSourceChanged();
                }
            }
        }

        public string Title
        {
            get => tslTitle.Text;
            set
            {
                tslTitle.Text = value;
                Text = value;
            }
        }

        [Browsable(false)]
        public EditFormPurpose FormPurpose { get; set; }

        //ctor
        public AutoEditForm()
        {
            InitializeComponent();
        }

        public AutoEditForm(ViewModelBase model, string title)
        {
            InitializeComponent();
            Type type = model.GetRealType();
            this.ViewModelTypeFullName = type.FullName;
            Title = title;
        }

        //protected
        protected virtual void OnDataSourceChanged()
        {
            DataBind();
            DataSourceChanged?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnFilteringProperties(FilteringPropertiesEventArgs e)
        {
            FilteringProperties?.Invoke(this, e);
        }

        protected virtual void ValidateFialed(string propertyName, string msg)
        {
            var query = from p in DataSource.GetRealType().GetProperties()
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
            if (DataSource != null && DataSource.GetIsModified() && !Msgbox.DontSaveConfirm())
                e.Cancel = true;
        }

        //public
        public virtual void DataBind()
        {
            //此时控件应该已经创建好了，根据名称查找并绑定

            if (DataSource != null)
            {
                foreach (AutoEditGroup g in this.Controls.OfType<AutoEditGroup>())
                {
                    g.DataSource = DataSource;
                }
            }
        }

        public virtual void CreateControls(IEnumerable<PropertyInfo> properties)
        {
            //过滤掉不要的属性//错误，已经过滤掉了！
            //properties = properties.Where(p => FilterProperty(p));
            //查找组
            var query = from p in properties
                        from a in p.GetCustomAttributes(typeof(AutoGenControlAttribute), true).OfType<AutoGenControlAttribute>()
                        select a.GroupName;

            foreach (string g in query.Distinct())
            {
                //创建组控件！！！需要Init
                AutoEditGroup group = new AutoEditGroup();
                group.BeginInit();
                group.Title = g ?? "";
                group.ViewModelTypeFullName = ViewModelTypeFullName;
                group.ViewModelAssemblyName = properties.First().DeclaringType.Assembly.FullName;
                group.Dock = DockStyle.Top;
                group.FormPurpose = FormPurpose;
                group.FilteringProperties += (object sender, FilteringPropertiesEventArgs e) =>
                {
                    //用组名过滤属性
                    if (!e.Ignored)
                    {
                        var queryGroupname = from attrib in e.PropertyInfo.GetCustomAttributes(typeof(AutoGenControlAttribute), true).OfType<AutoGenControlAttribute>()
                                             select attrib.GroupName;
                        string gName = queryGroupname.FirstOrDefault() ?? "";
                        e.Ignored = !string.Equals(g ?? "", gName, StringComparison.CurrentCultureIgnoreCase);
                    }
                };
                group.EndInit();
                group.Parent = this;
                group.BringToFront();
            }
        }

        //private
        private bool FilterProperty(PropertyInfo property)
        {
            FilteringPropertiesEventArgs e = new FilteringPropertiesEventArgs(property);
            OnFilteringProperties(new FilteringPropertiesEventArgs(property));
            return !e.Ignored;
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
            if (DataSource != null && DataSource.Submit())
            {
                DataSource.AfterSubmit();
                errorProvider1.Clear();
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        public void BeginInit()
        {
            throw new NotImplementedException();
        }

        public void EndInit()
        {
            //过滤属性并创建控件
            var query = from p in DataSource.GetRealType().GetProperties()
                        where FilterProperty(p)
                        select p;
            CreateControls(query);
            DataSource = model;
        }
    }
}
