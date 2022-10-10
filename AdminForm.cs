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
        public AdminForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Q5.2 Create a method that will receive the staff ID from the general form
        /// an then populate texboxes with the related data
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        public AdminForm(string id, string name)
        {
            InitializeComponent();
            textBoxId.Text = id;
            textBoxName.Text = name;
        }

        /// <summary>
        /// Q5.3 Create a method that will create a new staff ID and input the staff name
        /// from the related textbox. The new staff member must be added to the Dictionary
        /// data structure
        /// </summary>
        private void CreateNewStaffMember()
        {
            Random rnd = new Random();
            string random = "77" + rnd.Next(0000000, 9999999).ToString();
            int id = int.Parse(random);
            string name = textBoxName.ToString();
            MasterFileProject.MasterFile.Add(id, name);
        }

        /// <summary>
        /// Q5.4 Create a method that will update the name of the current staff ID
        /// </summary>
        private void UpdateStaffMember()
        {
            int id = int.Parse(textBoxId.Text);
            string name = textBoxName.Text;
            MasterFileProject.MasterFile.Remove(id);
            MasterFileProject.MasterFile.Add(id, name);
        }

        /// <summary>
        /// Q5.5 Create a method that will remove the current staff id and clear the textboxes
        /// </summary>
        private void RemoveStaffMember()
        {
            int id = int.Parse(textBoxId.Text);
            MasterFileProject.MasterFile.Remove(id);
            textBoxId.Clear();
            textBoxName.Clear();
        }

        /// <summary>
        /// Q5.6 Create a method that will save changes to the csv file, this method should be 
        /// called before the form closes
        /// </summary>
        private void SaveChangesToCSV()
        {
            // TODO: Save stuff
        }

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
    }
}
