using DVLD.Classes;
using DVLD.Properties;
using DVLD_Buisness;
using DVLD_BusinessLayer;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DVLD.Tests.Controls
{
    public partial class ctrlScheduleTest : UserControl
    {
        public enum enMode { AddNew = 0, Update = 1 }
        private enMode _Mode = enMode.AddNew;

        public enum enCreationMode { FirstTimeSchedule = 0, RetakeTestSchedule = 1 }
        private enCreationMode _CreationMode = enCreationMode.FirstTimeSchedule;

        private clsTestType.enTestType _TestTypeID = clsTestType.enTestType.VisionTest;

        private int _LocalDrivingLicenseApplicationID = -1;
        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplicationInfo = null;

        private int _TestAppointmentID = -1;
        private clsTestAppointment _TestAppointmentInfo = null;

        private readonly Dictionary<clsTestType.enTestType, clsTestType.enTestType?> _Prerequisites
            = new Dictionary<clsTestType.enTestType, clsTestType.enTestType?>()
            {
                { clsTestType.enTestType.VisionTest , null },
                { clsTestType.enTestType.WrittenTest , clsTestType.enTestType.VisionTest },
                { clsTestType.enTestType.StreetTest ,  clsTestType.enTestType.WrittenTest }
            };

        public clsTestType.enTestType TestTypeID
        {
            get { return _TestTypeID; }
            set
            {
                _TestTypeID = value;
                switch (_TestTypeID)
                {
                    case clsTestType.enTestType.VisionTest:
                        lblTitle.Text = "Vision Test";
                        gbTestType.Text = "Vision Test";
                        pbTestTypeImage.Image = Resources.Vision_Test;
                        break;

                    case clsTestType.enTestType.WrittenTest:
                        lblTitle.Text = "Written Test";
                        gbTestType.Text = "Written Test";
                        pbTestTypeImage.Image = Resources.Written_Test;
                        break;

                    case clsTestType.enTestType.StreetTest:
                        lblTitle.Text = "Street Test";
                        gbTestType.Text = "Street Test";
                        pbTestTypeImage.Image = Resources.Street_Test;
                        break;
                }
            }
        }

        public ctrlScheduleTest()
        {
            InitializeComponent();
        }

        public void LoadInfo(int localDrivingLicenseApplicationID, int testAppointmentID = -1)
        {
            // assign IDs first
            _LocalDrivingLicenseApplicationID = localDrivingLicenseApplicationID;
            _TestAppointmentID = testAppointmentID;

            // decide mode after assignment
            _Mode = (_TestAppointmentID == -1) ? enMode.AddNew : enMode.Update;

            _LocalDrivingLicenseApplicationInfo =
                clsLocalDrivingLicenseApplication.FindByLocalDrivingLicenseID(_LocalDrivingLicenseApplicationID);

            if (_LocalDrivingLicenseApplicationInfo == null)
            {
                MessageBox.Show(
                    $"Error: No Local Driving License Application with ID = {_LocalDrivingLicenseApplicationID}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return;
            }

            // determine creation mode
            _CreationMode = _LocalDrivingLicenseApplicationInfo.DoesAttendTestType(_TestTypeID)
                ? enCreationMode.RetakeTestSchedule
                : enCreationMode.FirstTimeSchedule;

            if (_CreationMode == enCreationMode.RetakeTestSchedule)
            {
                gbRetakeTestInfo.Enabled = true;
                lblRetakeTestAppFees.Text = clsApplicationTypes.Find((int)clsApplication.enApplicationType.RetakeTest).Fees.ToString();
                lblTitle.Text = "Schedule Retake Test";
                lblRetakeTestAppID.Text = "0";
            }
            else
            {
                gbRetakeTestInfo.Enabled = false;
                lblTitle.Text = "Schedule Test";
                lblRetakeTestAppFees.Text = "0";
                lblRetakeTestAppID.Text = "A/N";
            }

            // fill general info
            lblD_L_APP_ID.Text = _LocalDrivingLicenseApplicationInfo.ApplicationID.ToString();
            lblD_Class.Text = _LocalDrivingLicenseApplicationInfo.LicenseClassInfo.ClassName;
            lblName.Text = _LocalDrivingLicenseApplicationInfo.ApplicantFullName;
            lblTrial.Text = _LocalDrivingLicenseApplicationInfo.TotalTrialsPerTest(_TestTypeID).ToString();

            if (_Mode == enMode.AddNew)
            {
                dtpTestDate.MinDate = DateTime.Now;
                lblFees.Text = clsTestType.Find(_TestTypeID).Fees.ToString();
                lblRetakeTestAppID.Text = "A/N";
                _TestAppointmentInfo = new clsTestAppointment();
            }
            else
            {
                if (!_LoadTestAppointmentData()) return;
            }

            lblTotalFees.Text = (Convert.ToSingle(lblFees.Text) +
                                 Convert.ToSingle(lblRetakeTestAppFees.Text)).ToString();

            // run constraints
            if (!_HandleActiveTestAppointmentConstraint()) return;
            if (!_HandleAppointmentLockedConstraint()) return;
            if (!_HandlePreviousTestConstraint()) return;
        }

        private bool _LoadTestAppointmentData()
        {
            _TestAppointmentInfo = clsTestAppointment.Find(_TestAppointmentID);

            if (_TestAppointmentInfo == null)
            {
                MessageBox.Show(
                    $"Error: No Appointment with ID = {_TestAppointmentID}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return false;
            }

            lblFees.Text = _TestAppointmentInfo.PaidFees.ToString();
            dtpTestDate.MinDate = DateTime.Compare(DateTime.Now, _TestAppointmentInfo.AppointmentDate) < 0
                ? DateTime.Now
                : _TestAppointmentInfo.AppointmentDate;

            dtpTestDate.Value = _TestAppointmentInfo.AppointmentDate;

            if (_TestAppointmentInfo.RetakeTestApplicationID == -1)
            {
                lblRetakeTestAppID.Text = "N/A";
                lblRetakeTestAppFees.Text = "0";
            }
            else
            {
                gbRetakeTestInfo.Enabled = true;
                lblTitle.Text = "Schedule Retake Test";
                lblRetakeTestAppID.Text = _TestAppointmentInfo.RetakeTestApplicationID.ToString();
                lblRetakeTestAppFees.Text = _TestAppointmentInfo.RetakeTestAppInfo.PaidFees.ToString();
            }

            return true;
        }

        private bool _HandleActiveTestAppointmentConstraint()
        {
            if (_Mode == enMode.AddNew &&
                clsLocalDrivingLicenseApplication.IsThereAnActiveScheduledTest(_LocalDrivingLicenseApplicationID, _TestTypeID))
            {
                _SetUIState(false, "Person already has an active appointment for this test.");
                return false;
            }
            return true;
        }

        private bool _HandleAppointmentLockedConstraint()
        {
            if (_TestAppointmentInfo != null && _TestAppointmentInfo.IsLocked)
            {
                _SetUIState(false, "Person already sat for the test, appointment locked.");
                return false;
            }
            else
            {
                lblUserMessage.Visible = false;
            }
            return true;
        }

        private void _SetUIState(bool canSchedule, string message = "")
        {
            lblUserMessage.Text = message;
            lblUserMessage.Visible = !canSchedule && !string.IsNullOrWhiteSpace(message);
            btnSave.Enabled = canSchedule;
            dtpTestDate.Enabled = canSchedule;
        }

        private bool _HandlePreviousTestConstraint()
        {
            if (!_Prerequisites.TryGetValue(_TestTypeID, out var requiredTest))
            {
                _SetUIState(false, "Unknown test type");
                return false;
            }

            if (requiredTest == null)
            {
                _SetUIState(true);
                return true;
            }

            if (!_LocalDrivingLicenseApplicationInfo.DoesPassTestType(requiredTest.Value))
            {
                _SetUIState(false, $"Cannot schedule, {requiredTest} must be passed first.");
                return false;
            }

            _SetUIState(true);
            return true;
        }

        private bool _HandleRetakeApplication()
        {
            if (_Mode == enMode.AddNew && _CreationMode == enCreationMode.RetakeTestSchedule)
            {
                clsApplication app = new clsApplication
                {
                    ApplicantPersonID = _LocalDrivingLicenseApplicationInfo.ApplicantPersonID,
                    Date = DateTime.Now,
                    ApplicationTypeID = (int)clsApplication.enApplicationType.RetakeTest,
                    Status = clsApplication.enApplicationStatus.Completed,
                    LastStatusDate = DateTime.Now,
                    PaidFees = clsApplicationTypes.Find((int)clsApplication.enApplicationType.RetakeTest).Fees,
                    CreatedByUserID = Global.CurrentUser.ID
                };

                if (!app.Save())
                {
                    MessageBox.Show("Failed to create retake test application", "Failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                _TestAppointmentInfo.RetakeTestApplicationID = app.ApplicationID;
            }
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_HandleRetakeApplication()) return;

            _TestAppointmentInfo.TestTypeID = _TestTypeID;
            _TestAppointmentInfo.LocalDrivingLicenseApplicationID =
                _LocalDrivingLicenseApplicationInfo.LocalDrivingLicenseApplicationID;
            _TestAppointmentInfo.AppointmentDate = dtpTestDate.Value;
            _TestAppointmentInfo.PaidFees = Convert.ToSingle(lblFees.Text);
            _TestAppointmentInfo.CreatedByUserID = Global.CurrentUser.ID;

            if (_TestAppointmentInfo.Save())
            {
                _Mode = enMode.Update;
                MessageBox.Show("Data saved successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error: Data not saved successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
