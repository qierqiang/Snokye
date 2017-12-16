namespace Snokye.VVM
{
    partial class FilterControlBase
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
            this.lTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lTitle
            // 
            this.lTitle.Dock = System.Windows.Forms.DockStyle.Left;
            this.lTitle.Location = new System.Drawing.Point(0, 0);
            this.lTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lTitle.Name = "lTitle";
            this.lTitle.Size = new System.Drawing.Size(66, 40);
            this.lTitle.TabIndex = 0;
            this.lTitle.Text = "过滤条件";
            this.lTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FilterControlBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.lTitle);
            this.Name = "FilterControlBase";
            this.Size = new System.Drawing.Size(253, 40);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lTitle;
    }
}
