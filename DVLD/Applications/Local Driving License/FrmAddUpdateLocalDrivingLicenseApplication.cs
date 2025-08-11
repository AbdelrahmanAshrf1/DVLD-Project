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
using DVLD_Buisness;
using DVLD.Classes;
using System.Web.Hosting;

namespace DVLD
{
    public partial class FrmAddUpdateLocalDrivingLicenseApplication : Form
    {
        public enum enMode { AddNew = 1,Update = 2 }
        private enMode _Mode;

        private int _LocalDrivingLicenseApplicationID;
        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;
        private int _SelectedPersonID = -1;
        private clsApplication _application;
        public FrmAddUpdateLocalDrivingLicenseApplication()
        {
            InitializeComponent();

            _Mode = enMode.AddNew;
        }
        public FrmAddUpdateLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();

            _Mode = enMode.Update;
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void _ResetDefaultValues()
        {
            _FillLicenseClassesInCombobox();

            if (_Mode == enMode.AddNew)
            {
                lblMode.Text = "New Local Driving License Application";
                this.Text = "New Local Driving License Application";
                _LocalDrivingLicenseApplication = new clsLocalDrivingLicenseApplication();
                ctrlPersonInfoCardWithFilter1.FilterFocus();
                tbApplicationInfo.Enabled = false;
                cbLicenseClass.SelectedIndex = 2;
                lblApplicationFees.Text = clsApplicationTypes.Find((int)clsApplication.enApplicationType.NewDrivingLicense).Fees.ToString();
                lblApplicationDate.Text = DateTime.Now.ToShortDateString();
                lblCreatedBy.Text = Global.CurrentUser.Username;
            }
            else
            {
                lblMode.Text = "Update Local Driving License Application";
                this.Text = "Update Local Driving License Application";
                tbApplicationInfo.Enabled = true;
                btnSave.Enabled = true;
            }
        }
        private void _LoadLocalDrivingLicenseApplicationInfo()
        {
            ctrlPersonInfoCardWithFilter1.FilterEnabled = false;
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingLicenseID(_LocalDrivingLicenseApplicationID);

            if(_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show("No Application with ID = " + _LocalDrivingLicenseApplicationID, "Application Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();

                return;
            }

            ctrlPersonInfoCardWithFilter1.LoadPersonInfo(_LocalDrivingLicenseApplication.ApplicantPersonID);
            lblApplicationID.Text = _LocalDrivingLicenseApplication.ApplicationID.ToString();
            lblApplicationDate.Text = _LocalDrivingLicenseApplication.Date.ToString();
            cbLicenseClass.SelectedIndex = cbLicenseClass.FindString(clsLicenseClass.Find(_LocalDrivingLicenseApplication.LicenseClassID).ClassName);
            lblApplicationFees.Text = _LocalDrivingLicenseApplication.PaidFees.ToString();
            lblCreatedBy.Text = clsUser.FindByUserID(_LocalDrivingLicenseApplication.CreatedByUserID).Username;
        }

        private void _FillLicenseClassesInCombobox()
        {
            DataTable dataTable = clsLicenseClass.GetAllLicenseClasses();
            cbLicenseClass.DataSource = dataTable;

            cbLicenseClass.DisplayMember = "ClassName";
            cbLicenseClass.ValueMember = "ClassFees";
        }
        private void FrmAddUpdateLocalDrivingLicenseApplication_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();
            if (_Mode == enMode.Update) _LoadLocalDrivingLicenseApplicationInfo();
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            if(_Mode == enMode.Update)
            {
                btnSave.Enabled = true;
                tbApplicationInfo.Enabled = true;
                tcApplicationInfo.SelectedTab = tcApplicationInfo.TabPages["tbApplicationInfo"];
            }

            //incase of add new mode.
            if (ctrlPersonInfoCardWithFilter1.PersonID != -1)
            {
                btnSave.Enabled = true;
                tbApplicationInfo.Enabled = true;
                tcApplicationInfo.SelectedTab = tcApplicationInfo.TabPages["tbApplicationInfo"];
            }
            else
            {
                MessageBox.Show("Please Select a Person", "Select a Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrlPersonInfoCardWithFilter1.FilterFocus();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int LicenseClassID = clsLicenseClass.Find(cbLicenseClass.Text).ClassID;
            int ActiveApplicationID = clsApplication.GetActiveApplicationIDForLicenseClass(_SelectedPersonID, clsApplication.enApplicationType.NewDrivingLicense, LicenseClassID);

            if (ActiveApplicationID != -1)
            {
                MessageBox.Show("Choose another License Class, the selected Person Already have an active application for the selected class with id=" + ActiveApplicationID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbLicenseClass.Focus();
                return;
            }

            if( clsLicense.IsLicenseClassExistByPersonID(ctrlPersonInfoCardWithFilter1.PersonID, LicenseClassID))
            {
                MessageBox.Show("Person already have a license with the same applied driving class, Choose diffrent driving class", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
    
            _LocalDrivingLicenseApplication.ApplicantPersonID = ctrlPersonInfoCardWithFilter1.PersonID;
            _LocalDrivingLicenseApplication.Date = DateTime.Now;
            _LocalDrivingLicenseApplication.ApplicationTypeID = 1;
            _LocalDrivingLicenseApplication.Status = clsApplication.enApplicationStatus.New;
            _LocalDrivingLicenseApplication.LastStatusDate = DateTime.Now;
            _LocalDrivingLicenseApplication.PaidFees = Convert.ToSingle(lblApplicationFees.Text);
            _LocalDrivingLicenseApplication.CreatedByUserID = Global.CurrentUser.ID;
            _LocalDrivingLicenseApplication.LicenseClassID = LicenseClassID;

            if(_LocalDrivingLicenseApplication.Save())
            {
                lblApplicationID.Text = _LocalDrivingLicenseApplication.ApplicationID.ToString();
                _Mode = enMode.Update;
                lblMode.Text = "Update Local Driving License Application";

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void ctrlPersonInfoCardWithFilter1_OnPersonSelected(int obj)
        {
            _SelectedPersonID = obj;
        }
        private void FrmAddUpdateLocalDrivingLicenseApplication_Activated(object sender, EventArgs e)
        {
            ctrlPersonInfoCardWithFilter1.FilterFocus();
        }
    }
}
