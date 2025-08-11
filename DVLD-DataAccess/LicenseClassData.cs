using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DataAccessLayer
{
    public class LicenseClassData
    {
        public static DataTable GetAllLicenseClasses()
        {
            DataTable dataTable = new DataTable();
            string connectionString = DataAccessSettings.ConnectionString;
            string query = @"SELECT * FROM LicenseClasses;";

            using(SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                try
                {
                    connection.Open();

                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        dataTable.Load(reader);
                    }
                }
                catch(Exception ex)
                {
                    throw new ApplicationException("Error : " + ex.Message);
                }
            }

            return dataTable;
        }

        public static int AddNewLicenseClass(string ClassName, string ClassDescription, byte MinimumAllowedAge, 
                                             byte DefaultValidityLength, float ClassFees)
        {
            int insertedID = -1;
            string connectionString = DataAccessSettings.ConnectionString;

            string query = @"INSERT INTO LicenseClasses 
                     (ClassName, ClassDescription, MinimumAllowedAge, DefaultValidityLength, ClassFees)
                     VALUES 
                     (@ClassName, @ClassDescription, @MinimumAllowedAge, @DefaultValidityLength, @ClassFees);
                     SELECT SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@ClassName", SqlDbType.NVarChar).Value = ClassName;
                command.Parameters.Add("@ClassDescription", SqlDbType.NVarChar).Value = ClassDescription;
                command.Parameters.Add("@MinimumAllowedAge", SqlDbType.TinyInt).Value = MinimumAllowedAge;
                command.Parameters.Add("@DefaultValidityLength", SqlDbType.TinyInt).Value = DefaultValidityLength;
                command.Parameters.Add("@ClassFees", SqlDbType.SmallMoney).Value = ClassFees;

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out int newID))
                        insertedID = newID;
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("Failed to add new license class.", ex);
                }
            }

            return insertedID;
        }
        public static bool UpdateLicenseClass(int LicenseClassID, string ClassName, string ClassDescription,
                                              byte MinimumAllowedAge, byte DefaultValidityLength, float ClassFees)
        {
            int rowsAffected = 0;
            string connectionString = DataAccessSettings.ConnectionString;

            string query = @"UPDATE LicenseClasses SET 
                        ClassName = @ClassName,
                        ClassDescription = @ClassDescription,
                        MinimumAllowedAge = @MinimumAllowedAge,
                        DefaultValidityLength = @DefaultValidityLength,
                        ClassFees = @ClassFees
                     WHERE LicenseClassID = @LicenseClassID;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@LicenseClassID", SqlDbType.Int).Value = LicenseClassID;
                command.Parameters.Add("@ClassName", SqlDbType.NVarChar).Value = ClassName;
                command.Parameters.Add("@ClassDescription", SqlDbType.NVarChar).Value = ClassDescription;
                command.Parameters.Add("@MinimumAllowedAge", SqlDbType.TinyInt).Value = MinimumAllowedAge;
                command.Parameters.Add("@DefaultValidityLength", SqlDbType.TinyInt).Value = DefaultValidityLength;
                command.Parameters.Add("@ClassFees", SqlDbType.SmallMoney).Value = ClassFees;

                try
                {
                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("Failed to update license class.", ex);
                }
            }

            return rowsAffected > 0;
        }
        public static bool GetLicenseClassInfoByID(int LicenseClassID,ref string ClassName, ref string ClassDescription,
        ref byte MinimumAllowedAge,ref byte DefaultValidityLength, ref float ClassFees)
        {
            bool isFound = false;
            string connectionString = DataAccessSettings.ConnectionString;

            string query = @"SELECT * FROM LicenseClasses WHERE LicenseClassID = @LicenseClassID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@LicenseClassID", SqlDbType.Int).Value = LicenseClassID;

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            isFound = true;

                            ClassName = reader["ClassName"].ToString();
                            ClassDescription = reader["ClassDescription"].ToString();
                            MinimumAllowedAge = Convert.ToByte(reader["MinimumAllowedAge"]);
                            DefaultValidityLength = Convert.ToByte(reader["DefaultValidityLength"]);
                            ClassFees = Convert.ToSingle(reader["ClassFees"]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("Failed to get license class info by ID.", ex);
                }
            }

            return isFound;
        }

        public static bool GetLicenseClassInfoByClassName(ref int LicenseClassID, string ClassName, ref string ClassDescription,
        ref byte MinimumAllowedAge, ref byte DefaultValidityLength, ref float ClassFees)
        {
            bool isFound = false;
            string connectionString = DataAccessSettings.ConnectionString;

            string query = @"SELECT * FROM LicenseClasses WHERE ClassName = @ClassName";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@ClassName", SqlDbType.NVarChar).Value = ClassName;

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            isFound = true;
                            LicenseClassID = Convert.ToInt32(reader["LicenseClassID"]);
                            ClassDescription = reader["ClassDescription"].ToString();
                            MinimumAllowedAge = Convert.ToByte(reader["MinimumAllowedAge"]);
                            DefaultValidityLength = Convert.ToByte(reader["DefaultValidityLength"]);
                            ClassFees = Convert.ToSingle(reader["ClassFees"]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("Failed to get license class info by class name.", ex);
                }
            }

            return isFound;
        }
    }
}
