using DVLD.Utils;
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
    public partial class frmEditApplicationType : Form
    {
        int _Id = -1;
        ClsApplicationTypes ApplicationTypes = null ;
        public frmEditApplicationType(int Id)
        {
            _Id = Id;
            InitializeComponent();
        }


        void _InitializeForm()
        {
            if ( ApplicationTypes != null)
            {
                lblApplicationTypeID.Text = ApplicationTypes.ApplicationTypeId.ToString();
                txtTitle.Text = ApplicationTypes.ApplicationTypeTitle.ToString();
                txtFees.Text = ApplicationTypes.Fees.ToString();
            }
            else
            {
                txtFees.Text = string.Empty;
                txtTitle.Text = string.Empty;
                lblApplicationTypeID.Text = "???";
            }
        }
        private void frmEditApplicationType_Load(object sender, EventArgs e)
        {
            ApplicationTypes = ClsApplicationTypes.GetApplicationInfoById(_Id);
            _InitializeForm();

        }
        private void validatetxtbox(object sender, CancelEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (string.IsNullOrEmpty(textBox.Text))
            {
                errorProvider1.SetError(textBox, "this cannot be empty!");
            }
            else
            {
                errorProvider1.SetError(textBox, null);
            }
        }

        bool validate()
        {
            if (!ClsValidation.ValidateNumberFloat(txtFees.Text))
            {
                errorProvider1.SetError(txtFees, "Invalid Number.");
                return false;
            }
            else
                errorProvider1.SetError(txtFees, null);


            if ( !(Convert.ToSingle(txtFees.Text.ToString()) > 0))
            {
                errorProvider1.SetError(txtFees, "You Have To Write Number Positif");
                return false;
            }
            else
                errorProvider1.SetError(txtFees, null);
            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(validate())
            {

                ApplicationTypes.Fees = Convert.ToSingle(txtFees.Text);
                ApplicationTypes.ApplicationTypeTitle = txtTitle.Text;

                if (ApplicationTypes.Save())
                {
                    MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                    MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        private void txtFees_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTitle_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
