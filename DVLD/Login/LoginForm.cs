using DVLD_Buisness_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Login
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            ClsUser _CurrentUser = ClsUser.FindUserByUsernameAndPassword(txtUserName.Text.Trim(), txtPassword.Text);

            if (_CurrentUser != null)
            {

                if (checkBox1.Checked == true)
                {
                    ClsGlobalUser.RememberUsernameAndPassword(_CurrentUser.UserName, _CurrentUser.Password);
                }
                else 
                    ClsGlobalUser.RememberUsernameAndPassword("","");

                ClsGlobalUser.GlobalUser = _CurrentUser;
                this.Hide();
                Main_Screen main_Screen = new Main_Screen(this);
                main_Screen.Show();
                
            }
            else
                label1.Text = "UserName or Password Incorrect!";

        }


        private void LoginForm_Load(object sender, EventArgs e)
        {
            Initialize();
        }

        public void Initialize()
        {

            string UserId = string.Empty;
            string Password = string.Empty;

            if (ClsGlobalUser.GetStoredCredential(ref UserId, ref Password))
            {
                txtUserName.Text = UserId;
                txtPassword.Text = Password;
                checkBox1.Checked = true;
                label1.Text = string.Empty;
            }
            else
            {
                txtUserName.Text = string.Empty;
                txtPassword.Text = string.Empty;
                checkBox1.Checked = false;
                label1.Text = string.Empty;
            }
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
