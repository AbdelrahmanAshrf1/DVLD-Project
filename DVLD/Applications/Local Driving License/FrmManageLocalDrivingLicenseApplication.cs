using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD.Applications.Local_Driving_License;
using DVLD.Licenses;
using DVLD.Licenses.Local_Licenses;
using DVLD.Tests;
using DVLD_Buisness;
using DVLD_BusinessLayer;

namespace DVLD
{
    public partial class FrmManageLocalDrivingLicenseApplication : Form
    {
        private DataTable _dtAllLocalDrivingLicenseApplications;
        public FrmManageLocalDrivingLicenseApplication()
        {
            InitializeComponent();
        }
        private void _LoadLocalDrivingLicenseApplicationsList()
        {
            _dtAllLocalDrivingLicenseApplications = clsLocalDrivingLicenseApplication.GetAllLocalDrivingLicenseApplications();
            dgvLocalDrivingLicenseApplications.DataSource = _dtAllLocalDrivingLicenseApplications;
            lblRecordsNumber.Text = dgvLocalDrivingLicenseApplications.Rows.Count.ToString();

            if(dgvLocalDrivingLicenseApplications.Rows.Count > 0 )
            {
                dgvLocalDrivingLicenseApplications.Columns[0].HeaderText = "L.D.L.AppID";
                dgvLocalDrivingLicenseApplications.Columns[1].HeaderText = "Driving Class";
                dgvLocalDrivingLicenseApplications.Columns[2].HeaderText = "National No.";
                dgvLocalDrivingLicenseApplications.Columns[3].HeaderText = "Full Name";
                dgvLocalDrivingLicenseApplications.Columns[4].HeaderText = "Application Date";
                dgvLocalDrivingLicenseApplications.Columns[5].HeaderText = "Passed Tests";
            }

            cbFilteredBy.SelectedIndex = 0;
            txtFilterValue.Visible = false;
        }
        private void FrmManageLDLA_Load(object sender, EventArgs e)
        {
            _LoadLocalDrivingLicenseApplicationsList();
        }
        private void btnCancel_Click(object sender, EventArgs e) => this.Close();
        private void cbFilteredBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Visible = (cbFilteredBy.Text != "None");
        }
        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";

            switch(cbFilteredBy.Text)
            {
                case "L.D.L.ID":
                    FilterColumn = "LocalDrivingLicenseApplicationID";
                    break;

                case "National No":
                    FilterColumn = "NationalNo";
                    break;

                case "Full Name":
                    FilterColumn = "FullName";
                    break;

                case "Status":
                    FilterColumn = "Status";
                    break;
            }

            if(txtFilterValue.Text.Trim() == "" || txtFilterValue.Text.Trim() == "")
            {
                _dtAllLocalDrivingLicenseApplications.DefaultView.RowFilter = "";
                lblRecordsNumber.Text = dgvLocalDrivingLicenseApplications.Rows.Count.ToString();
                return;
            }

            if (FilterColumn == "LocalDrivingLicenseApplicationID")
                _dtAllLocalDrivingLicenseApplications.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            else
                _dtAllLocalDrivingLicenseApplications.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());

            lblRecordsNumber.Text = dgvLocalDrivingLicenseApplications.Rows.Count.ToString();
        }
        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(txtFilterValue.Text.Trim() == "L.D.L.ID")
                e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar); 
        }
        private void cmsItem1ShowApplicationDetails_Click(object sender, EventArgs e)
        {
            FrmLocalDrivingLicenseApplicationInfo frm =
                new FrmLocalDrivingLicenseApplicationInfo((int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _LoadLocalDrivingLicenseApplicationsList();
        }
        private void btnAddNewLocalDrivingLicenseApplication_Click(object sender, EventArgs e)
        {
            FrmAddUpdateLocalDrivingLicenseApplication frm = new FrmAddUpdateLocalDrivingLicenseApplication();
            frm.ShowDialog();
        }
        private void cmsItem2EditApplication_Click(object sender, EventArgs e)
        {
            FrmAddUpdateLocalDrivingLicenseApplication frm = new 
            FrmAddUpdateLocalDrivingLicenseApplication((int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }
        private void cmsItem3DeleteApplication_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure do want to delete this application?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            int LocalDrivingLicenseApplicationID = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;
            if(clsLocalDrivingLicenseApplication.Delete(LocalDrivingLicenseApplicationID))
            {
                MessageBox.Show("Application Deleted Successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _LoadLocalDrivingLicenseApplicationsList(); // refresh
            }
            else
                MessageBox.Show("Could not delete applicatoin, other data depends on it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void cmsItem4CancelApplication_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure do want to cancel this application?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            int LocalDrivingLicenseApplicationID = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;
            clsLocalDrivingLicenseApplication tempLocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingLicenseID(LocalDrivingLicenseApplicationID);

            if(tempLocalDrivingLicenseApplication != null)
            {
                if (tempLocalDrivingLicenseApplication.Cancel())
                {
                    MessageBox.Show("Application Cancel Successfully.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _LoadLocalDrivingLicenseApplicationsList(); // refresh
                }
                else
                    MessageBox.Show("Could not cancel applicatoin.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cmsItem7ShowLicense_Click(object sender, EventArgs e)
        {
            int LocalDrivingLicenseApplicationID = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;
            int LicenseID = clsLocalDrivingLicenseApplication.FindByLocalDrivingLicenseID(LocalDrivingLicenseApplicationID).GetActiveLicenseID();

            if(LicenseID != -1)
            {
                frmShowLicenseInfo frm = new frmShowLicenseInfo(LicenseID);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("No License Found!", "No License", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private void cmsApplications_Opening(object sender, CancelEventArgs e)
        {
            int LocalDrivingLicenseApplicationID = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;
            clsLocalDrivingLicenseApplication LocalDrivingLicenseApplicationInfo =
            clsLocalDrivingLicenseApplication.FindByLocalDrivingLicenseID(LocalDrivingLicenseApplicationID);
            byte TotalPassedTests = LocalDrivingLicenseApplicationInfo.GetPassedTestCount();
            bool LicenseIssued = LocalDrivingLicenseApplicationInfo.IsLicenseIssued();

            cmsItem2EditApplication.Enabled = (LocalDrivingLicenseApplicationInfo.Status == clsApplication.enApplicationStatus.New) && !LicenseIssued;
            cmsItem3DeleteApplication.Enabled = (LocalDrivingLicenseApplicationInfo.Status == clsApplication.enApplicationStatus.New);
            cmsItem4CancelApplication.Enabled = (LocalDrivingLicenseApplicationInfo.Status == clsApplication.enApplicationStatus.New);

            bool PassedVisionTest = LocalDrivingLicenseApplicationInfo.DoesPassTestType(clsTestType.enTestType.VisionTest);
            bool PassedWrittenTest = LocalDrivingLicenseApplicationInfo.DoesPassTestType(clsTestType.enTestType.WrittenTest);
            bool PassedStreetTest = LocalDrivingLicenseApplicationInfo.DoesPassTestType(clsTestType.enTestType.StreetTest);

            cmsItem5ScheduleTests.Enabled = (!PassedVisionTest || !PassedWrittenTest || !PassedStreetTest)
                && (LocalDrivingLicenseApplicationInfo.Status == clsApplication.enApplicationStatus.New);

            scheduleVisionTestToolStripMenuItem.Enabled = !PassedVisionTest;
            scheduleWrittenTestToolStripMenuItem.Enabled = PassedVisionTest && !PassedWrittenTest;
            scheduleStreetTestToolStripMenuItem.Enabled = PassedVisionTest && PassedWrittenTest && !PassedStreetTest;

            cmsItem6SIssueLicense.Enabled = (TotalPassedTests == 3) && !LicenseIssued;
            cmsItem7ShowLicense.Enabled = LicenseIssued;
        }
        private void _ScheduleTest(clsTestType.enTestType TestType)
        {
            int LocalDrivingLicenseApplicationID = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;
            frmManageTestAppointments frm = new frmManageTestAppointments(LocalDrivingLicenseApplicationID, TestType);
            frm.ShowDialog();
            _LoadLocalDrivingLicenseApplicationsList();
        }
        private void scheduleVisionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ScheduleTest(clsTestType.enTestType.VisionTest);
        }
        private void scheduleWrittenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ScheduleTest(clsTestType.enTestType.WrittenTest);

        }
        private void scheduleStreetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ScheduleTest(clsTestType.enTestType.StreetTest);
        }
        private void cmsItem6SIssueLicense_Click(object sender, EventArgs e)
        {
            int LocalDrivingLicenseApplicationID = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;

            frmIssueLicenseForTheFirstTime frm = new frmIssueLicenseForTheFirstTime(LocalDrivingLicenseApplicationID);
            frm.ShowDialog();
            _LoadLocalDrivingLicenseApplicationsList();
        }
        private void cmsItem8ShowPersonHistory_Click(object sender, EventArgs e)
        {
            int LocalDrivingLicenseApplicationID = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;
            clsLocalDrivingLicenseApplication LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingLicenseID(LocalDrivingLicenseApplicationID);
            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(LocalDrivingLicenseApplication.ApplicantPersonID);
            frm.ShowDialog();
        }
    }  
}
