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

namespace Complex_Data_Structures_AT3
{
    public partial class MasterFileProject : Form
    {
        public MasterFileProject()
        {
            InitializeComponent();
            LoadStaffDetails();
            DisplayFullData();
            TextBoxControls();
        }

        /// <summary>
        /// Q4.1 Create a Dictionary data structure with a TKey of type integer
        /// and a TValue of type string, name the new structure "MasterFile"
        /// </summary>
        static public Dictionary<int, string> MasterFile = new Dictionary<int, string>();
        string FileName = "MalinStaffNamesV2.csv";

        #region LOAD AND DISPLAY
        /// <summary>
        /// Q4.2 Create a method that will read the data from the .csv file into
        /// the Dictionary data structure when the form loads
        /// </summary>
        private void LoadStaffDetails()
        {
            using (StreamReader sr = new StreamReader(@FileName))
            {
                sr.ReadLine(); // skips first line of .csv ("mobile,name")
                while (!sr.EndOfStream)
                {
                    string[] staffMember = sr.ReadLine().Split(',');
                    int id = int.Parse(staffMember[0]);
                    string name = staffMember[1];
                    MasterFile.Add(id, name);
                }
            }
        }

        /// <summary>
        /// Q4.3 Create a method to display the Dictionary data into a non-selectable
        /// listbox (i.e. read only)
        /// </summary>
        private void DisplayFullData()
        {
            foreach (var staff in MasterFile)
            {
                DisplaySingleStaffMember(listViewDisplay, staff);
            }
        }

        /// <summary>
        /// Displays a single staff member's ID and name in the specified ListView
        /// </summary>
        /// <param name="listView">The ListView in which to display the data</param>
        /// <param name="staffMember">A KeyValuePair from the Dictionary</param>
        private void DisplaySingleStaffMember(ListView listView, KeyValuePair<int, string> staffMember)
        {
            ListViewItem lvi = new ListViewItem(staffMember.Key.ToString());
            lvi.SubItems.Add(staffMember.Value);
            listView.Items.Add(lvi);
        }
        #endregion LOAD AND DISPLAY

        #region FILTERING

        /// <summary>
        /// Q4.4 Create a method to filter the staff name data from the Dictionary into
        /// a second selectable listbox. This method must use a textbox input and update
        /// as each character is entered. The listbox must reflect the filtered data in
        /// real time
        /// </summary>
        /// <param name="textBox">The staff name being searched</param>
        private void DisplayFilteredNames(TextBox textBox)
        {
            listViewFilter.Items.Clear();
            string target = textBox.Text.ToUpper();
            foreach (var staff in MasterFile)
            {
                if (staff.Value.ToUpper().Contains(target))
                {
                    DisplaySingleStaffMember(listViewFilter, staff);
                }
            }
        }

        private void textBoxFilterName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsSeparator(e.KeyChar))
            {
                DisplayFilteredNames(textBoxFilterName);
            }
            else
                e.Handled = true;
        }

        /// <summary>
        /// Calls above method to filter staff name data as text is typed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxFilterId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
                return;
            }
            DisplayFilteredIDs(textBoxFilterId);
        }

        /// <summary>
        /// Q4.5 Create a method to filter the staff ID data from the Dictionary into
        /// a second selectable listbox. This method must use a textbox input and update
        /// as each number is entered. The listbox must reflect the filtered data in
        /// real time
        /// </summary>
        /// <param name="textBox">The TextBox containing the search target</param>
        private void DisplayFilteredIDs(TextBox textBox)
        {
            listViewFilter.Items.Clear();
            string target = textBox.Text.ToString();
            foreach (var staff in MasterFile)
            {
                string Id = staff.Key.ToString();
                if (Id.Contains(target))
                {
                    DisplaySingleStaffMember(listViewFilter, staff);
                }
            }
        }
        #endregion FILTERING

        #region TEXTBOX MANAGEMENT
        /// <summary>
        /// Q4.8 Create a mouse click method for the filtered listbox which will populate
        /// the two textboxes when a staff record is selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listViewFilter_Click(object sender, EventArgs e)
        {
            int index = listViewFilter.SelectedIndices[0];
            ListViewItem lvi = listViewFilter.Items[index];
            textBoxFilterId.Text = lvi.SubItems[0].Text.ToString();
            textBoxFilterName.Text = lvi.SubItems[1].Text.ToString();
        }

        /// <summary>
        /// A method that clears a given TextBox's Text property and gives it focus
        /// </summary>
        /// <param name="textBox"></param>
        private void ClearTextBox(TextBox textBox)
        {
            textBox.Clear();
            textBox.Focus();
        }
        #endregion TEXTBOX MANAGEMENT

        #region OPENING ADMIN FORM
        /// <summary>
        /// Q4.6 Create a method for the staff name text box which will clear the 
        /// contents and place the focus into the staff name text box. Utilise a
        /// keyboard shortcut
        /// Q4.7 Create a method for the staff ID text box which will clear the 
        /// contents and place the focus into the staff ID text box. Utilise a keyboard
        /// shortcut
        /// Q4.9 Create a method that will open the admin form when the Alt + A keys are
        /// pressed. Ensure the general form sends the currently selected staff ID value to
        /// the admin form which is opened as modal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MasterFileProject_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Alt)
            {
                switch (e.KeyCode)
                {
                    case Keys.A:
                        if (listViewFilter.SelectedItems.Count > 0)
                        {
                            int.TryParse(listViewFilter.SelectedItems[0].Text, out int id);
                            AdminForm adminForm = new AdminForm(id);
                            adminForm.ShowDialog();
                        }
                        else
                        {
                            UserMessage(1);
                        }
                        break;
                    case Keys.I:
                        ClearTextBox(textBoxFilterId);
                        UserMessage(2);
                        break;
                    case Keys.N:
                        ClearTextBox(textBoxFilterName);
                        UserMessage(3);
                        break;
                    default:
                        break;
                }
            }
            else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.C)
            {
                Close();
            }
        }
        #endregion OPENING ADMIN FORM

        #region UTILITIES
        private void TextBoxControls()
        {
            richTextBoxControls.Text =
                "Controls:\n" +
                "Alt+A: Admin\n" +
                "Alt+I: Clear ID\n" +
                "Alt+N: Clear Name\n" +
                "Ctrl+C: Close";
        }
        #endregion UTILITIES

        #region USER MESSAGING
        private void UserMessage(int message)
        {
            switch (message)
            {
                case 1:
                    toolStripStatusLabel.Text = "Select a staff member to open the Admin Form";
                    break;
                case 2:
                    toolStripStatusLabel.Text = "ID TextBox cleared";
                    break;
                case 3:
                    toolStripStatusLabel.Text = "Name TextBox cleared";
                    break;
                default:
                    break;
            }
        }
        #endregion USER MESSAGING
    }
}
