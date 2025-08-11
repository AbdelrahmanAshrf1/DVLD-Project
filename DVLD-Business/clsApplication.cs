using DVLD_BusinessLayer;
using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_Buisness
{
    public class clsApplication
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enum enApplicationType
        {
            NewDrivingLicense = 1, RenewDrivingLicense = 2, ReplaceLostDrivingLicense = 3,
            ReplaceDamagedDrivingLicense = 4, ReleaseDetainedDrivingLicsense = 5, NewInternationalLicense = 6, RetakeTest = 7
        };
        public enum enApplicationStatus { New = 1, Cancelled = 2, Completed = 3 };


        public enMode Mode = enMode.AddNew;
        public int ApplicationID { get; set; }
        public int ApplicantPersonID { get; set; }
        public clsPerson PersonInfo { get; set; }
        public string ApplicantFullName
        {
            get { return clsPerson.Find(ApplicantPersonID).FullName(); }
        }
        public DateTime Date { get; set; }
        public int ApplicationTypeID { get; set; }
        public clsApplicationTypes ApplicationTypeInfo;
        public enApplicationStatus Status { get; set; }
        public string StatusText
        {
            get
            {
                switch(Status)
                {
                    case enApplicationStatus.New:
                        return "New";
                    case enApplicationStatus.Cancelled:
                        return "Cancelled";
                    case enApplicationStatus.Completed:
                        return "Completed";
                    default:
                        return "Unknown";
                }
            }
        }
        public DateTime LastStatusDate { get; set; }
        public float PaidFees { get; set; }
        public int CreatedByUserID { get; set; }
        public clsUser CreatedByUserInfo;
   
        public clsApplication()
        {
            this.ApplicationID = -1;
            this.ApplicantPersonID = -1;
            this.Date = DateTime.Now;
            this.ApplicationTypeID = -1;
            this.Status = enApplicationStatus.New;
            this.LastStatusDate = DateTime.Now;
            this.PaidFees = 0;
            this.CreatedByUserID = -1;

            Mode = enMode.AddNew;
        }
        protected clsApplication(int ApplicationID, int ApplicantPersonID,DateTime ApplicationDate, int ApplicationTypeID,
             enApplicationStatus ApplicationStatus, DateTime LastStatusDate,float PaidFees, int CreatedByUserID)
        {
            this.ApplicationID = ApplicationID;
            this.ApplicantPersonID = ApplicantPersonID;
            this.PersonInfo = clsPerson.Find(ApplicantPersonID);
            this.Date = ApplicationDate;
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationTypeInfo = clsApplicationTypes.Find(ApplicationTypeID);
            this.Status = ApplicationStatus;
            this.LastStatusDate = LastStatusDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            CreatedByUserInfo = clsUser.FindByUserID(CreatedByUserID);

            Mode = enMode.Update;
        }
        private bool _AddNewApplication()
        {
            this.ApplicationID = ApplicationData.AddNewApplication(
                this.ApplicantPersonID, this.Date,this.ApplicationTypeID, (byte)this.Status,
                this.LastStatusDate, this.PaidFees, this.CreatedByUserID);
            return (this.ApplicationID != -1);
        }
        private bool _UpdateApplication()
        {
            return ApplicationData.UpdateApplication(this.ApplicationID, this.ApplicantPersonID, this.Date, this.ApplicationTypeID, (byte)this.Status,
                this.LastStatusDate, this.PaidFees, this.CreatedByUserID);
        }

        public static clsApplication FindBaseApplication(int ID)
        {
            int ApplicantPersonID = -1 , ApplicationTypeID = -1, CreatedByUserID = -1;
            DateTime ApplicationDate = DateTime.Now, LastStatusDate = DateTime.Now;
            byte ApplicationStatus = 1; float PaidFees = 0;

            if (ApplicationData.GetApplicationInfoByID(ID, ref ApplicantPersonID,
                                    ref ApplicationDate, ref ApplicationTypeID,
                                    ref ApplicationStatus, ref LastStatusDate,
                                    ref PaidFees, ref CreatedByUserID))

                return new clsApplication(ID, ApplicantPersonID, ApplicationDate,
            ApplicationTypeID, (enApplicationStatus)ApplicationStatus,
            LastStatusDate, PaidFees, CreatedByUserID);
            else
                return null;
        }

        public bool Cancel()
        {
            return ApplicationData.UpdateStatus(this.ApplicationID, 2);
        }
        public bool SetCompelete()
        {
            return ApplicationData.UpdateStatus(this.ApplicationID, 3);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:

                    if (_AddNewApplication())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;

                case enMode.Update:
                    return _UpdateApplication();
            }
            return false;
        }
        public static bool Delete(int ApplicationID)
        {
            return ApplicationData.DeleteApplication(ApplicationID);
        }
        public static bool DoesPersonHaveActiveApplication(int PersonID ,int ApplicationTypeID)
        {
            return ApplicationData.DoesPersonHaveActiveApplication(PersonID, ApplicationTypeID);
        }
        public static int GetActiveApplicationID(int PersonID, clsApplication.enApplicationType ApplicationTypeID)
        {
            return ApplicationData.GetActiveApplicationID(PersonID,(int) ApplicationTypeID);
        }
        public static int GetActiveApplicationIDForLicenseClass(int PersonID, clsApplication.enApplicationType ApplicationTypeID,int LicenseClassID)
        {
            return ApplicationData.GetActiveApplicationIDForLicenseClass(PersonID, (int)ApplicationTypeID, LicenseClassID);
        }
    }
}
