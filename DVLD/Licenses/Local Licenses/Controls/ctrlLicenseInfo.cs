using DVLD.Properties;
using DVLD_BusinessLayer;
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Licenses.Local_Licenses.Controls
{
    public partial class ctrlLicenseInfo : UserControl
    {
        private int _LicenseID;
        private clsLicense _LicenseInfo;

        public int LicenseID
        {
            get { return _LicenseID; }
        }
        public clsLicense SelectedLicenseInfo
        {
            get { return _LicenseInfo; }
        }

        public ctrlLicenseInfo()
        {
            InitializeComponent();
        }
        private void _LoadPersonImage()
        {
            if (_LicenseInfo.DriverInfo.PersonInfo.Gender == clsPerson.enGender.Male)
                pbPersonImage.Image = Resources.man;
            else
                pbPersonImage.Image = Resources.girl;
            
            string ImagePath = _LicenseInfo.DriverInfo.PersonInfo.ImagePath;

            if (ImagePath != "")
                if (File.Exists(ImagePath))
                    pbPersonImage.Load(ImagePath);
                else
                    MessageBox.Show("Could not find this image: = " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void _FillLicenseInfoOnForm()
        {
            lblLicenseID.Text = _LicenseInfo.LicenseID.ToString();
            lblIsActive.Text = _LicenseInfo.IsActive ? "Yes" : "No";
            lblIsDetained.Text = _LicenseInfo.IsDetained ? "Yes" : "No";
            lblClass.Text = _LicenseInfo.LicenseClassInfo.ClassName;
            lblName.Text = _LicenseInfo.DriverInfo.PersonInfo.FullName();
            lblNationalNo.Text = _LicenseInfo.DriverInfo.PersonInfo.NationalNo;
            lblGender.Text = _LicenseInfo.DriverInfo.PersonInfo.Gender == 0 ? "Male" : "Female";
            lblDateOfBirth.Text = _LicenseInfo.DriverInfo.PersonInfo.DateOfBirth.ToShortDateString();
            lblDriverID.Text = _LicenseInfo.DriverID.ToString();
            lblIssueDate.Text = _LicenseInfo.IssueDate.ToShortDateString();
            lblExpirationDate.Text = _LicenseInfo.ExpirationDate.ToShortDateString();
            lblIssueReason.Text = _LicenseInfo.IssueReasonText;
            lblNotes.Text = (_LicenseInfo.Notes == "" )? "No Notes" : _LicenseInfo.Notes;
            _LoadPersonImage();
        }
        public void LoadLicenseInfo(int LicenseID)
        {
            _LicenseID = LicenseID;
            _LicenseInfo = clsLicense.Find(_LicenseID);

            if(_LicenseInfo == null)
            {
                MessageBox.Show("Could not find License ID = " + _LicenseID.ToString(),"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillLicenseInfoOnForm();
        }
    }
}
