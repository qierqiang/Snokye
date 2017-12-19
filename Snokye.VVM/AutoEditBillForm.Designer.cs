namespace Snokye.VVM
{
    partial class AutoEditBillForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabPageDefualt = new System.Windows.Forms.TabPage();
            this.tabDetail = new System.Windows.Forms.TabControl();
            this.tabDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPageDefualt
            // 
            this.tabPageDefualt.Location = new System.Drawing.Point(4, 22);
            this.tabPageDefualt.Name = "tabPageDefualt";
            this.tabPageDefualt.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDefualt.Size = new System.Drawing.Size(1005, 436);
            this.tabPageDefualt.TabIndex = 0;
            this.tabPageDefualt.Text = "明细";
            this.tabPageDefualt.UseVisualStyleBackColor = true;
            // 
            // tabDetail
            // 
            this.tabDetail.Controls.Add(this.tabPageDefualt);
            this.tabDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabDetail.Location = new System.Drawing.Point(0, 59);
            this.tabDetail.MinimumSize = new System.Drawing.Size(0, 400);
            this.tabDetail.Name = "tabDetail";
            this.tabDetail.SelectedIndex = 0;
            this.tabDetail.Size = new System.Drawing.Size(1013, 462);
            this.tabDetail.TabIndex = 2;
            // 
            // AutoEditBillForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1013, 521);
            this.Controls.Add(this.tabDetail);
            this.Name = "AutoEditBillForm";
            this.Text = "AutoEditBillForm";
            this.Controls.SetChildIndex(this.tabDetail, 0);
            this.tabDetail.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabPage tabPageDefualt;
        private System.Windows.Forms.TabControl tabDetail;
    }
}