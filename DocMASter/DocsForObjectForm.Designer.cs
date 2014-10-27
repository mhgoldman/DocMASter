namespace DocMASter
{
    partial class DocsForObjectForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DocsForObjectForm));
            this.docListGroupBox = new System.Windows.Forms.GroupBox();
            this.docsListView = new System.Windows.Forms.ListView();
            this.fileNameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.fileTypeColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.timeStampColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DocOperationsGroup = new System.Windows.Forms.GroupBox();
            this.claimDocButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.openFolderButton = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.aboutGroupBox = new System.Windows.Forms.GroupBox();
            this.aboutLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.docListGroupBox.SuspendLayout();
            this.DocOperationsGroup.SuspendLayout();
            this.aboutGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // docListGroupBox
            // 
            this.docListGroupBox.Controls.Add(this.docsListView);
            this.docListGroupBox.Location = new System.Drawing.Point(11, 6);
            this.docListGroupBox.Name = "docListGroupBox";
            this.docListGroupBox.Size = new System.Drawing.Size(773, 258);
            this.docListGroupBox.TabIndex = 3;
            this.docListGroupBox.TabStop = false;
            this.docListGroupBox.Text = "Docs Available";
            // 
            // docsListView
            // 
            this.docsListView.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.docsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.fileNameColumn,
            this.fileTypeColumn,
            this.timeStampColumn});
            this.docsListView.FullRowSelect = true;
            this.docsListView.HideSelection = false;
            this.docsListView.Location = new System.Drawing.Point(12, 21);
            this.docsListView.MultiSelect = false;
            this.docsListView.Name = "docsListView";
            this.docsListView.Size = new System.Drawing.Size(750, 224);
            this.docsListView.TabIndex = 3;
            this.docsListView.UseCompatibleStateImageBehavior = false;
            this.docsListView.View = System.Windows.Forms.View.Details;
            this.docsListView.DoubleClick += new System.EventHandler(this.docsListView_DoubleClick);
            // 
            // fileNameColumn
            // 
            this.fileNameColumn.Text = "File Name";
            this.fileNameColumn.Width = 400;
            // 
            // fileTypeColumn
            // 
            this.fileTypeColumn.Text = "File Type";
            this.fileTypeColumn.Width = 200;
            // 
            // timeStampColumn
            // 
            this.timeStampColumn.Text = "Time Stamp";
            this.timeStampColumn.Width = 146;
            // 
            // DocOperationsGroup
            // 
            this.DocOperationsGroup.Controls.Add(this.claimDocButton);
            this.DocOperationsGroup.Controls.Add(this.closeButton);
            this.DocOperationsGroup.Controls.Add(this.openFolderButton);
            this.DocOperationsGroup.Location = new System.Drawing.Point(13, 271);
            this.DocOperationsGroup.Name = "DocOperationsGroup";
            this.DocOperationsGroup.Size = new System.Drawing.Size(367, 168);
            this.DocOperationsGroup.TabIndex = 4;
            this.DocOperationsGroup.TabStop = false;
            this.DocOperationsGroup.Text = "Doc Operations";
            // 
            // claimDocButton
            // 
            this.claimDocButton.Location = new System.Drawing.Point(110, 22);
            this.claimDocButton.Name = "claimDocButton";
            this.claimDocButton.Size = new System.Drawing.Size(148, 42);
            this.claimDocButton.TabIndex = 3;
            this.claimDocButton.Text = "Claim Doc";
            this.claimDocButton.UseVisualStyleBackColor = true;
            this.claimDocButton.Click += new System.EventHandler(this.claimDocButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(110, 118);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(148, 42);
            this.closeButton.TabIndex = 2;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // openFolderButton
            // 
            this.openFolderButton.Location = new System.Drawing.Point(110, 70);
            this.openFolderButton.Name = "openFolderButton";
            this.openFolderButton.Size = new System.Drawing.Size(148, 42);
            this.openFolderButton.TabIndex = 1;
            this.openFolderButton.Text = "Open Folder";
            this.openFolderButton.UseVisualStyleBackColor = true;
            this.openFolderButton.Click += new System.EventHandler(this.openFolderButton_Click);
            // 
            // aboutGroupBox
            // 
            this.aboutGroupBox.Controls.Add(this.aboutLabel);
            this.aboutGroupBox.Controls.Add(this.pictureBox1);
            this.aboutGroupBox.Location = new System.Drawing.Point(417, 271);
            this.aboutGroupBox.Name = "aboutGroupBox";
            this.aboutGroupBox.Size = new System.Drawing.Size(367, 168);
            this.aboutGroupBox.TabIndex = 5;
            this.aboutGroupBox.TabStop = false;
            this.aboutGroupBox.Text = "About";
            // 
            // aboutLabel
            // 
            this.aboutLabel.AutoSize = true;
            this.aboutLabel.Location = new System.Drawing.Point(7, 20);
            this.aboutLabel.Name = "aboutLabel";
            this.aboutLabel.Size = new System.Drawing.Size(35, 13);
            this.aboutLabel.TabIndex = 1;
            this.aboutLabel.Text = "About";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DocMASter.Properties.Resources.tms_logo;
            this.pictureBox1.Location = new System.Drawing.Point(77, 110);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(214, 50);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // DocsForObjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 449);
            this.Controls.Add(this.aboutGroupBox);
            this.Controls.Add(this.DocOperationsGroup);
            this.Controls.Add(this.docListGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "DocsForObjectForm";
            this.Text = "DocsForObjectForm";
            this.docListGroupBox.ResumeLayout(false);
            this.DocOperationsGroup.ResumeLayout(false);
            this.aboutGroupBox.ResumeLayout(false);
            this.aboutGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox docListGroupBox;
        private System.Windows.Forms.GroupBox DocOperationsGroup;
        private System.Windows.Forms.Button openFolderButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button claimDocButton;
        private System.Windows.Forms.GroupBox aboutGroupBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label aboutLabel;
        private System.Windows.Forms.ListView docsListView;
        private System.Windows.Forms.ColumnHeader fileNameColumn;
        private System.Windows.Forms.ColumnHeader fileTypeColumn;
        private System.Windows.Forms.ColumnHeader timeStampColumn;
    }
}