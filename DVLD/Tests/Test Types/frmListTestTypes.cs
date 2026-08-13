using DVLD.ApplicationTypes;
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

namespace DVLD.Tests.Test_Types
{
    public partial class frmListTestTypes : Form
    {


        static DataTable _AllTestTypes = ClsTestTypes.GetAllTestTypes();

        DataTable TestTypesInfo = _AllTestTypes.DefaultView.ToTable(false, "TestTypeID", "TestTypeTitle", "TestTypeDescription", "TestTypeFees");

        public frmListTestTypes()
        {
            InitializeComponent();
        }


        void _LoadAllTestTypes()
        {
            _AllTestTypes = ClsTestTypes.GetAllTestTypes();
            TestTypesInfo = _AllTestTypes.DefaultView.ToTable(false, "TestTypeID", "TestTypeTitle", "TestTypeDescription" , "TestTypeFees");
            dgvTestTypes.DataSource = TestTypesInfo;
            lblRecordsCount.Text = dgvTestTypes.RowCount.ToString();
        }
        private void frmListTestTypes_Load(object sender, EventArgs e)
        {
            _LoadAllTestTypes();

            if (dgvTestTypes.Rows.Count > 0)
            {
                dgvTestTypes.Columns[0].HeaderText = "TestTypeID";
                dgvTestTypes.Columns[0].Width = 100;

                dgvTestTypes.Columns[1].HeaderText = "TestTypeTitle";
                dgvTestTypes.Columns[1].Width = 150;

                dgvTestTypes.Columns[2].HeaderText = "TestTypeDescription";
                dgvTestTypes.Columns[2].Width = 250;

                dgvTestTypes.Columns[3].HeaderText = "TestTypeFees";
                dgvTestTypes.Columns[3].Width = 100;
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(dgvTestTypes.CurrentRow.Cells[0].Value);
            frmEditTestType frm = new frmEditTestType(Id);
            frm.ShowDialog();
            _LoadAllTestTypes();
        }
    }
}
