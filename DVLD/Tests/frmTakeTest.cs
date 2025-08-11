using DVLD.Classes;
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

namespace DVLD.Tests
{
    public partial class frmTakeTest : Form
    {
        private int _TestID = -1;
        private clsTest _Test;
        private int _TestAppomintmentID = -1;
        private clsTestType.enTestType _TestType;


        public frmTakeTest(int TestAppomintmentID, clsTestType.enTestType TestType)
        {
            InitializeComponent();

            _TestAppomintmentID = TestAppomintmentID;
            _TestType = TestType;
        }

        private void frmTakeTest_Load(object sender, EventArgs e)
        {
            ctrlScheduledTest1.TestType = _TestType;
            ctrlScheduledTest1.LoadAppointmentData(_TestAppomintmentID);

            btnSave.Enabled = (ctrlScheduledTest1.TestAppointmentID == -1) ? false : true;

            _TestID = ctrlScheduledTest1.TestID;

            if(_TestID != -1)
            {
                _Test = clsTest.Find(_TestID);
                if(_Test.TestResult)
                    chkPass.Checked = true;
                else
                    chkFail.Checked = false;

                txtNotes.Text = _Test.Notes;

                lblUserMessage.Visible = true;
                chkPass.Enabled = false;
                chkFail.Enabled = false;
            }
            else
                _Test = new clsTest();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddNewTestAppointment_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to save? After that you cannot change the Pass/Fail results after you save?.",
                 "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                 return;

            _Test.TestAppointmentID = _TestAppomintmentID;
            _Test.Notes = txtNotes.Text.Trim();
            _Test.TestResult = chkPass.Checked;
            _Test.CreatedByUserID = Global.CurrentUser.ID;

            if(_Test.Save())
            {
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
