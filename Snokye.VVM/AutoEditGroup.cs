using Snokye.Controls;
using Snokye.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Proxies;
using System.Windows.Forms;

namespace Snokye.VVM
{
    public partial class AutoEditGroup : UserControl, ISupportInitialize
    {
        /*实现步骤
         * 1. ctor
         * 2. beginInit
         * 3. set property values
         * 4. endInit
         * 4.1   create editControl
         * 4.2   dataBind
         */

        #region 1. ctor

        //ctor
        public AutoEditGroup()
        {
            InitializeComponent();
        }

        public AutoEditGroup(ViewModelBase viewModel, string title, EditFormPurpose formPurpose, List<PropertyInfo> properties) : this()
        {
            ViewModel = viewModel;
            Title = title;
            FormPurpose = formPurpose;
            Properties = properties;
        }

        public ViewModelBase ViewModel { get; private set; }

        public string Title
        {
            get { return lTitle.Text; }
            private set { lTitle.Text = value; }
        }

        [Browsable(false)]
        public EditFormPurpose FormPurpose { get; private set; }

        internal List<PropertyInfo> Properties { get; private set; }

        #endregion

        #region 2. beginInit

        public void BeginInit() { }

        #endregion

        #region 4. endInit

        private int _rowCount = 0;
        private bool _expanded = true;

        private void CreateEditControl()
        {
            TableLayoutPanel layoutPanel = NewRow();

            foreach (PropertyInfo p in Properties)
            {
                AutoGenControlAttribute a = p.GetAttribute<AutoGenControlAttribute>();

                if (a == null) continue;

                //布局分为两块，左边和右边。
                //如果左边被占用就放右边，右边也被占用就另起一行。
                int colIndex = 0;
                //左
                if (layoutPanel.GetControlFromPosition(colIndex, 0) != null)
                {
                    //右 前提没有强制另起一行
                    if (a.BeginNewRow)
                    {
                        layoutPanel = NewRow();
                    }
                    else
                    {
                        colIndex = 3;
                        if (layoutPanel.GetControlFromPosition(colIndex, 0) != null)
                        {
                            //都占用就用新行的左边
                            layoutPanel = NewRow();
                            colIndex = 0;
                        }
                    }
                }
                //TODO: 长控件独占一行

                // create Editor
                Control editor = (Control)Activator.CreateInstance(a.EditorType);
                editor.Name = a.EditorType.Name.LowerFirstLetter() + "_" + p.Name;
                editor.Dock = DockStyle.Fill;
                editor.Margin = new Padding(10, 12, 80, 10);
                editor.Enabled = a.Enabled;
                //read only
                var readOnlyProperty = (from pp in a.EditorType.GetProperties() where pp.Name == "ReadOnly" && pp.CanWrite select pp).FirstOrDefault();
                if (readOnlyProperty != null)
                {
                    switch (FormPurpose)
                    {
                        case EditFormPurpose.Create:
                            readOnlyProperty.SetValue(editor, a.ReadOnlyWhenCreate, null);
                            break;
                        case EditFormPurpose.Modify:
                            readOnlyProperty.SetValue(editor, a.ReadOnlyWhenModify, null);
                            break;
                        default:
                            readOnlyProperty.SetValue(editor, true, null);
                            break;
                    }
                }

                editor.Parent = layoutPanel;
                layoutPanel.SetColumn(editor, colIndex + 1);
                layoutPanel.SetRow(editor, 0);

                //dataBind
                DefaultPropertyAttribute @default = editor.GetType().GetAttribute<DefaultPropertyAttribute>();
                if (@default != null)
                    editor.DataBindings.Add(new Binding(@default.Name, ViewModel, p.Name, true, DataSourceUpdateMode.OnPropertyChanged));

                // create Label
                Label label = new Label
                {
                    Name = "lable_" + p.Name,
                    AutoSize = false,
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleRight,
                    Margin = new Padding(10, 11, 3, 11),
                    Text = a.DisplayName ?? p.Name,
                    Parent = layoutPanel,
                    Tag = editor,
                };
                layoutPanel.SetColumn(label, colIndex);
                layoutPanel.SetRow(label, 0);

                label.Click += Label_Click;
            }
        }

        private TableLayoutPanel NewRow()
        {
            Panel panel = new Panel
            {
                Name = "rowPanel" + _rowCount,
                Size = new Size(800, 46),
            };

            TableLayoutPanel layoutPanel = new TableLayoutPanel
            {
                Name = "layoutPanel" + _rowCount,
                RowCount = 1,
                ColumnCount = 5,
                Dock = DockStyle.Fill,
            };

            layoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100));
            layoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            layoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100));
            layoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100));
            layoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));

            layoutPanel.Parent = panel;
            panel.Parent = flowPanel;

            _rowCount++;

            return layoutPanel;
        }

        public void EndInit()
        {
            CreateEditControl();
        }

        #endregion

        private void Label_Click(object sender, EventArgs e)
        {
            if (sender is Label l && l.Tag is Control c && c.CanFocus)
                c.Focus();
        }

        private void Title_DoubleClick(object sender, EventArgs e)
        {
            _expanded = !_expanded;
            var query = from p in flowPanel.Controls.OfType<Control>() where p.Name.StartsWith("rowPanel") select p;
            query.ToList().ForEach(c => c.Visible = _expanded);
            lExpandStatus.Text = _expanded ? "6" : "5";
        }
    }
}
