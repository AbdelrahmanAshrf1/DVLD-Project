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

namespace DVLD.Applications.Local_Driving_License
{
    public partial class FrmLocalDrivingLicenseApplicationInfo : Form
    {
        private int _LocallDrivingLicenseApplicationID = -1;
        public FrmLocalDrivingLicenseApplicationInfo(int locallDrivingLicenseApplicationID)
        {
            InitializeComponent();
            _LocallDrivingLicenseApplicationID = locallDrivingLicenseApplicationID;
        }
        private void FrmLocalDrivingLicenseApplicationInfo_Load(object sender, EventArgs e)
        {
            ctrlDrivingLicenseApplicationInfo1.LoadApplicationInfoByLocalDrivingApplicationID(_LocallDrivingLicenseApplicationID);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
