using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DocMASter
{
    public partial class SelectFileTypeDialog : Form
    {
        #region Class properties
        /// <summary>
        /// The filename for which the doc type is to be selected
        /// </summary>
        private string FileName { get; set; }

        /// <summary>
        /// A DMObject representing the MAS object to which the file will be associated
        /// </summary>
        private DMObject MyDMObject { get; set; }

        /// <summary>
        /// The doc type selected by the user
        /// </summary>
        public string FileType { get; private set; }

        /// <summary>
        /// Whether we are going to copy (false) or move (false) the file
        /// </summary>
        public bool RemoveOriginal { get; private set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor for Select Doc Type dialog
        /// </summary>
        /// <param name="fileName">The name of the file selected for association</param>
        /// <param name="dmObject">The DMObject to which the file will be associated</param>
        public SelectFileTypeDialog(string fileName, DMObject dmObject)
        {
            FileName = fileName;
            MyDMObject = dmObject;
            InitializeComponent();
        }
        #endregion

        #region Form events
        /// <summary>
        /// Form Load event: populatse the Doc Type dropdown and the informational labels
        /// </summary>
        private void SelectFileTypeDialog_Load(object sender, EventArgs e)
        {
            fileTypeDropdown.Items.Clear();
            fileTypeDropdown.Items.Insert(0,"-- Select Doc Type --");
            fileTypeDropdown.Items.AddRange(MyDMObject.AvailableFileTypes);
            fileTypeDropdown.SelectedIndex = 0;
            this.Text = "Claim Doc '" + FileName + "'";
        }

        /// <summary>
        /// Cancel Button Click event -- sets the Dialog Result and closes the dialog 
        /// </summary>
        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        /// <summary>
        /// OK Button Click event -- validates that a Doc Type was selected, sets the dialog properties, and closes the dialog
        /// </summary>
        private void okButton_Click(object sender, EventArgs e)
        {
            if (fileTypeDropdown.SelectedIndex == 0) {
                MessageBox.Show("You must select a Doc Type to continue.", "Error");
                return; 
            }

            DialogResult = DialogResult.OK;
            FileType = fileTypeDropdown.SelectedItem.ToString();
            RemoveOriginal = removeOriginalCheckbox.Checked;
            Close();
        }
        #endregion


    }
}
