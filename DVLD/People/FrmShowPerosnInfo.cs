using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_BusinessLayer;

namespace DVLD
{
    public partial class FrmShowPersonInfo : Form
    {
        public FrmShowPersonInfo(int PersonID)
        {
            InitializeComponent();
            ctrlPersonInfoCard1.LoadPersonInfo(PersonID);
        }

        public FrmShowPersonInfo(string NationalNo)
        {
            InitializeComponent();
            ctrlPersonInfoCard1.LoadPersonInfo(NationalNo);
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
