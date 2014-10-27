namespace DocMASter
{
    partial class SelectFileTypeDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectFileTypeDialog));
            this.fileTypeDropdown = new System.Windows.Forms.ComboBox();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.removeOriginalCheckbox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // fileTypeDropdown
            // 
            this.fileTypeDropdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fileTypeDropdown.FormattingEnabled = true;
            this.fileTypeDropdown.Location = new System.Drawing.Point(11, 12);
            this.fileTypeDropdown.Name = "fileTypeDropdown";
            this.fileTypeDropdown.Size = new System.Drawing.Size(223, 21);
            this.fileTypeDropdown.TabIndex = 0;
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(11, 81);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(98, 24);
            this.okButton.TabIndex = 2;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(136, 81);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(98, 24);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // removeOriginalCheckbox
            // 
            this.removeOriginalCheckbox.AutoSize = true;
            this.removeOriginalCheckbox.Checked = true;
            this.removeOriginalCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.removeOriginalCheckbox.Location = new System.Drawing.Point(30, 48);
            this.removeOriginalCheckbox.Name = "removeOriginalCheckbox";
            this.removeOriginalCheckbox.Size = new System.Drawing.Size(181, 17);
            this.removeOriginalCheckbox.TabIndex = 1;
            this.removeOriginalCheckbox.Text = "Remove file from original location";
            this.removeOriginalCheckbox.UseVisualStyleBackColor = true;
            // 
            // SelectFileTypeDialog
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(244, 116);
            this.Controls.Add(this.removeOriginalCheckbox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.fileTypeDropdown);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelectFileTypeDialog";
            this.Text = "Claim Doc";
            this.Load += new System.EventHandler(this.SelectFileTypeDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox fileTypeDropdown;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.CheckBox removeOriginalCheckbox;
    }
}