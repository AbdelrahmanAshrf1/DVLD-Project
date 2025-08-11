using DVLD.Classes;
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

namespace DVLD.Applications.Replace_Lost_or_Damage_License
{
    public partial class frmReplaceLostOrDamagedLicense : Form
    {
        private int _NewLicenseID = -1;
        public frmReplaceLostOrDamagedLicense()
        {
            InitializeComponent();
        }
        private int _GetApplicationTypeID()
        {
            return rbDamagedLicense.Checked ? (int)clsApplication.enApplicationType.ReplaceDamagedDrivingLicense
                : (int)clsApplication.enApplicationType.ReplaceLostDrivingLicense;
        }
        private clsLicense.enIssueReason _GetIssueReason()
        {
            return rbDamagedLicense.Checked ? clsLicense.enIssueReason.DamagedReplacement : clsLicense.enIssueReason.LostReplacement;
        }
        private void frmReplaceLostOrDamagedLicense_Load(object sender, EventArgs e)
        {
            btnReplace.Enabled = false;
            rbDamagedLicense.Checked = true;
            lblCreatedBy.Text = Global.CurrentUser.Username;
            lblApplicationDate.Text = DateTime.Now.ToShortDateString();
            llblShowNewLicenseInfo.Enabled = false;
            llblShowLicensesHistory.Enabled = false;
            lblApplicationFees.Text = clsApplicationTypes.Find(_GetApplicationTypeID()).Fees.ToString();
        }

        private void ctrlLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {
            int SelectedLicenseID = obj;
            lblOldLicenseID.Text = SelectedLicenseID.ToString();
            llblShowLicensesHistory.Enabled = SelectedLicenseID != -1;
            if (SelectedLicenseID == -1) return;

            if(!ctrlLicenseInfoWithFilter1.SelectedLicenseInfo.IsActive)
            {
                MessageBox.Show("Selected License is not Not Active, choose an active license.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnReplace.Enabled = false;
                return;
            }

            btnReplace.Enabled = true;
        }
        private void rbLostLicense_CheckedChanged(object sender, EventArgs e)
        {
            lblApplicationFees.Text = clsApplicationTypes.Find(_GetApplicationTypeID()).Fees.ToString();
        }
        private void rbDamagedLicense_CheckedChanged(object sender, EventArgs e)
        {
            lblApplicationFees.Text = clsApplicationTypes.Find(_GetApplicationTypeID()).Fees.ToString();
        }
        private void llblShowNewLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseInfo frm = new frmShowLicenseInfo(_NewLicenseID);
            frm.ShowDialog();
        }
        private void _LoadNewLicenseData(clsLicense NewLicense)
        {
            _NewLicenseID = NewLicense.LicenseID;
            lblApplicationID.Text = NewLicense.ApplicationID.ToString();
            lblReplacedLicenseID.Text = NewLicense.LicenseID.ToString();

            ctrlLicenseInfoWithFilter1.FilterEnabled = false;
            llblShowNewLicenseInfo.Enabled = true;
            rbDamagedLicense.Enabled = false;
            rbLostLicense.Enabled = false;
            btnReplace.Enabled = false;
        }
        private void btnReplace_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Issue a Replacement for the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

            clsLicense NewLicense = ctrlLicenseInfoWithFilter1.SelectedLicenseInfo.Replace(_GetIssueReason(), Global.CurrentUser.ID);

            if(NewLicense == null)
            {
                MessageBox.Show("Faild to Issue a replacemnet for this  License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _LoadNewLicenseData(NewLicense);

            MessageBox.Show("Licensed Replaced Successfully with ID=" + _NewLicenseID.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
