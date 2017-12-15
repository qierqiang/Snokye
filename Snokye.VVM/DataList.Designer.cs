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
            this.bFilter = new System.Windows.Forms.Button();
            this.pagingControl1 = new Snokye.Controls.PagingControl();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.bNew = new System.Windows.Forms.ToolStripButton();
            this.tslTitle = new System.Windows.Forms.ToolStripLabel();
            this.bEdit = new System.Windows.Forms.ToolStripButton();
            this.bView = new System.Windows.Forms.ToolStripButton();
            this.bDel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bClose = new System.Windows.Forms.ToolStripButton();
            this.bAdvFilter = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabContainer = new System.Windows.Forms.TabControl();
            this.panelSelect.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pagingControl1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSelect
            // 
            this.panelSelect.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelSelect.Controls.Add(this.bSelect);
            this.panelSelect.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelSelect.Location = new System.Drawing.Point(0, 450);
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
            // bFilter
            // 
            this.bFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bFilter.Location = new System.Drawing.Point(713, 3);
            this.bFilter.Name = "bFilter";
            this.bFilter.Size = new System.Drawing.Size(81, 28);
            this.bFilter.TabIndex = 5;
            this.bFilter.Text = "过滤（&F)";
            this.bFilter.UseVisualStyleBackColor = true;
            this.bFilter.Click += new System.EventHandler(this.bFilter_Click);
            // 
            // pagingControl1
            // 
            this.pagingControl1.AutoSize = true;
            this.pagingControl1.CurrentPage = 1;
            this.pagingControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pagingControl1.Location = new System.Drawing.Point(0, 421);
            this.pagingControl1.MinimumSize = new System.Drawing.Size(600, 29);
            this.pagingControl1.Name = "pagingControl1";
            this.pagingControl1.Size = new System.Drawing.Size(825, 29);
            this.pagingControl1.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bNew,
            this.tslTitle,
            this.bEdit,
            this.bView,
            this.bDel,
            this.toolStripSeparator1,
            this.toolStripButton1,
            this.toolStripSeparator2,
            this.bClose});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(825, 59);
            this.toolStrip1.Stretch = true;
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // bNew
            // 
            this.bNew.Image = global::Snokye.VVM.Properties.Resources.icons8_文件_40;
            this.bNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bNew.Name = "bNew";
            this.bNew.Size = new System.Drawing.Size(51, 56);
            this.bNew.Text = "新建(&N)";
            this.bNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
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
            // bEdit
            // 
            this.bEdit.Image = global::Snokye.VVM.Properties.Resources.icons8_编辑文件_40;
            this.bEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bEdit.Name = "bEdit";
            this.bEdit.Size = new System.Drawing.Size(51, 56);
            this.bEdit.Text = "修改(&E)";
            this.bEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // bView
            // 
            this.bView.Image = global::Snokye.VVM.Properties.Resources.icons8_查看文件_40;
            this.bView.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bView.Name = "bView";
            this.bView.Size = new System.Drawing.Size(51, 56);
            this.bView.Text = "查看(&V)";
            this.bView.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // bDel
            // 
            this.bDel.Image = global::Snokye.VVM.Properties.Resources.icons8_关闭窗口_40;
            this.bDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bDel.Name = "bDel";
            this.bDel.Size = new System.Drawing.Size(51, 56);
            this.bDel.Text = "删除(&D)";
            this.bDel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 59);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = global::Snokye.VVM.Properties.Resources.icons8_计算器_40;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(51, 56);
            this.toolStripButton1.Text = "计算(&C)";
            this.toolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 59);
            // 
            // bClose
            // 
            this.bClose.Image = global::Snokye.VVM.Properties.Resources.icons8_出口_40;
            this.bClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bClose.Name = "bClose";
            this.bClose.Size = new System.Drawing.Size(51, 56);
            this.bClose.Text = "退出(&X)";
            this.bClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // bAdvFilter
            // 
            this.bAdvFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bAdvFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bAdvFilter.Font = new System.Drawing.Font("Webdings", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.bAdvFilter.Location = new System.Drawing.Point(791, 3);
            this.bAdvFilter.Name = "bAdvFilter";
            this.bAdvFilter.Size = new System.Drawing.Size(30, 28);
            this.bAdvFilter.TabIndex = 7;
            this.bAdvFilter.Text = "6";
            this.bAdvFilter.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.bFilter);
            this.panel1.Controls.Add(this.bAdvFilter);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 59);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(825, 35);
            this.panel1.TabIndex = 8;
            // 
            // tabContainer
            // 
            this.tabContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabContainer.Location = new System.Drawing.Point(0, 94);
            this.tabContainer.Name = "tabContainer";
            this.tabContainer.SelectedIndex = 0;
            this.tabContainer.Size = new System.Drawing.Size(825, 327);
            this.tabContainer.TabIndex = 9;
            // 
            // DataList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 492);
            this.Controls.Add(this.tabContainer);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.pagingControl1);
            this.Controls.Add(this.panelSelect);
            this.Name = "DataList";
            this.panelSelect.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pagingControl1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panelSelect;
        private System.Windows.Forms.Button bSelect;
        private Controls.PagingControl pagingControl1;
        private System.Windows.Forms.Button bFilter;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton bNew;
        private System.Windows.Forms.ToolStripLabel tslTitle;
        private System.Windows.Forms.ToolStripButton bEdit;
        private System.Windows.Forms.ToolStripButton bView;
        private System.Windows.Forms.ToolStripButton bDel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton bClose;
        private System.Windows.Forms.Button bAdvFilter;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabContainer;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}
