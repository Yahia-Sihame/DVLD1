using DVLD.Users.Controls;
using DVLD_Buisness_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD.Person.Controls;

namespace DVLD.Users
{
    public partial class FormAddUpdateUser : Form
    {
        enum enMode { Add = 0 , Update = 1}
        enMode _Mode = enMode.Add;
        int _UserId = -1;
        ClsUser _User = null;
        public FormAddUpdateUser()
        {
            InitializeComponent();

            _Mode = enMode.Add;
        }

        public FormAddUpdateUser(int UserId)
        {
            _UserId = UserId;
            _User = ClsUser.FindUserByUserId(_UserId); 
            _Mode = enMode.Update;
            InitializeComponent();


        }

        private void FormAddUpdateUser_Load(object sender, EventArgs e)
        {
            Initialize();

        }
  
        void Initialize()
        {
            if ( _Mode == enMode.Add)
            {
                lblTitle.Text = "Add User";
                UserInfoScreen.Enabled = false;
                btnSave.Enabled = false;
                personInfoWithFilter1.EnableGbFilter = true;
            }
            else
            {
                lblTitle.Text = "Update User";
                UserInfoScreen.Enabled = false;
                btnSave.Enabled = false;
                personInfoWithFilter1.EnableGbFilter = false;
                personInfoWithFilter1.CbFilterby = 1;
                personInfoWithFilter1.TextFilterValue = _User.PersonId.ToString();
                personInfoWithFilter1.LoadPerson();
            }
        }

        private void personInfoWithFilter1_Load(object sender, EventArgs e)
        {
            
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int Id; 
            if (personInfoWithFilter1.CbFilterby == 0)
            {
                Id = ClsPerson.Find(personInfoWithFilter1.NationalNu).PersonId;
            }
            else 
                Id = personInfoWithFilter1.PersonId;

            if ( _Mode  == enMode.Add )
            {
                if (ClsUser.IsUserExistForPersonId(Id))
                {
                    MessageBox.Show("This Person Is Already have User!", "ERRER", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    btnSave.Enabled = false;
                    return;
                }
                if ( ClsPerson.isPersonExist(Id) )
                {
                    tcuseraddupdate.SelectedTab = tcuseraddupdate.TabPages["UserInfoScreen"] ;
                    lblUserID.Text = Id.ToString() ;
                    btnSave.Enabled = true;
                    chkIsActive.Checked = true ;
                    UserInfoScreen.Enabled = true;
                }
                else
                    MessageBox.Show("You Have To SelectPerson First");
            }
            else if ( _Mode == enMode.Update)
            {
                if (ClsPerson.isPersonExist(Id))
                {
              
                        tcuseraddupdate.SelectedTab = tcuseraddupdate.TabPages["UserInfoScreen"];
                        UserInfoScreen.Enabled = true;
                        btnSave.Enabled = true;
                        

                        txtUserName.Text = _User.UserName;
                        txtPassword.Text = _User.Password;
                        txtConfirmPassword.Text = _User.Password;
               
                }
            }


            if (_Mode == enMode.Update)
            {

            }
            
            if ( _Mode == enMode.Update) 
            {
                if (ClsUser.FindUserByUserId(_UserId).PersonId != -1)
                {
                    if (!ClsUser.IsUserExistForPersonId(ClsUser.FindUserByUserId(_UserId).PersonId))
                    {
                        MessageBox.Show("This Person Not have User!", "ERRER", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        btnSave.Enabled = false;
                        return;
                    }
                    if (tcuseraddupdate.SelectedIndex < tcuseraddupdate.TabCount - 1)
                    {
                        tcuseraddupdate.SelectedIndex++;
                        UserInfoScreen.Enabled = true;
                        btnSave.Enabled = true;
                        lblUserID.Text = _User.UserId.ToString();
                        txtUserName.Text = _User.UserName.ToString();
                        txtPassword.Text = _User.Password.ToString();
                        txtConfirmPassword.Text = _User.Password.ToString();
                        if (_User.IsActive)
                        {
                            chkIsActive.Checked = true;
                        }
                        else
                            chkIsActive.Checked = false;
                    }
                }
            }    
        }

        bool validate()
        {
            bool IsValidate = true;
            bool IsFound = false;
            if (string.IsNullOrWhiteSpace(txtUserName.Text))
            {
                errorProvider1.SetError(txtUserName, "User Name cannot be blank");
                IsValidate = false;
            }
            else
            {
                errorProvider1.SetError(txtUserName,null);
            }
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                errorProvider1.SetError(txtUserName, "Password cannot be blank");
                IsValidate = false;
            }
            else
            {
                errorProvider1.SetError(txtPassword, null);
            }
            if (_Mode == enMode.Update)
            {
                IsFound = (ClsUser.IsUserExist(txtUserName.Text) && txtUserName.Text != _User.UserName.ToString());
            }
            else
                IsFound = (ClsUser.IsUserExist(txtUserName.Text));

            if (IsFound)
            {
                errorProvider1.SetError(txtUserName, "This User Name already exist!");
                IsValidate = false;
            }
            else
                errorProvider1.SetError(txtPassword, null);

            if ( txtPassword.Text != txtConfirmPassword.Text)
            {
                errorProvider1.SetError(txtConfirmPassword, "Password Confirmation doas not match Passsword");
                IsValidate = false;
            }
            else
                errorProvider1.SetError(txtConfirmPassword, null);

            return IsValidate;

        }

        void AddUser()
        {
            ClsUser clsUser = new ClsUser();
            clsUser.UserName = txtUserName.Text;
            clsUser.Password = txtPassword.Text;
            clsUser.PersonId = Convert.ToInt32(lblUserID.Text);
            if (chkIsActive.Checked)
            {
                clsUser.IsActive = true;
            }
            else
                clsUser.IsActive = false;

            if (clsUser.Save())
                MessageBox.Show("User Add Succeessfully");
            else
                MessageBox.Show("Faild To Add user");
        }

        void UpdateUser()
        {
            _User.UserName = txtUserName.Text;
            _User.Password = txtPassword.Text;
            if (chkIsActive.Checked)
            {
                _User.IsActive = true;
            }
            else
                _User.IsActive = false;

            if (_User.Save())
                MessageBox.Show("User Update Succeessfully");
            else
                MessageBox.Show("Faild To Update user");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!validate())
            {
                MessageBox.Show("somme Faild not emplemented yet , check your user info");
                return;
            }

            if ( _Mode == enMode.Add)
            {
                AddUser();
            }
            else
            {
                UpdateUser();
            }
            this.Close();
        }

        public static bool DeletUser(int UserId)
        {
            return ClsUser.DeleteUser(UserId);
        }

     
        private void LoginInfoScreen_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
