using DVLD.Classes;
using DVLD.Licenses;
using DVLD.Licenses.International_License;
using DVLD_Buisness;
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

namespace DVLD.Applications.International_License
{
    public partial class frmAddNewInternationalLicenseApplication : Form
    {
        private int _InternaionalLicenseID = -1;
        public frmAddNewInternationalLicenseApplication()
        {
            InitializeComponent();
        }
        private void frmAddNewInternationalLicenseApplication_Load(object sender, EventArgs e)
        {
            lblApplicationDate.Text = DateTime.Now.ToShortDateString();
            lblIssueDate.Text = lblApplicationDate.Text;
            lblFees.Text = clsApplicationTypes.Find((int)clsApplication.enApplicationType.NewInternationalLicense).Fees.ToString();
            lblExpirationDate.Text = DateTime.Now.AddYears(1).ToShortDateString();
            lblCreatedBy.Text = Global.CurrentUser.Username;
            llblShowLicenseInfo.Enabled = false;
            llblShowLicensesHistory.Enabled = false;
            btnIssueLicense.Enabled = false;
        }
        private void ctrlLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {
            int SelectedLicenseID = obj;

            lblLocalLicenseID.Text = SelectedLicenseID.ToString();
            llblShowLicensesHistory.Enabled = SelectedLicenseID != -1;
            if (SelectedLicenseID == -1) return;

            if(ctrlLicenseInfoWithFilter1.SelectedLicenseInfo.LicenseClassInfo.ClassID != 3)
            {
                MessageBox.Show("Selected License should be Class 3, select another one.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int DriverID = ctrlLicenseInfoWithFilter1.SelectedLicenseInfo.DriverID;
            int ActiveInternaionalLicenseID = clsInternationalLicense.GetActiveInternationalLicenseIDByDriverID(DriverID);

            if(ActiveInternaionalLicenseID != -1)
            {
                MessageBox.Show("Person already have an active international license with ID = " + ActiveInternaionalLicenseID.ToString(), "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                llblShowLicenseInfo.Enabled = true;
                btnIssueLicense.Enabled = false;
                lblInternationalLicenseID.Text = ActiveInternaionalLicenseID.ToString();
                _InternaionalLicenseID = ActiveInternaionalLicenseID;
            }

            btnIssueLicense.Enabled = true;
        }

        private void btnIssueLicense_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to issue the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

            clsInternationalLicense Application = new clsInternationalLicense();

            Application.DriverID = ctrlLicenseInfoWithFilter1.SelectedLicenseInfo.DriverID;
            Application.IssuedUsingLocalLicenseID = ctrlLicenseInfoWithFilter1.SelectedLicenseInfo.LicenseID;
            Application.IssueDate = DateTime.Now;
            Application.ExpirationDate = DateTime.Now.AddYears(1);
            Application.IsActive = true;
            Application.CreatedByUserID = Global.CurrentUser.ID;

            // Add Base Application Record 
            Application.ApplicationInfo.Status = clsApplication.enApplicationStatus.Completed;
            Application.ApplicationInfo.ApplicantPersonID = ctrlLicenseInfoWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID;
            Application.ApplicationInfo.Date = DateTime.Now;
            Application.ApplicationInfo.LastStatusDate = DateTime.Now;
            Application.ApplicationInfo.PaidFees = clsApplicationTypes.Find((int)clsApplication.enApplicationType.NewInternationalLicense).Fees;
            Application.ApplicationInfo.CreatedByUserID = Global.CurrentUser.ID;

            if(!Application.Save())
            {
                MessageBox.Show("Faild to Issue International License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _InternaionalLicenseID = Application.InternationalLicenseID;
            lblApplicationID.Text = Application.ApplicationInfo.ApplicationID.ToString();
            lblInternationalLicenseID.Text = Application.InternationalLicenseID.ToString();

            MessageBox.Show("International License Issued Successfully with ID=" + _InternaionalLicenseID.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnIssueLicense.Enabled = false;
            llblShowLicenseInfo.Enabled = true;
            ctrlLicenseInfoWithFilter1.FilterEnabled = false;
        }
        private void llblShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowInternationalLicenseInfo frm = new frmShowInternationalLicenseInfo(_InternaionalLicenseID);
            frm.ShowDialog();
        }
        private void llblShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int PersonID = ctrlLicenseInfoWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID;
            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(PersonID);
            frm.ShowDialog();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
