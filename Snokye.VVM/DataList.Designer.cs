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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pCheckFilter = new System.Windows.Forms.FlowLayoutPanel();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.pTextFilter = new System.Windows.Forms.Panel();
            this.bAdvFilter = new System.Windows.Forms.Button();
            this.bFilter = new System.Windows.Forms.Button();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.panelSelect = new System.Windows.Forms.Panel();
            this.bSelect = new System.Windows.Forms.Button();
            this.gridViewer1 = new SalesmenSettlement.Forms.GridViewer();
            this.pagingControl1 = new Snokye.Controls.PagingControl();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pCheckFilter.SuspendLayout();
            this.pTextFilter.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panelSelect.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewer1)).BeginInit();
            this.SuspendLayout();
            // 
            // pCheckFilter
            // 
            this.pCheckFilter.Controls.Add(this.radioButton1);
            this.pCheckFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pCheckFilter.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.pCheckFilter.Location = new System.Drawing.Point(0, 0);
            this.pCheckFilter.Name = "pCheckFilter";
            this.pCheckFilter.Padding = new System.Windows.Forms.Padding(5);
            this.pCheckFilter.Size = new System.Drawing.Size(841, 31);
            this.pCheckFilter.TabIndex = 0;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(739, 8);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(89, 16);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "radioStatus";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // pTextFilter
            // 
            this.pTextFilter.Controls.Add(this.bAdvFilter);
            this.pTextFilter.Controls.Add(this.bFilter);
            this.pTextFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pTextFilter.Location = new System.Drawing.Point(0, 31);
            this.pTextFilter.Name = "pTextFilter";
            this.pTextFilter.Size = new System.Drawing.Size(841, 40);
            this.pTextFilter.TabIndex = 1;
            // 
            // bAdvFilter
            // 
            this.bAdvFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bAdvFilter.Font = new System.Drawing.Font("Webdings", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.bAdvFilter.Location = new System.Drawing.Point(813, 6);
            this.bAdvFilter.Name = "bAdvFilter";
            this.bAdvFilter.Size = new System.Drawing.Size(21, 28);
            this.bAdvFilter.TabIndex = 1;
            this.bAdvFilter.Text = "6";
            this.bAdvFilter.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bAdvFilter.UseVisualStyleBackColor = true;
            // 
            // bFilter
            // 
            this.bFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bFilter.Location = new System.Drawing.Point(740, 6);
            this.bFilter.Name = "bFilter";
            this.bFilter.Size = new System.Drawing.Size(81, 28);
            this.bFilter.TabIndex = 0;
            this.bFilter.Text = "button2";
            this.bFilter.UseVisualStyleBackColor = true;
            // 
            // tabMain
            // 
            this.tabMain.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabMain.Controls.Add(this.tabPage1);
            this.tabMain.Controls.Add(this.tabPage2);
            this.tabMain.Controls.Add(this.tabPage3);
            this.tabMain.Controls.Add(this.tabPage4);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 71);
            this.tabMain.Name = "tabMain";
            this.tabMain.RightToLeftLayout = true;
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(841, 352);
            this.tabMain.TabIndex = 2;
            this.tabMain.TabStop = false;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.gridViewer1);
            this.tabPage1.Controls.Add(this.pagingControl1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(833, 323);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(833, 323);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(833, 323);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(833, 323);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "tabPage4";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // panelSelect
            // 
            this.panelSelect.Controls.Add(this.bSelect);
            this.panelSelect.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelSelect.Location = new System.Drawing.Point(0, 423);
            this.panelSelect.Name = "panelSelect";
            this.panelSelect.Size = new System.Drawing.Size(841, 42);
            this.panelSelect.TabIndex = 3;
            this.panelSelect.Visible = false;
            // 
            // bSelect
            // 
            this.bSelect.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.bSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bSelect.Location = new System.Drawing.Point(383, 5);
            this.bSelect.Name = "bSelect";
            this.bSelect.Size = new System.Drawing.Size(75, 33);
            this.bSelect.TabIndex = 0;
            this.bSelect.Text = "button1";
            this.bSelect.UseVisualStyleBackColor = true;
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
            this.gridViewer1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewCheckBoxColumn1,
            this.dataGridViewTextBoxColumn1});
            this.gridViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridViewer1.Location = new System.Drawing.Point(3, 3);
            this.gridViewer1.MultiSelect = false;
            this.gridViewer1.Name = "gridViewer1";
            this.gridViewer1.ReadOnly = true;
            this.gridViewer1.RowTemplate.Height = 23;
            this.gridViewer1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridViewer1.Size = new System.Drawing.Size(827, 288);
            this.gridViewer1.TabIndex = 0;
            // 
            // pagingControl1
            // 
            this.pagingControl1.AutoSize = true;
            this.pagingControl1.CurrentPage = 1;
            this.pagingControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pagingControl1.Location = new System.Drawing.Point(3, 291);
            this.pagingControl1.MinimumSize = new System.Drawing.Size(600, 29);
            this.pagingControl1.Name = "pagingControl1";
            this.pagingControl1.Size = new System.Drawing.Size(827, 29);
            this.pagingControl1.TabIndex = 1;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.HeaderText = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.ReadOnly = true;
            this.dataGridViewCheckBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // DataList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.panelSelect);
            this.Controls.Add(this.pTextFilter);
            this.Controls.Add(this.pCheckFilter);
            this.Name = "DataList";
            this.Size = new System.Drawing.Size(841, 465);
            this.pCheckFilter.ResumeLayout(false);
            this.pCheckFilter.PerformLayout();
            this.pTextFilter.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.panelSelect.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridViewer1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel pCheckFilter;
        private System.Windows.Forms.Panel pTextFilter;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Button bAdvFilter;
        private System.Windows.Forms.Button bFilter;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panelSelect;
        private System.Windows.Forms.Button bSelect;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private SalesmenSettlement.Forms.GridViewer gridViewer1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private Controls.PagingControl pagingControl1;
    }
}
