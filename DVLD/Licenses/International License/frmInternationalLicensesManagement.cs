using DVLD.Applications.International_License;
using DVLD_Business;
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

namespace DVLD.Licenses.International_License
{
    public partial class frmInternationalLicensesManagement : Form
    {
        private DataTable _dtAllInternationalLicenses;
        public frmInternationalLicensesManagement()
        {
            InitializeComponent();
        }
        private void _LoadData()
        {
            _dtAllInternationalLicenses = clsInternationalLicense.GetAllInternationalLicenses();
            dgvInternationalLicensesInfo.DataSource = _dtAllInternationalLicenses;
            lblRecordsNumber.Text = dgvInternationalLicensesInfo.Rows.Count.ToString();

            txtFilterBy.Visible = false;
            cbIsActive.Visible = false;

            if (dgvInternationalLicensesInfo.Rows.Count > 0)
            {
                dgvInternationalLicensesInfo.Columns[0].HeaderText = "Int.License ID";
                dgvInternationalLicensesInfo.Columns[1].HeaderText = "Application ID";
                dgvInternationalLicensesInfo.Columns[2].HeaderText = "Driver ID";
                dgvInternationalLicensesInfo.Columns[3].HeaderText = "L.License ID";
                dgvInternationalLicensesInfo.Columns[4].HeaderText = "Issue Date";
                dgvInternationalLicensesInfo.Columns[5].HeaderText = "Expiration Date";
                dgvInternationalLicensesInfo.Columns[6].HeaderText = "Is Active";
            }
        }
        private void frmInternationalLicensesManagement_Load(object sender, EventArgs e)
        {
            _LoadData();
        }
        private void cbFilteredBy_SelectedIndexChanged(object sender, EventArgs e)
        {

           if(cbFilteredBy.Text == "Is Active")
           {
                txtFilterBy.Visible = false;
                cbIsActive.Visible = true;
                cbIsActive.Focus();
                cbIsActive.SelectedIndex = 0;
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
            
            switch (cbFilteredBy.Text)
            {
                case "Int.License ID":
                    FilterColumn = "InternationalLicenseID";
                    break;
                case "Application ID":
                    FilterColumn = "ApplicationID";
                    break;
                    
                case "Driver ID":
                    FilterColumn = "DriverID";
                    break;

                case "L.License ID":
                    FilterColumn = "IssuedUsingLocalLicenseID";
                    break;

                case "Is Active":
                    FilterColumn = "IsActive";
                    break;

                default:
                    FilterColumn = "None";
                    break;
            }

            if (txtFilterBy.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtAllInternationalLicenses.DefaultView.RowFilter = "";
                lblRecordsNumber.Text = dgvInternationalLicensesInfo.Rows.Count.ToString();
                return;
            }

            _dtAllInternationalLicenses.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterBy.Text.Trim());
            lblRecordsNumber.Text = _dtAllInternationalLicenses.Rows.Count.ToString();
        }
        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumn = "IsActive";
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
                _dtAllInternationalLicenses.DefaultView.RowFilter = "";
            else
                _dtAllInternationalLicenses.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, FilterValue);
                lblRecordsNumber.Text = _dtAllInternationalLicenses.Rows.Count.ToString();
        }
        private void txtFilterBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnAddNewInternationalLicense_Click(object sender, EventArgs e)
        {
            frmAddNewInternationalLicenseApplication frm = new frmAddNewInternationalLicenseApplication();
            frm.ShowDialog();
            _LoadData(); // refresh
        }
        private void cmsShowPersonDetailsItem_Click(object sender, EventArgs e)
        {
            int DriverID = (int)dgvInternationalLicensesInfo.CurrentRow.Cells[2].Value;
            int PersonID = clsDriver.FindByDriverID(DriverID).PersonID;
            FrmShowPersonInfo frm = new FrmShowPersonInfo(PersonID);
            frm.ShowDialog();
            _LoadData(); // refresh
        }
        private void cmsShowLicenseDetails_Click(object sender, EventArgs e)
        {
            int InternationalLicenseID = (int)dgvInternationalLicensesInfo.CurrentRow.Cells[0].Value;
            frmShowInternationalLicenseInfo frm = new frmShowInternationalLicenseInfo(InternationalLicenseID);
            frm.ShowDialog();
        }
        private void editToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int DriverID = (int)dgvInternationalLicensesInfo.CurrentRow.Cells[2].Value;
            int PersonID = clsDriver.FindByDriverID(DriverID).PersonID;
            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(PersonID);
            frm.ShowDialog();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
