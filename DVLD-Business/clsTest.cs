using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer
{
    public class clsTest
    {
        public enum enMode { AddNew = 1,Update = 2 }
        public enMode Mode = enMode.AddNew;

        public int TestID { get; set; }
        public int TestAppointmentID { get; set; }
        public clsTestAppointment TestAppointmentInfo;
        public bool TestResult { get; set; }
        public string Notes { get; set; }
        public int CreatedByUserID { get; set; }
        public clsUser CreatedByUserInfo;

        public clsTest()
        {
            this.TestID = -1;
            this.TestAppointmentID = -1;
            this.TestAppointmentInfo = null;
            this.TestResult = false;
            this.Notes = null;
            this.CreatedByUserID = -1;
            this.CreatedByUserInfo = null;

            this.Mode = enMode.AddNew;
        }
        private clsTest(int TestID, int TestAppointmentID, bool TestResult,string Notes,int CreatedByUserID)
        {
            this.TestID  = TestID;
            this.TestAppointmentID = TestAppointmentID;
            this.TestAppointmentInfo = clsTestAppointment.Find(TestAppointmentID);
            this.TestResult = TestResult;
            this.Notes = Notes;
            this.CreatedByUserID = CreatedByUserID;
            this.CreatedByUserInfo = clsUser.FindByUserID(CreatedByUserID);

            this.Mode = enMode.Update;
        }

        private bool _AddNewTest()
        {
            this.TestID = TestData.AddNewTest(this.TestAppointmentID, this.TestResult, this.Notes, this.CreatedByUserID);
            return (this.TestID != -1);
        }
        private bool _UpdateTest()
        {
            return TestData.UpdateTest(this.TestID,this.TestAppointmentID, this.TestResult, this.Notes, this.CreatedByUserID);
        }
        public bool Save()
        {
            switch(this.Mode)
            {
                case enMode.AddNew:
                    if (_AddNewTest())
                    {
                        this.Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;

                case enMode.Update:
                    return _UpdateTest();
            }

            return false;
        }

        public static clsTest Find(int TestID)
        {
            string Notes = null;
            bool TestResult = false;
            int TestAppointmentID = -1, CreatedByUserID = -1;

            if (TestData.GetTestInfoByID(TestID, ref TestAppointmentID, ref TestResult, ref Notes, ref CreatedByUserID))
                return new clsTest(TestID, TestAppointmentID, TestResult, Notes, CreatedByUserID);
            else
                return null;
        }
        public static clsTest FindLastTestPerPersonAndLicenseClass(int PersonID,int LicenseClassID, clsTestType.enTestType TestTypeID)
        {
            string Notes = null;
            bool TestResult = false;
            int TestAppointmentID = -1, CreatedByUserID = -1 , TestID = -1;

            if (TestData.GetLastTestByPersonAndTestTypeAndLicenseClass(PersonID, LicenseClassID,
                                                                       (int)TestTypeID,ref TestID,
                                                                        ref TestAppointmentID,ref TestResult,
                                                                        ref Notes, ref CreatedByUserID))

                return new clsTest(TestID, TestAppointmentID, TestResult, Notes, CreatedByUserID);
            else
                return null;
        }
        public static byte GetPassedTestCount(int LocalDrivingLicenseApplicationID)
        {
            return TestData.GetPassedTestCount(LocalDrivingLicenseApplicationID);
        }
        public static bool PassedAllTests(int LocalDrivingLicenseApplicationID)
        {
            return (TestData.GetPassedTestCount(LocalDrivingLicenseApplicationID) == 3);
        }
        public static DataTable GetAllTests()
        {
            return TestData.GetAllTests();
        }
        public static int FindTestIDByTestAppointmentID(int testAppointmentID)
        {
            return TestData.GetTestIDByTestAppointmentID(testAppointmentID);
        }
    }
}
