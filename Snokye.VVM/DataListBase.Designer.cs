namespace Snokye.VVM
{
    partial class DataListBase
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.bNew = new System.Windows.Forms.ToolStripButton();
            this.tslTitle = new System.Windows.Forms.ToolStripLabel();
            this.bEdit = new System.Windows.Forms.ToolStripButton();
            this.bView = new System.Windows.Forms.ToolStripButton();
            this.bDisable = new System.Windows.Forms.ToolStripButton();
            this.bDel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bExport = new System.Windows.Forms.ToolStripButton();
            this.bCalculate = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.bRefreshData = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bClose = new System.Windows.Forms.ToolStripButton();
            this.bAdvFilter = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pFilters = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabContainer = new System.Windows.Forms.TabControl();
            this.pagingControl1 = new Snokye.Controls.PagingControl();
            this.panelSelect.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pagingControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelSelect
            // 
            this.panelSelect.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelSelect.Controls.Add(this.bSelect);
            this.panelSelect.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelSelect.Location = new System.Drawing.Point(0, 450);
            this.panelSelect.Name = "panelSelect";
            this.panelSelect.Size = new System.Drawing.Size(856, 42);
            this.panelSelect.TabIndex = 3;
            this.panelSelect.Visible = false;
            // 
            // bSelect
            // 
            this.bSelect.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.bSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bSelect.Location = new System.Drawing.Point(384, 5);
            this.bSelect.Name = "bSelect";
            this.bSelect.Size = new System.Drawing.Size(85, 33);
            this.bSelect.TabIndex = 0;
            this.bSelect.Text = "确认选择(&C)";
            this.bSelect.UseVisualStyleBackColor = true;
            this.bSelect.Click += new System.EventHandler(this.bSelect_Click);
            // 
            // bFilter
            // 
            this.bFilter.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.bFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bFilter.Location = new System.Drawing.Point(5, 6);
            this.bFilter.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.bFilter.Name = "bFilter";
            this.bFilter.Size = new System.Drawing.Size(80, 28);
            this.bFilter.TabIndex = 5;
            this.bFilter.Text = "查询（&F)";
            this.bFilter.UseVisualStyleBackColor = true;
            this.bFilter.Click += new System.EventHandler(this.Filter_Click);
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
            this.bDisable,
            this.bDel,
            this.toolStripSeparator1,
            this.bExport,
            this.bCalculate,
            this.toolStripSeparator3,
            this.bRefreshData,
            this.toolStripSeparator2,
            this.bClose});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(856, 59);
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
            this.bNew.Click += new System.EventHandler(this.New_Click);
            // 
            // tslTitle
            // 
            this.tslTitle.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tslTitle.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tslTitle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tslTitle.Name = "tslTitle";
            this.tslTitle.Size = new System.Drawing.Size(129, 56);
            this.tslTitle.Text = "表单标题";
            // 
            // bEdit
            // 
            this.bEdit.Image = global::Snokye.VVM.Properties.Resources.icons8_编辑文件_40;
            this.bEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bEdit.Name = "bEdit";
            this.bEdit.Size = new System.Drawing.Size(51, 56);
            this.bEdit.Text = "修改(&M)";
            this.bEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.bEdit.Click += new System.EventHandler(this.Edit_Click);
            // 
            // bView
            // 
            this.bView.Image = global::Snokye.VVM.Properties.Resources.icons8_查看文件_40;
            this.bView.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bView.Name = "bView";
            this.bView.Size = new System.Drawing.Size(51, 56);
            this.bView.Text = "查看(&V)";
            this.bView.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.bView.Click += new System.EventHandler(this.View_Click);
            // 
            // bDisable
            // 
            this.bDisable.Image = global::Snokye.VVM.Properties.Resources.icons8_手册_40;
            this.bDisable.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bDisable.Name = "bDisable";
            this.bDisable.Size = new System.Drawing.Size(51, 56);
            this.bDisable.Text = "禁用(&B)";
            this.bDisable.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.bDisable.ToolTipText = "禁用(B)";
            this.bDisable.Click += new System.EventHandler(this.Disable_Click);
            // 
            // bDel
            // 
            this.bDel.Image = global::Snokye.VVM.Properties.Resources.icons8_关闭窗口_40;
            this.bDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bDel.Name = "bDel";
            this.bDel.Size = new System.Drawing.Size(51, 56);
            this.bDel.Text = "删除(&D)";
            this.bDel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.bDel.Click += new System.EventHandler(this.Delete_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 59);
            // 
            // bExport
            // 
            this.bExport.Image = global::Snokye.VVM.Properties.Resources.icons8_ms_excel中_40;
            this.bExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bExport.Name = "bExport";
            this.bExport.Size = new System.Drawing.Size(51, 56);
            this.bExport.Text = "导出(&E)";
            this.bExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.bExport.Click += new System.EventHandler(this.Export_Click);
            // 
            // bCalculate
            // 
            this.bCalculate.Image = global::Snokye.VVM.Properties.Resources.icons8_适马_40;
            this.bCalculate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bCalculate.Name = "bCalculate";
            this.bCalculate.Size = new System.Drawing.Size(51, 56);
            this.bCalculate.Text = "合计(&S)";
            this.bCalculate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.bCalculate.Click += new System.EventHandler(this.Calculator_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 59);
            // 
            // bRefreshData
            // 
            this.bRefreshData.Image = global::Snokye.VVM.Properties.Resources.icons8_同步_40;
            this.bRefreshData.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bRefreshData.Name = "bRefreshData";
            this.bRefreshData.Size = new System.Drawing.Size(51, 56);
            this.bRefreshData.Text = "刷新(&R)";
            this.bRefreshData.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.bRefreshData.Click += new System.EventHandler(this.RefreshData_Click);
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
            this.bClose.Click += new System.EventHandler(this.Close_Click);
            // 
            // bAdvFilter
            // 
            this.bAdvFilter.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.bAdvFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bAdvFilter.Font = new System.Drawing.Font("Webdings", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.bAdvFilter.Location = new System.Drawing.Point(84, 6);
            this.bAdvFilter.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.bAdvFilter.Name = "bAdvFilter";
            this.bAdvFilter.Size = new System.Drawing.Size(21, 28);
            this.bAdvFilter.TabIndex = 7;
            this.bAdvFilter.Text = "6";
            this.bAdvFilter.UseVisualStyleBackColor = true;
            this.bAdvFilter.Click += new System.EventHandler(this.AdvFilter_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pFilters);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 59);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(856, 40);
            this.panel1.TabIndex = 8;
            // 
            // pFilters
            // 
            this.pFilters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pFilters.Location = new System.Drawing.Point(0, 0);
            this.pFilters.Name = "pFilters";
            this.pFilters.Size = new System.Drawing.Size(748, 40);
            this.pFilters.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.bFilter);
            this.panel2.Controls.Add(this.bAdvFilter);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(748, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(108, 40);
            this.panel2.TabIndex = 8;
            // 
            // tabContainer
            // 
            this.tabContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabContainer.Location = new System.Drawing.Point(0, 99);
            this.tabContainer.Name = "tabContainer";
            this.tabContainer.SelectedIndex = 0;
            this.tabContainer.Size = new System.Drawing.Size(856, 322);
            this.tabContainer.TabIndex = 9;
            // 
            // pagingControl1
            // 
            this.pagingControl1.AutoSize = true;
            this.pagingControl1.CurrentPage = 1;
            this.pagingControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pagingControl1.Location = new System.Drawing.Point(0, 421);
            this.pagingControl1.MinimumSize = new System.Drawing.Size(600, 29);
            this.pagingControl1.Name = "pagingControl1";
            this.pagingControl1.Size = new System.Drawing.Size(856, 29);
            this.pagingControl1.TabIndex = 1;
            // 
            // DataListBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 492);
            this.Controls.Add(this.tabContainer);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.pagingControl1);
            this.Controls.Add(this.panelSelect);
            this.Name = "DataListBase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.DataList_Load);
            this.panelSelect.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pagingControl1)).EndInit();
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
        private System.Windows.Forms.ToolStripButton bCalculate;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.FlowLayoutPanel pFilters;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStripButton bExport;
        private System.Windows.Forms.ToolStripButton bDisable;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton bRefreshData;
    }
}
