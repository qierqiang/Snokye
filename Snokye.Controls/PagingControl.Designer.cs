namespace Snokye.Controls
{
    partial class PagingControl
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
            this.bFirst = new System.Windows.Forms.Button();
            this.bPrev = new System.Windows.Forms.Button();
            this.bNext = new System.Windows.Forms.Button();
            this.bLast = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.nCurPage = new System.Windows.Forms.NumericUpDown();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label12 = new System.Windows.Forms.Label();
            this.lCurLast = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lCurFirst = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lCurPage = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.lPageCount = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.lTotalCount = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nCurPage)).BeginInit();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // bFirst
            // 
            this.bFirst.Enabled = false;
            this.bFirst.FlatAppearance.BorderSize = 0;
            this.bFirst.Font = new System.Drawing.Font("Webdings", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.bFirst.Location = new System.Drawing.Point(404, 3);
            this.bFirst.Name = "bFirst";
            this.bFirst.Size = new System.Drawing.Size(23, 23);
            this.bFirst.TabIndex = 0;
            this.bFirst.Text = "9";
            this.bFirst.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bFirst.UseVisualStyleBackColor = true;
            // 
            // bPrev
            // 
            this.bPrev.Enabled = false;
            this.bPrev.FlatAppearance.BorderSize = 0;
            this.bPrev.Font = new System.Drawing.Font("Webdings", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.bPrev.Location = new System.Drawing.Point(433, 3);
            this.bPrev.Name = "bPrev";
            this.bPrev.Size = new System.Drawing.Size(23, 23);
            this.bPrev.TabIndex = 1;
            this.bPrev.Text = "3";
            this.bPrev.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bPrev.UseVisualStyleBackColor = true;
            // 
            // bNext
            // 
            this.bNext.Enabled = false;
            this.bNext.FlatAppearance.BorderSize = 0;
            this.bNext.Font = new System.Drawing.Font("Webdings", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.bNext.Location = new System.Drawing.Point(545, 3);
            this.bNext.Name = "bNext";
            this.bNext.Size = new System.Drawing.Size(23, 23);
            this.bNext.TabIndex = 2;
            this.bNext.Text = "4";
            this.bNext.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bNext.UseVisualStyleBackColor = true;
            // 
            // bLast
            // 
            this.bLast.Enabled = false;
            this.bLast.FlatAppearance.BorderSize = 0;
            this.bLast.Font = new System.Drawing.Font("Webdings", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.bLast.Location = new System.Drawing.Point(574, 3);
            this.bLast.Name = "bLast";
            this.bLast.Size = new System.Drawing.Size(23, 23);
            this.bLast.TabIndex = 3;
            this.bLast.Text = ":";
            this.bLast.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bLast.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.bLast);
            this.flowLayoutPanel1.Controls.Add(this.bNext);
            this.flowLayoutPanel1.Controls.Add(this.nCurPage);
            this.flowLayoutPanel1.Controls.Add(this.bPrev);
            this.flowLayoutPanel1.Controls.Add(this.bFirst);
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel2);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(600, 29);
            this.flowLayoutPanel1.TabIndex = 8;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // nCurPage
            // 
            this.nCurPage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nCurPage.InterceptArrowKeys = false;
            this.nCurPage.Location = new System.Drawing.Point(462, 5);
            this.nCurPage.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.nCurPage.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nCurPage.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nCurPage.Name = "nCurPage";
            this.nCurPage.Size = new System.Drawing.Size(77, 21);
            this.nCurPage.TabIndex = 12;
            this.nCurPage.TabStop = false;
            this.nCurPage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nCurPage.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.Controls.Add(this.label12);
            this.flowLayoutPanel2.Controls.Add(this.lCurLast);
            this.flowLayoutPanel2.Controls.Add(this.label14);
            this.flowLayoutPanel2.Controls.Add(this.lCurFirst);
            this.flowLayoutPanel2.Controls.Add(this.label16);
            this.flowLayoutPanel2.Controls.Add(this.lCurPage);
            this.flowLayoutPanel2.Controls.Add(this.label18);
            this.flowLayoutPanel2.Controls.Add(this.lPageCount);
            this.flowLayoutPanel2.Controls.Add(this.label20);
            this.flowLayoutPanel2.Controls.Add(this.lTotalCount);
            this.flowLayoutPanel2.Controls.Add(this.label22);
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(48, 3);
            this.flowLayoutPanel2.MinimumSize = new System.Drawing.Size(350, 23);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(350, 23);
            this.flowLayoutPanel2.TabIndex = 13;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(297, 6);
            this.label12.Margin = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 13;
            this.label12.Text = "条记录。";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lCurLast
            // 
            this.lCurLast.AutoSize = true;
            this.lCurLast.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lCurLast.Location = new System.Drawing.Point(285, 6);
            this.lCurLast.Margin = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.lCurLast.Name = "lCurLast";
            this.lCurLast.Size = new System.Drawing.Size(12, 12);
            this.lCurLast.TabIndex = 15;
            this.lCurLast.Text = "0";
            this.lCurLast.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(262, 6);
            this.label14.Margin = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(23, 12);
            this.label14.TabIndex = 13;
            this.label14.Text = " - ";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lCurFirst
            // 
            this.lCurFirst.AutoSize = true;
            this.lCurFirst.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lCurFirst.Location = new System.Drawing.Point(250, 6);
            this.lCurFirst.Margin = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.lCurFirst.Name = "lCurFirst";
            this.lCurFirst.Size = new System.Drawing.Size(12, 12);
            this.lCurFirst.TabIndex = 15;
            this.lCurFirst.Text = "0";
            this.lCurFirst.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(209, 6);
            this.label16.Margin = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(41, 12);
            this.label16.TabIndex = 11;
            this.label16.Text = "页、第";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lCurPage
            // 
            this.lCurPage.AutoSize = true;
            this.lCurPage.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lCurPage.Location = new System.Drawing.Point(197, 6);
            this.lCurPage.Margin = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.lCurPage.Name = "lCurPage";
            this.lCurPage.Size = new System.Drawing.Size(12, 12);
            this.lCurPage.TabIndex = 14;
            this.lCurPage.Text = "1";
            this.lCurPage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(108, 6);
            this.label18.Margin = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(89, 12);
            this.label18.TabIndex = 15;
            this.label18.Text = "页。当前显示第";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lPageCount
            // 
            this.lPageCount.AutoSize = true;
            this.lPageCount.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lPageCount.Location = new System.Drawing.Point(96, 6);
            this.lPageCount.Margin = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.lPageCount.Name = "lPageCount";
            this.lPageCount.Size = new System.Drawing.Size(12, 12);
            this.lPageCount.TabIndex = 13;
            this.lPageCount.Text = "0";
            this.lPageCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(43, 6);
            this.label20.Margin = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(53, 12);
            this.label20.TabIndex = 13;
            this.label20.Text = "条记录，";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lTotalCount
            // 
            this.lTotalCount.AutoSize = true;
            this.lTotalCount.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lTotalCount.Location = new System.Drawing.Point(31, 6);
            this.lTotalCount.Margin = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.lTotalCount.Name = "lTotalCount";
            this.lTotalCount.Size = new System.Drawing.Size(12, 12);
            this.lTotalCount.TabIndex = 12;
            this.lTotalCount.Text = "0";
            this.lTotalCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(2, 6);
            this.label22.Margin = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(29, 12);
            this.label22.TabIndex = 10;
            this.label22.Text = "共有";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PagingControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.flowLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(600, 29);
            this.Name = "PagingControl";
            this.Size = new System.Drawing.Size(600, 29);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nCurPage)).EndInit();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bFirst;
        private System.Windows.Forms.Button bPrev;
        private System.Windows.Forms.Button bNext;
        private System.Windows.Forms.Button bLast;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.NumericUpDown nCurPage;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lCurLast;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lCurFirst;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lCurPage;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label lPageCount;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label lTotalCount;
        private System.Windows.Forms.Label label22;
    }
}
