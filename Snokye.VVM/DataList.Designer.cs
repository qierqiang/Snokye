namespace Snokye.VVM
{
    partial class DataList
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
            this.panelSelect = new System.Windows.Forms.Panel();
            this.bSelect = new System.Windows.Forms.Button();
            this.pagingControl1 = new Snokye.Controls.PagingControl();
            this.bFilter = new System.Windows.Forms.Button();
            this.panelSelect.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pagingControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelSelect
            // 
            this.panelSelect.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelSelect.Controls.Add(this.bSelect);
            this.panelSelect.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelSelect.Location = new System.Drawing.Point(0, 385);
            this.panelSelect.Name = "panelSelect";
            this.panelSelect.Size = new System.Drawing.Size(825, 42);
            this.panelSelect.TabIndex = 3;
            this.panelSelect.Visible = false;
            // 
            // bSelect
            // 
            this.bSelect.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.bSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bSelect.Location = new System.Drawing.Point(368, 5);
            this.bSelect.Name = "bSelect";
            this.bSelect.Size = new System.Drawing.Size(85, 33);
            this.bSelect.TabIndex = 0;
            this.bSelect.Text = "确认选择(&C)";
            this.bSelect.UseVisualStyleBackColor = true;
            this.bSelect.Click += new System.EventHandler(this.bSelect_Click);
            // 
            // pagingControl1
            // 
            this.pagingControl1.AutoSize = true;
            this.pagingControl1.CurrentPage = 0;
            this.pagingControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pagingControl1.Location = new System.Drawing.Point(0, 356);
            this.pagingControl1.MinimumSize = new System.Drawing.Size(600, 29);
            this.pagingControl1.Name = "pagingControl1";
            this.pagingControl1.Size = new System.Drawing.Size(825, 29);
            this.pagingControl1.TabIndex = 1;
            // 
            // bFilter
            // 
            this.bFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bFilter.Location = new System.Drawing.Point(732, 12);
            this.bFilter.Name = "bFilter";
            this.bFilter.Size = new System.Drawing.Size(81, 28);
            this.bFilter.TabIndex = 5;
            this.bFilter.Text = "过滤（&F)";
            this.bFilter.UseVisualStyleBackColor = true;
            // 
            // DataList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 427);
            this.Controls.Add(this.bFilter);
            this.Controls.Add(this.pagingControl1);
            this.Controls.Add(this.panelSelect);
            this.Name = "DataList";
            this.panelSelect.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pagingControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panelSelect;
        private System.Windows.Forms.Button bSelect;
        private Controls.PagingControl pagingControl1;
        private System.Windows.Forms.Button bFilter;
    }
}
