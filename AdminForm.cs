using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

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
        private void CreateNewStaffMember()
        {
            if (!string.IsNullOrEmpty(textBoxName.Text))
            {
                int id = GenerateUniqueIdNumber();
                string name = textBoxName.Text.ToString();
                textBoxId.Text = id.ToString();
                MasterFileProject.MasterFile.Add(id, name);
                UserMessageAdmin(0);
            }
            else
                UserMessageAdmin(4);
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
        private void UpdateStaffMember()
        {
            int id = int.Parse(textBoxId.Text);
            string name = textBoxName.Text;
            MasterFileProject.MasterFile.Remove(id);
            MasterFileProject.MasterFile.Add(id, name);
            UserMessageAdmin(1);
        }
        #endregion UPDATE

        #region DELETE
        /// <summary>
        /// Q5.5 Create a method that will remove the current staff id and clear the textboxes
        /// </summary>
        private void DeleteStaffMember()
        {
            int id = int.Parse(textBoxId.Text);
            DialogResult delChoice = MessageBox.Show("Do you wish to delete this staff member?",
                    "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (delChoice == DialogResult.Yes)
            {
                MasterFileProject.MasterFile.Remove(id);
                textBoxId.Clear();
                textBoxName.Clear();
                UserMessageAdmin(2);
            }
        }
        #endregion DELETE

        #region ROLLBACK
        private void RollBackAction()
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
            // *** This method is slower ***
            //Using a StreamWriter object to write to the CSV file
            var stopwatch = Stopwatch.StartNew();
            //using (StreamWriter sw = new StreamWriter(@MasterFileProject.FileName))
            using (StreamWriter sw = new StreamWriter(@"SavedFile.csv"))
            {
                foreach (var staff in MasterFileProject.MasterFile)
                {
                    sw.WriteLine(staff.Key + "," + staff.Value);
                }
            }
            stopwatch.Stop();
            TimeSpan ts = stopwatch.Elapsed;
            Trace.WriteLine("");
            Trace.WriteLine("Data set saved to CSV using StreamWriter: " + ts.Milliseconds.ToString() + " milliseconds, "
                + ts.Ticks.ToString() + " ticks");

            // *** Faster method ***
            // Using a StringBuilder object to create a string from the Dictionary, 
            // then File.WriteAllText() to the CSV file
            var st = Stopwatch.StartNew();
            StringBuilder sb = new StringBuilder();
            foreach (var item in MasterFileProject.MasterFile)
            {
                sb.Append(item.Key + "," + item.Value + "\n");
            }
            File.WriteAllText(@"SavedFile.csv", sb.ToString());
            stopwatch.Stop();
            TimeSpan tis = st.Elapsed;
            Trace.WriteLine("");
            Trace.WriteLine("Data set saved to CSV using File.WriteAllText(): " + tis.Milliseconds.ToString() + " milliseconds, "
                + tis.Ticks.ToString() + " ticks");
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
                case 4:
                    toolStripStatusLabelAdmin.Text = "Enter a name to add a new staff member";
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
            if (e.Modifiers == Keys.Alt)
            {
                switch (e.KeyCode)
                {
                    case Keys.C:
                        CreateNewStaffMember();
                        break;
                    case Keys.U:
                        UpdateStaffMember();
                        break;
                    case Keys.D:
                        DeleteStaffMember();
                        break;
                    case Keys.R:
                        RollBackAction();
                        break;
                    case Keys.L:
                        SaveChangesToCSV();
                        Close();
                        break;
                    default:
                        break;
                }
            }
        }

        private void TextBoxControlsAdmin()
        {
            richTextBoxAdmin.Text =
                "Controls:\n" +
                "Tab: Navigate\n" +
                "Enter: Confirm\n" +
                "Alt+C: Create\n" +
                "Alt+U: Update\n" +
                "Alt+D: Delete\n" +
                "Alt+R: Rollback\n" +
                "Alt+L: Close Admin";
        }
        #endregion UTILITIES
    }
}
