using DVLD_Buisness;
using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer
{
    public class clsLicense
    {
        public enum enMode { AddNew = 0, Update = 1 }; 
        public enMode Mode = enMode.AddNew;

        public enum enIssueReason { FirstTime = 1, Renew = 2, DamagedReplacement = 3, LostReplacement = 4 }
        public enIssueReason IssueReason = enIssueReason.FirstTime;

        public int LicenseID {  get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public clsDriver DriverInfo;
        public int LicenseClassID { get; set; }
        public clsLicenseClass LicenseClassInfo;
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Notes { get; set; }
        public float PaidFees { get; set; }
        public bool IsActive { get; set; }
        public int CreatedByUserID { get; set; }
        public clsUser CreatedByUserInfo;
        public string IssueReasonText
        {
            get
            {
                switch (IssueReason)
                {
                    case enIssueReason.FirstTime:
                        return "FirstTime";
                    case enIssueReason.Renew:
                        return "Renew";
                    case enIssueReason.DamagedReplacement:
                        return "DamagedReplacement";
                    case enIssueReason.LostReplacement:
                        return "LostReplacement";
                    default:
                        return "FirstTime";
                }
            }
        }
        public clsDetainedLicense DetainedLicenseInfo { get; set; }
        public bool IsDetained
        {
            get { return clsDetainedLicense.IsLicenseDetained(this.LicenseID); }
        }
        public clsLicense()
        {
            this.LicenseID = -1;
            this.ApplicationID = -1;
            this.DriverID = -1;
            this.DriverInfo = null;
            this.LicenseClassID = -1;
            this.LicenseClassInfo = null;
            this.IssueDate = DateTime.Now;
            this.ExpirationDate = DateTime.Now;
            this.Notes = "";
            this.PaidFees = 0;
            this.IsActive = true;
            this.IssueReason = enIssueReason.FirstTime;
            this.CreatedByUserID = -1;
            this.CreatedByUserInfo = null;

            Mode = enMode.AddNew;
        }
        public clsLicense(int LicenseID, int ApplicationID, int DriverID, int LicenseClass,
            DateTime IssueDate, DateTime ExpirationDate, string Notes,
            float PaidFees, bool IsActive, enIssueReason IssueReason, int CreatedByUserID)
        {
            this.LicenseID = LicenseID;
            this.ApplicationID = ApplicationID;
            this.DriverID = DriverID;
            this.LicenseClassID = LicenseClass;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.Notes = Notes;
            this.PaidFees = PaidFees;
            this.IsActive = IsActive;
            this.IssueReason = IssueReason;
            this.CreatedByUserID = CreatedByUserID;

            this.DriverInfo = clsDriver.FindByDriverID(this.DriverID);
            this.LicenseClassInfo = clsLicenseClass.Find(this.LicenseClassID);
            this.CreatedByUserInfo = clsUser.FindByUserID(this.CreatedByUserID);
            this.DetainedLicenseInfo = clsDetainedLicense.FindByLicenseID(this.LicenseID);

            Mode = enMode.Update;
        }

        private bool _AddNewLicense()
        {
            this.LicenseID = LicenseData.AddNewLicense(this.ApplicationID, this.DriverID,
                                                       this.LicenseClassID, this.IssueDate,
                                                       this.ExpirationDate, this.Notes,
                                                       this.PaidFees, this.IsActive,
                                                       (byte)this.IssueReason, this.CreatedByUserID);
            return (this.LicenseID != -1);
        }
        private bool _UpdateLicense()
        {
            return LicenseData.UpdateLicense(this.LicenseID, this.ApplicationID,
                                             this.DriverID, this.LicenseClassID,
                                             this.IssueDate, this.ExpirationDate,
                                             this.Notes, this.PaidFees,
                                             this.IsActive, (byte)this.IssueReason,
                                             this.CreatedByUserID);
        }
        public bool Save()
        {
            switch(this.Mode)
            {
                case enMode.AddNew:
                    {
                        if(_AddNewLicense())
                        {
                            this.Mode = enMode.Update;
                            return true;
                        }
                        else
                            return false;
                    }

                case enMode.Update:
                    {
                        return _UpdateLicense();
                    }
            }

            return false;
        }
        public static clsLicense Find(int LicenseID)
        {
            byte IssueReason = 1;
            string Notes = ""; float PaidFees = 0; bool IsActive = false;
            DateTime IssueDate = DateTime.Now, ExpirationDate = DateTime.Now;
            int ApplicationID = -1, DriverID = -1, LicenseClassID = -1, CreatedByUserID = -1;    

            if(LicenseData.GetLicenseInfoByID(LicenseID,ref ApplicationID, ref DriverID, ref LicenseClassID,
            ref IssueDate,ref ExpirationDate, ref  Notes,ref PaidFees,ref IsActive, ref IssueReason, ref CreatedByUserID))
                return new clsLicense(LicenseID, ApplicationID, DriverID, LicenseClassID,
             IssueDate,  ExpirationDate,  Notes,  PaidFees,  IsActive,(enIssueReason)IssueReason, CreatedByUserID);
            else
                return null;
        }
        public static DataTable GetAllLicenses()
        {
            return LicenseData.GetAllLicenses();   
        }
        public static int GetActiveLicenseIDByPersonID(int PersonID,int LicenseClassID)
        {
            return LicenseData.GetActiveLicenseIDByPersonID(PersonID, LicenseClassID);
        }
        public static bool IsLicenseClassExistByPersonID(int PersonID, int LicenseClassID)
        {
            return (GetActiveLicenseIDByPersonID(PersonID,LicenseClassID) != -1);
        }
        public static DataTable GetAllDriverLicenses(int DriverID)
        {
            return LicenseData.GetAllDriverLicenses(DriverID);
        }
        public Boolean IsLicenseExpired()
        {
            return this.ExpirationDate < DateTime.Now;
        }
        public bool DeactivedCurrentLicense()
        {
            return LicenseData.DeactivateLicense(this.LicenseID);
        }
        public int Detain(float FineFees,int CreatedByUserID)
        {
            clsDetainedLicense DetainedLicense = new clsDetainedLicense();

            DetainedLicense.LicenseID = this.LicenseID;
            DetainedLicense.DetainDate = DateTime.Now;
            DetainedLicense.FineFees = FineFees;
            DetainedLicense.CreatedByUserID = CreatedByUserID;

            if (!DetainedLicense.Save()) return -1;

            return DetainedLicense.DetainID;
        }
        public clsLicense RenewLicense(string Notes , int CreatedByUserID)
        {
            clsApplication Application = new clsApplication();

            Application.ApplicantPersonID = this.DriverInfo.PersonID;
            Application.Date = DateTime.Now;
            Application.ApplicationTypeID = (int)clsApplication.enApplicationType.RenewDrivingLicense;
            Application.Status = clsApplication.enApplicationStatus.Completed;
            Application.LastStatusDate = DateTime.Now;
            Application.PaidFees = clsApplicationTypes.Find((int)clsApplication.enApplicationType.RenewDrivingLicense).Fees;
            Application.CreatedByUserID = CreatedByUserID;

            if (!Application.Save()) return null;

            clsLicense NewLicense = new clsLicense();

            NewLicense.ApplicationID = Application.ApplicationID;
            NewLicense.DriverID = this.DriverID;
            NewLicense.LicenseClassID = this.LicenseClassID;
            NewLicense.IssueDate = DateTime.Now;
            int DefaultValidityLength = this.LicenseClassInfo.DefaultValidityLength;
            NewLicense.ExpirationDate = DateTime.Now.AddYears(DefaultValidityLength);
            NewLicense.Notes = Notes;
            NewLicense.PaidFees = this.LicenseClassInfo.ClassFees;
            NewLicense.IsActive = true;
            NewLicense.IssueReason = clsLicense.enIssueReason.Renew;
            NewLicense.CreatedByUserID = CreatedByUserID;

            if(!NewLicense.Save()) return null;

            DeactivedCurrentLicense(); // Deactivate the old License.

            return NewLicense;
        }
        public clsLicense Replace(enIssueReason IssueReason, int CreatedByUserID)
        {
            clsApplication Application = new clsApplication();

            Application.ApplicantPersonID = this.DriverInfo.PersonID;
            Application.Date = DateTime.Now;
            Application.ApplicationTypeID = (IssueReason == enIssueReason.DamagedReplacement) ?
            (int)clsApplication.enApplicationType.ReplaceDamagedDrivingLicense :
            (int)clsApplication.enApplicationType.ReplaceLostDrivingLicense;
            Application.Status = clsApplication.enApplicationStatus.Completed;
            Application.LastStatusDate = DateTime.Now;
            Application.PaidFees = clsApplicationTypes.Find((int)clsApplication.enApplicationType.RenewDrivingLicense).Fees;
            Application.CreatedByUserID = CreatedByUserID;

            if (!Application.Save()) return null;

            clsLicense NewLicense = new clsLicense();

            NewLicense.ApplicationID = Application.ApplicationID;
            NewLicense.DriverID = this.DriverID;
            NewLicense.LicenseClassID = this.LicenseClassID;
            NewLicense.IssueDate = DateTime.Now;
            NewLicense.ExpirationDate = this.ExpirationDate;
            NewLicense.Notes = Notes;
            NewLicense.PaidFees = 0;// No fees for the license because it's a replacement.
            NewLicense.IsActive = true;
            NewLicense.IssueReason = IssueReason;
            NewLicense.CreatedByUserID = CreatedByUserID;

            if (!NewLicense.Save()) return null;

            DeactivedCurrentLicense(); // Deactivate the old License.

            return NewLicense;
        }
        public bool ReleaseDetainedLicense(int ReleasedByUserID,ref int ApplicationID)
        {
            clsApplication Application = new clsApplication();

            Application.ApplicantPersonID = this.DriverInfo.PersonID;
            Application.Date = DateTime.Now;
            Application.ApplicationTypeID = (int)clsApplication.enApplicationType.ReleaseDetainedDrivingLicsense;
            Application.Status = clsApplication.enApplicationStatus.Completed;
            Application.LastStatusDate = DateTime.Now;
            Application.PaidFees = clsApplicationTypes.Find((int)clsApplication.enApplicationType.ReleaseDetainedDrivingLicsense).Fees;
            Application.CreatedByUserID = CreatedByUserID;

            if (!Application.Save()) return false;

            ApplicationID = Application.ApplicationID;

           return this.DetainedLicenseInfo.ReleaseDetainedLicense(ReleasedByUserID, Application.ApplicationID);
        }
    }
}
