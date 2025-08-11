using DVLD.Properties;
using DVLD_Business;
using DVLD_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Licenses.International_License.Controls
{
    public partial class ctrlDriverInternationalLicenseInfo : UserControl
    {
        private int _LicenseID = -1;
        private clsInternationalLicense _InternationalLicenseInfo;

        public int LicenseID
        {
            get { return _LicenseID; }
        }
        public clsInternationalLicense SelectedLicenseInfo
        {
            get { return _InternationalLicenseInfo; }
        }
        public ctrlDriverInternationalLicenseInfo()
        {
            InitializeComponent();
        }
        private void _LoadPersonImage()
        {
            if (_InternationalLicenseInfo.DriverInfo.PersonInfo.Gender == clsPerson.enGender.Male)
                pbPersonImage.Image = Resources.man;
            else
                pbPersonImage.Image = Resources.girl;

            string ImagePath = _InternationalLicenseInfo.DriverInfo.PersonInfo.ImagePath;

            if (ImagePath != "")
                if (File.Exists(ImagePath))
                    pbPersonImage.Load(ImagePath);
                else
                    MessageBox.Show("Could not find this image: = " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void _FillLicenseInfoOnForm()
        {
            lblName.Text = _InternationalLicenseInfo.DriverInfo.PersonInfo.FullName();
            lblInternationalLicenseID.Text = _InternationalLicenseInfo.InternationalLicenseID.ToString();
            lblLicenseID.Text = _InternationalLicenseInfo.IssuedUsingLocalLicenseID.ToString();
            lblNationalNO.Text = _InternationalLicenseInfo.DriverInfo.PersonInfo.NationalityCountryID.ToString();
            lblGender.Text = (_InternationalLicenseInfo.DriverInfo.PersonInfo.Gender == clsPerson.enGender.Male) ? "Male" : "Female";
            lblIssueDate.Text = _InternationalLicenseInfo.IssueDate.ToShortDateString();
            lblApplicationID.Text = _InternationalLicenseInfo.ApplicationInfo.ApplicationID.ToString();
            lblIsActive.Text = (_InternationalLicenseInfo.IsActive == true) ? "Yes" : "No";
            lblDateOfBirth.Text = _InternationalLicenseInfo.DriverInfo.PersonInfo.DateOfBirth.ToShortDateString();
            lblDriverID.Text = _InternationalLicenseInfo.DriverID.ToString();
            lblExpirationDate.Text = _InternationalLicenseInfo.ExpirationDate.ToShortDateString();
            _LoadPersonImage();
        }
        public void LoadLicenseInfo(int LicenseID)
        {
            _LicenseID = LicenseID;
            _InternationalLicenseInfo = clsInternationalLicense.Find(_LicenseID);

            if(_InternationalLicenseInfo == null )
            {
                MessageBox.Show("Could not find License ID = " + _LicenseID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillLicenseInfoOnForm();
        }
    }
}
