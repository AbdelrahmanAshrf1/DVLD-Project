using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DVLD_DataAccessLayer
{
    public class ApplicationData
    {
        public static int AddNewApplication(int ApplicantPersonID, DateTime ApplicationDate, int ApplicationTypeID,
                                      byte ApplicationStatus, DateTime LastStatusDate, float PaidFees, int CreatedByUserID)
        {
            int ID = -1;
            string connectionString = DataAccessSettings.ConnectionString;

            string query = @"INSERT INTO Applications 
                        (ApplicantPersonID, ApplicationDate, ApplicationTypeID, ApplicationStatus, 
                         LastStatusDate, PaidFees, CreatedByUserID)
                     VALUES 
                        (@ApplicantPersonID, @ApplicationDate, @ApplicationTypeID, @ApplicationStatus, 
                         @LastStatusDate, @PaidFees, @CreatedByUserID);
                     SELECT SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@ApplicantPersonID", SqlDbType.Int).Value = ApplicantPersonID;
                command.Parameters.Add("@ApplicationDate", SqlDbType.DateTime).Value = ApplicationDate;
                command.Parameters.Add("@ApplicationTypeID", SqlDbType.Int).Value = ApplicationTypeID;
                command.Parameters.Add("@ApplicationStatus", SqlDbType.TinyInt).Value = ApplicationStatus;
                command.Parameters.Add("@LastStatusDate", SqlDbType.DateTime).Value = LastStatusDate;
                command.Parameters.Add("@PaidFees", SqlDbType.SmallMoney).Value = PaidFees;
                command.Parameters.Add("@CreatedByUserID", SqlDbType.Int).Value = CreatedByUserID;

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int extractedID))
                    {
                        ID = extractedID;
                    }
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("Failed to add new application.", ex);
                }
            }

            return ID;
        }
        public static bool UpdateApplication(int ApplicationID, int ApplicantPersonID, DateTime ApplicationDate,
        int ApplicationTypeID, byte ApplicationStatus, DateTime LastStatusDate,float PaidFees, int CreatedByUserID)
        {
            int rowsAffected = 0;
            string connectionString = DataAccessSettings.ConnectionString;

            string query = @"UPDATE Applications SET
                                    ApplicantPersonID = @ApplicantPersonID,
                                    ApplicationDate = @ApplicationDate,
                                    ApplicationTypeID = @ApplicationTypeID,
                                    ApplicationStatus = @ApplicationStatus,
                                    LastStatusDate = @LastStatusDate,
                                    PaidFees = @PaidFees,
                                    CreatedByUserID = @CreatedByUserID

                            WHERE   ApplicationID = @ApplicationID;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@ApplicationID", SqlDbType.Int).Value = ApplicationID;
                command.Parameters.Add("@ApplicantPersonID", SqlDbType.Int).Value = ApplicantPersonID;
                command.Parameters.Add("@ApplicationDate", SqlDbType.DateTime).Value = ApplicationDate;
                command.Parameters.Add("@ApplicationTypeID", SqlDbType.Int).Value = ApplicationTypeID;
                command.Parameters.Add("@ApplicationStatus", SqlDbType.TinyInt).Value = ApplicationStatus;
                command.Parameters.Add("@LastStatusDate", SqlDbType.DateTime).Value = LastStatusDate;
                command.Parameters.Add("@PaidFees", SqlDbType.SmallMoney).Value = PaidFees;
                command.Parameters.Add("@CreatedByUserID", SqlDbType.Int).Value = CreatedByUserID;

                try
                {
                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("Failed to update application.", ex);
                }
            }

            return (rowsAffected > 0);
        }
        public static bool GetApplicationInfoByID(int ApplicationID, ref int ApplicantPersonID, ref DateTime ApplicationDate,
        ref int ApplicationTypeID, ref byte ApplicationStatus, ref DateTime LastStatusDate, ref float PaidFees, ref int CreatedByUserID)
        {
            bool IsFound = false;
            string connectionString = DataAccessSettings.ConnectionString;

            string query = @"SELECT * FROM Applications WHERE ApplicationID = @ApplicationID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@ApplicationID", SqlDbType.Int).Value = ApplicationID;

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            IsFound = true;

                            ApplicantPersonID = (int)reader["ApplicantPersonID"];
                            ApplicationDate = (DateTime)reader["ApplicationDate"];
                            ApplicationTypeID = (int)reader["ApplicationTypeID"];
                            ApplicationStatus = (byte)reader["ApplicationStatus"];
                            LastStatusDate = (DateTime)reader["LastStatusDate"];
                            PaidFees = Convert.ToSingle(reader["PaidFees"]);
                            CreatedByUserID = (int)reader["CreatedByUserID"];
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("Failed to retrieve application information.", ex);
                }
            }

            return IsFound;
        }
        public static bool UpdateStatus(int ApplicationID,short NewStatus)
        {
            int RowsAffected = 0;
            string connectionStirng = DataAccessSettings.ConnectionString;

            string query = @"UPDATE Applications 
                             SET    ApplicationStatus = @NewStatus,
                                    LastStatusDate = @LastDate
                             WHERE  ApplicationID = @ApplicationID;";

            using(SqlConnection connection = new SqlConnection(connectionStirng))
            using(SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@NewStatus", SqlDbType.TinyInt).Value = NewStatus;
                command.Parameters.Add("LastDate", SqlDbType.DateTime).Value = DateTime.Now;
                command.Parameters.Add("ApplicationID", SqlDbType.Int).Value = ApplicationID;

                try
                {
                    connection.Open();

                    RowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("Failed to update application status.", ex);
                }
                return (RowsAffected > 0);
            }
        }
        public static bool DeleteApplication(int ApplicationID)
        {
            int rowsAffected = 0;
            string connectionString = DataAccessSettings.ConnectionString;

            string query = @"DELETE FROM Applications WHERE ApplicationID = @ApplicationID;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@ApplicationID", SqlDbType.Int).Value = ApplicationID;

                try
                {
                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("Failed to delete application.", ex);
                }
            }

            return rowsAffected > 0;
        }
        public static int GetActiveApplicationID(int PersonID , int ApplicationTypeID)
        {
            int ActiveApplicationID = -1;

            string connectionString = DataAccessSettings.ConnectionString;
            string query = @"SELECT ApplicationID FROM Applications WHERE ApplicantPersonID = @ApplicantPersonID 
                             AND ApplicationTypeID = @ApplicationTypeID AND ApplicationStatus = 1;";

            using(SqlConnection  connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();

                command.Parameters.Add("@ApplicantPersonID", SqlDbType.Int).Value = PersonID;
                command.Parameters.Add("@ApplicationTypeID", SqlDbType.Int).Value = ApplicationTypeID;

                try
                {
                    object result = command.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out int ExtractedID))
                        ActiveApplicationID = ExtractedID;
                }
                catch (Exception ex) 
                { 
                    throw new ApplicationException("Error : " + ex.Message);
                }
            }
            return ActiveApplicationID;
        }
        public static bool DoesPersonHaveActiveApplication(int PersonID, int ApplicationTypeID)
        {
            return (GetActiveApplicationID(PersonID, ApplicationTypeID) != -1);
        }
        public static int GetActiveApplicationIDForLicenseClass(int PersonID, int ApplicationTypeID,int LicenseClassID)
        {
            int ActiveApplicationID = -1;

            string connectionString = DataAccessSettings.ConnectionString;
            string query = @"SELECT 
                            A.ApplicationID 
                            FROM Applications A
                            INNER JOIN LocalDrivingLicenseApplications L
                            ON A.ApplicationID = L.ApplicationID
                            WHERE A.ApplicantPersonID = @ApplicantPersonID 
                            AND   A.ApplicationTypeID = @ApplicationTypeID
                            AND   L.LicenseClassID = @LicenseClassID
                            AND   A.ApplicationStatus = 1;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();

                command.Parameters.Add("@ApplicantPersonID", SqlDbType.Int).Value = PersonID;
                command.Parameters.Add("@ApplicationTypeID", SqlDbType.Int).Value = ApplicationTypeID;
                command.Parameters.Add("@LicenseClassID", SqlDbType.Int).Value = LicenseClassID;

                try
                {
                    object result = command.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out int ExtractedID))
                        ActiveApplicationID = ExtractedID;
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("Error : " + ex.Message);
                }
            }
            return ActiveApplicationID;
        }
     
    }
}
