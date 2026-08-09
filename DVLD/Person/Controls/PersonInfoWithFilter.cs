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
        private int _PersonId = -1;
        public string NationalNu = string.Empty;


        public string TextFilterValue
        {
            get { return txtFilterValue.Text; }
            set { txtFilterValue.Text = value; }
        }
        public int PersonId
        {
            get {  return _PersonId; } 
        }
        public bool ShowBtnAdd
        {
            get { return btnAddPerson.Enabled; }
            set { btnAddPerson.Enabled = value; }
        }
        public bool EnableGbFilter
        {
            get { return gbFilters.Enabled; }
            set { gbFilters.Enabled = value; }
        }
        public int CbFilterby
        {
            get
            {
                return cbFilterBy.SelectedIndex;
            }

            set { cbFilterBy.SelectedIndex = value; }
        }
        public PersonInfoWithFilter()
        {
            InitializeComponent();
        }
        private void btnFind_Click(object sender, EventArgs e)
        {
            LoadPerson();
                
        }
        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            FormAddUpdatePerson frm = new FormAddUpdatePerson();
            frm.SendIdBack += UseNewPerson;
            frm.ShowDialog();
        }

        void UseNewPerson(object sender , int PersonId)
        {
            txtFilterValue.Text = PersonId.ToString();
            cbFilterBy.SelectedIndex = 1;
            gbFilters.Enabled = false;
            LoadPerson();
        }        
        public void LoadPerson()
        {
            if (string.IsNullOrEmpty(txtFilterValue.Text))
            {
                txtFilterValue.Focus();
                errorProvider1.SetError(txtFilterValue, "You have To Write value !");
            }
            else
            {
                errorProvider1.SetError(txtFilterValue, null);
                if (cbFilterBy.Text == "National No")
                {
                    NationalNu = txtFilterValue.Text.Trim();
                    LoadPersonInfo(NationalNu);
                }
                else
                {
                    _PersonId = Convert.ToInt32(txtFilterValue.Text);
                    LoadPersonInfo(PersonId);
                }
            }
        }
        void LoadPersonInfo(string NationalNu)
        { 
            bool isExist = ClsPerson.isPersonExist(NationalNu); 
            if (isExist)
            {
                ctrlDetails1.LoadPerson(ClsPerson.Find(NationalNu).PersonId);
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
        private void PersonInfoWithFilter_Load(object sender, EventArgs e)
        {

        }
    }
}
