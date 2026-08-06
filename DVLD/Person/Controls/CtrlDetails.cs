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
using DVLD.Person.Controls;

namespace DVLD.Person.Controls
{
    public partial class CtrlDetails : UserControl
    {
        int _Id; 
        ClsPerson _Person;
        public CtrlDetails()
        {
            InitializeComponent();
        }

        private void initialize()
        {
            lblPersonID.Text = "[????]";
            lblFullName.Text = "[????]";
            lblEmail.Text = "[????]";
            lblDateOfBirth.Text = "[????]";
            lblCountry.Text = "[????]";
            lblGendor.Text = "[????]";
            lblAddress.Text = "[????]";
            lblNationalNo.Text = "[????]";
            lblPhone.Text = "[????]";
            pibPersonImage.ImageLocation = FormAddUpdatePerson.DefultImageMale;
        }

        private void _FillFields()
        {
            _Person = ClsPerson.Find(_Id);

            lblPersonID.Text = _Person.PersonId.ToString();
            lblFullName.Text = _Person.FirstName + " " + _Person.SecondName + " " + _Person.ThirdName + " " + _Person.LastName ;
            lblEmail.Text = _Person.Email;
            lblDateOfBirth.Text = _Person.DateOfBirth.ToShortDateString();
            if (_Person.Gendor == 0)
                lblGendor.Text = "Male";
            else
                lblGendor.Text = "Female";
            lblAddress.Text = _Person.Address;
            lblCountry.Text = _Person.Country.CountryName;
            lblNationalNo.Text = _Person.NationalNo.ToString();
            lblPhone.Text = _Person.Phone;
            if (_Person.ImagePath == string.Empty)
            {
                if (_Person.Gendor == 0)
                    pibPersonImage.ImageLocation = FormAddUpdatePerson.DefultImageMale;
                else
                    pibPersonImage.ImageLocation = FormAddUpdatePerson.DefultImageFemale;
            }
            else
                pibPersonImage.ImageLocation = _Person.ImagePath;
        }

        public  void LoadPerson(int Id)
        {
            linkEditPersonInfo.Enabled = true;
            this._Id=Id;

            if (!ClsPerson.isPersonExist(_Id))
            {
                initialize();
                MessageBox.Show("This Person Doas Not Exist");
                return;
            }

            _FillFields();
        }

        private void llEditPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormAddUpdatePerson formAddUpdatePerson = new FormAddUpdatePerson(_Id);
            formAddUpdatePerson.ShowDialog();
            _FillFields();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
