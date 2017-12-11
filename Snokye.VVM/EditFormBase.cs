using System;
using System.ComponentModel;
using System.Windows.Forms;
using Snokye.Controls;

namespace Snokye.VVM
{
    public class EditFormBase : Form
    {
        private ToolStrip toolStrip1;
        private ToolStripButton bSave;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton bClose;
        private ToolStripLabel tslTitle;

        public event EventHandler DataSourceChanged;

        private ViewModelBase _dataSource;

        public ViewModelBase DataSource
        {
            get => _dataSource;
            set
            {
                if (_dataSource != value)
                {
                    _dataSource = value;
                    OnDataSourceChanged();
                }
            }
        }

        public EditFormBase() { }

        public EditFormBase(ViewModelBase model)
        {
            DataSource = model;
        }

        public virtual void DataBind()
        {
            //if ()
        }

        public virtual bool ValidateForm() { return true; }

        public virtual bool Submit()
        {
            if (ValidateForm())
            {
                //EntityProvider.Instance.Save(DataSource);
                throw new NotImplementedException();
            }
            return true;
        }

        protected virtual void OnDataSourceChanged()
        {
            DataBind();
            DataSourceChanged?.Invoke(this, EventArgs.Empty);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            if (!e.Cancel && DataSource != null && DataSource.GetIsModified() && !Msgbox.DontSaveConfirm())
            {
                e.Cancel = true;
            }
        }

        private void InitializeComponent()
        {
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.bSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bClose = new System.Windows.Forms.ToolStripButton();
            this.tslTitle = new System.Windows.Forms.ToolStripLabel();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bSave,
            this.toolStripSeparator1,
            this.bClose,
            this.tslTitle});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(782, 59);
            this.toolStrip1.Stretch = true;
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // bSave
            // 
            this.bSave.Image = global::Snokye.VVM.Properties.Resources.icons8_保存_40;
            this.bSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(51, 56);
            this.bSave.Text = "保存(&S)";
            this.bSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 59);
            // 
            // bClose
            // 
            this.bClose.Image = global::Snokye.VVM.Properties.Resources.icons8_关闭窗口_40;
            this.bClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bClose.Name = "bClose";
            this.bClose.Size = new System.Drawing.Size(51, 56);
            this.bClose.Text = "关闭(&X)";
            this.bClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tslTitle
            // 
            this.tslTitle.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tslTitle.Font = new System.Drawing.Font("黑体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tslTitle.ForeColor = System.Drawing.SystemColors.Highlight;
            this.tslTitle.Name = "tslTitle";
            this.tslTitle.Size = new System.Drawing.Size(133, 56);
            this.tslTitle.Text = "表单标题";
            // 
            // EditFormBase
            // 
            this.ClientSize = new System.Drawing.Size(782, 396);
            this.Controls.Add(this.toolStrip1);
            this.Name = "EditFormBase";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
