namespace Snokye.VVM
{
    partial class FilterBar
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
            this.pCheckFilter = new System.Windows.Forms.FlowLayoutPanel();
            this.rStatusUnChecked = new System.Windows.Forms.RadioButton();
            this.rStatusChecked = new System.Windows.Forms.RadioButton();
            this.rStatusToCheck = new System.Windows.Forms.RadioButton();
            this.rStatusEditing = new System.Windows.Forms.RadioButton();
            this.rStatusAll = new System.Windows.Forms.RadioButton();
            this.bAdvFilter = new System.Windows.Forms.Button();
            this.bFilter = new System.Windows.Forms.Button();
            this.pCheckFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // pCheckFilter
            // 
            this.pCheckFilter.Controls.Add(this.rStatusUnChecked);
            this.pCheckFilter.Controls.Add(this.rStatusChecked);
            this.pCheckFilter.Controls.Add(this.rStatusToCheck);
            this.pCheckFilter.Controls.Add(this.rStatusEditing);
            this.pCheckFilter.Controls.Add(this.rStatusAll);
            this.pCheckFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pCheckFilter.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.pCheckFilter.Location = new System.Drawing.Point(0, 0);
            this.pCheckFilter.MinimumSize = new System.Drawing.Size(300, 31);
            this.pCheckFilter.Name = "pCheckFilter";
            this.pCheckFilter.Padding = new System.Windows.Forms.Padding(5);
            this.pCheckFilter.Size = new System.Drawing.Size(500, 31);
            this.pCheckFilter.TabIndex = 2;
            this.pCheckFilter.WrapContents = false;
            // 
            // rStatusUnChecked
            // 
            this.rStatusUnChecked.AutoSize = true;
            this.rStatusUnChecked.Location = new System.Drawing.Point(404, 8);
            this.rStatusUnChecked.Name = "rStatusUnChecked";
            this.rStatusUnChecked.Size = new System.Drawing.Size(83, 16);
            this.rStatusUnChecked.TabIndex = 0;
            this.rStatusUnChecked.Text = "审核不通过";
            this.rStatusUnChecked.UseVisualStyleBackColor = true;
            // 
            // rStatusChecked
            // 
            this.rStatusChecked.AutoSize = true;
            this.rStatusChecked.Checked = true;
            this.rStatusChecked.Location = new System.Drawing.Point(327, 8);
            this.rStatusChecked.Name = "rStatusChecked";
            this.rStatusChecked.Size = new System.Drawing.Size(71, 16);
            this.rStatusChecked.TabIndex = 1;
            this.rStatusChecked.TabStop = true;
            this.rStatusChecked.Text = "审核通过";
            this.rStatusChecked.UseVisualStyleBackColor = true;
            // 
            // rStatusToCheck
            // 
            this.rStatusToCheck.AutoSize = true;
            this.rStatusToCheck.Location = new System.Drawing.Point(262, 8);
            this.rStatusToCheck.Name = "rStatusToCheck";
            this.rStatusToCheck.Size = new System.Drawing.Size(59, 16);
            this.rStatusToCheck.TabIndex = 2;
            this.rStatusToCheck.Text = "待审核";
            this.rStatusToCheck.UseVisualStyleBackColor = true;
            // 
            // rStatusEditing
            // 
            this.rStatusEditing.AutoSize = true;
            this.rStatusEditing.Location = new System.Drawing.Point(197, 8);
            this.rStatusEditing.Name = "rStatusEditing";
            this.rStatusEditing.Size = new System.Drawing.Size(59, 16);
            this.rStatusEditing.TabIndex = 3;
            this.rStatusEditing.Text = "编辑中";
            this.rStatusEditing.UseVisualStyleBackColor = true;
            // 
            // rStatusAll
            // 
            this.rStatusAll.AutoSize = true;
            this.rStatusAll.Location = new System.Drawing.Point(144, 8);
            this.rStatusAll.Name = "rStatusAll";
            this.rStatusAll.Size = new System.Drawing.Size(47, 16);
            this.rStatusAll.TabIndex = 4;
            this.rStatusAll.Text = "全部";
            this.rStatusAll.UseVisualStyleBackColor = true;
            // 
            // bAdvFilter
            // 
            this.bAdvFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bAdvFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bAdvFilter.Font = new System.Drawing.Font("Webdings", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.bAdvFilter.Location = new System.Drawing.Point(470, 37);
            this.bAdvFilter.Name = "bAdvFilter";
            this.bAdvFilter.Size = new System.Drawing.Size(21, 28);
            this.bAdvFilter.TabIndex = 4;
            this.bAdvFilter.Text = "5";
            this.bAdvFilter.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bAdvFilter.UseVisualStyleBackColor = true;
            this.bAdvFilter.Click += new System.EventHandler(this.bAdvFilter_Click);
            // 
            // bFilter
            // 
            this.bFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bFilter.Location = new System.Drawing.Point(397, 37);
            this.bFilter.Name = "bFilter";
            this.bFilter.Size = new System.Drawing.Size(81, 28);
            this.bFilter.TabIndex = 3;
            this.bFilter.Text = "过滤（&F)";
            this.bFilter.UseVisualStyleBackColor = true;
            this.bFilter.Click += new System.EventHandler(this.bFilter_Click);
            // 
            // FilterBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.bAdvFilter);
            this.Controls.Add(this.bFilter);
            this.Controls.Add(this.pCheckFilter);
            this.MinimumSize = new System.Drawing.Size(500, 70);
            this.Name = "FilterBar";
            this.Size = new System.Drawing.Size(500, 140);
            this.pCheckFilter.ResumeLayout(false);
            this.pCheckFilter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel pCheckFilter;
        private System.Windows.Forms.RadioButton rStatusUnChecked;
        private System.Windows.Forms.RadioButton rStatusChecked;
        private System.Windows.Forms.RadioButton rStatusToCheck;
        private System.Windows.Forms.RadioButton rStatusEditing;
        private System.Windows.Forms.RadioButton rStatusAll;
        private System.Windows.Forms.Button bAdvFilter;
        private System.Windows.Forms.Button bFilter;
    }
}
