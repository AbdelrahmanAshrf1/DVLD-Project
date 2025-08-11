using DVLD.Licenses.International_License;
using DVLD.Licenses.Local_Licenses;
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

namespace DVLD.Licenses.Controls
{
    public partial class ctrlDriverLicenses : UserControl
    {
        private int _DriverID = -1;
        private clsDriver _DriverInfo = null;
        private DataTable _dtLocalDriverLicensesHistory;
        private DataTable _dtInternationalDriverLicensesHistory;
        public ctrlDriverLicenses()
        {
            InitializeComponent();
        }
        private void _LoadLocalDriverLicenses()
        {
            _dtLocalDriverLicensesHistory = clsDriver.GetLicense(_DriverID);
            dgvLocalLicensesHistory.DataSource = _dtLocalDriverLicensesHistory;
            lblLocalLicensesRecords.Text = _dtLocalDriverLicensesHistory.Rows.Count.ToString();

            if(_dtLocalDriverLicensesHistory.Rows.Count > 0)
            {
                dgvLocalLicensesHistory.Columns[0].HeaderText = "Lic.ID";
                dgvLocalLicensesHistory.Columns[1].HeaderText = "App.ID";
                dgvLocalLicensesHistory.Columns[2].HeaderText = "Class Name";
                dgvLocalLicensesHistory.Columns[3].HeaderText = "Issue Date";
                dgvLocalLicensesHistory.Columns[4].HeaderText = "Expiration Date";
                dgvLocalLicensesHistory.Columns[5].HeaderText = "Is Active";
            }
        }
        private void _LoadInternationalDriverLicenses()
        {
            _dtInternationalDriverLicensesHistory = clsDriver.GetDriverInternationalLicenses( _DriverID);
            dgvInternationalLicensesHistory.DataSource = _dtInternationalDriverLicensesHistory;
            lblInternationalLicensesRecords.Text = _dtInternationalDriverLicensesHistory.Rows.Count.ToString();

            if(_dtInternationalDriverLicensesHistory.Rows.Count > 0)
            {
                dgvInternationalLicensesHistory.Columns[0].HeaderText = "Int.License ID";
                dgvInternationalLicensesHistory.Columns[1].HeaderText = "Application ID";
                dgvInternationalLicensesHistory.Columns[2].HeaderText = "L.License ID";
                dgvInternationalLicensesHistory.Columns[3].HeaderText = "Issue Date";
                dgvInternationalLicensesHistory.Columns[4].HeaderText = "Expiration Date";
                dgvInternationalLicensesHistory.Columns[5].HeaderText = "Is Active";
            }
        }
        public void LoadInfoByDriverID(int DriverID)
        {
            _DriverID = DriverID;
            _DriverInfo = clsDriver.FindByDriverID(DriverID);

            if(_DriverInfo == null)
            {
                MessageBox.Show("There is no Driver with ID " + _DriverID, "Wrong", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _LoadLocalDriverLicenses();
            _LoadInternationalDriverLicenses();
        }
        public void LoadInfoByPersonID(int PersonID)
        {
            _DriverInfo = clsDriver.FindByPersonID(PersonID);

            if (_DriverInfo == null)
            {
                MessageBox.Show("There is no Driver Linked with Person ID " + PersonID, "Wrong", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _DriverID = _DriverInfo.DriverID;

            _LoadLocalDriverLicenses();
            _LoadInternationalDriverLicenses();
        }
        public void Clear()
        {
            _dtLocalDriverLicensesHistory.Clear();
            _dtInternationalDriverLicensesHistory.Clear();
        }
        private void dgvInternationalLicensesHistory_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; //  header

            object value = dgvInternationalLicensesHistory.Rows[e.RowIndex].Cells[0].Value;
            if (value == null) return; // ignore empty cells

            int id = Convert.ToInt32(value);
            frmShowInternationalLicenseInfo frm = new frmShowInternationalLicenseInfo(id);
            frm.ShowDialog();
        }

        private void dgvLocalLicensesHistory_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int LicenseID = (int)dgvLocalLicensesHistory.CurrentRow.Cells[0].Value;
            frmShowLicenseInfo frm = new frmShowLicenseInfo(LicenseID);
            frm.ShowDialog();
        }
    }
}
