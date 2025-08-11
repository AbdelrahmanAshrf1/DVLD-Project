using DVLD_BusinessLayer;
using PhoneNumbers;
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
using DVLD.Properties;
using DVLD.Global_Classes;

namespace DVLD
{
    public partial class FrmAddUpdatePerson : Form
    {
        // Declare a delegate
        public delegate void DataBackEventHandler(object sender, int PersonID);

        // Declare an event using the delegate
        public event DataBackEventHandler DataBack;

        public enum enMode { AddNew = 0, Update = 1 };
        public enum enGendor { Male = 0, Female = 1 };

        private string _basePath = System.Windows.Forms.Application.StartupPath.Replace(@"\bin\Debug", "\\Resources\\");
        private enMode _Mode;
        private int _PersonID;
        private clsPerson _Person;
        public FrmAddUpdatePerson()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }
        public FrmAddUpdatePerson(int personID)
        {
            InitializeComponent();

            _PersonID = personID;
            _Mode = enMode.Update;
        }
        private void _FillCountriesInComboBox()
        {
            DataTable dtPeople = clsCountry.GetAllCountries();
            
            foreach(DataRow row in dtPeople.Rows)
            {
                cbCountries.Items.Add(row["CountryName"]);
            }
        }
        private void _ResetDefaultValues()
        {
            _FillCountriesInComboBox();

            if(_Mode == enMode.AddNew)
            {
                lblMode.Text = "Add New Person";
                _Person = new clsPerson();
            }
            else
            {
                lblMode.Text = "Update Person";
            }

            if (rbMale.Checked)
                pbPersonImage.Image = Resources.man;
            else
                pbPersonImage.Image= Resources.girl;

            llRemove.Visible = (pbPersonImage.ImageLocation != null);

            dtpDateOfBirth.MinDate = DateTime.Now.AddYears(-100);
            dtpDateOfBirth.Value = dtpDateOfBirth.MaxDate;
            dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(-18);

            cbCountries.SelectedIndex = cbCountries.FindString("Egypt");

            txtFirstName.Text = "";
            txtSecondName.Text = "";
            txtThirdName.Text = "";
            txtLastName.Text = "";
            txtNationalNumber.Text = "";
            rbMale.Checked = true;
            txtPhoneNumber.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";
            
        }
        private void _LoadData()
        {
            _Person = clsPerson.Find(_PersonID);

            if (_Person == null)
            {
                MessageBox.Show($"This Form will be closed because no Person with ID {_PersonID} Found!");
                this.Close();
                return;
            }

            lblPersonID.Text = _Person.ID.ToString();
            txtFirstName.Text = _Person.FirstName;
            txtSecondName.Text = _Person.SecondName;
            txtLastName.Text = _Person.LastName;
            txtNationalNumber.Text = _Person.NationalNo;
            dtpDateOfBirth.Value = _Person.DateOfBirth;
            txtPhoneNumber.Text = _Person.Phone;
            txtAddress.Text = _Person.Address;


            if (_Person.Gender == clsPerson.enGender.Male)
                rbMale.Checked = true;
            else
                rbFemale.Checked = true;

            txtAddress.Text = _Person.Address;
            txtPhoneNumber.Text = _Person.Phone;
            txtEmail.Text = _Person.Email;
            cbCountries.SelectedIndex = cbCountries.FindString(_Person.CountryInfo.CountryName);

            if (!string.IsNullOrEmpty(_Person.ImagePath)) pbPersonImage.ImageLocation = _Person.ImagePath;

            llRemove.Visible = (!string.IsNullOrEmpty(_Person.ImagePath));
        }
        private void FrmAddUpdatePersonInfo_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();
            if (_Mode == enMode.Update) _LoadData();
        }
        private bool _HandlePersonImage()
        {
            //_Person.ImagePath contains the old Image, we check if it changed then we copy the new image
            if (_Person.ImagePath != pbPersonImage.ImageLocation)
            {
                if (_Person.ImagePath != "")
                {
                    try
                    {
                        File.Delete(_Person.ImagePath);
                    }
                    catch (IOException)
                    {
                    
                    }
                }

                if (pbPersonImage.ImageLocation != null)
                {
                    //then we copy the new image to the image folder after we rename it
                    string SourceImageFile = pbPersonImage.ImageLocation.ToString();

                    if (Util.CopyImageToProjectImagesFolder(ref SourceImageFile))
                    {
                        pbPersonImage.ImageLocation = SourceImageFile;
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Error Copying Image File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(!_HandlePersonImage()) return;

            _PopulatePersonFromForm();

            if (_Person.Save())
            {
                lblPersonID.Text = _PersonID.ToString();
                // Change form Mode to update
                _Mode = enMode.Update;
                lblMode.Text = "Update Person";
                MessageBox.Show("Data saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                DataBack?.Invoke(this, _Person.ID);
                this.Close();
            }
            else
                MessageBox.Show("Error: Data was not saved successfully!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void _PopulatePersonFromForm()
        {
            int NationalityCountryID = clsCountry.Find(cbCountries.Text).ID;

            _Person.FirstName = txtFirstName.Text.Trim();
            _Person.SecondName = txtSecondName.Text.Trim();
            _Person.ThirdName = txtThirdName.Text.Trim();
            _Person.LastName = txtLastName.Text.Trim();
            _Person.NationalNo = txtNationalNumber.Text.Trim();
            _Person.Email = txtEmail.Text.Trim();
            _Person.Phone = txtPhoneNumber.Text.Trim();
            _Person.Address = txtAddress.Text.Trim();
            _Person.DateOfBirth = dtpDateOfBirth.Value;
            _Person.Gender = rbMale.Checked ? clsPerson.enGender.Male : clsPerson.enGender.Female;
            _Person.NationalityCountryID = NationalityCountryID;
            _Person.ImagePath = pbPersonImage.ImageLocation != null ? pbPersonImage.ImageLocation : "";
        }
        private void llSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string SelectedFilePath = openFileDialog1.FileName;
                pbPersonImage.ImageLocation = SelectedFilePath;
                llRemove.Visible = true;
            }
        }
        private void llRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbPersonImage.Image = null;

            if (_Person.Gender == clsPerson.enGender.Male)
                rbMale.Checked = true;
            else
                rbFemale.Checked = true;

            llRemove.Visible = false;
        }
        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            if(pbPersonImage.ImageLocation == null) pbPersonImage.Image = Resources.man;
        }
        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (pbPersonImage.ImageLocation == null) pbPersonImage.Image = Resources.girl;
        }
        private void ValidateEmptyTextBox(object sender, CancelEventArgs e)
        {
            Guna.UI2.WinForms.Guna2TextBox temp = (Guna.UI2.WinForms.Guna2TextBox)sender;

            if (string.IsNullOrWhiteSpace(temp.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(txtFirstName, "This field is required!");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(temp, null);
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            return;
        }
        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (txtEmail.Text.Trim() == "") return;

            if (!Validation.ValidateEmail(txtEmail.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(txtEmail, "Invalid Email Address Format!");
            }
            else
                errorProvider.SetError(txtEmail, null);
        }
        private void txtNationalNumber_Validating(object sender, CancelEventArgs e)
        {
            string NationalNo = txtNationalNumber.Text.Trim();
            if (string.IsNullOrWhiteSpace(NationalNo))
            {
                e.Cancel = true;
                errorProvider.SetError(txtNationalNumber, "This feild is required!");
                return;
            }
            else
                errorProvider.SetError(txtNationalNumber,null);

            if (NationalNo != _Person.NationalNo && clsPerson.IsPersonExist(NationalNo))
            {
                e.Cancel = true;
                errorProvider.SetError(txtNationalNumber, "National Number is used for another person!");
            }
            else
                errorProvider.SetError(txtNationalNumber, null);
        }
        private void cbCountries_SelectedIndexChanged(object sender, EventArgs e)
        {
            clsCountry selectedCountry = clsCountry.Find(cbCountries.Text);
            pbFlag.ImageLocation = Path.Combine(_basePath + @"Flags\", $"{selectedCountry.CountryISO}.png");
        }
        private void txtPhoneNumber_Validating(object sender, CancelEventArgs e)
        {
            string phoneNumberInput = txtPhoneNumber.Text.Trim();
            var selectedCountry = clsCountry.Find(cbCountries.Text.Trim());

            if (selectedCountry == null)
            {
                e.Cancel = true;
                errorProvider.SetError(txtPhoneNumber, "Please select a valid country.");
                pbPhoneNumberState.ImageLocation = Path.Combine(_basePath, "False.png");
                return;
            }

            string countryISO = selectedCountry.CountryISO.ToUpper();

            if (Validation.ValidatePhoneNumber(phoneNumberInput, countryISO, out string errorMessage))
            {
                errorProvider.SetError(txtPhoneNumber, "");
                pbPhoneNumberState.ImageLocation = Path.Combine(_basePath, "True.png");
            }
            else
            {
                e.Cancel = true;
                errorProvider.SetError(txtPhoneNumber, errorMessage);
                pbPhoneNumberState.ImageLocation = Path.Combine(_basePath, "False.png");
            }
        }

    }
}
