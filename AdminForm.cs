using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Complex_Data_Structures_AT3
{
    public partial class AdminForm : Form
    {
        /// <summary>
        /// Q5.1 Create a form with the following settings: Control Box = false and 
        /// KeyPreview = True, then add three buttons and two textboxes. The textbox 
        /// for the Staff ID should be read-only.
        /// </summary>
        public AdminForm()
        {
            InitializeComponent();
            TextBoxControlsAdmin();
        }

        /// <summary>
        /// Q5.2 Create a method that will receive the staff ID from the general form
        /// and then populate texboxes with the related data
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        public AdminForm(int id)
        {
            InitializeComponent();
            TextBoxControlsAdmin();
            MasterFileProject.MasterFile.TryGetValue(id, out string name);
            textBoxId.Text = id.ToString();
            textBoxName.Text = name;
            StaffId = id;
            StaffName = name;
        }

        // Global variables to save staff details for Rollback option
        public static int StaffId = 0;
        public static string StaffName = "";

        #region CREATE
        /// <summary>
        /// Q5.3 Create a method that will create a new staff ID and input the staff name
        /// from the related textbox. The new staff member must be added to the Dictionary
        /// data structure
        /// </summary>
        private void buttonCreate_Click(object sender, EventArgs e)
        {
            CreateNewStaffMember();
            UserMessageAdmin(0);
        }

        /// <summary>
        /// Adds the new staff member to the Dictionary
        /// </summary>
        private void CreateNewStaffMember()
        {
            int id = GenerateUniqueIdNumber();
            string name = textBoxName.Text.ToString();
            textBoxId.Text = id.ToString();
            MasterFileProject.MasterFile.Add(id, name);
        }

        /// <summary>
        /// Generates a new unique ID number for creating a new staff member
        /// </summary>
        /// <returns>A unique 9-digit ID number beginning with '77'</returns>
        private int GenerateUniqueIdNumber()
        {
            bool uniqueId = false;
            int id = 0;
            while (!uniqueId)
            {
                Random rnd = new Random();
                string random = "77" + rnd.Next(0000000, 9999999).ToString();
                id = int.Parse(random);
                if (!MasterFileProject.MasterFile.ContainsKey(id))
                {
                    uniqueId = true;
                }
            }
            //textBoxId.Text = id.ToString();
            return id;
        }
        #endregion CREATE

        #region UPDATE
        /// <summary>
        /// Q5.4 Create a method that will update the name of the current staff ID
        /// </summary>
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            UpdateStaffMember();
            UserMessageAdmin(1);
        }

        // Updates staff member by id
        private void UpdateStaffMember()
        {
            int id = int.Parse(textBoxId.Text);
            string name = textBoxName.Text;
            MasterFileProject.MasterFile.Remove(id);
            MasterFileProject.MasterFile.Add(id, name);
        }
        #endregion UPDATE

        #region DELETE
        /// <summary>
        /// Q5.5 Create a method that will remove the current staff id and clear the textboxes
        /// </summary>
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            RemoveStaffMember();
            UserMessageAdmin(2);
        }

        // Deletes a staff member
        private void RemoveStaffMember()
        {
            int id = int.Parse(textBoxId.Text);
            DialogResult delChoice = MessageBox.Show("Do you wish to delete this staff member?",
                    "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (delChoice == DialogResult.Yes)
            {
                MasterFileProject.MasterFile.Remove(id);
                textBoxId.Clear();
                textBoxName.Clear();
            }
        }
        #endregion DELETE

        #region ROLLBACK
        private void buttonRollBack_Click(object sender, EventArgs e)
        {
            // Removing newly created/updated Staff Member (if applicable)
            try
            {
                MasterFileProject.MasterFile.Remove(int.Parse(textBoxId.Text));
            }
            catch (Exception) { }

            // Adding back original Staff Member
            try
            {
                MasterFileProject.MasterFile.Add(StaffId, StaffName);
            }
            catch (ArgumentException) { }
            textBoxId.Text = StaffId.ToString();
            textBoxName.Text = StaffName;
            UserMessageAdmin(3);
        }
        #endregion ROLLBACK

        #region SAVE
        /// <summary>
        /// Q5.6 Create a method that will save changes to the csv file, this method should be 
        /// called before the form closes
        /// </summary>
        private void SaveChangesToCSV()
        {
            // TODO: Save stuff
        }
        #endregion SAVE

        #region USER MESSAGING
        private void UserMessageAdmin(int message)
        {
            switch (message)
            {
                case 0:
                    toolStripStatusLabelAdmin.Text = "New staff member created: " + textBoxName.Text.ToString();
                    break;
                case 1:
                    toolStripStatusLabelAdmin.Text = "Staff member updated: " + textBoxName.Text.ToString();
                    break;
                case 2:
                    toolStripStatusLabelAdmin.Text = "Staff member deleted: " + StaffName;
                    break;
                case 3:
                    toolStripStatusLabelAdmin.Text = "Action undone";
                    break;
                default:
                    break;
            }
        }
        #endregion USER MESSAGING

        #region UTILITIES
        /// <summary>
        /// Q5.7 Create a method that will close the admin form when the Alt + L keys are pressed
        /// </summary>
        private void AdminForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.L && e.Modifiers == Keys.Alt)
            {
                Close();
            }
        }

        private void TextBoxControlsAdmin()
        {
            richTextBoxAdmin.Text =
                "Controls:\n" +
                "Tab: Navigate\n" +
                "Enter: Confirm\n" +
                "Alt+L: Close Admin";
        }
        #endregion UTILITIES
    }
}
