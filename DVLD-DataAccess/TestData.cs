using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccessLayer
{
    public class TestData
    {
        public static int AddNewTest(int testAppointmentID, bool testResult, string notes, int createdByUserID)
        {
            int TestID = -1;

            string connectionString = DataAccessSettings.ConnectionString;

            string query = @"INSERT INTO Tests (TestAppointmentID, TestResult, Notes, CreatedByUserID)
                             VALUES (@TestAppointmentID, @TestResult, @Notes, @CreatedByUserID);

                             UPDATE TestAppointments
                             SET IsLocked = 1 WHERE TestAppointmentID = @TestAppointmentID;

                             SELECT SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@TestAppointmentID", SqlDbType.Int).Value = testAppointmentID;
                command.Parameters.Add("@TestResult", SqlDbType.Bit).Value = testResult;
                command.Parameters.Add("@CreatedByUserID", SqlDbType.Int).Value = createdByUserID;

                if(string.IsNullOrEmpty(notes))
                    command.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = DBNull.Value;
                else
                    command.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = notes;

                try
                {
                    connection.Open();

                    object result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int ExtractedID)) TestID = ExtractedID;
                }
                catch (Exception ex)
                { 
                  throw new Exception("Error adding new Test.", ex);
                }
            }

            return TestID;
        }
        public static bool UpdateTest(int testID, int testAppointmentID, bool testResult, string notes, int createdByUserID)
        {
            int rowsAffected = 0;

            string connectionString = DataAccessSettings.ConnectionString;

            string query = @"UPDATE Tests 
                             SET 
                                 TestAppointmentID = @TestAppointmentID,
                                 TestResult = @TestResult,
                                 Notes = @Notes,
                                 CreatedByUserID = @CreatedByUserID
                             WHERE 
                                 TestID = @TestID;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@TestID", SqlDbType.Int).Value = testID;
                command.Parameters.Add("@TestAppointmentID", SqlDbType.Int).Value = testAppointmentID;
                command.Parameters.Add("@TestResult", SqlDbType.Bit).Value = testResult;
                command.Parameters.Add("@CreatedByUserID", SqlDbType.Int).Value = createdByUserID;

                if (string.IsNullOrEmpty(notes))
                    command.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = DBNull.Value;
                else
                    command.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = notes;

                try
                {
                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error updating Test.", ex);
                }
            }

            return (rowsAffected > 0);
        }
        public static bool GetTestInfoByID(int testID, ref int testAppointmentID, ref bool testResult, ref string notes, ref int createdByUserID)
        {
            bool isFound = false;

            string connectionString = DataAccessSettings.ConnectionString;

            string query = @"SELECT 
                                 TestAppointmentID,
                                 TestResult,
                                 Notes,
                                 CreatedByUserID
                             FROM 
                                 Tests
                             WHERE 
                                 TestID = @TestID;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@TestID", SqlDbType.Int).Value = testID;

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            isFound = true;

                            testAppointmentID = (int)reader["TestAppointmentID"];
                            testResult = (bool)reader["TestResult"];
                            notes = reader["Notes"] == DBNull.Value ? null : (string)reader["Notes"];
                            createdByUserID = (int)reader["CreatedByUserID"];
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error finding Test info.", ex);
                }
            }

            return isFound;
        }
        public static bool GetLastTestByPersonAndTestTypeAndLicenseClass(int personID,int licenseClassID,int testTypeID,ref int testID,
            ref int testAppointmentID,ref bool testResult ,ref string notes, ref int createdByUserID)
        {
            bool isFound = false;

            string connectionString = DataAccessSettings.ConnectionString;

            string query = @"SELECT TOP 1
                             	 T.TestID,
                             	 T.TestAppointmentID,
                             	 T.TestResult,
                             	 T.Notes,
                             	 T.CreatedByUserID,
                             	 A.ApplicantPersonID
                             FROM 
                             	 Tests T
                             	 INNER JOIN TestAppointments TA ON T.TestAppointmentID = TA.TestAppointmentID
                             	 INNER JOIN LocalDrivingLicenseApplications LLA ON TA.LocalDrivingLicenseApplicationID = LLA.LocalDrivingLicenseApplicationID
                             	 INNER JOIN Applications A ON LLA.ApplicationID = A.ApplicationID
                             WHERE
                             	 A.ApplicantPersonID = @PersonID
                             	 AND LLA.LicenseClassID = @LicenseClassID
                             	 AND TA.TestTypeID = @TestTypeID
                             ORDER BY 
                             	 T.TestAppointmentID DESC;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query,connection))
            {
                command.Parameters.Add("@PersonID",SqlDbType.Int).Value = personID;
                command.Parameters.Add("@LicenseClassID", SqlDbType.Int).Value = licenseClassID;
                command.Parameters.Add("@TestTypeID", SqlDbType.Int).Value = testTypeID;

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if(reader.Read())
                        {
                            isFound = true;

                            testID = (int)reader["TestID"];
                            testAppointmentID = (int)reader["TestAppointmentID"];
                            testResult = (bool)reader["TestResult"];
                            notes = reader["Notes"] == DBNull.Value ? null : (string)reader["Notes"];
                            createdByUserID = (int)reader["CreatedByUserID"];
                        }
                    }
                }
                catch(Exception ex)
                {
                    throw new Exception("Error Finding Test.", ex);
                }
            }

            return isFound;
        }
        public static byte GetPassedTestCount(int LocalDrivingLicenseApplicationID)
        {
            byte TestCount = 0;

            string connectionString = DataAccessSettings.ConnectionString;

            string query = @"SELECT 
                             	COUNT(TA.TestTypeID)
                             FROM 
                             	Tests T
                             	INNER JOIN TestAppointments TA ON T.TestAppointmentID = TA.TestAppointmentID
                             WHERE 
                             	T.TestResult = 1
                                 AND TA.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@LocalDrivingLicenseApplicationID",SqlDbType.Int).Value = LocalDrivingLicenseApplicationID;

                try
                {
                    connection.Open();

                    object result = command.ExecuteScalar();
                    if (result != null && byte.TryParse(result.ToString(), out byte extractedTestCount))
                        TestCount = extractedTestCount;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error finding Test Count.", ex);
                }
            }

            return TestCount;
        }
        public static DataTable GetAllTests()
        {
            DataTable dt = new DataTable();

            string connectionString = DataAccessSettings.ConnectionString;

            string query = @"SELECT * FROM Tests ORDER BY TestID DESC;";   
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                try
                {
                    connection.Open();

                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows) dt.Load(reader);
                    }    

                }
                catch (Exception ex)
                {
                    throw new Exception("Error getting all Tests.", ex);
                }
            }

            return dt;
        }
        public static int GetTestIDByTestAppointmentID(int testAppointmentID)
        {
            int testID = -1;

            string connectionString = DataAccessSettings.ConnectionString;
            string query = @"SELECT TestID FROM Tests WHERE TestAppointmentID = @TestAppointmentID;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@TestAppointmentID", SqlDbType.Int).Value = testAppointmentID;

                try
                {
                    connection.Open();

                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                        testID = Convert.ToInt32(result);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error in Finding Test ID ", ex);
                }
            }

            return testID;
        }
    }
}
