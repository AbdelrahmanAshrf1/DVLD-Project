using DVLD.Properties;
using DVLD_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Tests
{
    public partial class frmManageTestAppointments : Form
    {
        private DataTable  _dtTestAppointments;
        private int _LocalDrivingLicenseApplicationID = -1;
        private clsTestType.enTestType _TestType = clsTestType.enTestType.VisionTest;
        public frmManageTestAppointments(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestType)
        {
            InitializeComponent();

            _TestType = TestType;
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
        }
        private void _PrepareFromLayoutForVisionTest()
        {
            lblTestTypeTitle.Text = "Vision Test Appointment";
            pbTestType.Image = Resources.Vision_Test;
            this.Text = "Vision Test Appointment";
        }
        private void _PrepareFromLayoutForWrittenTest()
        {
            lblTestTypeTitle.Text = "Written Test Appointment";
            pbTestType.Image = Resources.Written_Test;
            this.Text = "Written Test Appointment";
        }
        private void _PrepareFromLayoutForStreetTest()
        {
            lblTestTypeTitle.Text = "Driving Test Appointment";
            pbTestType.Image = Resources.Street_Test;
            this.Text = "Driving Test Appointment";
        }
        private void _PrepareFromLayoutForTestType()
        {
            switch( _TestType)
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
        private void _LoadData()
        {
            ctrlDrivingLicenseApplicationInfo1.LoadApplicationInfoByLocalDrivingApplicationID(_LocalDrivingLicenseApplicationID);
            _dtTestAppointments = clsTestAppointment.GetTestAppointmentsPerTestType(_LocalDrivingLicenseApplicationID, _TestType);

            dgvLicenseTestAppointments.DataSource = _dtTestAppointments;
            lblRecordsNumber.Text = dgvLicenseTestAppointments.Rows.Count.ToString();

            if(dgvLicenseTestAppointments.Rows.Count > 0)
            {
                dgvLicenseTestAppointments.Columns[0].HeaderText = "Appointment ID";
                dgvLicenseTestAppointments.Columns[1].HeaderText = "Appointment Date";
                dgvLicenseTestAppointments.Columns[2].HeaderText = "Paid Fees";
                dgvLicenseTestAppointments.Columns[3].HeaderText = "Is Locked";
            }
        }
        private void frmManageTestAppointments_Load(object sender, EventArgs e)
        {
            _PrepareFromLayoutForTestType();
            _LoadData();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnAddNewTestAppointment_Click(object sender, EventArgs e)
        {
            clsLocalDrivingLicenseApplication localDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingLicenseID(_LocalDrivingLicenseApplicationID);


            if (localDrivingLicenseApplication.IsThereAnActiveScheduledTest(_TestType))
            {
                MessageBox.Show("Person Already have an active appointment for this test, You cannot add new appointment", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            clsTest LastTest = localDrivingLicenseApplication.GetLastTestPerTestType(_TestType);

            // Incase it was the first time doing test.
            if(LastTest == null)
            {
                frmScheduleTest frm1 = new frmScheduleTest(_LocalDrivingLicenseApplicationID, _TestType);
                frm1.ShowDialog();
                frmManageTestAppointments_Load(null, null);
                return;
            }

            // Incase Person already passed the test he/she can't retake it 
            if (LastTest.TestResult == true)
            {
                MessageBox.Show("This person already passed this test before, you can only retake faild test", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Incase Person failed test adding Another application for retake test 
            frmScheduleTest frm2 = new frmScheduleTest(LastTest.TestAppointmentInfo.LocalDrivingLicenseApplicationID, _TestType);
            frm2.ShowDialog();
            frmManageTestAppointments_Load(null, null);
        }

        private void TakeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int TestAppointmentID = (int)dgvLicenseTestAppointments.CurrentRow.Cells[0].Value;
            frmTakeTest frm = new frmTakeTest(TestAppointmentID, _TestType);
            frm.ShowDialog();
            frmManageTestAppointments_Load(null, null);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int TestAppointmentID = (int)dgvLicenseTestAppointments.CurrentRow.Cells[0].Value;
            frmScheduleTest frm = new frmScheduleTest(_LocalDrivingLicenseApplicationID, _TestType, TestAppointmentID);
            frm.ShowDialog();
            frmManageTestAppointments_Load(null, null);
        }
    }
}
