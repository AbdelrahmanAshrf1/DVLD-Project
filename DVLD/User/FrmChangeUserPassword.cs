using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_BusinessLayer;
using System.Runtime.CompilerServices;
using DVLD.Global_Classes;
using DVLD.Classes;

namespace DVLD
{
    public partial class FrmChangeUserPassword : Form
    {
        private int _UserID;
        private clsUser _User;
        public FrmChangeUserPassword(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;
        }
        private void _ResetDefualtValues()
        {
            txtCurrentPassword.Text = "";
            txtNewPassword.Text = "";
            txtConfirmPassword.Text = "";
            txtCurrentPassword.Focus();
        }
        private void FrmChangeUserPassword_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();

            _User = clsUser.FindByUserID(_UserID);

            if(_User == null)
            {
                MessageBox.Show("Could not Find User with id = " + _UserID,"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            ctrlUserCard1.LoadUserInfo(_UserID);
        }
        private void txtCurrentPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtCurrentPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider.SetError(txtCurrentPassword, "Password cannot be blank");
                return;
            }
            else
                errorProvider.SetError(txtCurrentPassword, null);
       

            if (!CryptoManager.VerifyPassword(_User.Password, txtCurrentPassword.Text.Trim()))
            {
                errorProvider.SetError(txtCurrentPassword, "Current password is wrong!");
                return;
            }
            else
                errorProvider.SetError(txtCurrentPassword, "");
        }
        private void txtNewPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNewPassword.Text.Trim()))
            {
                errorProvider.SetError(txtNewPassword, "Password cannot be blank");
                return;
            }
            else
                errorProvider.SetError(txtNewPassword, null);
        }
        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtConfirmPassword.Text.Trim() != txtNewPassword.Text.Trim())
            {
                e.Cancel = true;
                errorProvider.SetError(txtConfirmPassword, "Password Confirmation does not match New Password!");
                return;
            }
            else
                errorProvider.SetError(txtConfirmPassword, null);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro",
                "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _User.Password = txtNewPassword.Text.Trim();
            // Update Remeber me Credential
            Global.RememberUsernameAndPassword(_User.Username.ToString(), _User.Password.ToString());

            if (_User.Save())
            {
                MessageBox.Show("Password Changed Successfully.","Saved.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _ResetDefualtValues();
            }
            else
                MessageBox.Show("An Erro Occured, Password did not change.","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
          
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtNewPassword.PasswordChar = chkShowPassword.Checked ? '\0' : '*';
        }
    }
}
