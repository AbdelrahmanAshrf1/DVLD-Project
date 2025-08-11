using Guna.UI2.WinForms;
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
    public partial class FrmPeopleManagement : Form
    {
        private DataTable _dtOriginalPeopleTable;
        private DataTable _dtCustomPeopleView;
        private void _RefreshPeoplList()
        {
            _LoadPeopleDataTable();
        }

        private void _LoadPeopleDataTable()
        {
            _dtOriginalPeopleTable = clsPerson.GetAllPeople();
            _dtCustomPeopleView = _dtOriginalPeopleTable.DefaultView.ToTable(
            false, "PersonID", "NationalNo", "FirstName", "SecondName", "ThirdName",
            "LastName", "GenderCaption", "DateOfBirth", "CountryName", "Phone", "Email");

            dgvPeopleInfo.DataSource = _dtCustomPeopleView;
            lblRecordsNumber.Text = dgvPeopleInfo.Rows.Count.ToString();
        }
        public FrmPeopleManagement()
        {
            InitializeComponent();
            _LoadPeopleDataTable();
        }

        private void FrmPeopleManagement_Load(object sender, EventArgs e)
        {
            cbFilteredBy.SelectedIndex = 0;
            txtFilterValue.Visible = false;
            lblRecordsNumber.Text = dgvPeopleInfo.Rows.Count.ToString();
        }
        private void cbFilteredBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Visible = (cbFilteredBy.Text != "None");
            if (cbFilteredBy.Text != "None") txtFilterValue.Focus();
        }
        private void cmsShowDetailsItem_Click(object sender, EventArgs e)
        {
            int PersonID = (int)dgvPeopleInfo.CurrentRow.Cells[0].Value;
            FrmShowPersonInfo frm = new FrmShowPersonInfo(PersonID);
            frm.ShowDialog();
        }
        private void editToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int PersonID = (int)dgvPeopleInfo.CurrentRow.Cells[0].Value;
            FrmAddUpdatePerson frm = new FrmAddUpdatePerson(PersonID);
            frm.ShowDialog();
            _RefreshPeoplList();
        }
        private void featureNotImplementedYet(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature is not implemented yet!", "Not ready", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to delete Person [" + dgvPeopleInfo.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                int PersonID = (int)dgvPeopleInfo.CurrentRow.Cells[0].Value;
                if (clsPerson.DeletePerson(PersonID))
                    MessageBox.Show("Person deleted successfully", "Process", MessageBoxButtons.OK);
                else
                    MessageBox.Show("Error : Person doesn't deleted successfully", "Process", MessageBoxButtons.OK);
                _RefreshPeoplList();
            }
        }
        private void addNewPersonToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FrmAddUpdatePerson frm = new FrmAddUpdatePerson();
            frm.ShowDialog();
            _RefreshPeoplList();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            FrmAddUpdatePerson frm = new FrmAddUpdatePerson();
            frm.ShowDialog();
            _RefreshPeoplList();
        }
        private void txtFilterBy_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";

            switch (cbFilteredBy.Text)
            {

                case "Person ID":
                    FilterColumn = "PersonID";
                    break;

                case "National No":
                    FilterColumn = "NationalNo";
                    break;

                case "First Name":
                    FilterColumn = "FirstName";
                    break;

                case "Second Name":
                    FilterColumn = "SecondName";
                    break;

                case "Third Name":
                    FilterColumn = "ThirdName";
                    break;

                case "Last Name":
                    FilterColumn = "LastName";
                    break;

                case "Gender":
                    FilterColumn = "GenderCaption";
                    break;

                case "Phone":
                    FilterColumn = "Phone";
                    break;

                case "Email":
                    FilterColumn = "Email";
                    break;

                default:
                    FilterColumn = "None";
                    break;
            }

            if (txtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtCustomPeopleView.DefaultView.RowFilter = "";
                lblRecordsNumber.Text = dgvPeopleInfo.Rows.Count.ToString();
                return;
            }

            if (FilterColumn == "PersonID")
                _dtCustomPeopleView.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            else
                _dtCustomPeopleView.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());

            lblRecordsNumber.Text = dgvPeopleInfo.Rows.Count.ToString();
        }

        private void txtFilterBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(cbFilteredBy.Text == "Person ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
