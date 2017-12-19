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
    public partial class AutoEditGroup : UserControl
    {
        //fields
        private int _rowCount = 0;
        private bool _expanded = true;
        private List<PropertyInfo> _properties;
        private ViewModelBase _viewModel;
        private EditFormPurpose _formPurpose;

        //ctor
        /// <summary>
        /// 运行时不可调用无参构造！！！
        /// </summary>
        public AutoEditGroup()
        {
            InitializeComponent();
        }

        public AutoEditGroup(ViewModelBase viewModel, string title, EditFormPurpose formPurpose, List<PropertyInfo> properties)
        {
            InitializeComponent();
            SuspendLayout();
            _viewModel = viewModel;
            lTitle.Text = title;
            _formPurpose = formPurpose;
            _properties = properties;
            CreateEditControl();
            ResumeLayout();
        }

        //private
        private void CreateEditControl()
        {
            TableLayoutPanel layoutPanel = NewRow();

            foreach (PropertyInfo p in _properties)
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
                    switch (_formPurpose)
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
                    editor.DataBindings.Add(new Binding(@default.Name, _viewModel, p.Name, true, DataSourceUpdateMode.OnPropertyChanged));

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