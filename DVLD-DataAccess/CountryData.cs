using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DataAccessLayer
{
    public class CountryData
    {
        public static bool GetCountryInfoByID(int ID, ref string CountryName, ref string ISO)
        {
            string connectionString = DataAccessSettings.ConnectionString;
            string query = "SELECT * FROM Countries WHERE CountryID = @CountryID;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@CountryID", SqlDbType.Int).Value = ID;

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            CountryName = reader["CountryName"].ToString();
                            ISO = reader["CountryISO"].ToString();

                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("Error retrieving country data: " + ex.Message, ex);
                }

            }
        }
        public static bool GetCountryInfoByName(string CountryName, ref int ID, ref string ISO)
        {
            string connectionString = DataAccessSettings.ConnectionString;
            string query = "SELECT * FROM Countries WHERE CountryName = @CountryName;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@CountryName", SqlDbType.NVarChar).Value = CountryName;

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            ID = (int)reader["CountryID"];
                            ISO = reader["CountryISO"].ToString();

                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("Error retrieving country data: " + ex.Message, ex);
                }

            }
        }
        public static DataTable GetAllCountries()
        {
            DataTable dataTable = new DataTable();

            string connectionString = DataAccessSettings.ConnectionString;
            string query = "SELECT * FROM Countries;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        dataTable.Load(reader);
                    }
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("Error : Can't Get Countries info", ex);
                }
            }

            return dataTable;
        }
    }
}
