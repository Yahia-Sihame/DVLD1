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

namespace DVLD.ApplicationTypes
{
    public partial class frmListApplicationTypes : Form
    {
        static DataTable _AllApplicationTypes = ClsApplicationTypes.GetAllApplicationTypes();

        DataTable ApplicationTypesInfo = _AllApplicationTypes.DefaultView.ToTable(false, "ApplicationTypeId", "ApplicationTypeTitle", "ApplicationFees");
        public frmListApplicationTypes()
        {
            InitializeComponent();
        }

        void _LoadAllApplicationTypes()
        {
            _AllApplicationTypes = ClsApplicationTypes.GetAllApplicationTypes();
            ApplicationTypesInfo = _AllApplicationTypes.DefaultView.ToTable(false, "ApplicationTypeId", "ApplicationTypeTitle", "ApplicationFees");
            dgvApplicationTypes.DataSource = ApplicationTypesInfo;
            lblRecordsCount.Text = dgvApplicationTypes.RowCount.ToString();
        }
        private void ListApplicationTypes_Load(object sender, EventArgs e)
        {
            _LoadAllApplicationTypes();

            if (dgvApplicationTypes.Rows.Count > 0)
            {
                dgvApplicationTypes.Columns[0].HeaderText = "ApplicationTypeId";
                dgvApplicationTypes.Columns[0].Width = 100;

                dgvApplicationTypes.Columns[1].HeaderText = "ApplicationTypeTitle";
                dgvApplicationTypes.Columns[1].Width = 250;

                dgvApplicationTypes.Columns[2].HeaderText = "ApplicationFees";
                dgvApplicationTypes.Columns[2].Width = 150;

            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(dgvApplicationTypes.CurrentRow.Cells[0].Value);
            frmEditApplicationType frm = new frmEditApplicationType(Id);
            frm.ShowDialog();
            _LoadAllApplicationTypes();
        }
    }
}
