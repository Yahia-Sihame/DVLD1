using DVLD.Users;
using DVLD_Buisness_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace DVLD.Peoples.Users
{
    public partial class AllUsersList : Form
    {

        static DataTable _AllUsersInfo = ClsUser.GetAllUsers();

        DataTable UserInfo = _AllUsersInfo.DefaultView.ToTable(false, "UserID", "PersonId" , "FullName" , "UserName", "IsActive");
        public AllUsersList()
        {
            InitializeComponent();
        }
        void _LoadAllUsers()
        {
            _AllUsersInfo = ClsUser.GetAllUsers();
            UserInfo = _AllUsersInfo.DefaultView.ToTable(false, "UserID","PersonId", "FullName", "UserName", "IsActive");
            dgvUsers.DataSource = UserInfo;
            lblCountRecords.Text = dgvUsers.RowCount.ToString();
            CmbFilterBy.SelectedIndex = 0;
        }
        private void AllUsersList_Load(object sender, EventArgs e)
        {
            _LoadAllUsers();

            if (dgvUsers.Rows.Count > 0 )
            {
                dgvUsers.Columns[0].HeaderText = "User ID";
                dgvUsers.Columns[0].Width = 160;

                dgvUsers.Columns[1].HeaderText = "Person ID";
                dgvUsers.Columns[1].Width = 160;

                dgvUsers.Columns[2].HeaderText = "Full Name";
                dgvUsers.Columns[2].Width = 290;

                dgvUsers.Columns[3].HeaderText = "User Name";
                dgvUsers.Columns[3].Width = 180;

                dgvUsers.Columns[4].HeaderText = "Is Active";
                dgvUsers.Columns[4].Width = 135;
            }
            
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterBy = string.Empty;
            string FilterText = txtFilterValue.Text.Trim();

           switch(CmbFilterBy.Text)
           {
                case "Person ID" : 
                    FilterBy = "PersonId"; 
                    break;
                case "User ID":
                    FilterBy = "UserId"; 
                    break;
                case "Full Name":
                    FilterBy = "FullName";
                    break;
                case "User Name":
                    FilterBy = "UserName";
                    break;
                default :
                    FilterBy = "None";
                    break;
            }
            if (FilterBy == "None" || txtFilterValue.Text.Trim() == "")
            {
                UserInfo.DefaultView.RowFilter = "";
                lblCountRecords.Text = dgvUsers.Rows.Count.ToString();
                return;
            }

            if (FilterBy == "PersonId" || FilterBy == "UserId")
            {
                UserInfo.DefaultView.RowFilter = string.Format("[{0}] = {1} ", FilterBy, txtFilterValue.Text.Trim());
            }
            else
            {
                UserInfo.DefaultView.RowFilter = string.Format("[{0}] like '{1}%'", FilterBy, txtFilterValue.Text.Trim());
            }

            lblCountRecords.Text = UserInfo.Rows.Count.ToString(); 
        }

        private void CmbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbFilterBy.Text == "Is Active")
            {
                txtFilterValue.Visible = false;
                cmbisactive.Visible = true;
                cmbisactive.SelectedIndex = 0;
            }
            else
            {
                txtFilterValue.Visible = (CmbFilterBy.Text != "None");
                cmbisactive.Visible= false;
                if (txtFilterValue.Visible)
                {
                    txtFilterValue.Text = "";
                    txtFilterValue.Focus();
                }
            }
            
        }

        private void cmbisactive_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbisactive.Text == "All")
            {
                UserInfo.DefaultView.RowFilter = "";
            } 
            else if (cmbisactive.Text == "Yes")
            {
                UserInfo.DefaultView.RowFilter = string.Format("[{0}] = {1} ", "IsActive", 1);
            }
            else 
            {
                UserInfo.DefaultView.RowFilter = string.Format("[{0}] = {1} ", "IsActive", 0);
            }
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (CmbFilterBy.Text == "Person ID" || CmbFilterBy.Text == "User ID")
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            FormAddUpdateUser formAddUpdateUser = new FormAddUpdateUser();
            formAddUpdateUser.ShowDialog();
            _LoadAllUsers();
        }


        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserId = Convert.ToInt32(dgvUsers.CurrentRow.Cells[0].Value);
            Form1 form1 = new Form1(UserId);
            form1.ShowDialog();
            _LoadAllUsers();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormAddUpdateUser formAddUpdateUser = new FormAddUpdateUser();
            formAddUpdateUser.ShowDialog();
            _LoadAllUsers();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserId = Convert.ToInt32(dgvUsers.CurrentRow.Cells[0].Value);
            FormAddUpdateUser formAddUpdateUser = new FormAddUpdateUser(UserId);
            formAddUpdateUser.ShowDialog();
            _LoadAllUsers();
        }
    }
}
