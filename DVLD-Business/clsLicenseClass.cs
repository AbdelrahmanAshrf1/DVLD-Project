using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccessLayer;

namespace DVLD_BusinessLayer
{
    public class clsLicenseClass
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int ClassID { get; set; }
        public string ClassName { get; set; }
        public string ClassDescription { get; set; }
        public byte MinimumAllowedAge { get; set; }
        public byte DefaultValidityLength { get; set; }
        public float ClassFees { get; set; }

        public clsLicenseClass()
        {
            this.ClassID = -1;
            this.ClassName = "";
            this.ClassDescription = "";
            this.MinimumAllowedAge = 0;
            this.DefaultValidityLength = 0;
            this.ClassFees = 0;
            Mode = enMode.AddNew;
        }
        public clsLicenseClass(int LicenseClassID, string ClassName,string ClassDescription,
                        byte MinimumAllowedAge, byte DefaultValidityLength, float ClassFees)
        {
            this.ClassID = LicenseClassID;
            this.ClassName = ClassName;
            this.ClassDescription = ClassDescription;
            this.MinimumAllowedAge = MinimumAllowedAge;
            this.DefaultValidityLength = DefaultValidityLength;
            this.ClassFees = ClassFees;
            Mode = enMode.Update;
        }

        private bool _AddNewLicenseClass()
        {
            this.ClassID = LicenseClassData.AddNewLicenseClass(this.ClassName, this.ClassDescription,
                this.MinimumAllowedAge, this.DefaultValidityLength, this.ClassFees);
            return (this.ClassID != -1);
        }
        private bool _UpdateLicenseClass()
        {
            return LicenseClassData.UpdateLicenseClass(this.ClassID, this.ClassName, this.ClassDescription,
                this.MinimumAllowedAge, this.DefaultValidityLength, this.ClassFees);
        }
        public static clsLicenseClass Find(int ClassID)
        {
            string ClassName = "", ClassDescription = "";
            byte MinimumAllowedAge = 18; byte DefaultValidityLength = 10; float ClassFees = 0;

            if (LicenseClassData.GetLicenseClassInfoByID(ClassID, ref ClassName, ref ClassDescription, ref MinimumAllowedAge,
               ref DefaultValidityLength, ref ClassFees))

                return new clsLicenseClass(ClassID, ClassName, ClassDescription, MinimumAllowedAge, DefaultValidityLength, ClassFees);
            else
                return null;
        }
        public static clsLicenseClass Find(string ClassName)
        {
            int ClassID = -1; string ClassDescription = "";
            byte MinimumAllowedAge = 18; byte DefaultValidityLength = 10; float ClassFees = 0;

            if (LicenseClassData.GetLicenseClassInfoByClassName(ref ClassID, ClassName, ref ClassDescription, ref MinimumAllowedAge,
               ref DefaultValidityLength, ref ClassFees))

                return new clsLicenseClass(ClassID, ClassName, ClassDescription, MinimumAllowedAge, DefaultValidityLength, ClassFees);
            else
                return null;
        }
        public bool Save()
        {
            switch(Mode)
            {
                case enMode.AddNew:
                    if(_AddNewLicenseClass())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;

                case enMode.Update:
                    return _UpdateLicenseClass();
            }

            return false;
        }

        public static DataTable GetAllLicenseClasses()
        {
            return LicenseClassData.GetAllLicenseClasses();
        }
    }
}
