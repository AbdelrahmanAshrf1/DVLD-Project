using System;
using System.ComponentModel;
using System.Windows.Forms;
using DVLD_BusinessLayer;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DVLD
{
    public partial class FrmAddUpdateUserInfo : Form
    {
        public enum enMode { AddNew, Update }

        private enMode _Mode;
        private int _UserID = -1;
        private clsUser _User;
        public FrmAddUpdateUserInfo()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }
        public FrmAddUpdateUserInfo(int userID)
        {
            InitializeComponent();

            _UserID = userID;
            _Mode = enMode.Update;
        }
        private void _ResetDefaultValues()
        {
            if(_Mode == enMode.AddNew)
            {
                lblMode.Text = "Add New User";
                this.Text = "Add New User";
                _User = new clsUser();

                tbLoginInfo.Enabled = false;

                ctrlPersonInfoCardWithFilter1.FilterFocus();
            }
            else
            {
                lblMode.Text = "Update User";
                this.Text = "Update User";

                tbLoginInfo.Enabled = true;
                btnSave.Enabled = true;
            }

            txtUsername.Text = "";
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";
            chkIsActive.Checked = true;
        }
        private void _LoadData()
        {
            _User = clsUser.FindByUserID( _UserID );
            ctrlPersonInfoCardWithFilter1.FilterEnabled = false;

            if (_User == null)
            {
                MessageBox.Show("No User with ID = " + _UserID, "User Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }

            lblUserID.Text = _User.ID.ToString();
            txtUsername.Text = _User.Username;
            txtPassword.Text= _User.Password;
            txtConfirmPassword.Text = _User.Password;
            chkIsActive.Checked = _User.IsActive;
            ctrlPersonInfoCardWithFilter1.LoadPersonInfo(_User.PersonID);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro",
                "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            PopulateUserFromForm();

            if (_User.Save())
            {
                lblUserID.Text = _User.ID.ToString();

                _Mode = enMode.Update;
                lblMode.Text = "Update User";
                this.Text = "Update User";

                MessageBox.Show("Data saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Error: Data was not saved successfully!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void PopulateUserFromForm()
        {
            _User.PersonID = ctrlPersonInfoCardWithFilter1.PersonID;
            _User.Username = txtUsername.Text.Trim();
            _User.Password = txtPassword.Text.Trim();
            _User.IsActive = chkIsActive.Checked;
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtConfirmPassword.Text.Trim() != txtPassword.Text.Trim())
            {
                e.Cancel = true;
                errorProvider.SetError(txtConfirmPassword, "Password Confirmation does not match Password!");
            }
            else
                errorProvider.SetError(txtConfirmPassword, null);
        }
        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider.SetError(txtPassword, "Password cannot be blank");
            }
            else
                errorProvider.SetError(txtPassword, null);
        }
        private void txtUsername_Validating(object sender, CancelEventArgs e)
        {
            string username = txtUsername.Text.Trim();

            if (string.IsNullOrEmpty(username))
            {
                e.Cancel = true;
                errorProvider.SetError(txtUsername, "Username cannot be blank");
                return;
            }
            else
                errorProvider.SetError(txtUsername, null);

            if(_Mode == enMode.AddNew)
            {
                if (clsUser.IsUserExist(username))
                {
                    e.Cancel = true;
                    errorProvider.SetError(txtUsername, "username is used by another user");
                }
                else
                    errorProvider.SetError(txtUsername, null);
            }
            else
            {
                if(username != _User.Username)
                {
                    if(clsUser.IsUserExist(username))
                    {
                        e.Cancel = true;
                        errorProvider.SetError(txtUsername, "Username is used by another user");
                    }
                    else
                        errorProvider.SetError(txtUsername, null);
                }
            }
        }
        private void btnClose_Click(object sender, EventArgs e) => Close();
        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = chkShowPassword.Checked ? '\0' : '*';
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.Update)
            {
                btnSave.Enabled = true;
                tbLoginInfo.Enabled = true;
                txtPassword.Enabled = false;
                txtConfirmPassword.Enabled = false;
                chkShowPassword.Enabled = false;
                tcUserInfo.SelectedTab = tcUserInfo.TabPages["tbLoginInfo"];
                return;
            }

            //incase of add new mode.
            if (ctrlPersonInfoCardWithFilter1.PersonID != -1)
            {
                if (clsUser.IsUserExistForPersonID(ctrlPersonInfoCardWithFilter1.PersonID))
                {
                    MessageBox.Show("Selected Person already has a user, choose another one.", "Select another Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ctrlPersonInfoCardWithFilter1.FilterFocus();
                }
                else
                {
                    btnSave.Enabled = true;
                    tbLoginInfo.Enabled = true;
                    tcUserInfo.SelectedTab = tcUserInfo.TabPages["tbLoginInfo"];
                }
            }
            else
            {
                MessageBox.Show("Please Select a Person", "Select a Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrlPersonInfoCardWithFilter1.FilterFocus();
            }
        }
        private void FrmAddUpdateUserInfo_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();
            if (_Mode == enMode.Update) _LoadData();
        }
    }
}
