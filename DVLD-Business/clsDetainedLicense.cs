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
    public class clsDetainedLicense
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int DetainID { get; set; }
        public int LicenseID { get; set; }
        public DateTime DetainDate { get; set; }
        public float FineFees { get; set; }
        public int CreatedByUserID {  get; set; }
        public clsUser CreatedByUserInfo;
        public bool IsReleased { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int ReleasedByUserID { get; set; }
        public int ReleasedApplicationID { get; set; }
        public clsUser ReleasedByUserInfo;

        public clsDetainedLicense()
        {
            DetainID = -1;
            LicenseID = -1;
            DetainDate = DateTime.Now;
            FineFees = 0;
            CreatedByUserID = -1;
            CreatedByUserInfo = null;
            IsReleased = false;
            ReleaseDate = DateTime.Now;
            ReleasedByUserID = -1;
            ReleasedApplicationID = -1;
            ReleasedByUserInfo = null;

            Mode = enMode.AddNew;
        }
        private clsDetainedLicense(int detainID, int licenseID, DateTime detainDate, float fineFees,
        int createdByUserID, bool isReleased,DateTime releaseDate, int releasedByUserID,int releasedApplicationID)
        {
            DetainID = detainID;
            LicenseID = licenseID;
            DetainDate = detainDate;
            FineFees = fineFees;
            CreatedByUserID = createdByUserID;
            CreatedByUserInfo = clsUser.FindByUserID(createdByUserID); 
            IsReleased = isReleased;
            ReleaseDate = releaseDate;
            ReleasedByUserID = releasedByUserID;
            ReleasedByUserInfo = clsUser.FindByUserID(releasedByUserID); 
            ReleasedApplicationID = releasedApplicationID;

            Mode = enMode.Update;
        }

        private bool _AddNewDetainedLicense()
        {
            this.DetainID = DetainedLicenseData.AddNewDetainedLicense(this.LicenseID,this.DetainDate,this.FineFees,this.CreatedByUserID);

            return (this.DetainID != -1);
        }
        private bool _UpdateDetainedLicense()
        {
            return DetainedLicenseData.UpdateDetainedLicense(this.DetainID,this.LicenseID, this.DetainDate, this.FineFees,this.CreatedByUserID);
        }
        public bool Save()
        {
            switch (this.Mode)
            {
                case enMode.AddNew:
                    {
                        if (_AddNewDetainedLicense())
                        {
                            this.Mode = enMode.Update;
                            return true;
                        }
                        else
                            return false;
                    }

                case enMode.Update:
                    {
                        return _UpdateDetainedLicense();
                    }
            }

            return false;
        }
        public static clsDetainedLicense FindByDetainID(int DetainID)
        {
            float FineFees = 0; bool IsReleased = false;
            DateTime DetainDate = DateTime.Now, ReleaseDate = DateTime.MaxValue;
            int LicenseID = -1, ReleasedByUserID = -1, ReleasedApplicationID = -1, CreatedByUserID = -1;

            if (DetainedLicenseData.GetDetainedLicenseInfoByID(DetainID, ref LicenseID, ref DetainDate, ref FineFees,
                ref CreatedByUserID, ref IsReleased, ref ReleaseDate, ref ReleasedByUserID, ref ReleasedApplicationID))
                return new clsDetainedLicense(DetainID, LicenseID, DetainDate, FineFees, CreatedByUserID, IsReleased, ReleaseDate, ReleasedByUserID, ReleasedApplicationID);
            else
                return null;
        }
        public static clsDetainedLicense FindByLicenseID(int LicenseID)
        {
            float FineFees = 0; bool IsReleased = false;
            DateTime DetainDate = DateTime.Now, ReleaseDate = DateTime.MaxValue;
            int DetainID = -1, ReleasedByUserID = -1, ReleasedApplicationID = -1, CreatedByUserID = -1;

            if (DetainedLicenseData.GetDetainedLicenseInfoByLicenseID(LicenseID, ref DetainID, ref DetainDate, ref FineFees,
                ref CreatedByUserID, ref IsReleased,ref ReleaseDate, ref ReleasedByUserID, ref ReleasedApplicationID))
                return new clsDetainedLicense(DetainID, LicenseID, DetainDate, FineFees, CreatedByUserID, IsReleased, ReleaseDate, ReleasedByUserID, ReleasedApplicationID);
            else
                return null;
        }
        public static DataTable GetAllDetainedLicenses()
        {
            return DetainedLicenseData.GetAllDetainedLicenses();
        }
        public static bool IsLicenseDetained(int LicenseID)
        {
            return DetainedLicenseData.IsLicenseDetained(LicenseID);
        }
        public bool ReleaseDetainedLicense(int ReleasedByUserInfo,int ReleasedApplicationID)
        {
            return DetainedLicenseData.ReleaseDetainedLicense(this.DetainID, ReleasedByUserInfo, ReleasedApplicationID);
        }
    }
}
