using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccessLayer
{
    public class InternationalLicenseData
    {
        public static int AddNewInternationalLicense(int ApplicationID , int DriverID, int IssuedUsingLocalLicenseID,
        DateTime IssueDate, DateTime ExpirationDate, bool IsActive,int CreatedByUserID)
        {
            int internationalLicenseID = -1;
            string connectionString = DataAccessSettings.ConnectionString;

            string query = @"INSERT INTO InternationalLicenses 
                    (ApplicationID, DriverID, IssuedUsingLocalLicenseID, IssueDate, ExpirationDate, IsActive,CreatedByUserID)
                     VALUES 
                    (@ApplicationID, @DriverID, @IssuedUsingLocalLicenseID, @IssueDate, @ExpirationDate, @IsActive, @CreatedByUserID);
                     SELECT SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@ApplicationID", SqlDbType.Int).Value = ApplicationID;
                command.Parameters.Add("@DriverID", SqlDbType.Int).Value = DriverID;
                command.Parameters.Add("@IssuedUsingLocalLicenseID", SqlDbType.Int).Value = IssuedUsingLocalLicenseID;
                command.Parameters.Add("@IssueDate", SqlDbType.DateTime).Value = IssueDate;
                command.Parameters.Add("@ExpirationDate", SqlDbType.DateTime).Value = ExpirationDate;
                command.Parameters.Add("@IsActive", SqlDbType.Bit).Value = IsActive;
                command.Parameters.Add("@CreatedByUserID", SqlDbType.Int).Value = CreatedByUserID;

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null)
                        internationalLicenseID = Convert.ToInt32(result);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error in Add New International License", ex);
                }
            }

            return internationalLicenseID;
        }
        public static bool UpdateInternationalLicense(int InternationalLicenseID, int ApplicationID, int DriverID,
        int IssuedUsingLocalLicenseID, DateTime IssueDate,DateTime ExpirationDate, bool IsActive,int CreatedByUserID)
        {
            int rowsAffected = 0;
            string connectionString = DataAccessSettings.ConnectionString;

            string query = @"UPDATE InternationalLicenses
                     SET   ApplicationID = @ApplicationID,
                           DriverID = @DriverID,
                           IssuedUsingLocalLicenseID = @IssuedUsingLocalLicenseID,
                           IssueDate = @IssueDate,
                           ExpirationDate = @ExpirationDate,
                           IsActive = @IsActive,
                           CreatedByUserID = @CreatedByUserID
                     WHERE InternationalLicenseID = @InternationalLicenseID;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@InternationalLicenseID", SqlDbType.Int).Value = InternationalLicenseID;
                command.Parameters.Add("@ApplicationID", SqlDbType.Int).Value = ApplicationID;
                command.Parameters.Add("@DriverID", SqlDbType.Int).Value = DriverID;
                command.Parameters.Add("@IssuedUsingLocalLicenseID", SqlDbType.Int).Value = IssuedUsingLocalLicenseID;
                command.Parameters.Add("@IssueDate", SqlDbType.DateTime).Value = IssueDate;
                command.Parameters.Add("@ExpirationDate", SqlDbType.DateTime).Value = ExpirationDate;
                command.Parameters.Add("@IsActive", SqlDbType.Bit).Value = IsActive;
                command.Parameters.Add("@CreatedByUserID", SqlDbType.Int).Value = CreatedByUserID;

                try
                {
                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error in Update International License", ex);
                }
            }

            return (rowsAffected > 0);
        }
        public static bool GetInternationalLicenseInfoByID(int InternationalLicenseID,ref int ApplicationID, ref int DriverID, ref int IssuedUsingLocalLicenseID,
        ref DateTime IssueDate, ref DateTime ExpirationDate,ref bool IsActive, ref int CreatedByUserID)
        {
            bool isFound = false;
            string connectionString = DataAccessSettings.ConnectionString;

            string query = @"SELECT * FROM InternationalLicenses WHERE InternationalLicenseID = @InternationalLicenseID;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@InternationalLicenseID", SqlDbType.Int).Value = InternationalLicenseID;

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            isFound = true;

                            ApplicationID = Convert.ToInt32(reader["ApplicationID"]);
                            DriverID = Convert.ToInt32(reader["DriverID"]);
                            IssuedUsingLocalLicenseID = Convert.ToInt32(reader["IssuedUsingLocalLicenseID"]);
                            IssueDate = Convert.ToDateTime(reader["IssueDate"]);
                            ExpirationDate = Convert.ToDateTime(reader["ExpirationDate"]);
                            IsActive = Convert.ToBoolean(reader["IsActive"]);
                            CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error in Get International License Info", ex);
                }
            }

            return isFound;
        }
        public static DataTable GetAllInternationalLicenses()
        {
            DataTable dt = new DataTable();
            string connectionString = DataAccessSettings.ConnectionString;

            string query = @"SELECT
                             	 InternationalLicenseID,
                             	 ApplicationID,DriverID,
                                 IssuedUsingLocalLicenseID,
                             	 IssueDate, 
                                 ExpirationDate,
                             	 IsActive
                             FROM
                             	 InternationalLicenses 
                             ORDER BY
                             	 IsActive DESC,
                             	 ExpirationDate DESC;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {

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
                    throw new Exception("Error in Get All International Licenses!", ex);
                }
            }

            return dt;
        }
        public static DataTable GetDriverInternationalLicenses(int DriverID)
        {
            DataTable dt = new DataTable();
            string connectionString = DataAccessSettings.ConnectionString;

            string query = @"SELECT
                             	 InternationalLicenseID,
                             	 ApplicationID,DriverID,
                                 IssuedUsingLocalLicenseID,
                             	 IssueDate, 
                                 ExpirationDate,
                             	 IsActive
                             FROM
                             	 InternationalLicenses
                             WHERE 
                                 DriverID = @DriverID
                             ORDER BY
                             	 IsActive DESC,
                             	 ExpirationDate DESC;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@DriverID",SqlDbType.Int).Value = DriverID;

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
                    throw new Exception("Error in Get Driver International Licenses!", ex);
                }
            }

            return dt;
        }
        public static int GetActiveInternationalLicenseIDByDriverID(int DriverID)
        {
            int InternationalLicenseID = -1;
            string connectionString = DataAccessSettings.ConnectionString;

            string query = @"SELECT TOP 1
                             	 InternationalLicenseID
                             FROM
                             	 InternationalLicenses
                             WHERE 
                                 DriverID = @DriverID 
                                 AND IsActive = 1
                             ORDER BY
                             	 ExpirationDate DESC;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@DriverID", SqlDbType.Int).Value = DriverID;

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if(result != null) InternationalLicenseID = Convert.ToInt32(result);

                }
                catch (Exception ex)
                {
                    throw new Exception("Error in Get Actice Driver International LicensesID!", ex);
                }
            }

            return InternationalLicenseID;
        }
    }
}
