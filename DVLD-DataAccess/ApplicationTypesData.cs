using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccessLayer
{
    public class ApplicationTypesData
    {
        public static DataTable GetAllApplicationTypes()
        {
            DataTable dataTable = new DataTable();
            string connectionString = DataAccessSettings.ConnectionString;

            string query = "SELECT * FROM ApplicationTypes;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader()) dataTable.Load(reader); 
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("Failed to retrieve application types.", ex);
                }

            }
            return dataTable;
        }

        public static int AddNewApplicationType(string Title, float Fees)
        {
            int ID = -1;
            string connectionString = DataAccessSettings.ConnectionString;

            string query = @"INSERT INTO ApplicationTypes (ApplicationTypeTitle, ApplicationFees)
                            VALUES (@ApplicationTypeTitle, @ApplicationFees);
                            SELECT SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@ApplicationTypeTitle", SqlDbType.NVarChar).Value = Title;
                command.Parameters.Add("@ApplicationFees", SqlDbType.SmallMoney).Value = Fees;

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        ID = Convert.ToInt32(result);
                    }
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("Failed to insert new application type.", ex);
                }
            }

            return ID;
        }
        public static bool UpdateApplicationType(int ID, string Title, float Fees)
        {
            int rowsAffected = 0;
            string connectionString = DataAccessSettings.ConnectionString;
            string query = @"UPDATE ApplicationTypes SET
                                    ApplicationTypeTitle = @ApplicationTypeTitle ,
                                    ApplicationFees = @ApplicationFees
                             WHERE  ApplicationTypeID = @ApplicationTypeID;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query,connection))
            {
                command.Parameters.Add("@ApplicationTypeID", SqlDbType.Int).Value = ID;
                command.Parameters.Add("@ApplicationTypeTitle", SqlDbType.NVarChar).Value = Title;
                command.Parameters.Add("@ApplicationFees", SqlDbType.SmallMoney).Value = Fees;

                try
                {
                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("Failed to Update application types.", ex);
                }
            }
            return (rowsAffected > 0);
        }
        public static bool GetApplicationTypeInfoByID(int ID, ref string Title , ref float Fees)
        {
            bool IsFound = false;
            string connectionString = DataAccessSettings.ConnectionString;
            string query = @"SELECT * FROM ApplicationTypes WHERE ApplicationTypeID = @ApplicationTypeID;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@ApplicationTypeID", SqlDbType.Int).Value = ID;
             
                try
                {
                    connection.Open();

                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Title = reader["ApplicationTypeTitle"].ToString();
                            Fees = Convert.ToSingle(reader["ApplicationFees"]);

                            IsFound = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("Failed to Find application types.", ex);
                }

                return IsFound;
            }
        }
    }
}
