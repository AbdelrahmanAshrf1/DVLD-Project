using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_BusinessLayer;

namespace DVLD
{
    public partial class FrmUpdateApplicationTypes : Form
    {
        private int _ApplicationID;
        private clsApplicationTypes _ApplicationType = new clsApplicationTypes();
        public FrmUpdateApplicationTypes(int ApplicationID)
        {
            InitializeComponent();
            _ApplicationID = ApplicationID;
        }
        private void txtTitle_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                errorProvider.SetError(txtTitle, "Please enter a title for the Application");
                return;
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(txtTitle, "");
            }
        }
        private void txtFees_Validating(object sender, CancelEventArgs e)
        {
            string input = txtFees.Text.Trim();

            if (string.IsNullOrWhiteSpace(input))
            {
                e.Cancel = true;
                errorProvider.SetError(txtFees, "Please enter the Fees for the Application");
                return;
            }

            if (!decimal.TryParse(input, out decimal fees))
            {
                e.Cancel = true;
                errorProvider.SetError(txtFees, "Please enter a valid number (e.g. 100.00)");
                return;
            }

            if (fees < 0)
            {
                e.Cancel = true;
                errorProvider.SetError(txtFees, "Fees must be a positive value");
                return;
            }

            e.Cancel = false;
            errorProvider.SetError(txtFees, "");
        }
        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void _CollectApplicationTypeInfo()
        {
            _ApplicationType.ID = Convert.ToInt32(lblID.Text);
            _ApplicationType.Title = txtTitle.Text;
            _ApplicationType.Fees = Convert.ToSingle(txtFees.Text);
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if(ValidateChildren())
            {
                _CollectApplicationTypeInfo();


                if (_ApplicationType.Save())
                {
                    MessageBox.Show("Data saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                else
                {
                    MessageBox.Show("Error: Data was not saved successfully!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void _PopulateApplicationTypeInfo()
        {
            lblID.Text = _ApplicationType.ID.ToString();
            txtTitle.Text = _ApplicationType.Title;
            txtFees.Text = _ApplicationType.Fees.ToString();
        }
        private void FrmUpdateApplicationTypes_Load(object sender, EventArgs e)
        {
            _ApplicationType = clsApplicationTypes.Find(_ApplicationID);
            _PopulateApplicationTypeInfo();
        }
    }
}
