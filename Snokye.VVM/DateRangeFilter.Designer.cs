namespace Snokye.VVM
{
    partial class DateRangeFilter
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>


        private void InitializeComponent()
        {
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpStop = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // dtpStart
            // 
            this.dtpStart.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtpStart.Checked = false;
            this.dtpStart.CustomFormat = "yyyy-MM-dd";
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStart.Location = new System.Drawing.Point(69, 8);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.ShowCheckBox = true;
            this.dtpStart.Size = new System.Drawing.Size(122, 21);
            this.dtpStart.TabIndex = 1;
            this.dtpStart.Value = new System.DateTime(2017, 12, 15, 19, 50, 35, 0);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(197, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "到";
            // 
            // dtpStop
            // 
            this.dtpStop.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtpStop.Checked = false;
            this.dtpStop.CustomFormat = "yyyy-MM-dd";
            this.dtpStop.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStop.Location = new System.Drawing.Point(220, 8);
            this.dtpStop.Name = "dtpStop";
            this.dtpStop.ShowCheckBox = true;
            this.dtpStop.Size = new System.Drawing.Size(122, 21);
            this.dtpStop.TabIndex = 3;
            this.dtpStop.Value = new System.DateTime(2017, 12, 15, 19, 50, 35, 0);
            // 
            // DateRangeFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.dtpStop);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpStart);
            this.Name = "DateRangeFilter";
            this.Size = new System.Drawing.Size(350, 40);
            this.Controls.SetChildIndex(this.dtpStart, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.dtpStop, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpStop;
        private System.Windows.Forms.DateTimePicker dtpStart;
    }
}
