using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_Buisness_Layer; 

namespace DVLD.Person
{
    public partial class AllPeopleList : Form
    {

        private static DataTable _DataAllPerson = ClsPerson.AllPeople();
        private DataTable _DataPerson = _DataAllPerson.DefaultView.ToTable(false, "personId", "NationalNo",
                                                       "FirstName", "SecondName", "ThirdName", "LastName",
                                                       "GendorCaption", "DateOfBirth", "CountryName",
                                                       "Phone", "Email");

        private  void _GetAllPeoples()
        {
            _DataAllPerson = ClsPerson.AllPeople();
            _DataPerson = _DataAllPerson.DefaultView.ToTable(false, "personId", "NationalNo",
                                                       "FirstName", "SecondName", "ThirdName", "LastName",
                                                       "GendorCaption", "DateOfBirth", "CountryName",
                                                       "Phone", "Email");

            DgvPeoples.DataSource = _DataPerson;
            lblCountRecords.Text = DgvPeoples.Rows.Count.ToString();
        }
        public AllPeopleList()
        {
            InitializeComponent();
            
        }

        private void AllPeopleList_Load(object sender, EventArgs e)
        {
            DgvPeoples.DataSource = _DataPerson;
            CmbFilterBy.SelectedIndex = 0;
            lblCountRecords.Text = DgvPeoples.Rows.Count.ToString();

            if (DgvPeoples.Rows.Count > 0 )
            {
                DgvPeoples.Columns[0].HeaderText = "Person ID";
                DgvPeoples.Columns[0].Width = 80;

                DgvPeoples.Columns[1].HeaderText = "National No";
                DgvPeoples.Columns[1].Width = 80;

                DgvPeoples.Columns[2].HeaderText = "First Name";
                DgvPeoples.Columns[2].Width = 100;

                DgvPeoples.Columns[3].HeaderText = "Second Name";
                DgvPeoples.Columns[3].Width = 100;

                DgvPeoples.Columns[4].HeaderText = "Third Name";
                DgvPeoples.Columns[4].Width = 100;

                DgvPeoples.Columns[5].HeaderText = "Last Name";
                DgvPeoples.Columns[5].Width = 100;

                DgvPeoples.Columns[6].HeaderText = "Gendor";
                DgvPeoples.Columns[6].Width = 60;

                DgvPeoples.Columns[7].HeaderText = "Date Of Birth";
                DgvPeoples.Columns[7].Width = 100;

                DgvPeoples.Columns[8].HeaderText = "Nationality";
                DgvPeoples.Columns[8].Width = 100;

                DgvPeoples.Columns[9].HeaderText = "Phone";
                DgvPeoples.Columns[9].Width = 100;

                DgvPeoples.Columns[10].HeaderText = "Email";
                DgvPeoples.Columns[10].Width = 120;
            }
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterBy = "";

            switch (CmbFilterBy.Text)
            {
                case "Person ID":
                    FilterBy = "personId";
                    break;
                case "National No":
                    FilterBy = "NationalNo";
                    break;
                case "First Name":
                    FilterBy = "FirstName";
                    break;

                case "Second Name":
                    FilterBy = "SecondName";
                    break;

                case "Third Name":
                    FilterBy = "ThirdName";
                    break;

                case "Last Name":
                    FilterBy = "LastName";
                    break;

                case "Nationality":
                    FilterBy = "CountryName";
                    break;

                case "Gendor":
                    FilterBy = "GendorCaption";
                    break;

                case "Phone":
                    FilterBy = "Phone";
                    break;

                case "Email":
                    FilterBy = "Email";
                    break;

                default:
                    FilterBy = "None";
                    break;
            }


            if (FilterBy == "None" || txtFilterValue.Text.Trim() == "")
            {
                _DataPerson.DefaultView.RowFilter = "";
                lblCountRecords.Text = DgvPeoples.Rows.Count.ToString();
                return;
            }

            if (FilterBy == "personId")
            {
                _DataPerson.DefaultView.RowFilter = string.Format("[{0}] = {1} ", FilterBy, txtFilterValue.Text.Trim());
            }
            else
                _DataPerson.DefaultView.RowFilter = string.Format("[{0}] like '{1}%'", FilterBy, txtFilterValue.Text.Trim());

            lblCountRecords.Text = DgvPeoples.Rows.Count.ToString();
        }

        private void CmbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Visible = (CmbFilterBy.Text != "None"); 
            if (txtFilterValue.Visible )
            {
                txtFilterValue.Text = "";
                txtFilterValue.Focus();
            }
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (CmbFilterBy.Text == "Person ID" || CmbFilterBy.Text == "Phone")
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar);
            }

        }

        private void _AddPerson()
        {
            Person.FormAddUpdatePerson formAddUpdate = new Person.FormAddUpdatePerson();
            formAddUpdate.ShowDialog();
        }

        private void _UpdatePerson()
        {
            int PersonID = Convert.ToInt32(DgvPeoples.CurrentRow.Cells[0].Value);
            Person.FormAddUpdatePerson formAddUpdate = new Person.FormAddUpdatePerson(PersonID);
            formAddUpdate.ShowDialog();
        }

        private void MenuAdd_Click(object sender, EventArgs e)
        {
            _AddPerson();
            _GetAllPeoples();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _UpdatePerson();
            _GetAllPeoples();
        }

        private void MenuDelete_Click(object sender, EventArgs e)
        {
            int PersonID = Convert.ToInt32(DgvPeoples.CurrentRow.Cells[0].Value);
            if (MessageBox.Show("Are you sure you want to Delete this Person with id = " + PersonID, "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                Person.FormAddUpdatePerson formAddUpdate = new Person.FormAddUpdatePerson(PersonID);
                bool isDeleted = formAddUpdate.DeletePerson(PersonID);
                if (isDeleted)
                {
                    MessageBox.Show("The person Deleted Susseccfully");
                    _GetAllPeoples();
                }
                else
                    MessageBox.Show("Delete Faild");
            }

        }

        private void MenuDetails_Click(object sender, EventArgs e)
        {
            int PersonID = Convert.ToInt32(DgvPeoples.CurrentRow.Cells[0].Value);
            DetailsPerson detailsPerson = new DetailsPerson(PersonID);
            detailsPerson.ShowDialog();
            _GetAllPeoples();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _AddPerson();
            _GetAllPeoples();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
