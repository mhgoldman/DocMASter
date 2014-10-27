using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Threading;

namespace DocMASter
{
    public partial class DocsForObjectForm : Form
    {
        #region Application properties
        /// <summary>
        /// Application name displayed in form
        /// </summary>
        private static readonly string AppName = "DocMASter 1.3";

        /// <summary>
        /// Copyright message displayed in form
        /// </summary>
        private static readonly string CopyrightMessage = "\u00a9 Copyright 2013 Total Machine Solutions, Inc.\nAll rights reserved.";
        #endregion

        /// <summary>
        /// The DMObject (MAS object) for which we will display associated docs, and potentially associated additional docs
        /// </summary>
        public DMObject DMObject;

        #region Constructors
        /// <summary>
        /// Constructor for main form
        /// </summary>
        /// <param name="objectType">Type of MAS object (e.g. Sales Order) for which we will be managing documents</param>
        /// <param name="objectId">MAS object ID (e.g. Sales Order Number) for which we will be managing documents</param>
        public DocsForObjectForm(string objectType, string objectId)
        {
            try
            {
                DMObject = new DMObject(objectType, objectId);
                InitializeComponent();
                Text = "Docs for " + objectType + " " + objectId + " - " + AppName;
                aboutGroupBox.Text = "About " + AppName;
                aboutLabel.Text = CopyrightMessage + "\n\nDoc Library Path: " + Util.DocLibraryPath + "\nDoc Dropbox Path: " + Util.DocDropboxPath;
                LoadDocsList();
            }
            catch (Exception e)
            {
                Util.InformException("initializing", e);
            }
        }
        #endregion

        #region Event Handlers
        /// <summary>
        /// Cell Click handler: if clicking on an "Open" link, open the corresponding document
        /// </summary>
        private void docsListView_DoubleClick(object sender, EventArgs e)
        {
            DMDoc doc = (DMDoc)((ListView)sender).SelectedItems[0].Tag;
            Open(doc.FullName);
        }

        /// <summary>
        /// Claim Doc Button Click handler: initiates the process of claiming a doc
        /// </summary>
        private void claimDocButton_Click(object sender, EventArgs e)
        {
            ClaimDoc();
        }

        /// <summary>
        /// Close Button Click handler: exit the application
        private void closeButton_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        /// <summary>
        /// Open Folder Button handler: open the folder where the stored documents reside
        /// </summary>
        private void openFolderButton_Click(object sender, EventArgs e)
        {
            Open(DMObject.DocsPath);
        }
        #endregion

        #region Helper Methods
        /// <summary>
        /// Opens the specified file path via Explorer
        /// </summary>
        /// <param name="filePath">Path of file to open</param>
        private void Open(string filePath)
        {
            try
            {
                Process.Start(filePath);
            }
            catch (Exception e)
            {
                Util.InformException("opening path " + filePath, e);
            }
        }

        /// <summary>
        /// Loads the available docs into the data grid view
        /// </summary>
        private void LoadDocsList()
        {
            try
            {
                docsListView.Items.Clear();
                foreach (DMDoc doc in DMObject.DocList)
                {
                    ListViewItem lvi = new ListViewItem(new string[] { doc.Name, doc.FileTypeDescription, doc.CreationTimeString });
                    lvi.Tag = doc;
                    docsListView.Items.Add(lvi);
                }
            }
            catch (Exception e)
            {
                Util.InformException("loading doc list", e);
            }
        }

        /// <summary>
        /// Find a document and move it into our repository
        /// </summary>
        private void ClaimDoc()
        {
            try
            {
                openFileDialog.Title = "Select Doc to Claim";
                openFileDialog.InitialDirectory = Util.DocDropboxPath;
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Filter = "All files|*.*";
                openFileDialog.FileName = "";
                DialogResult drOpen = openFileDialog.ShowDialog();
                if (drOpen == System.Windows.Forms.DialogResult.OK)
                {
                    SelectFileTypeDialog selectFileTypeDialog = new SelectFileTypeDialog(openFileDialog.SafeFileName, DMObject);
                    selectFileTypeDialog.StartPosition = FormStartPosition.CenterParent;
                    DialogResult drSelectFileType = selectFileTypeDialog.ShowDialog();
                    if (drSelectFileType == System.Windows.Forms.DialogResult.OK)
                    {
                        Cursor.Current = Cursors.WaitCursor;

                        // claiming a document sometimes fails because the Explorer preview pane has locked it.
                        // retry once per second up to 10 times.
                        bool success = false;
                        for (int i = 0; i < 10; i++)
                        {
                            try
                            {
                                DMObject.AssociateDoc(new DMDoc(openFileDialog.FileName), selectFileTypeDialog.FileType, selectFileTypeDialog.RemoveOriginal);
                                success = true;
                                break;
                            }
                            catch (IOException)
                            {
                                Thread.Sleep(1000);
                            }
                        }

                        if (success)
                        {
                            LoadDocsList();
                            Cursor.Current = Cursors.Default;
                        }
                        else
                        {
                            Cursor.Current = Cursors.Default;
                            throw new Exception("Associate Doc failed for 10 seconds");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Util.InformException("claiming doc", e);
            }
        }
        #endregion
    }
}
