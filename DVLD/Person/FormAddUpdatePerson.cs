using DVLD.Utils;
using DVLD_Buisness_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD.Person.Controls;
using System.Windows.Forms;


namespace DVLD.Person
{
    public partial class FormAddUpdatePerson : Form
    {
        int Id { get; set; }
        ClsPerson Person1;

        enum enAddUpdate { add = 0 , update = 1 };
        enAddUpdate Mode = enAddUpdate.add;

        public static  string DefultImageMale = @"C:\Users\Hp\Downloads\Icons\Icons\Male 512.png";
        public static  string DefultImageFemale = @"C:\Users\Hp\Downloads\Icons\Icons\Female 512.png";



        public FormAddUpdatePerson()
        {
            InitializeComponent();
        }

        public FormAddUpdatePerson(int PersonId)
        {
            InitializeComponent();
            Id = PersonId;
            Mode = enAddUpdate.update; 
        }

        private void _LoadCmbCountries()
        {
            foreach (DataRow row in ClsCountries.GetAllCountries().Rows)
            {
                cmbCountry.Items.Add(row["CountryName"]);
            }

        }

        private void _LoadForm()
        {

            _ResetForm();

            if (Mode == enAddUpdate.update)
                _InitializeUpdate();
        }

        private void _ResetForm()
        {
            _LoadCmbCountries();

            if (Mode == enAddUpdate.add)
            {
                lblTitle.Text = "Add New Person";
                Person1 = new ClsPerson();
            }
            else
                lblTitle.Text = "Update Person";

            txtFirstName.Text = string.Empty;
            txtSecondName.Text = string.Empty;
            txtThirdName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtNationalNo.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtAddress.Text = string.Empty;

            rdbMale.Checked = true;
            picPersonImage.ImageLocation = DefultImageMale;

            cmbCountry.SelectedIndex = cmbCountry.FindString("Morocco");
            
            LinkRemoveImage.Visible = false;

            dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(-18); ;
            dtpDateOfBirth.Value = dtpDateOfBirth.MaxDate;
            dtpDateOfBirth.MinDate = DateTime.Now.AddYears(-100);

        }

        

        private void _InitializeUpdate()
        {

         Person1 = ClsPerson.Find(Id);
     

            if (Person1 == null)
            {
                MessageBox.Show("No Person with ID = " + Id, "Person Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }


            lblId.Text = Person1.PersonId.ToString();
            txtNationalNo.Text = Person1.NationalNo;
            txtFirstName.Text = Person1.FirstName;
            txtSecondName.Text = Person1.SecondName;
            txtThirdName.Text = Person1.ThirdName; 
            txtLastName.Text = Person1.LastName;

            txtEmail.Text = Person1.Email;
            txtPhone.Text = Person1.Phone;
            txtAddress.Text = Person1.Address;

            dtpDateOfBirth.Value = Person1.DateOfBirth;

            if (Person1.Gendor == 0)
                rdbMale.Checked = true;
            else
                rdbFemale.Checked = true;


            cmbCountry.SelectedIndex = cmbCountry.FindString(Person1.Country.CountryName);

            if (Person1.ImagePath != string.Empty &&( picPersonImage.ImageLocation != DefultImageMale || picPersonImage.ImageLocation != DefultImageFemale) )
            {
                picPersonImage.ImageLocation = Person1.ImagePath;
            }
            

            LinkRemoveImage.Visible = (Person1.ImagePath != string.Empty);
        }

  
        private void FormAddUpdatePerson_Load(object sender, EventArgs e)
        {
            _LoadForm();
        }

        private void cmbCountry_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }



        private bool ImageSave()
        {
            if (picPersonImage.ImageLocation == DefultImageMale || picPersonImage.ImageLocation == DefultImageFemale)
            {
                if (!string.IsNullOrEmpty(Person1.ImagePath) && File.Exists(Person1.ImagePath))
                {
                    File.Delete(Person1.ImagePath);
                }

                Person1.ImagePath = ""; 
                return true;
            }

            if (picPersonImage.ImageLocation == Person1.ImagePath)
            {
                return true;
            }

            string newPathImage = picPersonImage.ImageLocation;

            if (ClsUtils.SaveImageInOurFile(ref newPathImage))
            {
                if (!string.IsNullOrEmpty(Person1.ImagePath) && File.Exists(Person1.ImagePath))
                {
                    File.Delete(Person1.ImagePath);
                }

                Person1.ImagePath = newPathImage;
                return true;
            }
            else
            {
                return false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (!ValidateChildren())
            {
                MessageBox.Show("Some fields are not valid! Put the mouse over the red icons to see the error.",
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }

            if (!ImageSave())
            {
                return;
            }

            Person1.NationalNo = txtNationalNo.Text.Trim();
            Person1.FirstName = txtFirstName.Text.Trim();
            Person1.SecondName = txtSecondName.Text.Trim();
            Person1.ThirdName = txtThirdName.Text.Trim();
            Person1.LastName = txtLastName.Text.Trim();
            Person1.Phone = txtPhone.Text.Trim();
            Person1.Address = txtAddress.Text.Trim();
            Person1.DateOfBirth = dtpDateOfBirth.Value;
            Person1.NationalityCountryID = ClsCountries.Find(cmbCountry.Text.ToString()).CountryId;

            if (!string.IsNullOrEmpty(txtEmail.Text))
                Person1.Email = txtEmail.Text.Trim();
            else
                Person1.Email = string.Empty;


            if (rdbMale.Checked)
                Person1.Gendor = 0;
            else
                Person1.Gendor = 1;

            if (picPersonImage.ImageLocation == DefultImageFemale || picPersonImage.ImageLocation == DefultImageMale)
                Person1.ImagePath = string.Empty;
            

            if (Mode == enAddUpdate.add)
            {
                if (Person1.save())
                {
                    MessageBox.Show("Data Saved Successfully with ID: " + Person1.PersonId, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Error: Data was NOT saved.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (Person1.save())
                    MessageBox.Show("Data Update Successfully with ID: " + Person1.PersonId, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Error: Data was NOT saved.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Close();
        }

        private void LinkSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SaveImagePath.InitialDirectory = @"C:\Users\Hp\Desktop\yahya";
            
            if (SaveImagePath.ShowDialog() == DialogResult.OK)
            {
                picPersonImage.ImageLocation = SaveImagePath.FileName;

                LinkRemoveImage.Visible = (!string.IsNullOrEmpty(SaveImagePath.FileName));
            }
        }

        private void LinkRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Person1.ImagePath = string.Empty;
           if (rdbFemale.Checked)
           {
                picPersonImage.ImageLocation = DefultImageFemale;
           }
           else
                picPersonImage.ImageLocation = DefultImageMale;

            LinkRemoveImage.Visible = false;
        }

        private void rdbMale_CheckedChanged(object sender, EventArgs e)
        {
            if( string.IsNullOrEmpty(Person1.ImagePath) )
                picPersonImage.ImageLocation = DefultImageMale;
        }

        private void rdbFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Person1.ImagePath))
                picPersonImage.ImageLocation = DefultImageFemale;
        }

         public bool DeletePerson(int PersonId)
        {
            if (ClsPerson.DeletePerson(PersonId))
                return true;
            return false;
        }

        private void lblId_Click(object sender, EventArgs e)
        {

        }

        
        private void ValidateTxt(object sender, CancelEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (textBox.Text == "")
            {
                errorProvider1.SetError(textBox, "You have To Write value !");
                e.Cancel = true;
            }
            else
                errorProvider1.SetError(textBox, null);
            
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            
            if (!ClsValidation.VerificationEmail(txtEmail.Text) && txtEmail.Text != string.Empty)
            {
                errorProvider1.SetError(txtEmail, "Invalid Format !");
                e.Cancel = true;
            }
            else
                errorProvider1.SetError(txtEmail, null);
        }

        private void Validating_IdAndPhone(object sender, CancelEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            ValidateTxt(sender, e);

            if (!ClsValidation.ValidateNumberInt(textBox.Text))
            {
                errorProvider1.SetError(textBox, "You have To write Number!");
                e.Cancel = true;
            }
            else 
                errorProvider1.SetError(textBox, null);
        }

        private void Validating_NationalNo(object sender, CancelEventArgs e)
        {
            if ( txtNationalNo.Text == string.Empty)
            {
                errorProvider1.SetError(txtNationalNo, "You Have To write value !");
                return;
            }

            if (ClsPerson.isPersonExist(txtNationalNo.Text) && txtNationalNo.Text != Person1.NationalNo)
            {
                e.Cancel=true;
                errorProvider1.SetError(txtNationalNo, "National Number Is used From another Person !");
            }
            else 
                errorProvider1.SetError(txtNationalNo, null);
        }
    }
}