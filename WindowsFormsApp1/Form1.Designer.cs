namespace WindowsFormsApp1
{
    partial class Form1
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
            this.pagingControl1 = new Snokye.Controls.PagingControl();
            ((System.ComponentModel.ISupportInitialize)(this.pagingControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // pagingControl1
            // 
            this.pagingControl1.AutoSize = true;
            this.pagingControl1.CurrentPage = 1;
            this.pagingControl1.Location = new System.Drawing.Point(153, 173);
            this.pagingControl1.MinimumSize = new System.Drawing.Size(600, 29);
            this.pagingControl1.Name = "pagingControl1";
            this.pagingControl1.Size = new System.Drawing.Size(600, 29);
            this.pagingControl1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 556);
            this.Controls.Add(this.pagingControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pagingControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Snokye.Controls.PagingControl pagingControl1;
    }
}