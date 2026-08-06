using DVLD.Peoples.Users;
using DVLD_Buisness_Layer;
using DVLD.Person.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;


namespace DVLD
{
    public partial class Main_Screen : Form
    {
        public Main_Screen()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void peoplesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Person.AllPeopleList().ShowDialog();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
             AllUsersList allUsersList = new AllUsersList();
             allUsersList.ShowDialog();
        }

        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
