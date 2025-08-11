using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DataAccessLayer
{
    public class LicenseData
    {
        public static int AddNewLicense(int ApplicationID, int DriverID, int LicenseClass,
            DateTime IssueDate, DateTime ExpirationDate, string Notes, float PaidFees,
            bool IsActive, byte IssueReason, int CreatedByUserID)
        {
            int LicenseID = -1;
            string connectionString = DataAccessSettings.ConnectionString;
            string query = @"INSERT INTO Licenses 
                             (ApplicationID, DriverID, LicenseClass, IssueDate, ExpirationDate, Notes, PaidFees, IsActive, IssueReason, CreatedByUserID)
                             VALUES (@ApplicationID, @DriverID, @LicenseClass, @IssueDate, @ExpirationDate, @Notes, @PaidFees, @IsActive, @IssueReasonID, @CreatedByUserID);
                             SELECT SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@ApplicationID", SqlDbType.Int).Value = ApplicationID;
                command.Parameters.Add("@DriverID", SqlDbType.Int).Value = DriverID;
                command.Parameters.Add("@LicenseClass", SqlDbType.Int).Value = LicenseClass;
                command.Parameters.Add("@IssueDate", SqlDbType.DateTime).Value = IssueDate;
                command.Parameters.Add("@ExpirationDate", SqlDbType.DateTime).Value = ExpirationDate;
                command.Parameters.Add("@PaidFees", SqlDbType.SmallMoney).Value = PaidFees;
                command.Parameters.Add("@IsActive", SqlDbType.Bit).Value = IsActive;
                command.Parameters.Add("@IssueReasonID", SqlDbType.TinyInt).Value = IssueReason;
                command.Parameters.Add("@CreatedByUserID", SqlDbType.Int).Value = CreatedByUserID;

                if (Notes == "")
                    command.Parameters.Add("@Notes", SqlDbType.NVarChar, 500).Value = DBNull.Value;
                else
                    command.Parameters.Add("@Notes", SqlDbType.NVarChar, 500).Value = Notes;

                try
                {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null) LicenseID = Convert.ToInt32(result);
                    }
                    catch (Exception ex)
                    {
                        throw new ApplicationException("Error can't Find Add new License !", ex);
                    }

            }

            return LicenseID;
        }
        public static bool UpdateLicense(int LicenseID, int ApplicationID, int DriverID, int LicenseClassID,
            DateTime IssueDate, DateTime ExpirationDate, string Notes, float PaidFees,
            bool IsActive, int IssueReasonID, int CreatedByUserID)
        {
            int rowsAffected = 0;
            string connectionString = DataAccessSettings.ConnectionString;
            string query = @"UPDATE Licenses
                             SET ApplicationID = @ApplicationID,
                                 DriverID = @DriverID,
                                 LicenseClassID = @LicenseClassID,
                                 IssueDate = @IssueDate,
                                 ExpirationDate = @ExpirationDate,
                                 Notes = @Notes,
                                 PaidFees = @PaidFees,
                                 IsActive = @IsActive,
                                 IssueReason = @IssueReasonID,
                                 CreatedByUserID = @CreatedByUserID
                             WHERE LicenseID = @LicenseID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@LicenseID", SqlDbType.Int).Value = LicenseID;
                command.Parameters.Add("@ApplicationID", SqlDbType.Int).Value = ApplicationID;
                command.Parameters.Add("@DriverID", SqlDbType.Int).Value = DriverID;
                command.Parameters.Add("@LicenseClassID", SqlDbType.Int).Value = LicenseClassID;
                command.Parameters.Add("@IssueDate", SqlDbType.DateTime).Value = IssueDate;
                command.Parameters.Add("@ExpirationDate", SqlDbType.DateTime).Value = ExpirationDate;
                command.Parameters.Add("@Notes", SqlDbType.NVarChar, 500).Value = Notes;
                command.Parameters.Add("@PaidFees", SqlDbType.SmallMoney).Value = PaidFees;
                command.Parameters.Add("@IsActive", SqlDbType.Bit).Value = IsActive;
                command.Parameters.Add("@IssueReasonID", SqlDbType.TinyInt).Value = IssueReasonID;
                command.Parameters.Add("@CreatedByUserID", SqlDbType.Int).Value = CreatedByUserID;

                try
                {
                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("Error can't Find Add new License !", ex);
                }

            }

            return (rowsAffected > 0);
        }
        public static bool GetLicenseInfoByID(int LicenseID, ref int ApplicationID, ref int DriverID,
            ref int LicenseClass, ref DateTime IssueDate, ref DateTime ExpirationDate, ref string Notes,
            ref float PaidFees, ref bool IsActive, ref byte IssueReason, ref int CreatedByUserID)
        {
            bool isFound = false;
            string connectionString = DataAccessSettings.ConnectionString;
            string query = @"SELECT * FROM Licenses WHERE LicenseID = @LicenseID";

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

                            ApplicationID = (int)reader["ApplicationID"];
                            DriverID = (int)reader["DriverID"];
                            LicenseClass = (int)reader["LicenseClass"];
                            IssueDate = (DateTime)reader["IssueDate"];
                            ExpirationDate = (DateTime)reader["ExpirationDate"];
                            Notes = reader["Notes"].ToString();
                            PaidFees = Convert.ToSingle(reader["PaidFees"]);
                            IsActive = (bool)reader["IsActive"];
                            IssueReason = (byte)reader["IssueReason"];
                            CreatedByUserID = (int)reader["CreatedByUserID"];
                        }
                    }

                }
                catch (Exception ex)
                {
                    throw new ApplicationException("Error can't Find License Info !", ex);
                }
            }

            return isFound;
        }
        public static DataTable GetAllLicenses()
        {
            DataTable dt = new DataTable();

            string query = @"SELECT * FROM Licenses";

            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
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
                catch(Exception ex)
                {
                    throw new ApplicationException("Error : Can't Get All Licenses !", ex);
                }

                return dt;
            }
        }
        public static int GetActiveLicenseIDByPersonID(int personID,int LicenseClassID)
        {
            int licenseID = -1;
            string connectionString = DataAccessSettings.ConnectionString;
            string query = @"SELECT 
                             	L.LicenseID 
                             FROM 
                             	Licenses L
                             	INNER JOIN Drivers D ON L.DriverID = D.DriverID
                             WHERE 
                             	D.PersonID = @PersonID
                             	AND L.LicenseClass = @LicenseClassID
                             	AND L.IsActive = 1; -- 1 = Active";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@PersonID",SqlDbType.Int).Value = personID;
                command.Parameters.Add("@LicenseClassID", SqlDbType.Int).Value = LicenseClassID;

                try
                {
                    connection.Open();

                    object result = command.ExecuteScalar();
                    if(result != null && result != DBNull.Value)
                        licenseID = (int)result;
                }
                catch(Exception ex)
                {
                    throw new ApplicationException("Error can't Find Get Active LicenseID !", ex);
                }
            }

            return licenseID;
        }
        public static DataTable GetAllDriverLicenses(int DriverID)
        {
            DataTable dt = new DataTable();
            string connectionString = DataAccessSettings.ConnectionString;
            string query = @"SELECT     
                                L.LicenseID,
                                L.ApplicationID,
                                LC.ClassName,
                                L.IssueDate, 
                                L.ExpirationDate, 
                                L.IsActive
                             FROM
                             	Licenses L
                             	INNER JOIN LicenseClasses LC ON L.LicenseClass = LC.LicenseClassID
                             WHERE 
                             	L.DriverID = @DriverID
                             ORDER BY 
                             	L.ExpirationDate DESC;
                             ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@DriverID", SqlDbType.Int).Value = DriverID;

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if(reader.HasRows) dt.Load(reader);
                    }
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("Error can't  Get Driver Licenses !", ex);
                }
            }

            return dt;
        }
        public static bool DeactivateLicense(int LicenseID)
        {
            int rowsAffected = 0;
            string connectionString = DataAccessSettings.ConnectionString;
            string query = @"UPDATE Licenses
                             SET    IsActive = 0
                             WHERE  LicenseID = @LicenseID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@LicenseID", SqlDbType.Int).Value = LicenseID;
                
                try
                {
                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("Error can't Deactivate License !", ex);
                }

            }

            return (rowsAffected > 0);
        }
    }
}
