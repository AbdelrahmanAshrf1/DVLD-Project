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
using System.IO;

namespace DVLD
{
    public partial class ctrlPersonCard : UserControl
    {
        private clsPerson _Person;

        private int _PersonID = -1;
        public int PersonID
        {
            get { return _PersonID; }
        }
        public clsPerson SelectedPersonInfo
        {
            get { return _Person; }
        }
        public ctrlPersonCard()
        {
            InitializeComponent();
        }

        public void LoadPersonInfo(int personID)
        {
            _Person = clsPerson.Find(personID);
            DisplayPersonInfo();
        }
        public void LoadPersonInfo(string NationalNo)
        {
            _Person = clsPerson.Find(NationalNo);
            DisplayPersonInfo();
        }
        public void ResetPersonInfo()
        {
            _PersonID = -1;
            lblPersonID.Text = "??";
            lblNationalNo.Text = "??";
            lblName.Text = "??";
            lblGender.Text = "??";
            lblEmail.Text = "??";
            lblPhone.Text = "??";
            lblDateOfBirth.Text = "??";
            lblCountry.Text = "??";
            lblAddress.Text = "??";
            pbPersonImage.Image = Resources.man;
        }
        private void LoadPersonInfo()
        {
            if (_Person.Gender == clsPerson.enGender.Male)
                pbPersonImage.Image = Resources.man;
            else
                pbPersonImage.Image = Resources.girl;

            string ImagePath = _Person.ImagePath;

            if (ImagePath != "")
                if(File.Exists(ImagePath))
                    pbPersonImage.ImageLocation = ImagePath;
                else
                    MessageBox.Show("Could not find this image: = " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void PopulatePersonInfo()
        {
            lblEditPersonInfo.Enabled = true;
            _PersonID = _Person.ID;
            lblPersonID.Text = _Person.ID.ToString();
            lblName.Text = _Person.FullName();
            lblNationalNo.Text = _Person.NationalNo;
            lblGender.Text = (_Person.Gender == clsPerson.enGender.Male) ? "Male" : "Female";
            lblEmail.Text = _Person.Email;
            lblAddress.Text = _Person.Address;
            lblDateOfBirth.Text = _Person.DateOfBirth.ToShortDateString();
            lblPhone.Text = _Person.Phone;
            lblCountry.Text = clsCountry.Find(_Person.NationalityCountryID).CountryName;
            LoadPersonInfo();
        }
        private void DisplayPersonInfo()
        {
            if (_Person == null)
            {
                ResetPersonInfo();
                MessageBox.Show("No Person Found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            PopulatePersonInfo();
        }
        private void lblEditPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmAddUpdatePerson frm = new FrmAddUpdatePerson(_PersonID);
            frm.ShowDialog();

            //refresh
            LoadPersonInfo(_PersonID);
        }
    }
}
