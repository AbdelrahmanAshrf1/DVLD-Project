using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccessLayer;

namespace DVLD_BusinessLayer
{
    public class clsTestType
    {
        public enum enMode { AddNew = 1,Update = 2 }
        public enMode Mode { get; set; }
        public enum enTestType { VisionTest = 1,WrittenTest = 2,StreetTest = 3 }
        public clsTestType.enTestType ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public float Fees { get; set; }

        public clsTestType()
        {
            this.ID = clsTestType.enTestType.VisionTest;
            this.Title = "";
            this.Description = "";
            this.Fees = 0;
            this.Mode = enMode.AddNew;
        }
        private clsTestType(clsTestType.enTestType TestTypeID, string Title,string Description,float Fees)
        {
            this.ID = TestTypeID;
            this.Title = Title;
            this.Description = Description;
            this.Fees = Fees;
            this.Mode = enMode.Update;
        }

        private bool _AddNewTestType()
        {
            this.ID = (clsTestType.enTestType)TestTypesData.AddNewTestType(this.Title, this.Description, this.Fees);
            return ((int)this.ID != -1);
        }
        private bool _UpdateTestType()
        {
            return TestTypesData.UpdateTestType((int)this.ID,this.Title,this.Description,this.Fees);
        }
        public bool Save()
        {
            switch(Mode)
            {
                case enMode.AddNew:
                    if(_AddNewTestType())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;

                case enMode.Update:

                    return _UpdateTestType();
            }
            return false;
        }
        public static DataTable GetAllTestTypes()
        {
            return TestTypesData.GetAllTestTypes();
        }
        public static clsTestType Find(clsTestType.enTestType ID)
        {
            float Fees = 0;
            string Title = "", Description = "";

            if (TestTypesData.GetTestTypeInfoByID((int)ID,ref Title, ref Description, ref Fees))
                return new clsTestType(ID, Title, Description, Fees);
            else
                return null;
        }
    }
}
