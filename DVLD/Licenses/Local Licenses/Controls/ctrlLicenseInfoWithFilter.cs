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

namespace DVLD.Licenses.Local_Licenses.Controls
{
    public partial class ctrlLicenseInfoWithFilter : UserControl
    { 
        // Define a custom event handler delegate with parameters
        public event Action<int> OnLicenseSelected;
        // Create a protected method to raise the event with a parameter
        protected virtual void LicenseSelected(int PersonID)
        {
            Action<int> handler = OnLicenseSelected;
            if (handler != null)
            {
                handler(PersonID); // Raise the event with the parameter
            }
        }

        private bool _FilterEnabled = true;
        public bool FilterEnabled
        {
            get { return _FilterEnabled; }
            set 
            { 
                _FilterEnabled = value;
                gbFilter.Enabled = _FilterEnabled;
            }
        }

        private int _LicenseID = -1;
        public int LicenseID { get { return ctrlLicenseInfo1.LicenseID; } }
        public clsLicense SelectedLicenseInfo { get { return ctrlLicenseInfo1.SelectedLicenseInfo; } }
        public void LoadLicenseInfo(int LicenseID)
        {
            txtLicenseID.Text = LicenseID.ToString();
            ctrlLicenseInfo1.LoadLicenseInfo(LicenseID);
            _LicenseID = ctrlLicenseInfo1.LicenseID;

            if (SelectedLicenseInfo == null)
            {
                // License not found, raise event with -1
                if (OnLicenseSelected != null && FilterEnabled)
                    OnLicenseSelected(-1);
                return;
            }

            // License found
            if (OnLicenseSelected != null && FilterEnabled)
                OnLicenseSelected(LicenseID);
        }
        public ctrlLicenseInfoWithFilter()
        {
            InitializeComponent();
        }
        private void btnFind_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _LicenseID = int.Parse(txtLicenseID.Text);
            LoadLicenseInfo(_LicenseID);
        }
        public void TxtLicenseIDFoucs()
        {
            txtLicenseID.Focus();
        }
        private void txtLicenseID_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            if(e.KeyChar == (char)13) btnFind.PerformClick(); // Check if Pressed key is Enter (13).
        }
        private void txtLicenseID_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtLicenseID.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtLicenseID, "This field is required!");
            }
            else
                errorProvider1.SetError(txtLicenseID,null);
        }
    }
}
