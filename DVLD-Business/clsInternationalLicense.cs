using System;
using System.Data;
using DVLD_Buisness;
using DVLD_BusinessLayer;
using DVLD_DataAccessLayer;

namespace DVLD_Business
{
    public class clsInternationalLicense
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode = enMode.AddNew;

        public int InternationalLicenseID { get; set; }
        public int DriverID { get; set; }
        public int IssuedUsingLocalLicenseID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsActive { get; set; }
        public int CreatedByUserID { get; set; }
        public clsDriver DriverInfo { get; private set; }
        public clsApplication ApplicationInfo { get; set; }
        public clsInternationalLicense()
        {
            this.InternationalLicenseID = -1;
            this.DriverID = -1;
            this.IssuedUsingLocalLicenseID = -1;
            this.IssueDate = DateTime.Now;
            this.ExpirationDate = DateTime.Now;
            this.IsActive = true;
            this.CreatedByUserID = -1;
            this.DriverInfo = null;
            this.ApplicationInfo = new clsApplication{ ApplicationTypeID = (int)clsApplication.enApplicationType.NewInternationalLicense};

            Mode = enMode.AddNew;
        }

        private clsInternationalLicense(int internationalLicenseID, int applicationID, int driverID,
        int issuedUsingLocalLicenseID, DateTime issueDate, DateTime expirationDate, bool isActive, int createdByUserID)
        {
            this.InternationalLicenseID = internationalLicenseID;
            this.DriverID = driverID;
            this.IssuedUsingLocalLicenseID = issuedUsingLocalLicenseID;
            this.IssueDate = issueDate;
            this.ExpirationDate = expirationDate;
            this.IsActive = isActive;
            this.CreatedByUserID = createdByUserID;
            this.DriverInfo = clsDriver.FindByDriverID(driverID);
            this.ApplicationInfo = clsApplication.FindBaseApplication(applicationID);

            Mode = enMode.Update;
        }

        private bool _AddNewInternationalLicense()
        {
            this.InternationalLicenseID = InternationalLicenseData.AddNewInternationalLicense(
                this.ApplicationInfo.ApplicationID,
                this.DriverID,
                this.IssuedUsingLocalLicenseID,
                this.IssueDate,
                this.ExpirationDate,
                this.IsActive,
                this.CreatedByUserID
            );

            return this.InternationalLicenseID != -1;
        }

        private bool _UpdateInternationalLicense()
        {
            return InternationalLicenseData.UpdateInternationalLicense(
                this.InternationalLicenseID,
                this.ApplicationInfo.ApplicationID,
                this.DriverID,
                this.IssuedUsingLocalLicenseID,
                this.IssueDate,
                this.ExpirationDate,
                this.IsActive,
                this.CreatedByUserID
            );
        }

        public bool Save()
        {
            this.ApplicationInfo.Mode = (clsApplication.enMode)this.Mode;

            if (!this.ApplicationInfo.Save()) return false;

            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewInternationalLicense())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return _UpdateInternationalLicense();
            }

            return false;
        }

        public static clsInternationalLicense Find(int internationalLicenseID)
        {
            int applicationID = -1, driverID = -1, issuedUsingLocalLicenseID = -1, createdByUserID = -1;
            DateTime issueDate = DateTime.MinValue, expirationDate = DateTime.MinValue;
            bool isActive = false;

            if (InternationalLicenseData.GetInternationalLicenseInfoByID(
                    internationalLicenseID,
                    ref applicationID,
                    ref driverID,
                    ref issuedUsingLocalLicenseID,
                    ref issueDate,
                    ref expirationDate,
                    ref isActive,
                    ref createdByUserID))
            {
                return new clsInternationalLicense(internationalLicenseID, applicationID, driverID,
                    issuedUsingLocalLicenseID, issueDate, expirationDate, isActive, createdByUserID);
            }

            return null;
        }

        public static DataTable GetAllInternationalLicenses()
        {
            return InternationalLicenseData.GetAllInternationalLicenses();
        }

        public static DataTable GetDriverInternationalLicenses(int driverID)
        {
            return InternationalLicenseData.GetDriverInternationalLicenses(driverID);
        }

        public static int GetActiveInternationalLicenseIDByDriverID(int driverID)
        {
            return InternationalLicenseData.GetActiveInternationalLicenseIDByDriverID(driverID);
        }
    }
}
