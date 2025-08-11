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
    public partial class FrmManageTestTypes : Form
    {
        private DataTable _dtAllTestTypes;
        public FrmManageTestTypes()
        {
            InitializeComponent();
        }
        private void _LoadTestTypesList()
        {
            _dtAllTestTypes = clsTestType.GetAllTestTypes();
            dgvTestTypesInfo.DataSource = _dtAllTestTypes;
            lblRecordsNumber.Text = dgvTestTypesInfo.Rows.Count.ToString();
        }
        private void FrmManageTestTypes_Load(object sender, EventArgs e)
        {
            _LoadTestTypesList();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void editApplicationTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUpdateTestTypes frm = new FrmUpdateTestTypes((clsTestType.enTestType)dgvTestTypesInfo.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _LoadTestTypesList();
        }
    }
}
