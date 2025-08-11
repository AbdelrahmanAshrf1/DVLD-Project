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

namespace DVLD.Applications.Release_Detain_License
{
    public partial class frmReleaseDetainLicenseApplication : Form
    {
        private int _SelectedLicenseID = -1;
        public frmReleaseDetainLicenseApplication()
        {
            InitializeComponent();
            llblShowLicensesHistory.Enabled = false;
            llblShowLicenseInfo.Enabled = false;
            btnRelease.Enabled = false;
        }
        public frmReleaseDetainLicenseApplication(int LicenseID)
        {
            InitializeComponent();

            _SelectedLicenseID = LicenseID;
            ctrlLicenseInfoWithFilter1.FilterEnabled = false;
            ctrlLicenseInfoWithFilter1.LoadLicenseInfo(_SelectedLicenseID);
        }
        private void ctrlLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {
            _SelectedLicenseID = obj;
            llblShowLicensesHistory.Enabled = _SelectedLicenseID != -1;

            if (_SelectedLicenseID == -1) return;

            if(!ctrlLicenseInfoWithFilter1.SelectedLicenseInfo.IsDetained)
            {
                MessageBox.Show("Selected License is not detained, choose another one.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblDetainID.Text = ctrlLicenseInfoWithFilter1.SelectedLicenseInfo.DetainedLicenseInfo.DetainID.ToString();
            lblDetainDate.Text = ctrlLicenseInfoWithFilter1.SelectedLicenseInfo.DetainedLicenseInfo.DetainDate.ToShortDateString();
            lblApplicationFees.Text = clsApplicationTypes.Find((int)clsApplication.enApplicationType.ReleaseDetainedDrivingLicsense).Fees.ToString();
            lblFineFees.Text = ctrlLicenseInfoWithFilter1.SelectedLicenseInfo.DetainedLicenseInfo.FineFees.ToString();
            lblTotalFees.Text = (Convert.ToSingle(lblApplicationFees.Text) + Convert.ToSingle(lblFineFees.Text)).ToString();
            lblLicenseID.Text = _SelectedLicenseID.ToString();
            lblCreatedBy.Text = Global.CurrentUser.Username;

            btnRelease.Enabled = true;
        }
        private void btnRelease_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to release this detained  license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)return;

            int ApplicationID = -1;
            bool IsReleased = ctrlLicenseInfoWithFilter1.SelectedLicenseInfo.ReleaseDetainedLicense(Global.CurrentUser.ID, ref ApplicationID);

            if (!IsReleased)
            {
                MessageBox.Show("Faild to to release the Detain License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            } 

            lblApplicationID.Text = ApplicationID.ToString();
            btnRelease.Enabled = false;
            ctrlLicenseInfoWithFilter1.FilterEnabled = false;
            llblShowLicenseInfo.Enabled = true;
    
            MessageBox.Show("Detained License released Successfully ", "Detained License Released", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void llblShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseInfo frm = new frmShowLicenseInfo(_SelectedLicenseID);
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
