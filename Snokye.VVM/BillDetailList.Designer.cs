namespace Snokye.VVM
{
    partial class BillDetailList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabContainer = new System.Windows.Forms.TabControl();
            this.tabPageDetail = new System.Windows.Forms.TabPage();
            this.gridViewer1 = new Snokye.Controls.GridViewer();
            this.tabContainer.SuspendLayout();
            this.tabPageDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewer1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabContainer
            // 
            this.tabContainer.Controls.Add(this.tabPageDetail);
            this.tabContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabContainer.Location = new System.Drawing.Point(0, 0);
            this.tabContainer.Name = "tabContainer";
            this.tabContainer.SelectedIndex = 0;
            this.tabContainer.Size = new System.Drawing.Size(683, 322);
            this.tabContainer.TabIndex = 0;
            // 
            // tabPageDetail
            // 
            this.tabPageDetail.Controls.Add(this.gridViewer1);
            this.tabPageDetail.Location = new System.Drawing.Point(4, 22);
            this.tabPageDetail.Name = "tabPageDetail";
            this.tabPageDetail.Size = new System.Drawing.Size(675, 296);
            this.tabPageDetail.TabIndex = 0;
            this.tabPageDetail.Text = "明细";
            this.tabPageDetail.UseVisualStyleBackColor = true;
            // 
            // gridViewer1
            // 
            this.gridViewer1.AllowUserToAddRows = false;
            this.gridViewer1.AllowUserToDeleteRows = false;
            this.gridViewer1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridViewer1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridViewer1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridViewer1.Location = new System.Drawing.Point(0, 0);
            this.gridViewer1.MultiSelect = false;
            this.gridViewer1.Name = "gridViewer1";
            this.gridViewer1.ReadOnly = true;
            this.gridViewer1.RowHeadersWidth = 22;
            this.gridViewer1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridViewer1.RowTemplate.Height = 23;
            this.gridViewer1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridViewer1.Size = new System.Drawing.Size(675, 296);
            this.gridViewer1.TabIndex = 0;
            // 
            // BillDetailList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabContainer);
            this.Name = "BillDetailList";
            this.Size = new System.Drawing.Size(683, 322);
            this.tabContainer.ResumeLayout(false);
            this.tabPageDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridViewer1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabContainer;
        private System.Windows.Forms.TabPage tabPageDetail;
        private Controls.GridViewer gridViewer1;
    }
}
