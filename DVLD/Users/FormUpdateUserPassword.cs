using DVLD.Users.Controls;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using TextBox = System.Windows.Forms.TextBox;

namespace DVLD.Users
{
    public partial class FormUpdateUserPassword : Form
    {
        int _UserId = -1; 
        ClsUser _user;
        public FormUpdateUserPassword()
        {
            InitializeComponent();
        }
        public FormUpdateUserPassword(int UserId)
        {
            InitializeComponent();
            _UserId = UserId;
        }

        private void FormUpdateUserPassword_Load(object sender, EventArgs e)
        {
            _user = ClsUser.FindUserByUserId(_UserId);

            if (!(_user != null) )
            {
                MessageBox.Show("This User Not Exist!","Not Exist",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            userControlFind1.LoadUserinfo(_UserId);
            ctrlDetails1.LoadPerson(_user.PersonId);


        }

        bool Validation()
        {
            if ( txtCurrentPassword.Text.Trim() != _user.Password )
            {
                errorProvider1.SetError(txtCurrentPassword,"Current Password Not correct");
                return false;
            }
            else
                errorProvider1.SetError(txtCurrentPassword, null);

            if ( txtNewPassword.Text.Trim() != txtConfirmPassword.Text.Trim())
            {
                errorProvider1.SetError(txtConfirmPassword, "Confirmation Not identical New Password");
                return false;
            }
            else
                errorProvider1.SetError(txtConfirmPassword, null);

            if ( txtNewPassword.Text.Trim() == txtCurrentPassword.Text.Trim() )
            {
                errorProvider1.SetError(txtNewPassword, "New Password identical of Current Password!");
                return false;
            }
            else
                errorProvider1.SetError(txtNewPassword, null);
            return true;
        }

        private void ValidateTxt(object sender, CancelEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                errorProvider1.SetError(textBox, "You have To Write value !");
            }
            else
                errorProvider1.SetError(textBox, null);

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
            {
                MessageBox.Show("Some fields are not valid! Put the mouse over the red icons to see the error.",
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if ( Validation() )
            {
                _user.Password = txtNewPassword.Text;
                if (_user.Save())
                {
                    MessageBox.Show("Password Update successfully");
                    this.Close();
                }
                else
                    MessageBox.Show("Password Update Faild!",
                        "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Some fields are not valid! Put the mouse over the red icons to see the error.",
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
