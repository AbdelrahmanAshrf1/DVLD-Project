using System;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.Remoting.Messaging;

namespace DVLD_DataAccessLayer
{
    public class UserData
    {
        public static bool IsUserExist(string username)
        {
            string connectionString = DataAccessSettings.ConnectionString;
            string query = "SELECT 1 FROM Users WHERE username = @username;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@username", SqlDbType.NVarChar).Value = username;

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    return result != null;
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("Error can't Find the User !", ex);
                }
            }
        }
        public static bool IsUserExist(int UserID)
        {
            string connectionString = DataAccessSettings.ConnectionString;
            string query = "SELECT 1 FROM Users WHERE UserID = @UserID;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@UserID", SqlDbType.Int).Value = UserID;

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    return result != null;
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("Error can't Find the User !", ex);
                }
            }
        }
        public static int AddNewUser(int PersonID, string Username, string Password, bool IsActive)
        {
            int ID = -1;
            string connectionString = DataAccessSettings.ConnectionString;

            string query = @" INSERT INTO Users (PersonID , Username , Password , IsActive ) 
                              VALUES (@PersonID, @Username, @Password, @IsActive);
                              SELECT SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@PersonID",SqlDbType.Int).Value = PersonID;
                command.Parameters.Add("@Username", SqlDbType.NVarChar).Value = Username;
                command.Parameters.Add("@Password", SqlDbType.NVarChar).Value = Password;
                command.Parameters.Add("@IsActive", SqlDbType.TinyInt).Value = IsActive;

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
                    throw new ApplicationException("Error inserting new User!", ex);
                }

                return ID;
            }
        }
        public static bool UpdateUser(int ID,int PersonID, string Username, string Password, bool IsActive)
        {
            int rowsAffected = 0;
            string connectionString = DataAccessSettings.ConnectionString;

            string Query = @"UPDATE Users SET 
                                                PersonID = @PersonID,
                                                Username = @Username,
                                                Password = @Password,
                                                IsActive = @IsActive
                                                
                                          WHERE UserID = @UserID;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(Query, connection))
            {
                command.Parameters.Add("@PersonID", SqlDbType.Int).Value = PersonID;
                command.Parameters.Add("@Username", SqlDbType.NVarChar).Value = Username;
                command.Parameters.Add("@Password", SqlDbType.NVarChar).Value = Password;
                command.Parameters.Add("@IsActive", SqlDbType.TinyInt).Value = IsActive ? 1 : 0;
                command.Parameters.Add("@UserID", SqlDbType.Int).Value = ID;
 
                try
                {
                    connection.Open();

                    rowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("Error Update User !", ex);
                }

                return (rowsAffected > 0);
            }
        }
        public static bool GetUserInfoByUserID(int ID,ref int PersonID, ref string Username, ref string Password, ref bool IsActive)
        {
            string connectionString = DataAccessSettings.ConnectionString;

            string Query = @"SELECT * FROM Users WHERE UserID = @UserID;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(Query, connection))
            {
                try
                {
                    command.Parameters.Add("@UserID", SqlDbType.Int).Value = ID;

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            PersonID = (int)reader["PersonID"];
                            Username = reader["Username"].ToString();
                            Password = reader["Password"].ToString();
                            IsActive = Convert.ToByte(reader["IsActive"]) == 1;

                            return true;
                        }
                        else
                            return false;
                    }

                }
                catch (Exception ex)
                {
                    throw new ApplicationException("\"Error: Cannot find the User.\"\r\n", ex);
                }
            }
        }
        public static bool GetUserInfoByPersonID(int ID, ref int UserID, ref string Username, ref string Password, ref bool IsActive)
        {
            string connectionString = DataAccessSettings.ConnectionString;

            string Query = @"SELECT * FROM Users WHERE PersonID = @PersonID;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(Query, connection))
            {
                try
                {
                    command.Parameters.Add("@PersonID", SqlDbType.Int).Value = ID;

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            UserID = (int)reader["UserID"];
                            Username = reader["Username"].ToString();
                            Password = reader["Password"].ToString();
                            IsActive = Convert.ToByte(reader["IsActive"]) == 1;

                            return true;
                        }
                        else
                            return false;

                    }

                }
                catch (Exception ex)
                {
                    throw new ApplicationException("Error: Cannot find the User.", ex);
                }
            }
        }
        public static bool GetUserInfoByUsername(string Username,ref string Password, ref int UserID, ref int PersonID, ref bool IsActive)
        {
            string connectionString = DataAccessSettings.ConnectionString;

            string qurey = "SELECT * FROM Users WHERE Username = @Username";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(qurey, connection))
            {
                command.Parameters.Add("@Username", SqlDbType.NVarChar).Value = Username;

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            UserID = (int)reader["UserID"];
                            Password = reader["Password"].ToString();
                            PersonID = (int)reader["PersonID"];
                            IsActive = Convert.ToByte(reader["IsActive"]) == 1;

                            return true;
                        }
                        else
                            return false;
                    }
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("Error: Cannot find the User.", ex);
                }

            }
        }
        public static bool GetUserInfoByUsernameAndPassword(string Username, string Password, ref int UserID, ref int PersonID, ref bool IsActive)
        {
            string connectionString = DataAccessSettings.ConnectionString;

            string qurey = "SELECT * FROM Users WHERE Username = @Username AND Password = @Password;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(qurey, connection))
            {
                command.Parameters.Add("@Username", SqlDbType.NVarChar).Value = Username;
                command.Parameters.Add("@Password", SqlDbType.NVarChar).Value = Password;

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            UserID = (int)reader["UserID"];
                            PersonID = (int)reader["PersonID"];
                            IsActive = Convert.ToByte(reader["IsActive"]) == 1;

                            return true;
                        }
                        else
                            return false;
                    }
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("Error: Cannot find the User.", ex);
                }

            }
        }
        public static bool DeleteUser(int userID)
        {
            int rowsAffected = 0;
            string connectionString = DataAccessSettings.ConnectionString;
            string Query = "DELETE FROM Users WHERE UserID = @UserID;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(Query, connection))
            {
                command.Parameters.Add("@UserID", SqlDbType.Int).Value = userID;

                try
                {
                    connection.Open();

                    rowsAffected = command.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    throw new ApplicationException($"Error Deleting User With {userID} ID ", ex);
                }

                return (rowsAffected > 0);
            }
        }
        public static DataTable GetAllUsers()
        {
            DataTable dataTable = new DataTable();
            string connectionString = DataAccessSettings.ConnectionString;
            string query = @"SELECT Users.UserID, People.PersonID, People.FirstName + ' ' + People.SecondName + ' ' + 
                                    People.ThirdName + ' ' + People.LastName AS FullName, Users.UserName, Users.IsActive
                             FROM   People INNER JOIN Users 
                             ON     People.PersonID = Users.PersonID;";

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
                    throw new ApplicationException("Error Getting All Users", ex);
                }

                return dataTable;
            }
        }
        public static bool IsUserExistForPersonID(int PersonID)
        {
            string connectionString = DataAccessSettings.ConnectionString;
            string query = "SELECT 1 FROM Users WHERE PersonID = @PersonID;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@PersonID", SqlDbType.Int).Value = PersonID;

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    return result != null;
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("Error can't Find the User !", ex);
                }
            }
        }
    }
}
