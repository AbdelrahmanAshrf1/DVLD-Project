using DVLD.Properties;
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

namespace DVLD.Tests.Controls
{
    public partial class ctrlScheduledTest : UserControl
    {
        private clsTestType.enTestType _TestTypeID;

        private int _LocalDrivingLicenseApplicationID = -1;
        private clsLocalDrivingLicenseApplication _LocalDivingLicenseApplicationInfo;

        private int _TestID;
        public int TestID
        {
            get { return _TestID; }
        }

        private int _TestAppointmentID = -1;
        private clsTestAppointment _TestAppointmentInfo;
        public int TestAppointmentID
        {
            get { return _TestAppointmentID; }
        }

        public clsTestType.enTestType TestType
        {
            get { return _TestTypeID; }
            set
            {
                _TestTypeID = value;

                switch(_TestTypeID)
                {
                    case clsTestType.enTestType.VisionTest:
                        _PrepareFromLayoutForVisionTest();
                        break;

                    case clsTestType.enTestType.WrittenTest:
                        _PrepareFromLayoutForWrittenTest();
                        break;

                    case clsTestType.enTestType.StreetTest:
                        _PrepareFromLayoutForStreetTest();
                        break;
                }
            }
        }
        private void _PrepareFromLayoutForVisionTest()
        {
            gbTestType.Text = "Vision Test";
            pbTestTypeImage.Image = Resources.Vision_Test;
        }
        private void _PrepareFromLayoutForWrittenTest()
        {
            gbTestType.Text = "Written Test";
            pbTestTypeImage.Image = Resources.Written_Test;
        }
        private void _PrepareFromLayoutForStreetTest()
        {
            gbTestType.Text = "Street Test";
            pbTestTypeImage.Image = Resources.Street_Test;
        }

        public ctrlScheduledTest()
        {
            InitializeComponent();
        }

        public void LoadAppointmentData(int TestAppointmentID)
        {
            _TestAppointmentID = TestAppointmentID;
            _TestAppointmentInfo = clsTestAppointment.Find(_TestAppointmentID);

            if(_TestAppointmentInfo == null)
            {
                MessageBox.Show("Error: No  Appointment ID = " + _TestAppointmentID.ToString(),"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _TestAppointmentID = -1;
                return;
            }

            _TestID = clsTest.FindTestIDByTestAppointmentID(_TestAppointmentInfo.TestAppointmentID);

            _LocalDrivingLicenseApplicationID = _TestAppointmentInfo.LocalDrivingLicenseApplicationID;
            _LocalDivingLicenseApplicationInfo = clsLocalDrivingLicenseApplication.FindByLocalDrivingLicenseID(_LocalDrivingLicenseApplicationID);

            if( _LocalDivingLicenseApplicationInfo == null)
            {
                MessageBox.Show("Error: No Local Driving License Application with ID = " + _LocalDrivingLicenseApplicationID.ToString(),"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblD_L_APP_ID.Text = _LocalDivingLicenseApplicationInfo.LocalDrivingLicenseApplicationID.ToString();
            lblD_Class.Text = _LocalDivingLicenseApplicationInfo.LicenseClassInfo.ClassName;
            lblName.Text = _LocalDivingLicenseApplicationInfo.ApplicantFullName;
            lblTrial.Text = _LocalDivingLicenseApplicationInfo.TotalTrialsPerTest(_TestTypeID).ToString();
            lblDate.Text = _TestAppointmentInfo.AppointmentDate.ToShortDateString();
            lblFees.Text = _TestAppointmentInfo.PaidFees.ToString();
            lblTestID.Text = (_TestID == -1)? "Not Taken Yet": _TestID.ToString();
        }
    }
}
