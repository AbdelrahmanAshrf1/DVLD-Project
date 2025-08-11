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

namespace DVLD
{
    public partial class FrmUserManagement : Form
    {
        private static DataTable _dtAllUsers;
        public FrmUserManagement()
        {
            InitializeComponent();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void FrmUserManagement_Load(object sender, EventArgs e)
        {
            _dtAllUsers = clsUser.GetAllUsers();
            dgvUsersInfo.DataSource = _dtAllUsers;
            cbFilteredBy.SelectedIndex = 0;
            lblRecordsNumber.Text = dgvUsersInfo.Rows.Count.ToString();
            txtFilterBy.Visible = false;
            cbIsActive.Visible = false;
        }
        private void cbFilteredBy_SelectedIndexChanged(object sender, EventArgs e)
        {
           if(cbFilteredBy.Text == "Is Active")
           {
                txtFilterBy.Visible = false;
                cbIsActive.Visible = true;
                cbIsActive.Focus();
                cbIsActive.SelectedIndex = 0;
           }
           else
           {
                txtFilterBy.Visible = (cbFilteredBy.Text != "None");
                cbIsActive.Visible = false;
                txtFilterBy.Text = "";
                txtFilterBy.Focus();
           }
        }
        private void txtFilterBy_TextChanged(object sender, EventArgs e)
        {
           string FilterColumn = "";

           switch(cbFilteredBy.Text)
           {
                case "User ID":
                    FilterColumn = "UserID";
                    break;

                case "Username":
                    FilterColumn = "Username";
                    break;

                case "Person ID":
                    FilterColumn = "PersonID";
                    break;

                case "Full Name":
                    FilterColumn = "FullName";
                    break;

                default:
                    FilterColumn = "None";
                    break;
           }

            if(txtFilterBy.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtAllUsers.DefaultView.RowFilter = "";
                lblRecordsNumber.Text = _dtAllUsers.Rows.Count.ToString();
                return;
            }

            if (FilterColumn != "FullName" && FilterColumn != "Username")
                _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterBy.Text.Trim());
            else
                _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] Like '{1}%'", FilterColumn, txtFilterBy.Text.Trim());

            lblRecordsNumber.Text = _dtAllUsers.DefaultView.Count.ToString();
        }
        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumn = "IsActive";
            string FilterValue = cbIsActive.Text;
            switch (FilterValue)
            {
                case "All":
                    break;

                case "Yes":
                    FilterValue = "1";
                    break;

                case "No":
                    FilterValue = "0";
                    break;
            }

            if (FilterValue == "All")
                _dtAllUsers.DefaultView.RowFilter = "";
            else
                _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, FilterValue);

            lblRecordsNumber.Text = _dtAllUsers.DefaultView.Count.ToString();
        }
        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            FrmAddUpdateUserInfo frm = new FrmAddUpdateUserInfo();
            frm.ShowDialog();
            FrmUserManagement_Load(null, null);
        }
        private void editToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int UserID = (int)dgvUsersInfo.CurrentRow.Cells[0].Value;

            FrmAddUpdateUserInfo frm = new FrmAddUpdateUserInfo(UserID);
            frm.ShowDialog();
            FrmUserManagement_Load(null, null);
        }
        private void addNewPersonToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FrmAddUpdateUserInfo frm = new FrmAddUpdateUserInfo();
            frm.ShowDialog();
            FrmUserManagement_Load(null, null);
        }
        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int UserID = (int)dgvUsersInfo.CurrentRow.Cells[0].Value;

            if(clsUser.DeleteUser(UserID))
                MessageBox.Show("User deleted successfully", "Process", MessageBoxButtons.OK);
            else
                MessageBox.Show("Error : User doesn't deleted successfully", "Process", MessageBoxButtons.OK);

            FrmUserManagement_Load(null, null);
        }
        private void featureNotImplementedYet(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature is not implemented yet!", "Not ready", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int UserID = (int)dgvUsersInfo.CurrentRow.Cells[0].Value;

            FrmChangeUserPassword frm = new FrmChangeUserPassword(UserID);
            frm.ShowDialog();
            FrmUserManagement_Load(null, null);
        }

        private void cmsShowDetailsItem_Click(object sender, EventArgs e)
        {
            int UserID = (int)dgvUsersInfo.CurrentRow.Cells[0].Value;
            FrmShowUserInfo frm = new FrmShowUserInfo(UserID);
            frm.ShowDialog();
        }

        private void txtFilterBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(cbFilteredBy.Text == "Person ID" || cbFilteredBy.Text == "User ID")
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void dgvUsersInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
