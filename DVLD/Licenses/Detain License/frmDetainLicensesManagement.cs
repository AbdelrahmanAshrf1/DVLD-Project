using DVLD.Applications.Release_Detain_License;
using DVLD.Licenses.Local_Licenses;
using DVLD_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Licenses.Detain_License
{
    public partial class frmDetainLicensesManagement : Form
    {
        private DataTable _dtDetainedLicenses;
        public frmDetainLicensesManagement()
        {
            InitializeComponent();
        }
        private void _LoadFormData()
        {
            cbFilteredBy.SelectedIndex = 0;
            txtFilterBy.Visible = false;
            cbIsActive.Visible = false;

            _dtDetainedLicenses = clsDetainedLicense.GetAllDetainedLicenses();
            dgvDetainedLicensesInfo.DataSource = _dtDetainedLicenses;
            lblRecordsNumber.Text = dgvDetainedLicensesInfo.Rows.Count.ToString();
        }
        private void frmDetainLicensesManagement_Load(object sender, EventArgs e)
        {
            _LoadFormData();
        }
        private void cbFilteredBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbFilteredBy.Text == "Is Released")
            {
                txtFilterBy.Visible = false;
                cbIsActive.Visible = true;
                cbIsActive.SelectedIndex = 0;
                cbIsActive.Focus();
            }
            else
            {
                txtFilterBy.Visible = (cbFilteredBy.Text != "None");
                cbIsActive.Visible = false;
                txtFilterBy.Text = "";
                txtFilterBy.Focus();
            }
        }

        private void txtFilterBy_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";

            switch(cbFilteredBy.Text)
            {
                case "Detain ID":
                    FilterColumn = "DetainID";
                    break;

                case "National No":
                    FilterColumn = "NationalNo";
                    break;

                case "Full Name":
                    FilterColumn = "FullName";
                    break;

                case "Release Application ID":
                    FilterColumn = "ReleaseApplicationID";
                    break;
            }

            if (txtFilterBy.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtDetainedLicenses.DefaultView.RowFilter = "";
                lblRecordsNumber.Text = dgvDetainedLicensesInfo.Rows.Count.ToString();
                return;
            }

            if (FilterColumn == "DetainID" || FilterColumn == "ReleaseApplicationID")
                _dtDetainedLicenses.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterBy.Text.Trim());
            else
                _dtDetainedLicenses.DefaultView.RowFilter = string.Format("[{0}] Like '{1}%'", FilterColumn, txtFilterBy.Text.Trim());
            lblRecordsNumber.Text = dgvDetainedLicensesInfo.Rows.Count.ToString();
        }
        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumn = "IsReleased";
            string FilterValue = cbIsActive.Text;
            switch (FilterValue)
            {
                case "All":
                    break;

                case "Yes":
                    FilterValue = "1";
                    break;

                case "No":
                    FilterValue = "0";
                    break;
            }

            if (FilterValue == "All")
                _dtDetainedLicenses.DefaultView.RowFilter = "";
            else
                _dtDetainedLicenses.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, FilterValue);

            lblRecordsNumber.Text = _dtDetainedLicenses.DefaultView.Count.ToString();
        }
        private void txtFilterBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(txtFilterBy.Text == "Detain ID" || txtFilterBy.Text == "Release Application ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void btnDetainLicense_Click(object sender, EventArgs e)
        {
            frmDetainLicenseApplication frm = new frmDetainLicenseApplication();
            frm.ShowDialog();
        }
        private void btnReleaseLicense_Click(object sender, EventArgs e)
        {
            frmReleaseDetainLicenseApplication frm = new frmReleaseDetainLicenseApplication();
            frm.ShowDialog();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void cmsDetainedLicenses_Opening(object sender, CancelEventArgs e)
        {
            cmsReleaseDetainedLicense.Enabled = !(bool)dgvDetainedLicensesInfo.CurrentRow.Cells[3].Value;
        }
        private void cmsShowPersonDetailsItem_Click(object sender, EventArgs e)
        {
            int LicenseID = (int)dgvDetainedLicensesInfo.CurrentRow.Cells[1].Value;
            int PersonID = clsLicense.Find(LicenseID).DriverInfo.PersonID;

            FrmShowPersonInfo frm = new FrmShowPersonInfo(PersonID);
            frm.ShowDialog();
            _LoadFormData(); // refresh
        }
        private void cmsShowLicenseDetailsItem_Click(object sender, EventArgs e)
        {
            int LicenseID = (int)dgvDetainedLicensesInfo.CurrentRow.Cells[1].Value;
            frmShowLicenseInfo frm = new frmShowLicenseInfo(LicenseID);
            frm.ShowDialog();
            _LoadFormData(); // refresh
        }
        private void cmsShowPersonLicenseHistoryItem_Click(object sender, EventArgs e)
        {
            int LicenseID = (int)dgvDetainedLicensesInfo.CurrentRow.Cells[1].Value;
            int PersonID = clsLicense.Find(LicenseID).DriverInfo.PersonID;

            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(PersonID);
            frm.ShowDialog();
            _LoadFormData(); // refresh
        }
    }
}
