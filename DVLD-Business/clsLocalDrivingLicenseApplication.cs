using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DVLD_Buisness;
using DVLD_DataAccessLayer;

namespace DVLD_BusinessLayer
{
    public class clsLocalDrivingLicenseApplication : clsApplication
    {
        public enum enMode { AddNew = 0,Update = 1 }
        public enMode Mode = enMode.AddNew;
        public int LocalDrivingLicenseApplicationID {  get; set; }
        public int LicenseClassID { get; set; }
        public clsLicenseClass LicenseClassInfo;
        public string PersonFullName
        {
            get { return base.ApplicantFullName; }
        }

        public clsLocalDrivingLicenseApplication()
        {
            LocalDrivingLicenseApplicationID = -1;
            LicenseClassID = -1;

            Mode = enMode.AddNew;
        }
        private clsLocalDrivingLicenseApplication(
            int LocalDrivingLicenseApplicationID,
            int ApplicationID,
            int ApplicantPersonID,
            DateTime ApplicationDate,
            int ApplicationTypeID,
            enApplicationStatus ApplicationStatus,
            DateTime LastStatusDate,
            float PaidFees,
            int CreatedByUserID,
            int LicenseClassID) : base(ApplicationID, ApplicantPersonID, ApplicationDate, ApplicationTypeID, ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID)
        {
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.LicenseClassID = LicenseClassID;
            this.LicenseClassInfo = clsLicenseClass.Find(LicenseClassID);
            Mode = enMode.Update;
        }

        public static clsLocalDrivingLicenseApplication FindByLocalDrivingLicenseID(int LocalDrivingLicenseApplicationID)
        {
            int ApplicationID = -1, LicenseID = -1;

            bool IsFound = LocalDrivingLicenseApplicationData.GetLocalDrivingLicenseApplicationInfoByID(
                LocalDrivingLicenseApplicationID, ref ApplicationID, ref LicenseID);

            if (IsFound)
            {
                clsApplication application = clsApplication.FindBaseApplication(ApplicationID);

                if (application != null)
                {
                    return new clsLocalDrivingLicenseApplication(
                        LocalDrivingLicenseApplicationID,
                        application.ApplicationID,
                        application.ApplicantPersonID,
                        application.Date,
                        application.ApplicationTypeID,
                        application.Status,
                        application.LastStatusDate,
                        application.PaidFees,
                        application.CreatedByUserID,
                        LicenseID
                    );
                }
            }

            return null;
        }
        public static clsLocalDrivingLicenseApplication FindByApplicationID(int ApplicationID)
        {
            int LocalDrivingLicenseApplicationID = -1, LicenseID = -1;

            bool IsFound = LocalDrivingLicenseApplicationData.GetLocalDrivingLicenseApplicationInfoByApplicationID(
                ApplicationID, ref LocalDrivingLicenseApplicationID, ref LicenseID);

            if (IsFound)
            {
                clsApplication application = clsApplication.FindBaseApplication(ApplicationID);

                if (application != null)
                {
                    return new clsLocalDrivingLicenseApplication(
                        LocalDrivingLicenseApplicationID,
                        application.ApplicationID,
                        application.ApplicantPersonID,
                        application.Date,
                        application.ApplicationTypeID,
                        application.Status,
                        application.LastStatusDate,
                        application.PaidFees,
                        application.CreatedByUserID,
                        LicenseID
                    );
                }
            }

            return null;
        }
        private bool _AddNewLocalDrivingLicenseApplication()
        {
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationData.AddNewLocalDrivingLicenseApplication(this.ApplicationID, this.LicenseClassID);
            return (this.LocalDrivingLicenseApplicationID != -1);
        }
        private bool _UpdateLocalDrivingLicenseApplication()
        {
            return LocalDrivingLicenseApplicationData.UpdateLocalDrivingLicenseApplication(this.LocalDrivingLicenseApplicationID, this.ApplicationID, this.LicenseClassID);
        }
        public static bool Delete(int LocalDrivingLicenseApplicationID)
        {
            int LicenseClassID = -1, ApplicationID = -1;

            if(!LocalDrivingLicenseApplicationData.GetLocalDrivingLicenseApplicationInfoByID(
                LocalDrivingLicenseApplicationID,ref ApplicationID,ref LicenseClassID))
                return false;

            if(!LocalDrivingLicenseApplicationData.DeleteLocalDrivingLicenseApplication(LocalDrivingLicenseApplicationID)) return false;

            return clsApplication.Delete(ApplicationID);
        }
        public bool Save()
        {
            base.Mode = (clsApplication.enMode)Mode;
            if(!base.Save()) return false;

            switch(Mode)
            {
                case enMode.AddNew:
                    {
                        if (_AddNewLocalDrivingLicenseApplication())
                        {
                            Mode = enMode.Update;
                            return true;
                        }
                        else
                            return false;
                    }

                case enMode.Update:
                    {
                        return _UpdateLocalDrivingLicenseApplication();
                    }
            }

            return false;
        }
        public static DataTable GetAllLocalDrivingLicenseApplications()
        {
            return LocalDrivingLicenseApplicationData.GetAllLocalDrivingLicenseApplications();
        }
        public static bool IsThereAnActiveScheduledTest(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestType)
        {
            return LocalDrivingLicenseApplicationData.IsThereAnActiveScheduledTest(LocalDrivingLicenseApplicationID, (int)TestType);
        }
        public bool IsThereAnActiveScheduledTest(clsTestType.enTestType TestType)
        {
            return LocalDrivingLicenseApplicationData.IsThereAnActiveScheduledTest(this.LocalDrivingLicenseApplicationID, (int)TestType);
        }
        public clsTest GetLastTestPerTestType(clsTestType.enTestType TestTypeID)
        {
            return clsTest.FindLastTestPerPersonAndLicenseClass(this.ApplicantPersonID,this.LicenseClassID, TestTypeID);
        }
        public byte TotalTrialsPerTest(clsTestType.enTestType TestType)
        {
            return LocalDrivingLicenseApplicationData.TotalTrialsPerTest(this.LocalDrivingLicenseApplicationID,(int)TestType);
        }
        public bool DoesAttendTestType(clsTestType.enTestType TestType)
        {
            return LocalDrivingLicenseApplicationData.DoesAttendTestType(this.LocalDrivingLicenseApplicationID, (int)TestType);
        }
        public byte GetPassedTestCount()
        {
            return LocalDrivingLicenseApplicationData.GetPassedTestCount(this.LocalDrivingLicenseApplicationID);
        }
        public bool DoesPassTestType( clsTestType.enTestType TestTypeID)
        {
            return LocalDrivingLicenseApplicationData.DoesPassTestType(this.LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }
        public static bool DoesPassTestType(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID)
        {
            return LocalDrivingLicenseApplicationData.DoesPassTestType(LocalDrivingLicenseApplicationID,(int)TestTypeID);
        }
        public bool PassedAllTests()
        {
            return clsTest.PassedAllTests(this.LocalDrivingLicenseApplicationID);
        }
        public int GetActiveLicenseID()
        {
            return clsLicense.GetActiveLicenseIDByPersonID(this.ApplicantPersonID, this.LicenseClassID);
        }
        public bool IsLicenseIssued()
        {
            return (GetActiveLicenseID() != -1);
        }
        public int issueLicenseForTheFirstTime(string Note , int CreatedByUserID)
        {
            int DriverID = -1;

            // Check if the Driver already exist for this Person.
            clsDriver Driver = clsDriver.FindByPersonID(this.ApplicantPersonID);

            if (Driver == null)
            {
                Driver = new clsDriver();

                Driver.PersonID = this.ApplicantPersonID;
                Driver.CreatedByUserID = CreatedByUserID;

                DriverID = (Driver.Save()) ? Driver.DriverID : -1;
            }
            else
                DriverID = Driver.DriverID;

            clsLicense Licnese = new clsLicense();

            Licnese.ApplicationID = this.ApplicationID;
            Licnese.DriverID = DriverID;
            Licnese.IssueDate = DateTime.Now;
            Licnese.LicenseClassID = this.LicenseClassID;
            Licnese.CreatedByUserID = CreatedByUserID;
            Licnese.ExpirationDate = DateTime.Now.AddYears(LicenseClassInfo.DefaultValidityLength);
            Licnese.IssueReason = clsLicense.enIssueReason.FirstTime;
            Licnese.PaidFees = LicenseClassInfo.ClassFees;
            Licnese.IsActive = true;
            Licnese.Notes = Note;

            if(Licnese.Save())
            {
                this.SetCompelete();
                return Licnese.DriverID;
            }
            else
                return -1;
        }
    }
}
