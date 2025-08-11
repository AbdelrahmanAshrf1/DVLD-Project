using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_Buisness;
using static System.Net.Mime.MediaTypeNames;
namespace DVLD.Applications.Controls
{
    public partial class ctrlApplicationBasicInfo : UserControl
    {
        private int _ApplicationID = -1;
        private clsApplication _Application;
        public int ApplicationID
        {
            get { return _ApplicationID; }
        }
        public ctrlApplicationBasicInfo()
        {
            InitializeComponent();
        }
        public void ResetDefaultValues()
        {
            _ApplicationID = -1;
            lblApplicationID.Text = "??";
            lblStatus.Text = "??";
            lblFees.Text = "??";
            lblType.Text = "??";
            lblApplicant.Text = "??";
            lblDate.Text = "??";
            lblStatusDate.Text = "??";
            lblCreatedBy.Text = "??";
        }
        private void _FillApplicationInfo()
        {
            _ApplicationID = _Application.ApplicationID;
            lblApplicationID.Text = _Application.ApplicationID.ToString();
            lblStatus.Text = _Application.Status.ToString();
            lblFees.Text = _Application.PaidFees.ToString();
            lblType.Text = _Application.ApplicationTypeInfo.Title;
            lblApplicant.Text = _Application.ApplicantFullName;
            lblDate.Text = _Application.Date.ToString();
            lblStatusDate.Text = _Application.LastStatusDate.ToString();
            lblCreatedBy.Text = _Application.CreatedByUserInfo.Username;
        }
        public void LoadApplicationInfo(int applicationID)
        {
            _Application = clsApplication.FindBaseApplication(applicationID);

            if (_Application == null)
            {
                ResetDefaultValues();
                MessageBox.Show("No Application with ApplicationID = " + applicationID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                _FillApplicationInfo();
        }
        private void lblViewPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmShowPersonInfo frm = new FrmShowPersonInfo(_Application.ApplicantPersonID);
            frm.ShowDialog();
            LoadApplicationInfo(_ApplicationID); // refresh
        }
    }
}
