using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD.Applications.International_License;
using DVLD.Applications.Release_Detain_License;
using DVLD.Applications.Renew_Driving_License;
using DVLD.Applications.Replace_Lost_or_Damage_License;
using DVLD.Classes;
using DVLD.Drivers;
using DVLD.Licenses.Detain_License;
using DVLD.Licenses.International_License;
using Guna.UI2.WinForms;

namespace DVLD
{
    public partial class FrmMain : Form
    {
        FrmLogin _LoginForm;
        public FrmMain(FrmLogin LoginForm)
        {
            InitializeComponent();
            _LoginForm = LoginForm;
        }

        private FrmPeopleManagement FrmPeople = null;
        private FrmUserManagement FrmUsers = null;
        private FrmManageApplicationTypes ApplicationTypes = null;
        private FrmManageTestTypes FrmTestTypes = null;
        private FrmAddUpdateLocalDrivingLicenseApplication FrmLAddocalLicense = null;
        private frmDriversManagement FrmDriversManagement = null;
        private FrmManageLocalDrivingLicenseApplication FrmManageLocalDrivingLicenseApplication = null;
        private frmDetainLicensesManagement frmDetainLicensesManagement = null;
        private frmInternationalLicensesManagement frmInternationalLicensesManagement = null;
        private void HideBackgroundAndShowForm(Form childForm)
        {
            pbMainBackground.Visible = false;
            childForm.MdiParent = this;
            childForm.Dock = DockStyle.Fill;

            childForm.FormClosed += (s, args) =>
            {
                if (childForm is FrmPeopleManagement) FrmPeople = null;
                if (childForm is FrmUserManagement) FrmUsers = null;

                pbMainBackground.Visible = true;
            };

            childForm.Show();
        }
        private void HideSubMenus()
        {
            panelAccountSettings.Visible = false;
            PanelLicenseServices.Visible = false;
            panelMainApplications.Visible = false;
            SubMenuMangeApplication.Visible = false;
            SubMenuNewLicense.Visible = false;
            subMenuDetainLicenses.Visible = false;
        }
        private void btnPeopleManagement_Click(object sender, EventArgs e)
        {
            if (FrmPeople == null || FrmPeople.IsDisposed)
            {
                HideSubMenus();
                HideBackgroundAndShowForm(new FrmPeopleManagement());
            }
        }
        private void btnUsers_Click(object sender, EventArgs e)
        {
            if (FrmUsers == null || FrmUsers.IsDisposed)
            {
                HideSubMenus();
                HideBackgroundAndShowForm(new FrmUserManagement());
            }
        }
        private void btnContactMe_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://www.linkedin.com/in/abdelrahman-ashrf-71bb68254");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open link: " + ex.Message,"Page not found",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void FrmMain_Load(object sender, EventArgs e)
        {
            HideSubMenus();
        }
        private void btnSubPanelCurrentUser_Click(object sender, EventArgs e)
        {
            panelAccountSettings.Visible = false;
            FrmShowUserInfo frm = new FrmShowUserInfo(Global.CurrentUser.ID);
            frm.ShowDialog();
        }
        private void btnSubPanelChangePassword_Click(object sender, EventArgs e)
        {
            panelAccountSettings.Visible = false;
            FrmChangeUserPassword frm = new FrmChangeUserPassword(Global.CurrentUser.ID);
            frm.ShowDialog();
        }
        private void btnSubPanelSignOut_Click(object sender, EventArgs e)
        {
            Global.CurrentUser = null;
            _LoginForm.Show();
            this.Close();
        }
        private void TogglePanelVisibility(Panel panel)
        {
            panel.Visible = !panel.Visible;
        }
        private void btnApplications_Click(object sender, EventArgs e)
        {
            TogglePanelVisibility(panelMainApplications);

            PanelLicenseServices.Visible = false;
            SubMenuNewLicense.Visible = false;
            subMenuDetainLicenses.Visible = false;
            SubMenuMangeApplication.Visible = false;
        }
        private void btnAccountSettings_Click(object sender, EventArgs e)
        {
            TogglePanelVisibility(panelAccountSettings);
        }
        private void btnManageApplicationTypes_Click(object sender, EventArgs e)
        {
            if (ApplicationTypes == null || ApplicationTypes.IsDisposed)
            {
                HideSubMenus();
                HideBackgroundAndShowForm(new FrmManageApplicationTypes());
            }
        }
        private void btnManageTestTypes_Click(object sender, EventArgs e)
        {
            if (FrmTestTypes == null || FrmTestTypes.IsDisposed)
            {
                HideSubMenus();
                HideBackgroundAndShowForm(new FrmManageTestTypes());
            }
        }
        private void btnDrivingServices_Click(object sender, EventArgs e)
        {
            TogglePanelVisibility(PanelLicenseServices);
        }
        private void btnManageApplications_Click(object sender, EventArgs e)
        {
            TogglePanelVisibility(SubMenuMangeApplication);
        }
        private void btnNewDrivingLicenses_Click(object sender, EventArgs e)
        {
            TogglePanelVisibility(SubMenuNewLicense);
        }
        private void btnLocalLicense_Click(object sender, EventArgs e)
        {
            if (FrmLAddocalLicense == null || FrmLAddocalLicense.IsDisposed)
            {
                HideSubMenus();
                FrmLAddocalLicense = new FrmAddUpdateLocalDrivingLicenseApplication();
                FrmLAddocalLicense.ShowDialog();
            }
        }
        private void btnLocalDrivingLicense_Click(object sender, EventArgs e)
        {
            if (FrmManageLocalDrivingLicenseApplication == null || FrmManageLocalDrivingLicenseApplication.IsDisposed)
            {
                HideSubMenus();
                HideBackgroundAndShowForm(new FrmManageLocalDrivingLicenseApplication());
            }
        }
        private void btbRenewDrivingLicenses_Click(object sender, EventArgs e)
        {
            HideSubMenus();
            frmRenewLocalDrivingLicenseApplication frm = new frmRenewLocalDrivingLicenseApplication();
            frm.ShowDialog();
        }
        private void btnReplacementForLost_Click(object sender, EventArgs e)
        {
            HideSubMenus();
            frmReplaceLostOrDamagedLicense frm = new frmReplaceLostOrDamagedLicense();
            frm.ShowDialog();
        }
        private void btnDrivers_Click(object sender, EventArgs e)
        {
            if (FrmDriversManagement == null || FrmDriversManagement.IsDisposed)
            {
                HideSubMenus();
                HideBackgroundAndShowForm(new frmDriversManagement());
            }
        }
        private void btnDetainLicenses_Click(object sender, EventArgs e)
        {
            TogglePanelVisibility(subMenuDetainLicenses);
        }
        private void btnInternationalLicenseApplication_Click(object sender, EventArgs e)
        {
            if (frmInternationalLicensesManagement == null || frmInternationalLicensesManagement.IsDisposed)
            {
                HideSubMenus();
                HideBackgroundAndShowForm(new frmInternationalLicensesManagement());
            }
        }
        private void btnDetainLicenses_Click_1(object sender, EventArgs e)
        {
            frmDetainLicenseApplication frm = new frmDetainLicenseApplication();
            frm.ShowDialog();
        }
        private void btnManageDetainedLicenses_Click(object sender, EventArgs e)
        {
            if (frmDetainLicensesManagement == null || frmDetainLicensesManagement.IsDisposed)
            {
                HideSubMenus();
                HideBackgroundAndShowForm(new frmDetainLicensesManagement());
            }
        }
        private void btnInternationalLicense_Click(object sender, EventArgs e)
        {
            HideSubMenus();
            frmAddNewInternationalLicenseApplication frm = new frmAddNewInternationalLicenseApplication();
            frm.ShowDialog();
        }

        private void btnReleaseDenatiedDrivingLicense_Click(object sender, EventArgs e)
        {
            HideSubMenus();
            frmReleaseDetainLicenseApplication frm = new frmReleaseDetainLicenseApplication();
            frm.ShowDialog();
        }
        private void btnReleaseDetainLicense_Click(object sender, EventArgs e)
        {
            HideSubMenus();
            frmReleaseDetainLicenseApplication frm = new frmReleaseDetainLicenseApplication();
            frm.ShowDialog();
        }
    }
}
