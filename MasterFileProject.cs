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
        Dictionary<int, string> MasterFile = new Dictionary<int, string>();
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
                listBoxDisplay.Items.Add(staff.Key);
            }
        }

        /// <summary>
        /// Q4.4 Create a method to filter the staff name data from the Dictionary into
        /// a second selectable listbox. This method must use a textbox input and update
        /// as each character is entered. The listbox must reflect the filtered data in
        /// real time
        /// </summary>
        private void textBoxFilterName_KeyPress(object sender, KeyPressEventArgs e)
        {
            DisplayFilteredNames(textBoxFilterName.Text);
        }
        private void DisplayFilteredNames(string FilterName)
        {
            listBoxFilter.Items.Clear();
            foreach (var staff in MasterFile)
            {
                if (staff.Value.ToUpper().Contains(FilterName.ToUpper()))
                {
                    listBoxFilter.Items.Add(staff.Value);
                }
            }
        }

        /// <summary>
        /// Q4.5 Create a method to filter the staff ID data from the Dictionary into
        /// a second selectable listbox. This method must use a textbox input and update
        /// as each number is entered. The listbox must reflect the filtered data in
        /// real time
        /// </summary>
        private void textBoxFilterId_KeyPress(object sender, KeyPressEventArgs e)
        {
            DisplayFilteredIDs(textBoxFilterId.Text);
        }
        private void DisplayFilteredIDs(string FilterId)
        {
            listBoxFilter.Items.Clear();
            foreach (var staff in MasterFile)
            {
                string Id = staff.Key.ToString();
                if (Id.Contains(FilterId))
                {
                    listBoxFilter.Items.Add(staff.Key);
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
    }
}
