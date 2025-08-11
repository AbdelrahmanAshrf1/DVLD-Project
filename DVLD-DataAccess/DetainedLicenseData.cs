using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlTypes;
using System.ComponentModel;

namespace DVLD_DataAccessLayer
{
    public class DetainedLicenseData
    {
        public static int AddNewDetainedLicense(int LicenseID, DateTime DetainDate, float FineFees,int CreatedByUserID)
        {
            int DetainID = -1;
            string connectionString = DataAccessSettings.ConnectionString;
            string query = @"INSERT INTO DetainedLicenses
                            (LicenseID, DetainDate, FineFees, CreatedByUserID, IsReleased)
                            VALUES
                            (@LicenseID, @DetainDate, @FineFees, @CreatedByUserID, 0);
                            SELECT SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@LicenseID", SqlDbType.Int).Value = LicenseID;
                command.Parameters.Add("@DetainDate", SqlDbType.DateTime).Value = DetainDate;
                command.Parameters.Add("@FineFees", SqlDbType.SmallMoney).Value = FineFees;
                command.Parameters.Add("@CreatedByUserID", SqlDbType.Int).Value = CreatedByUserID;
               
                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null) DetainID = Convert.ToInt32(result);
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("Error: Can't add new detained license!", ex);
                }
            }

            return DetainID;
        }
        public static bool UpdateDetainedLicense(int DetainID, int LicenseID, DateTime DetainDate, float FineFees,int CreatedByUserID)
        {
            int rowsAffected = 0;
            string connectionString = DataAccessSettings.ConnectionString;
            string query = @"UPDATE DetainedLicenses
                             SET    LicenseID = @LicenseID,
                                    DetainDate = @DetainDate,
                                    FineFees = @FineFees,
                                    CreatedByUserID = @CreatedByUserID
                             WHERE  DetainID = @DetainID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@DetainID", SqlDbType.Int).Value = DetainID;
                command.Parameters.Add("@LicenseID", SqlDbType.Int).Value = LicenseID;
                command.Parameters.Add("@DetainDate", SqlDbType.DateTime).Value = DetainDate;
                command.Parameters.Add("@FineFees", SqlDbType.SmallMoney).Value = FineFees;
                command.Parameters.Add("@CreatedByUserID", SqlDbType.Int).Value = CreatedByUserID;
      
                try
                {
                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("Error: Can't update detained license!", ex);
                }
            }

            return (rowsAffected > 0);
        }
        public static bool GetDetainedLicenseInfoByID(int DetainID, ref int LicenseID, ref DateTime DetainDate,
        ref float FineFees, ref int CreatedByUserID, ref bool IsReleased,ref DateTime ReleaseDate, ref int ReleasedByUserID, ref int ReleasedApplicationID)
        {
            bool isFound = false;
            string connectionString = DataAccessSettings.ConnectionString;
            string query = @"SELECT * FROM DetainedLicenses WHERE DetainID = @DetainID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@DetainID", SqlDbType.Int).Value = DetainID;

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            isFound = true;

                            LicenseID = (int)reader["LicenseID"];
                            DetainDate = (DateTime)reader["DetainDate"];
                            FineFees = Convert.ToSingle(reader["FineFees"]);
                            CreatedByUserID = (int)reader["CreatedByUserID"];
                            IsReleased = (bool)reader["IsReleased"];
                            ReleaseDate = (reader["ReleaseDate"] == DBNull.Value)? DateTime.MaxValue : (DateTime)reader["ReleaseDate"];
                            ReleasedByUserID = (reader["ReleasedByUserID"] == DBNull.Value)? -1 : (int)reader["ReleasedByUserID"];
                            ReleasedApplicationID = (reader["ReleasedApplicationID"] == DBNull.Value) ? -1 : (int)reader["ReleasedApplicationID"];
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("Error: Can't get detained license info!", ex);
                }
            }

            return isFound;
        }
        public static bool GetDetainedLicenseInfoByLicenseID(int LicenseID, ref int DetainID, ref DateTime DetainDate,
        ref float FineFees, ref int CreatedByUserID, ref bool IsReleased,ref DateTime ReleaseDate, ref int ReleasedByUserID, ref int ReleaseApplicationID)
        {
            bool isFound = false;
            string connectionString = DataAccessSettings.ConnectionString;
            string query = @"SELECT TOP 1 * FROM DetainedLicenses WHERE LicenseID = @LicenseID ORDER BY DetainID DESC;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@LicenseID", SqlDbType.Int).Value = LicenseID;

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            isFound = true;

                            DetainID = (int)reader["DetainID"];
                            DetainDate = (DateTime)reader["DetainDate"];
                            FineFees = Convert.ToSingle(reader["FineFees"]);
                            CreatedByUserID = (int)reader["CreatedByUserID"];
                            IsReleased = (bool)reader["IsReleased"];
                            ReleaseDate = (reader["ReleaseDate"] == DBNull.Value) ? DateTime.MaxValue : (DateTime)reader["ReleaseDate"];
                            ReleasedByUserID = (reader["ReleasedByUserID"] == DBNull.Value) ? -1 : (int)reader["ReleasedByUserID"];
                            ReleaseApplicationID = (reader["ReleaseApplicationID"] == DBNull.Value) ? -1 : (int)reader["ReleaseApplicationID"];
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("Error: Can't get detained license info!", ex);
                }
            }

            return isFound;
        }
        public static DataTable GetAllDetainedLicenses()
        {
            DataTable dt = new DataTable();
            string query = @"SELECT * FROM detainedLicenses_View ORDER BY IsReleased ,DetainID";

            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
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
                    throw new ApplicationException("Error: Can't get all detained licenses!", ex);
                }
            }

            return dt;
        }
        public static bool ReleaseDetainedLicense(int DetainID,int ReleasedByUserID,int ReleaseApplicationID)
        {
            int rowsAffected = 0;
            string connectionString = DataAccessSettings.ConnectionString;
            string query = @"UPDATE
                             	 DetainedLicenses
                             SET 
                             	 IsReleased = 1,
                             	 ReleaseDate = @ReleaseDate,
                             	 ReleasedByUserID = @ReleasedByUserID,
                             	 ReleaseApplicationID = @ReleaseApplicationID
                             WHERE 
                             	 DetainID = @DetainID AND IsReleased = 0;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@DetainID", SqlDbType.Int).Value = DetainID;
                command.Parameters.Add("@ReleaseDate", SqlDbType.DateTime).Value = DateTime.Now;
                command.Parameters.Add("@ReleasedByUserID", SqlDbType.Int).Value = ReleasedByUserID;
                command.Parameters.Add("@ReleaseApplicationID", SqlDbType.Int).Value = ReleaseApplicationID;

                try
                {
                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("Error: Can't Release Detained License!", ex);
                }
            }

            return (rowsAffected > 0);
        }
        public static bool IsLicenseDetained(int LicenseID)
        {
            bool isLicenseDetained = false;
            string connectionString = DataAccessSettings.ConnectionString;
            string query = @"SELECT 
                             	 IsDetained = 1
                             FROM 
                               	 DetainedLicenses
                             WHERE 
                             	 LicenseID = @LicenseID
                             	 AND IsReleased = 0;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@LicenseID", SqlDbType.Int).Value = LicenseID;
      
                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if(result != null) isLicenseDetained = Convert.ToBoolean(result);
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("Error: Can't Know if License Detained!", ex);
                }
            }

            return isLicenseDetained;
        }
    }
}
