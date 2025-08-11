using DVLD.Licenses;
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

namespace DVLD.Drivers
{
    public partial class frmDriversManagement : Form
    {
        private DataTable _AllDriversList;
        public frmDriversManagement()
        {
            InitializeComponent();
        }
        private void _LoadDriversData()
        {
            _AllDriversList = clsDriver.GetAllDrivers();
            dgvDriversInfo.DataSource = _AllDriversList;
            lblRecordsNumber.Text = dgvDriversInfo.RowCount.ToString();
            cbFilteredBy.SelectedIndex = 0;
            txtFilterValue.Visible = false;

            if(dgvDriversInfo.Rows.Count > 0 )
            {
                dgvDriversInfo.Columns[0].HeaderText = "Driver ID";
                dgvDriversInfo.Columns[1].HeaderText = "Person ID";
                dgvDriversInfo.Columns[2].HeaderText = "National No";
                dgvDriversInfo.Columns[3].HeaderText = "Full Name";
                dgvDriversInfo.Columns[4].HeaderText = "Date";
                dgvDriversInfo.Columns[5].HeaderText = "Active Licenses";
            }
        }
        private void frmDriversManagement_Load(object sender, EventArgs e)
        {
            _LoadDriversData();
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            //Map Selected Filter to real Column name 
            switch (cbFilteredBy.Text)
            {
                case "Driver ID":
                    FilterColumn = "DriverID";
                    break;

                case "Person ID":
                    FilterColumn = "PersonID";
                    break;

                case "National No":
                    FilterColumn = "NationalNo";
                    break;


                case "Full Name":
                    FilterColumn = "FullName";
                    break;

                default:
                    FilterColumn = "None";
                    break;

            }

            //Reset the filters in case nothing selected or filter value conains nothing.
            if (txtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                _AllDriversList.DefaultView.RowFilter = "";
                lblRecordsNumber.Text = dgvDriversInfo.Rows.Count.ToString();
                return;
            }


            if (FilterColumn != "FullName" && FilterColumn != "NationalNo")
                //in this case we deal with numbers not string.
                _AllDriversList.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            else
                _AllDriversList.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());

            lblRecordsNumber.Text = _AllDriversList.Rows.Count.ToString();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilteredBy.Text == "Driver ID" || cbFilteredBy.Text == "Person ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void showPersonInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = (int)dgvDriversInfo.CurrentRow.Cells[1].Value;
            FrmShowPersonInfo frm = new FrmShowPersonInfo(PersonID);
            frm.ShowDialog();
            _LoadDriversData(); //refresh
        }

        private void cbFilteredBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Visible = cbFilteredBy.Text != "None";
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = (int)dgvDriversInfo.CurrentRow.Cells[1].Value;
            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(PersonID);
            frm.ShowDialog();
        }
    }
}
