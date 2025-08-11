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
    public partial class FrmManageApplicationTypes : Form
    {
        private DataTable _dtAllApplicationTypes;
        public FrmManageApplicationTypes()
        {
            InitializeComponent();
        }
        private void _LoadApplicationTypes()
        {
            _dtAllApplicationTypes = clsApplicationTypes.GetAllApplicationTypes();
            dgvApplicatioTypesInfo.DataSource = _dtAllApplicationTypes;
            lblRecordsNumber.Text = dgvApplicatioTypesInfo.Rows.Count.ToString();
        }
        private void FrmManageApplicationTypes_Load(object sender, EventArgs e)
        {
            _LoadApplicationTypes();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void editApplicationTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUpdateApplicationTypes frm = new FrmUpdateApplicationTypes((int)dgvApplicatioTypesInfo.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _LoadApplicationTypes();
        }
    }
}
