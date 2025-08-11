using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccessLayer;

namespace DVLD_BusinessLayer
{
    public class clsApplicationTypes
    {
        public enum enMode { AddNew = 0 , Update = 1};
        public enMode Mode = enMode.AddNew;

        public int ID { get; set; }
        public string Title { get; set; }
        public float Fees { get; set; }

        public clsApplicationTypes()
        {
            this.ID = -1;
            this.Title = "";
            this.Fees = 0;
            this.Mode = enMode.AddNew;
        }
        public clsApplicationTypes(int ID,string Title,float Fees)
        {
            this.ID = ID;
            this.Title = Title;
            this.Fees = Fees;
            this.Mode = enMode.Update;
        }
        private bool _AddNewApplicationType()
        {
            this.ID = ApplicationTypesData.AddNewApplicationType(this.Title,this.Fees);
            return (this.ID != -1);
        }
        public bool _UpdateApplicationType()
        {
            return ApplicationTypesData.UpdateApplicationType(this.ID, this.Title, this.Fees);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewApplicationType())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateApplicationType();

            }

            return false;
        }
        public static DataTable GetAllApplicationTypes()
        {
            return ApplicationTypesData.GetAllApplicationTypes();
        }
        public static clsApplicationTypes Find(int ID)
        {
            string Title = ""; float Fees = 0;

            if(ApplicationTypesData.GetApplicationTypeInfoByID(ID,ref Title ,ref Fees))
                return new clsApplicationTypes(ID,Title,Fees);
            else 
                return null;
        }
    }
}
