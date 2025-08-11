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

namespace DVLD
{
    public partial class ctrlUserCard : UserControl
    {
        private clsUser _User;
        private int _UserID = -1;

        public int UserID
        {
            get { return  _UserID; }
        }
        public ctrlUserCard()
        {
            InitializeComponent();
        }

        public void LoadUserInfo(int UserID)
        {
             _UserID = UserID;
             _User = clsUser.FindByUserID(UserID);
            
            if (_User == null)
            {
                _ResetPersonInfo();
                MessageBox.Show("No User with UserID = " + UserID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _PopulateUserInfo();
        }

        private void _PopulateUserInfo()
        {
            ctrlPersonCard1.LoadPersonInfo(_User.PersonID);

            lblUserID.Text = _User.ID.ToString();
            lblUsername.Text = _User.Username.ToString();
            lblIsActive.Text = _User.IsActive ? "Yes" : "No";
        }

        private void _ResetPersonInfo()
        {
            ctrlPersonCard1.ResetPersonInfo();
            lblUserID.Text = "??";
            lblUsername.Text = "??";
            lblIsActive.Text = "??";
        }
            
    }
}
