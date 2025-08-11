using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows.Forms;
using DVLD.Classes;
using DVLD_BusinessLayer;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DVLD
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            clsUser user = clsUser.Authenticate(txtUsername.Text.Trim(), txtPassword.Text.Trim());

            if (user != null)
            {
              
                if(chkRememberMe.Checked)
                    Global.RememberUsernameAndPassword(txtUsername.Text.Trim(), txtPassword.Text.Trim());
                else
                    Global.RememberUsernameAndPassword("", "");


                if (!user.IsActive)
                {
                    MessageBox.Show("Your account is inactive. Please contact Admin.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Successful login
                Global.CurrentUser = user;
                this.Hide();
                FrmMain frm = new FrmMain(this);
                frm.FormClosed += (s, args) => this.Show();
                frm.ShowDialog();
            }
            else
            {
                txtUsername.Focus();
                MessageBox.Show("Incorrect username or password.", "Wrong Credentials", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            string Username = "", Password = "";

            if(Global.GetSortedCredential(ref Username,ref Password))
            {
                txtUsername.Text = Username;
                txtPassword.Text = Password;
                chkRememberMe.Checked = true;
            }
            else
                chkRememberMe.Checked = false;
        }

    }
}
