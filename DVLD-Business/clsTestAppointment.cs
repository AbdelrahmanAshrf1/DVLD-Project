using DVLD_Buisness;
using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer
{
    public class clsTestAppointment
    {
        public enum enMode { AddNew = 1,Update  = 2 };
        private enMode _Mode = enMode.AddNew;

        public int TestAppointmentID { get; set; }
        public clsTestType.enTestType TestTypeID { get; set; }
        public clsTestType TestTypeInfo;
        public int LocalDrivingLicenseApplicationID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public float PaidFees { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsLocked { get; set; }
        public int RetakeTestApplicationID { get; set; }
        public clsApplication RetakeTestAppInfo;

        public clsTestAppointment()
        {
            this.TestAppointmentID = -1;
            this.TestTypeID = clsTestType.enTestType.VisionTest;
            this.TestTypeInfo = null;
            this.LocalDrivingLicenseApplicationID = -1;
            this.AppointmentDate = DateTime.Now;
            this.PaidFees = 0.0f;
            this.CreatedByUserID = -1;
            this.IsLocked = false;
            this.RetakeTestApplicationID = -1;
            this.RetakeTestAppInfo = null;

            _Mode = enMode.AddNew;
        }
        private clsTestAppointment(int testAppointmentID, clsTestType.enTestType testTypeID,int localDrivingLicenseApplicationID,
            DateTime appointmentDate, float paidFees, int createdByUserID, bool isLocked, int retakeTestApplicationID)
        {
            this.TestAppointmentID = testAppointmentID;
            this.TestTypeID = testTypeID;
            this.TestTypeInfo = clsTestType.Find((clsTestType.enTestType)testTypeID);
            this.LocalDrivingLicenseApplicationID = localDrivingLicenseApplicationID;
            this.AppointmentDate = appointmentDate;
            this.PaidFees = paidFees;
            this.CreatedByUserID = createdByUserID;
            this.IsLocked = isLocked;
            this.RetakeTestApplicationID = retakeTestApplicationID;
            this.RetakeTestAppInfo = clsApplication.FindBaseApplication(retakeTestApplicationID);

            _Mode = enMode.Update;
        }

        public static clsTestAppointment Find(int TestAppointmentID)
        {
            DateTime appointmentDate = DateTime.Now;
            float paidFees = 0; bool isLocked = false;
            int testTypeID = 1, localDrivingLicenseApplicationID = -1, createdByUserID = -1 , retakeTestApplicationID = -1;

            if(TestAppointmentData.GetTestAppointmentInfoByID(TestAppointmentID,ref testTypeID,
                                                              ref localDrivingLicenseApplicationID,
                                                              ref appointmentDate, ref paidFees,
                                                              ref createdByUserID, ref isLocked,
                                                              ref retakeTestApplicationID))
            {
                return new clsTestAppointment(TestAppointmentID, (clsTestType.enTestType) testTypeID, localDrivingLicenseApplicationID,
                                       appointmentDate, paidFees, createdByUserID, isLocked, retakeTestApplicationID);
            }
            else
                return null;
        }

        private bool _AddNewTestAppointment()
        {
            this.TestAppointmentID = TestAppointmentData.AddNewTestAppointment((int)this.TestTypeID, this.LocalDrivingLicenseApplicationID,
                this.AppointmentDate,this.PaidFees,this.CreatedByUserID,this.IsLocked,this.RetakeTestApplicationID);
            return (this.TestAppointmentID != -1);
        }
        private bool _UpdateTestAppointment()
        {
            return TestAppointmentData.UpdateTestAppointment(this.TestAppointmentID, (int)this.TestTypeID, this.LocalDrivingLicenseApplicationID,
                this.AppointmentDate, this.PaidFees, this.CreatedByUserID, this.IsLocked, this.RetakeTestApplicationID);
        }
        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if(_AddNewTestAppointment())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }   
                    
                case enMode.Update:
                    return _UpdateTestAppointment();
            }

            return false;
        }
        public static clsTestAppointment GetLastTestAppointment(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID)
        {
            int TestAppointmentID = -1;
            DateTime AppointmentDate = DateTime.Now; float PaidFees = 0;
            int CreatedByUserID = -1; bool IsLocked = false; int RetakeTestApplicationID = -1;

            if (TestAppointmentData.GetLastTestAppointment(LocalDrivingLicenseApplicationID, (int)TestTypeID,
                                                           ref TestAppointmentID, ref AppointmentDate,
                                                           ref PaidFees, ref CreatedByUserID,
                                                           ref IsLocked, ref RetakeTestApplicationID))

                return new clsTestAppointment(TestAppointmentID, TestTypeID, LocalDrivingLicenseApplicationID,
                                              AppointmentDate,PaidFees, CreatedByUserID, IsLocked, RetakeTestApplicationID);
            else
                return null;

        }
        public static DataTable GetAllTestAppointments()
        {
            return TestAppointmentData.GetAllTestAppointments();
        }
        public static DataTable GetTestAppointmentsPerTestType(int LocalDrivingLicenseApplicationID,clsTestType.enTestType TestType)
        {
            return TestAppointmentData.GetTestAppointmentPerTestType(LocalDrivingLicenseApplicationID, (int)TestType);
        }
    }
}
