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
using DVLD.Users;
using DVLD.Login;
using DVLD.ApplicationTypes;
using DVLD.Tests.Test_Types;


namespace DVLD
{
    public partial class Main_Screen : Form
    {

        LoginForm _LoginForm = null;
        ClsUser _CurrentUser = null;
        public Main_Screen()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
   
        }

        public Main_Screen(LoginForm LoginForm)
        {
            InitializeComponent();
            _LoginForm = LoginForm;
            this.WindowState = FormWindowState.Maximized;
            _CurrentUser = ClsGlobalUser.GlobalUser;
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

        private void Main_Screen_Load(object sender, EventArgs e)
        {

        }

        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListApplicationTypes listApplicationTypes = new frmListApplicationTypes();
            listApplicationTypes.ShowDialog();
        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1(_CurrentUser.UserId);
            form.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (_CurrentUser != null)
            {
                FormUpdateUserPassword formUpdateUserPassword = new FormUpdateUserPassword(_CurrentUser.UserId);
                formUpdateUserPassword.ShowDialog();
            }
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _LoginForm.Show();
            _LoginForm.Initialize();
            this.Close();
        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListTestTypes frmListTestTypes = new frmListTestTypes();
            frmListTestTypes.ShowDialog();
        }
    }
}
