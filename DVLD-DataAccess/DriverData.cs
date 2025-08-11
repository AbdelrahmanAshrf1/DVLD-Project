using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccessLayer
{
    public class DriverData
    {
        public static int AddNewDriver(int PersonID, int CreatedByUserID, DateTime CreatedDate)
        {
            int DriverID = -1;
            string connectionString = DataAccessSettings.ConnectionString;
            string query = @"INSERT INTO Drivers (PersonID, CreatedByUserID, CreatedDate)
                                 VALUES (@PersonID, @CreatedByUserID, @CreatedDate);
                                 SELECT SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@PersonID", SqlDbType.Int).Value = PersonID;
                command.Parameters.Add("@CreatedByUserID", SqlDbType.Int).Value = CreatedByUserID;
                command.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = CreatedDate;

                try
                {
                    connection.Open();

                    object result = command.ExecuteScalar();
                    if (result != null) DriverID = Convert.ToInt32(result);
                  
                }
                catch (Exception ex)
                {
                    throw new Exception("Error adding new driver: " + ex.Message);
                }
            }

            return DriverID;
        }
        public static bool UpdateDriver(int DriverID, int PersonID, int CreatedByUserID, DateTime CreatedDate)
        {
            int rowsAffected = 0;
            string connectionString = DataAccessSettings.ConnectionString;
            string query = @"UPDATE Drivers
                             SET PersonID = @PersonID,
                                 CreatedByUserID = @CreatedByUserID,
                                 CreatedDate = @CreatedDate
                             WHERE DriverID = @DriverID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
            
                command.Parameters.Add("@DriverID", SqlDbType.Int).Value = DriverID;
                command.Parameters.Add("@PersonID", SqlDbType.Int).Value = PersonID;
                command.Parameters.Add("@CreatedByUserID", SqlDbType.Int).Value = CreatedByUserID;
                command.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = CreatedDate;

                try
                {
                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    // Log or handle exception
                    throw new Exception("Error updating driver: " + ex.Message);
                }
            }

            return (rowsAffected > 0);
        }
        public static bool GetDriverInfoByPersonID(int PersonID,ref int DriverID,ref int CreatedByUserID, ref DateTime CreatedDate)
        {
            bool isFound = false;
            string connectionString = DataAccessSettings.ConnectionString;
            string query = @"SELECT * FROM Drivers WHERE PersonID = @PersonID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@PersonID", SqlDbType.Int).Value = PersonID;

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            isFound = true;

                            DriverID = (int)reader["DriverID"];
                            CreatedByUserID = (int)reader["CreatedByUserID"];
                            CreatedDate = (DateTime)reader["CreatedDate"];
                        }
                    }    
                }
                catch (Exception ex)
                {
                    throw new Exception("Error retrieving driver info by PersonID: " + ex.Message);
                }
            }

            return isFound;
        }
        public static bool GetDriverInfoByDriverID(int DriverID, ref int PersonID, ref int CreatedByUserID, ref DateTime CreatedDate)
        {
            bool isFound = false;
            string connectionString = DataAccessSettings.ConnectionString;
            string query = @"SELECT * FROM Drivers WHERE DriverID = @DriverID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@DriverID", SqlDbType.Int).Value = DriverID;

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            isFound = true;

                            PersonID = (int)reader["PersonID"];
                            CreatedByUserID = (int)reader["CreatedByUserID"];
                            CreatedDate = (DateTime)reader["CreatedDate"];
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error retrieving driver info by DriverID: " + ex.Message);
                }
            }

            return isFound;
        }
        public static DataTable GetAllDrivers()
        {
            DataTable dt = new DataTable();
            string connectionString = DataAccessSettings.ConnectionString;
            string query = @"SELECT * FROM Drivers_View ORDER BY FullName;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    dt.Load(reader);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error retrieving all drivers: " + ex.Message);
                }
            }

            return dt;
        }
    }
}

