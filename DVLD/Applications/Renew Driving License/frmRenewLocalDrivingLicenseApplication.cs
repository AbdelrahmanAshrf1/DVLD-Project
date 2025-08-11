using DVLD.Classes;
using DVLD.Licenses;
using DVLD.Licenses.Local_Licenses;
using DVLD_Buisness;
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

namespace DVLD.Applications.Renew_Driving_License
{
    public partial class frmRenewLocalDrivingLicenseApplication : Form
    {
        private int _LicenseID = -1;
        public frmRenewLocalDrivingLicenseApplication()
        {
            InitializeComponent();
        }
        private void _LoadFormData()
        {
            ctrlLicenseInfoWithFilter1.TxtLicenseIDFoucs();
            lblApplicationDate.Text = DateTime.Now.ToShortDateString();
            lblIssueDate.Text = DateTime.Now.ToShortDateString();
            lblApplicationFees.Text = clsApplicationTypes.Find((int)clsApplication.enApplicationType.RenewDrivingLicense).Fees.ToString();
            lblCreatedBy.Text = Global.CurrentUser.Username;
            llblShowNewLicenseInfo.Enabled = false;
            llblShowLicensesHistory.Enabled = false;
            btnRenew.Enabled = false;
        }
        private void frmRenewLocalDrivingLicenseApplication_Load(object sender, EventArgs e)
        {
            _LoadFormData();
        }
        private void _LoadOldLicenseInfo(int LicenseID)
        {
            lblOldLicenseID.Text = LicenseID.ToString();
            llblShowLicensesHistory.Enabled = LicenseID != -1;
            lblLicenseFees.Text = ctrlLicenseInfoWithFilter1.SelectedLicenseInfo.LicenseClassInfo.ClassFees.ToString();
            lblTotalFees.Text = (Convert.ToSingle(lblApplicationFees.Text) + Convert.ToSingle(lblLicenseFees.Text)).ToString();
            int DefaultValidityLength = ctrlLicenseInfoWithFilter1.SelectedLicenseInfo.LicenseClassInfo.DefaultValidityLength;
            lblExpirationDate.Text = DateTime.Now.AddYears(DefaultValidityLength).ToShortDateString();
            txtNotes.Text = ctrlLicenseInfoWithFilter1.SelectedLicenseInfo.Notes;
        }
        private void ctrlLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {
            int SelectedLicenseID = obj;
            if (SelectedLicenseID == -1) return;

            _LoadOldLicenseInfo(SelectedLicenseID);

            if (!ctrlLicenseInfoWithFilter1.SelectedLicenseInfo.IsLicenseExpired())
            {
                MessageBox.Show("Selected License is not yet expiared, it will expire on: " + ctrlLicenseInfoWithFilter1.SelectedLicenseInfo.ExpirationDate.ToShortDateString(), "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnRenew.Enabled = false;
                return;
            }

            if (!ctrlLicenseInfoWithFilter1.SelectedLicenseInfo.IsActive)
            {
                MessageBox.Show("Selected License is not Not Active, choose an active license.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnRenew.Enabled = false;
                return;
            }

            btnRenew.Enabled = true;
        }
        private void _LoadNewLicenseInfo(clsLicense NewLicense)
        {
            _LicenseID = NewLicense.LicenseID;
            lblApplicationID.Text = NewLicense.ApplicationID.ToString();
            lblRenewLicenseID.Text = NewLicense.LicenseID.ToString();
            btnRenew.Enabled = false;
            llblShowNewLicenseInfo.Enabled = true;
            llblShowLicensesHistory.Enabled = true;
            ctrlLicenseInfoWithFilter1.FilterEnabled = false;
        }
        private void btnRenew_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Renew the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

            string Notes = txtNotes.Text.Trim();
            clsLicense newLicense = ctrlLicenseInfoWithFilter1.SelectedLicenseInfo.RenewLicense(Notes,Global.CurrentUser.ID);

            if (newLicense == null)
            {
                MessageBox.Show("Faild to Renew the License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _LoadNewLicenseInfo(newLicense);
            MessageBox.Show("Licensed Renewed Successfully with ID=" + newLicense.LicenseID.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void llblShowNewLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseInfo frm = new frmShowLicenseInfo(_LicenseID);
            frm.ShowDialog();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void llblShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int PersonID = ctrlLicenseInfoWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID;
            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(PersonID);
            frm.ShowDialog();
        }
    }
}
