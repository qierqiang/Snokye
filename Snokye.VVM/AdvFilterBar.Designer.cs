namespace Snokye.VVM
{
    partial class AdvFilterBar
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
            this.cmbField = new System.Windows.Forms.ComboBox();
            this.cmbOperator = new System.Windows.Forms.ComboBox();
            this.cNot = new System.Windows.Forms.CheckBox();
            this.bDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbField
            // 
            this.cmbField.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmbField.DisplayMember = "Text";
            this.cmbField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbField.FormattingEnabled = true;
            this.cmbField.Location = new System.Drawing.Point(3, 3);
            this.cmbField.Name = "cmbField";
            this.cmbField.Size = new System.Drawing.Size(121, 20);
            this.cmbField.TabIndex = 0;
            this.cmbField.ValueMember = "Value";
            this.cmbField.SelectedIndexChanged += new System.EventHandler(this.cmbField_SelectedIndexChanged);
            // 
            // cmbOperator
            // 
            this.cmbOperator.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmbOperator.DisplayMember = "Text";
            this.cmbOperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOperator.FormattingEnabled = true;
            this.cmbOperator.Location = new System.Drawing.Point(178, 3);
            this.cmbOperator.Name = "cmbOperator";
            this.cmbOperator.Size = new System.Drawing.Size(74, 20);
            this.cmbOperator.TabIndex = 1;
            this.cmbOperator.ValueMember = "Value";
            // 
            // cNot
            // 
            this.cNot.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cNot.AutoSize = true;
            this.cNot.Location = new System.Drawing.Point(130, 5);
            this.cNot.Name = "cNot";
            this.cNot.Size = new System.Drawing.Size(48, 16);
            this.cNot.TabIndex = 3;
            this.cNot.Text = "不是";
            this.cNot.UseVisualStyleBackColor = true;
            // 
            // bDelete
            // 
            this.bDelete.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.bDelete.BackgroundImage = global::Snokye.VVM.Properties.Resources.icons8_删除_40;
            this.bDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bDelete.Location = new System.Drawing.Point(402, 1);
            this.bDelete.Margin = new System.Windows.Forms.Padding(0);
            this.bDelete.Name = "bDelete";
            this.bDelete.Size = new System.Drawing.Size(25, 23);
            this.bDelete.TabIndex = 5;
            this.bDelete.UseVisualStyleBackColor = true;
            this.bDelete.Click += new System.EventHandler(this.bDelete_Click);
            // 
            // AdvFilterBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.bDelete);
            this.Controls.Add(this.cmbOperator);
            this.Controls.Add(this.cmbField);
            this.Controls.Add(this.cNot);
            this.Name = "AdvFilterBar";
            this.Size = new System.Drawing.Size(431, 26);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected internal System.Windows.Forms.ComboBox cmbField;
        protected internal System.Windows.Forms.ComboBox cmbOperator;
        protected internal System.Windows.Forms.CheckBox cNot;
        protected internal System.Windows.Forms.Button bDelete;
    }
}
