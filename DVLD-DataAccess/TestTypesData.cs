using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccessLayer
{
    public class TestTypesData
    {
        public static DataTable GetAllTestTypes()
        {
            DataTable dataTable = new DataTable();
            string connectionString = DataAccessSettings.ConnectionString;

            string query = "SELECT * FROM TestTypes;";

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
                    throw new ApplicationException("Failed to retrieve Test types.", ex);
                }

            }
            return dataTable;
        }
        public static int AddNewTestType(string Title, string Description, float Fees)
        {
            int insertedID = -1;
            string connectionString = DataAccessSettings.ConnectionString;

            string query = @"INSERT INTO TestTypes (TestTypeTitle, TestTypeDescription, TestTypeFees)
                             VALUES (@TestTypeTitle, @TestTypeDescription, @TestTypeFees);
                             SELECT SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@TestTypeTitle", SqlDbType.NVarChar).Value = Title;
                command.Parameters.Add("@TestTypeDescription", SqlDbType.NVarChar).Value = Description;
                command.Parameters.Add("@TestTypeFees", SqlDbType.SmallMoney).Value = Fees;

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    insertedID = Convert.ToInt32(result);
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("Failed to add new test type.", ex);
                }
            }

            return insertedID;
        }
        public static bool UpdateTestType(int ID ,string Title,string Description,float Fees)
        {
            int rowsAffected = 0;
            string connectionString = DataAccessSettings.ConnectionString;
            string query = @"UPDATE TestTypes SET
                                    TestTypeTitle = @TestTypeTitle ,
                                    TestTypeDescription = @TestTypeDescription,
                                    TestTypeFees = @TestTypeFees
                             WHERE  TestTypeID = @TestTypeID;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@TestTypeID", SqlDbType.Int).Value = ID;
                command.Parameters.Add("@TestTypeTitle", SqlDbType.NVarChar).Value = Title;
                command.Parameters.Add("@TestTypeDescription", SqlDbType.NVarChar).Value =Description;
                command.Parameters.Add("@TestTypeFees", SqlDbType.SmallMoney).Value = Fees;

                try
                {
                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("Failed to Update Test types.", ex);
                }
            }
            return (rowsAffected > 0);
        }
        public static bool GetTestTypeInfoByID(int ID ,ref string Title,ref string Description,ref float Fees)
        {
            string connectionString = DataAccessSettings.ConnectionString;
            string query = @"SELECT * FROM TestTypes WHERE TestTypeID = @TestTypeID;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@TestTypeID", SqlDbType.Int).Value = ID;

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Title = reader["TestTypeTitle"].ToString();
                            Description = reader["TestTypeDescription"].ToString();
                            Fees = Convert.ToSingle(reader["TestTypeFees"]);

                            return true;
                        }
                        else
                            return false; // Not found

                    }
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("Failed to Find Test types.", ex);
                }
            }
        }
    }
}
