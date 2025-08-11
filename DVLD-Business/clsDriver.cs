using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer
{
    public class clsDriver
    {
        public enum enMode { AddNew = 0,Update = 1 };
        private enMode _Mode;
        public int DriverID { get; set; }
        public int PersonID { get; set; }
        public clsPerson PersonInfo;
        public int CreatedByUserID { get; set; }
        public clsUser CreatedByUserInfo;
        public DateTime CreatedDate { get; set; }

        public clsDriver()
        {
            DriverID = -1;
            PersonID = -1;
            PersonInfo = null;
            CreatedByUserID = -1;
            CreatedByUserInfo = null;
            CreatedDate = DateTime.Now;

            _Mode = enMode.AddNew;
        }
        private clsDriver(int DriverID,int PersonID,int CreatedByUserID,DateTime CreatedDate)
        {
            this.DriverID = DriverID;
            this.PersonID = PersonID;
            this.PersonInfo = clsPerson.Find(PersonID);
            this.CreatedByUserID = CreatedByUserID;
            this.CreatedByUserInfo = clsUser.FindByUserID(CreatedByUserID);
            this.CreatedDate = CreatedDate;

            this._Mode = enMode.Update;
        }

        private bool _AddNewDriver()
        {
            this.DriverID = DriverData.AddNewDriver(this.PersonID, this.CreatedByUserID,this.CreatedDate);
            return (this.DriverID != -1); 
        }
        private bool _UpdateDriver()
        {
            return DriverData.UpdateDriver(this.DriverID, this.PersonID, this.CreatedByUserID, this.CreatedDate);
        }
        public bool Save()
        {
            switch(this._Mode)
            {
                case enMode.AddNew:
                    {
                        if (_AddNewDriver())
                        {
                            this._Mode = enMode.Update;
                            return true;
                        }
                        else
                            return false;
                    }

                case enMode.Update:
                    {
                        return _UpdateDriver();
                    }
            }

            return false;
        }
        public static clsDriver FindByPersonID(int PersonID)
        {
            DateTime CreatedDate = DateTime.Now;
            int DriverID = 0, CreatedByUserID = 0;

            if (DriverData.GetDriverInfoByPersonID(PersonID, ref DriverID, ref CreatedByUserID, ref CreatedDate))
                return new clsDriver(DriverID, PersonID, CreatedByUserID, CreatedDate);
            else
                return null;
        }
        public static clsDriver FindByDriverID(int DriverID)
        {
            DateTime CreatedDate = DateTime.Now;
            int PersonID = 0, CreatedByUserID = 0;

            if (DriverData.GetDriverInfoByDriverID(DriverID, ref PersonID, ref CreatedByUserID, ref CreatedDate))
                return new clsDriver(DriverID, PersonID, CreatedByUserID, CreatedDate);
            else
                return null;
        }
        public static DataTable GetAllDrivers()
        {
            return DriverData.GetAllDrivers();
        }
        public static DataTable GetLicense(int DriverID)
        {
            return clsLicense.GetAllDriverLicenses(DriverID);
        }
        public static DataTable GetDriverInternationalLicenses(int DriverID)
        {
            return InternationalLicenseData.GetDriverInternationalLicenses(DriverID);
        }
    }
}
