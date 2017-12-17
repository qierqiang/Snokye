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
            this.billDetailList1 = new Snokye.VVM.BillDetailList();
            this.SuspendLayout();
            // 
            // billDetailList1
            // 
            this.billDetailList1.DataSource = null;
            this.billDetailList1.Location = new System.Drawing.Point(12, 145);
            this.billDetailList1.Name = "billDetailList1";
            this.billDetailList1.Size = new System.Drawing.Size(989, 327);
            this.billDetailList1.TabIndex = 2;
            // 
            // AutoEditBillForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1013, 521);
            this.Controls.Add(this.billDetailList1);
            this.Name = "AutoEditBillForm";
            this.Text = "AutoEditBillForm";
            this.Controls.SetChildIndex(this.billDetailList1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BillDetailList billDetailList1;
    }
}