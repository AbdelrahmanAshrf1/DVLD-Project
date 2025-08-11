using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccessLayer
{
    public class TestAppointmentData
    {
        public static int AddNewTestAppointment(int testTypeID, int localDrivingLicenseApplicationID,
            DateTime appointmentDate, float paidFees, int createdByUserID, bool isLocked, int retakeTestApplicationID)
        {
            int testAppointmentID = -1;
            string connectionString = DataAccessSettings.ConnectionString;
            string query = @"INSERT INTO TestAppointments 
                            (TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate, PaidFees, CreatedByUserID, IsLocked, RetakeTestApplicationID)
                             VALUES (@TestTypeID, @LocalDrivingLicenseApplicationID, @AppointmentDate, @PaidFees, @CreatedByUserID, @IsLocked, @RetakeTestApplicationID);
                             SELECT SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                command.Parameters.Add("@TestTypeID", SqlDbType.Int).Value = testTypeID;
                command.Parameters.Add("@LocalDrivingLicenseApplicationID", SqlDbType.Int).Value = localDrivingLicenseApplicationID;
                command.Parameters.Add("@AppointmentDate", SqlDbType.DateTime).Value = appointmentDate;
                command.Parameters.Add("@PaidFees", SqlDbType.SmallMoney).Value = paidFees;
                command.Parameters.Add("@CreatedByUserID", SqlDbType.Int).Value = createdByUserID;
                command.Parameters.Add("@IsLocked", SqlDbType.Bit).Value = isLocked;

                if (retakeTestApplicationID == -1)
                    command.Parameters.Add("@RetakeTestApplicationID", SqlDbType.Int).Value = DBNull.Value;
                else
                    command.Parameters.Add("@RetakeTestApplicationID", SqlDbType.Int).Value = retakeTestApplicationID;
                try
                {
                    object result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int ExtractedID))
                        testAppointmentID = ExtractedID;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error in AddNewTestAppointment", ex);
                }
            }

            return testAppointmentID;
        }
        public static bool UpdateTestAppointment(int testAppointmentID, int testTypeID, int localDrivingLicenseApplicationID,
            DateTime appointmentDate, float paidFees, int createdByUserID, bool isLocked, int retakeTestApplicationID)
        {
            int rowsAffected = 0;
            string connectionString = DataAccessSettings.ConnectionString;
            string query = @"UPDATE TestAppointments
                             SET TestTypeID = @TestTypeID,
                                 LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID,
                                 AppointmentDate = @AppointmentDate,
                                 PaidFees = @PaidFees,
                                 CreatedByUserID = @CreatedByUserID,
                                 IsLocked = @IsLocked,
                                 RetakeTestApplicationID = @RetakeTestApplicationID
                             WHERE TestAppointmentID = @TestAppointmentID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();

                command.Parameters.Add("@TestAppointmentID", SqlDbType.Int).Value = testAppointmentID;
                command.Parameters.Add("@TestTypeID", SqlDbType.Int).Value = testTypeID;
                command.Parameters.Add("@LocalDrivingLicenseApplicationID", SqlDbType.Int).Value = localDrivingLicenseApplicationID;
                command.Parameters.Add("@AppointmentDate", SqlDbType.DateTime).Value = appointmentDate;
                command.Parameters.Add("@PaidFees", SqlDbType.SmallMoney).Value = paidFees;
                command.Parameters.Add("@CreatedByUserID", SqlDbType.Int).Value = createdByUserID;
                command.Parameters.Add("@IsLocked", SqlDbType.Bit).Value = isLocked;
                command.Parameters.Add("@RetakeTestApplicationID", SqlDbType.Int).Value = retakeTestApplicationID;

                try
                {
                    rowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error in UpdateTestAppointment", ex);
                }
            }

            return (rowsAffected > 0);
        }
        public static DataTable GetTestAppointmentPerTestType(int localDrivingLicenseApplicationID, int testTypeID)
        {
            DataTable dt = new DataTable();
            string connectionString = DataAccessSettings.ConnectionString;

            string query = @"
                            SELECT 
                                TestAppointmentID,
                                AppointmentDate,
                                PaidFees,
                                IsLocked
                            FROM 
                                TestAppointments
                            WHERE 
                                LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
                                AND TestTypeID = @TestTypeID
                            ORDER BY 
                                AppointmentDate DESC;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@LocalDrivingLicenseApplicationID", SqlDbType.Int).Value = localDrivingLicenseApplicationID;
                command.Parameters.Add("@TestTypeID", SqlDbType.Int).Value = testTypeID;

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error in GetTestAppointmentPerTestType.", ex);
                }
            }

            return dt;
        }
        public static bool GetTestAppointmentInfoByID(int testAppointmentID, ref int testTypeID, ref int localDrivingLicenseApplicationID,
            ref DateTime appointmentDate, ref float paidFees, ref int createdByUserID, ref bool isLocked, ref int retakeTestApplicationID)
        {
            bool isFound = false;

            string connectionString = DataAccessSettings.ConnectionString;
            string query = @"SELECT 
                                    TestTypeID,
                                    LocalDrivingLicenseApplicationID,
                                    AppointmentDate,
                                    PaidFees,
                                    CreatedByUserID,
                                    IsLocked,
                                    RetakeTestApplicationID
                                 FROM 
                                    TestAppointments
                                 WHERE 
                                    TestAppointmentID = @TestAppointmentID;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@TestAppointmentID", SqlDbType.Int).Value = testAppointmentID;

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            isFound = true;

                            testTypeID = (int)reader["TestTypeID"];
                            localDrivingLicenseApplicationID = (int)reader["LocalDrivingLicenseApplicationID"];
                            appointmentDate = (DateTime)reader["AppointmentDate"];
                            paidFees = Convert.ToSingle(reader["PaidFees"]);
                            createdByUserID = (int)reader["CreatedByUserID"];
                            isLocked = (bool)reader["IsLocked"];
                            retakeTestApplicationID = (reader["RetakeTestApplicationID"] == DBNull.Value) ? -1 : (int)reader["RetakeTestApplicationID"];
                        }
                    }

                }
                catch (Exception ex)
                {
                    throw new Exception("Error in Finding Test Appointment Info", ex);
                }
            }

            return isFound;
        }
        public static bool GetLastTestAppointment(int LocalDrivingLicenseApplicationID, int TestTypeID,ref int TestAppointmentID, ref DateTime AppointmentDate,
            ref float PaidFees, ref int CreatedByUserID, ref bool IsLocked, ref int RetakeTestApplicationID)
        {
            bool isFound = false;
            string connectionString = DataAccessSettings.ConnectionString;
            string query = @"SELECT TOP 1 
                             	*
                             FROM 
                             	TestAppointments TA
                             WHERE 
                             	TA.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
                             	AND TA.TestTypeID = @TestTypeID
                             ORDER BY 
                             	TA.TestAppointmentID DESC;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@LocalDrivingLicenseApplicationID",SqlDbType.Int).Value = LocalDrivingLicenseApplicationID;
                command.Parameters.Add("@TestTypeID", SqlDbType.Int).Value = TestTypeID;

                try
                {
                    connection.Open();

                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            isFound = true;

                            TestAppointmentID = (int)reader["TestAppointmentID"];
                            AppointmentDate = (DateTime)reader["AppointmentDate"];
                            PaidFees = (float)reader["PaidFees"];
                            CreatedByUserID = (int)reader["CreatedByUserID"];
                            IsLocked = (bool)reader["IsLocked"];

                            if (reader["RetakeTestApplicationID"] == DBNull.Value)
                                RetakeTestApplicationID = -1;
                            else
                                RetakeTestApplicationID = (int)reader["RetakeTestApplicationID"];
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error in Finding Last Test Appointment Info", ex);
                }
            }

            return isFound;
        }
        public static DataTable GetAllTestAppointments()
        {
            DataTable dt = new DataTable();
            string connectionString = DataAccessSettings.ConnectionString;
            string query = @"SELECT * FROM TestAppointments_View ORDER BY AppointmentDate DESC;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read()) dt.Load(reader);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error in Get All Test Appointments", ex);
                }
            }

            return dt;
        }
    }
}
