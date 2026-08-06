using DVLD.Person;
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

namespace DVLD.Users.Controls
{
    public partial class PersonInfoWithFilter : UserControl
    {
         enum enMode { Add =  0, Update = 1 }
         enMode Mode = enMode.Add ;
        int _PersonId = -1;
        string NationalNu = string.Empty;
        public static int SharePersonId = -1;
        public PersonInfoWithFilter()
        {
            InitializeComponent();
        }

        private void PersonInfoWithFilter_Load(object sender, EventArgs e)
        {
            InitializeForm();
        }

        public static void Gett(int UserId)
        {

        }
        void InitializeForm()
        {
            cbFilterBy.SelectedIndex = 1;

            if (Mode == enMode.Update)
            {
                gbFilters.Enabled = false;
                //txtFilterValue.Text = PersonIdForImplemented.ToString();
                FillFields();
                return;
            }
            else
            {
                //PersonIdForImplemented = -1;
                gbFilters.Enabled = true;
                txtFilterValue.Text = string.Empty; 
            }
        }
        void FillFields()
        {
            //ctrlDetails1.LoadPerson(PersonIdForImplemented);
        }
        
        private void btnFind_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFilterValue.Text))
            {
                txtFilterValue.Focus();
                errorProvider1.SetError(txtFilterValue, "You have To Write value !");
            }
            else
            {
                errorProvider1.SetError(txtFilterValue, null);
                LoadPerson();
            }
                
        }
        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            FormAddUpdatePerson frm = new FormAddUpdatePerson();
            frm.ShowDialog();
        }

        void LoadPerson()
        {
            if (cbFilterBy.Text == "National No")
            {
                NationalNu = txtFilterValue.Text.Trim();
                LoadPersonInfo(NationalNu);
            }
            else
            {
                _PersonId = Convert.ToInt32(txtFilterValue.Text);
                LoadPersonInfo(_PersonId);
            }
        }
        void LoadPersonInfo(string NationalNu)
        { 
            bool isExist = ClsPerson.isPersonExist(NationalNu); 
            if (isExist)
            {
                ctrlDetails1.LoadPerson(ClsPerson.Find(NationalNu).PersonId);
                SharePersonId = ClsPerson.Find(NationalNu).PersonId;
            }
            else
                MessageBox.Show("This Person is Not Exist");

        }
        void LoadPersonInfo(int PersonId)
        {
            bool isExist = ClsPerson.isPersonExist(PersonId);
            if (isExist)
            {
                ctrlDetails1.LoadPerson(PersonId);
                SharePersonId = PersonId;
            }
            else
            {
                MessageBox.Show("This Person is Not Exist");
            }
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(cbFilterBy.Text == "National No"))
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

            }
        }

        private void gbFilters_Enter(object sender, EventArgs e)
        {

        }
    }
}
