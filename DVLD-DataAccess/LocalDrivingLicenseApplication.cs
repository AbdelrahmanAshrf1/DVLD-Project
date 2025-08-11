using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;
using System.ComponentModel;
using System.Net.Http.Headers;

namespace DVLD_DataAccessLayer
{
    public class LocalDrivingLicenseApplicationData
    {
        public static DataTable GetAllLocalDrivingLicenseApplications()
        {
            DataTable dt = new DataTable();

            string connectionString = DataAccessSettings.ConnectionString;
            string query = @"SELECT * FROM LocalDrivingLicenseApplications_View 
                             ORDER BY ApplicationDate DESC;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                try
                {
                    connection.Open();

                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        if(reader.HasRows) dt.Load(reader);
                    }
                }
                catch(Exception ex)
                {
                    // Console.WriteLine("Error: " + ex.Message);
                }
                return dt;
            }
        }
        public static bool GetLocalDrivingLicenseApplicationInfoByID(int LocalDrivingLicenseApplicationID , ref int ApplicationID, ref int LicenseID)
        {
            bool IsFound = false;
            string connectionString = DataAccessSettings.ConnectionString;
            string query = @"SELECT * FROM LocalDrivingLicenseApplications WHERE
                             LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID;";

            using(SqlConnection connection = new SqlConnection( connectionString))
            using (SqlCommand command = new SqlCommand( query, connection))
            {
                connection.Open();
                
                command.Parameters.Add("@LocalDrivingLicenseApplicationID",SqlDbType.Int).Value = LocalDrivingLicenseApplicationID;

                try
                {
                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        if(reader.Read())
                        {
                            IsFound = true;

                            ApplicationID = (int)reader["ApplicationID"];
                            LicenseID = (int)reader["LicenseClassID"];
                        }
                    }
                }
                catch(Exception ex)
                {
                    throw new Exception(ex.Message);
                }

                return IsFound;
            }
        }
        public static bool GetLocalDrivingLicenseApplicationInfoByApplicationID(int ApplicationIDInput,ref int LocalDrivingLicenseApplicationID,ref int LicenseID)
        {
            bool IsFound = false;
            string connectionString = DataAccessSettings.ConnectionString;
            string query = @"
                            SELECT 
                                LocalDrivingLicenseApplicationID,
                                LicenseClassID
                            FROM 
                                LocalDrivingLicenseApplications
                            WHERE
                                ApplicationID = @ApplicationID;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@ApplicationID", SqlDbType.Int).Value = ApplicationIDInput;

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            IsFound = true;

                            LocalDrivingLicenseApplicationID = (int)reader["LocalDrivingLicenseApplicationID"];
                            LicenseID = (int)reader["LicenseClassID"];
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error in GetLocalDrivingLicenseApplicationInfoByApplicationID", ex);
                }
            }

            return IsFound;
        }
        public static int AddNewLocalDrivingLicenseApplication(int ApplicationID, int LicenseClassID)
        {
            int localDrivingLicenseApplicationID = -1;
            string connectionString = DataAccessSettings.ConnectionString;
            string query = @"INSERT INTO LocalDrivingLicenseApplications (ApplicationID, LicenseClassID)
                             VALUES (@ApplicationID, @LicenseClassID);
                             SELECT SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@ApplicationID", SqlDbType.Int).Value = ApplicationID;
                command.Parameters.Add("@LicenseClassID", SqlDbType.Int).Value = LicenseClassID;

                try
                {
                    connection.Open();

                    object result = command.ExecuteScalar();

                    if (result != null) localDrivingLicenseApplicationID = Convert.ToInt32(result);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error in Add New Local Driving License Application", ex);
                }
            }

            return localDrivingLicenseApplicationID;
        }
        public static bool UpdateLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID, int ApplicationID, int LicenseClassID)
        {
            int rowsAffected = 0;
            string connectionString = DataAccessSettings.ConnectionString;

            string query = @"UPDATE LocalDrivingLicenseApplications
                             SET ApplicationID = @ApplicationID,
                                 LicenseClassID = @LicenseClassID
                             WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@LocalDrivingLicenseApplicationID", SqlDbType.Int).Value = LocalDrivingLicenseApplicationID;
                command.Parameters.Add("@ApplicationID", SqlDbType.Int).Value = ApplicationID;
                command.Parameters.Add("@LicenseClassID", SqlDbType.Int).Value = LicenseClassID;

                try
                {
                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error in Update Local Driving License Application", ex);
                }
            }

            return (rowsAffected > 0);
        }
        public static bool DeleteLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID)
        {
            int rowsAffected = 0;
            string connectionString = DataAccessSettings.ConnectionString;

            string query = @"DELETE FROM LocalDrivingLicenseApplications
                             WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@LocalDrivingLicenseApplicationID", SqlDbType.Int).Value = LocalDrivingLicenseApplicationID;

                try
                {
                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error in Delete Local Driving License Application", ex);
                }
            }

            return (rowsAffected > 0);
        }
        public static byte GetPassedTestCount(int LocalDrivingLicenseApplicationID)
        {
            byte PassedTestCount = 0;
            string connectionString = DataAccessSettings.ConnectionString;
            string query = @"
                             SELECT COUNT(*) AS PassedTest
                             FROM Tests
                             INNER JOIN TestAppointments 
                                 ON Tests.TestAppointmentID = TestAppointments.TestAppointmentID
                             WHERE TestAppointments.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
                               AND Tests.TestResult = 1;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();

                command.Parameters.Add("@LocalDrivingLicenseApplicationID", SqlDbType.Int).Value = LocalDrivingLicenseApplicationID;

                try
                {
                    object result = command.ExecuteScalar();
                    if (result != null && byte.TryParse(result.ToString(), out byte ExtractedPassedTest))
                        PassedTestCount = ExtractedPassedTest;
                }
                catch(Exception ex)
                {
                    throw new Exception(ex.Message);
                }

                return PassedTestCount;
            }
        }
        public static bool IsThereAnActiveScheduledTest(int localDrivingLicenseApplicationID, int testTypeID)
        {
            bool isFound = false;
            string connectionString = DataAccessSettings.ConnectionString;
            string query = @"SELECT TOP 1 
                                  1 AS Found
                             FROM 
                                  LocalDrivingLicenseApplications LLA
                             	INNER JOIN TestAppointments TA ON LLA.LocalDrivingLicenseApplicationID = TA.LocalDrivingLicenseApplicationID
                              WHERE 
                                  LLA.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
                                  AND TA.TestTypeID = @TestTypeID
                                  AND TA.IsLocked = 0
                              ORDER BY 
                                  TA.TestAppointmentID DESC;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@LocalDrivingLicenseApplicationID", SqlDbType.Int).Value = localDrivingLicenseApplicationID;
                command.Parameters.Add("@TestTypeID", SqlDbType.Int).Value = testTypeID;

                try
                {
                    connection.Open();

                    object result = command.ExecuteScalar();
                    if (result != null) isFound = true;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error in IsThereAnActiveScheduledTest", ex);
                }

                return isFound;
            }
        }
        public static byte TotalTrialsPerTest(int localDrivingLicenseApplicationID, int testTypeID)
        {
            byte totalTrailsPerTest = 0;

            string connectionString = DataAccessSettings.ConnectionString;

            string query = @"SELECT 
                             	 COUNT(T.TestID) AS TotalTrials
                             FROM
                             	 Tests T
                             	 INNER JOIN TestAppointments TA ON T.TestAppointmentID = TA.TestAppointmentID
                             WHERE
                             	 TA.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
                             	 AND TA.TestTypeID = @TestTypeID;";
            
            using (SqlConnection connection = new SqlConnection((connectionString)))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@LocalDrivingLicenseApplicationID", SqlDbType.Int).Value = localDrivingLicenseApplicationID;
                command.Parameters.Add("@TestTypeID", SqlDbType.Int).Value = testTypeID;

                try
                {
                    connection.Open();

                    object result = command.ExecuteScalar();
                    if(result != null && result != DBNull.Value)
                        totalTrailsPerTest = Convert.ToByte(result);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error in TotalTrailsPerTest", ex);
                }
            }

            return totalTrailsPerTest;
        }
        public static bool DoesAttendTestType(int localDrivingLicenseApplicationID, int testTypeID)
        {
            bool DoesAttendTest = false;

            string connectionString = DataAccessSettings.ConnectionString;

            string query = @"SELECT 
                             	 TOP 1 Found = 1
                             FROM 
                             	 LocalDrivingLicenseApplications LLA
                             	 INNER JOIN TestAppointments TA ON LLA.LocalDrivingLicenseApplicationID = TA.LocalDrivingLicenseApplicationID
                             	 INNER JOIN Tests T ON TA.TestAppointmentID = T.TestAppointmentID
                             WHERE
                             	 LLA.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
                             	 AND TA.TestTypeID = @TestTypeID
                             ORDER BY
                             	 TA.TestAppointmentID DESC;";

            using (SqlConnection connection = new SqlConnection((connectionString)))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@LocalDrivingLicenseApplicationID", SqlDbType.Int).Value = localDrivingLicenseApplicationID;
                command.Parameters.Add("@TestTypeID", SqlDbType.Int).Value = testTypeID;

                try
                {
                    connection.Open();

                    object result = command.ExecuteScalar();
                    DoesAttendTest = (result != null && result != DBNull.Value);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error in DoesAttendTestType", ex);
                }
            }

            return DoesAttendTest;
        }
        public static bool DoesPassTestType(int localDrivingLicenseApplicationID, int testTypeID)
        {
            bool PassTest = false;
            string connectionString = DataAccessSettings.ConnectionString;
            string query = @"SELECT 
                             	top 1 T.TestResult
                             FROM 
                             	LocalDrivingLicenseApplications LLA
                             	INNER JOIN TestAppointments TA ON LLA.LocalDrivingLicenseApplicationID = TA.LocalDrivingLicenseApplicationID
                             	INNER JOIN Tests T ON TA.TestAppointmentID = T.TestAppointmentID
                             WHERE 
                             	LLA.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
                             	AND TA.TestTypeID = @TestTypeID
                             	AND T.TestResult = 1 -- 1 = PASS
                             ORDER BY 
                             	TA.TestAppointmentID DESC;";

            using (SqlConnection connection = new SqlConnection((connectionString)))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@LocalDrivingLicenseApplicationID", SqlDbType.Int).Value = localDrivingLicenseApplicationID;
                command.Parameters.Add("@TestTypeID", SqlDbType.Int).Value = testTypeID;

                try
                {
                    connection.Open();

                    object result = command.ExecuteScalar();
                    PassTest = (result != null && result != DBNull.Value);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error in DoesPassTestType", ex);
                }
            }

            return PassTest;
        }
    }
}
