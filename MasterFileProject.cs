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
        }

        /// <summary>
        /// Q4.1 Create a Dictionary data structure with a TKey of type integer
        /// and a TValue of type string, name the new structure "MasterFile"
        /// </summary>
        static public Dictionary<int, string> MasterFile = new Dictionary<int, string>();
        string FileName = "MyNames_v2.csv";

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

        private void DisplaySingleStaffMember(ListView listView, KeyValuePair<int, string> staffMember)
        {
            ListViewItem lvi = new ListViewItem(staffMember.Key.ToString());
            lvi.SubItems.Add(staffMember.Value);
            listView.Items.Add(lvi);
        }

        /// <summary>
        /// Q4.4 Create a method to filter the staff name data from the Dictionary into
        /// a second selectable listbox. This method must use a textbox input and update
        /// as each character is entered. The listbox must reflect the filtered data in
        /// real time
        /// </summary>
        private void textBoxFilterName_KeyUp(object sender, KeyEventArgs e)
        {
            DisplayFilteredNames(textBoxFilterName.Text);
        }

        /// <summary>
        /// Filters staff name data into Textbox using String.Contains()
        /// </summary>
        /// <param name="FilterName"></param>
        private void DisplayFilteredNames(string FilterName)
        {
            listViewFilter.Items.Clear();
            foreach (var staff in MasterFile)
            {
                if (staff.Value.ToUpper().Contains(FilterName.ToUpper()))
                {
                    DisplaySingleStaffMember(listViewFilter, staff);
                }
            }
        }

        /// <summary>
        /// Q4.5 Create a method to filter the staff ID data from the Dictionary into
        /// a second selectable listbox. This method must use a textbox input and update
        /// as each number is entered. The listbox must reflect the filtered data in
        /// real time
        /// </summary>
        private void textBoxFilterId_KeyUp(object sender, KeyEventArgs e)
        {
            DisplayFilteredIDs(textBoxFilterId.Text);
        }

        /// <summary>
        /// Filters staff ID data into Textbox using String.Contains()
        /// </summary>
        /// <param name="FilterId"></param>
        private void DisplayFilteredIDs(string FilterId)
        {
            listViewFilter.Items.Clear();
            foreach (var staff in MasterFile)
            {
                string Id = staff.Key.ToString();
                if (Id.Contains(FilterId))
                {
                    DisplaySingleStaffMember(listViewFilter, staff);
                }
            }
        }

        /// <summary>
        /// Q4.6 Create a double click method for the staff name text box which will
        /// clear the contents and place the focus into the staff name text box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxFilterName_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBoxFilterName.Clear();
        }

        /// <summary>
        /// Q4.7 Create a double click method for the staff ID text box which will
        /// clear the contents and place the focus into the staff ID text box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxFilterId_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBoxFilterId.Clear();
        }

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
    }
}
