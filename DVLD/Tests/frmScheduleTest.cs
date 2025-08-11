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

namespace DVLD.Tests
{
    public partial class frmScheduleTest : Form
    {
        private int _localDrivingLicenseApplicationID = -1;
        private clsTestType.enTestType _testTypeID = clsTestType.enTestType.VisionTest;
        private int _testAppointmnetID = -1;

        public frmScheduleTest(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID,int AppointmentID = -1)
        {
            InitializeComponent();

            _testTypeID = TestTypeID;
            _testAppointmnetID = AppointmentID;
            _localDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
        }

        private void frmScheduleTest_Load(object sender, EventArgs e)
        {
            ctrlScheduleTest1.TestTypeID = _testTypeID;
            ctrlScheduleTest1.LoadInfo(_localDrivingLicenseApplicationID, _testAppointmnetID);
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
