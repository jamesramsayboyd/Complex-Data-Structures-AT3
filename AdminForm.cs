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

        public AdminForm(string id, string name)
        {
            InitializeComponent();
            textBoxId.Text = id;
            textBoxName.Text = name;
        }

        List<string> list = new List<string>();
    }
}
