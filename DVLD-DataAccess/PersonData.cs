using System;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.Remoting.Messaging;

namespace DVLD_DataAccessLayer
{
    public class PersonData
    {
        public static bool IsPersonExist(int PersonID)
        {
            string connectionString = DataAccessSettings.ConnectionString;
            string query = "SELECT 1 FROM People WHERE PersonID = @PersonID;";

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
                    throw new ApplicationException("Error can't Find the Person !", ex);
                }
            }
        }

        public static bool IsPersonExist(string NationalNo)
        {
            string connectionString = DataAccessSettings.ConnectionString;
            string query = "SELECT 1 FROM People WHERE NationalNo = @NationalNo;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@NationalNo",SqlDbType.NVarChar).Value = NationalNo;

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    return result != null;
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("Error can't Find the Person !", ex);
                }
            }
        }

        public static int AddNewPerson(string FirstName, string SecondName,
           string ThirdName, string LastName, string NationalNo, DateTime DateOfBirth,
           byte Gender, string Address, string Phone, string Email,
           int NationalityCountryID, string ImagePath)
        {
            int ID = -1;
            string connectionString = DataAccessSettings.ConnectionString;

            string query = @"
                            INSERT INTO People (
                                NationalNo, FirstName, SecondName, ThirdName, LastName,
                                DateOfBirth, Gender, Address, Phone, Email, NationalityCountryID, ImagePath
                            ) 
                            VALUES (
                                @NationalNo, @FirstName, @SecondName, @ThirdName, @LastName,
                                @DateOfBirth, @Gender, @Address, @Phone, @Email, @NationalityCountryID, @ImagePath
                            );
                            SELECT SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@NationalNo", SqlDbType.NVarChar).Value = NationalNo;
                command.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = FirstName;
                command.Parameters.Add("@SecondName", SqlDbType.NVarChar).Value =SecondName;
                command.Parameters.Add("@ThirdName", SqlDbType.NVarChar).Value =
                string.IsNullOrWhiteSpace(ThirdName) ? DBNull.Value : (object)ThirdName;
                command.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = LastName;
                command.Parameters.Add("@DateOfBirth", SqlDbType.DateTime).Value = DateOfBirth;
                command.Parameters.Add("@Gender", SqlDbType.TinyInt).Value = (byte)Gender;
                command.Parameters.Add("@Address", SqlDbType.NVarChar).Value = Address;
                command.Parameters.Add("@Phone", SqlDbType.NVarChar).Value = Phone;
                command.Parameters.Add("@Email", SqlDbType.NVarChar).Value =
                string.IsNullOrWhiteSpace(Email) ? DBNull.Value : (object)Email;
                command.Parameters.Add("@NationalityCountryID", SqlDbType.Int).Value = NationalityCountryID;
                command.Parameters.Add("@ImagePath", SqlDbType.NVarChar).Value =
                string.IsNullOrWhiteSpace(ImagePath) ? DBNull.Value : (object)ImagePath;

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
                    throw new ApplicationException("Error inserting new person!", ex);
                }

                return ID;
            }
        }

        public static bool UpdatePerson(int ID, string FirstName, string SecondName,
           string ThirdName, string LastName, string NationalNo, DateTime DateOfBirth,
           byte Gender, string Address, string Phone, string Email,
           int NationalityCountryID, string ImagePath)
        {
            int rowsAffected = 0;
            string connectionString = DataAccessSettings.ConnectionString;

            string Query = @"UPDATE People SET 
                                                NationalNo = @NationalNo,
                                                FirstName = @FirstName,
                                                SecondName = @SecondName,
                                                ThirdName = @ThirdName,
                                                LastName = @LastName,
                                                DateOfBirth = @DateOfBirth,
                                                Gender = @Gender,
                                                Address = @Address,
                                                Phone = @Phone,
                                                Email = @Email,
                                                NationalityCountryID = @NationalityCountryID,
                                                ImagePath = @ImagePath

                                            WHERE PersonID = @PersonID;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(Query, connection))
            {
                command.Parameters.Add("@PersonID",SqlDbType.Int).Value = ID;
                command.Parameters.Add("@NationalNo",SqlDbType.NVarChar).Value = NationalNo;
                command.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = FirstName;
                command.Parameters.Add("@SecondName", SqlDbType.NVarChar).Value = SecondName;
                command.Parameters.Add("@ThirdName",SqlDbType.NVarChar).Value = 
                    string.IsNullOrWhiteSpace(ThirdName)? DBNull.Value : (object)ThirdName;
                command.Parameters.Add("@LastName", SqlDbType.NVarChar).Value =LastName;
                command.Parameters.Add("@DateOfBirth", SqlDbType.DateTime).Value = DateOfBirth;
                command.Parameters.Add("@Gender", SqlDbType.TinyInt).Value = (byte)Gender;
                command.Parameters.Add("@Address", SqlDbType.NVarChar).Value = Address;
                command.Parameters.Add("@Phone", SqlDbType.NVarChar).Value = Phone;
                command.Parameters.Add("@Email", SqlDbType.NVarChar).Value =
                    string.IsNullOrWhiteSpace(Email) ? DBNull.Value : (object)Email;
                command.Parameters.Add("@NationalityCountryID", SqlDbType.Int).Value = NationalityCountryID;
                command.Parameters.Add("@ImagePath", SqlDbType.NVarChar).Value =
                  string.IsNullOrWhiteSpace(ImagePath) ? DBNull.Value : (object)ImagePath;

                try
                {
                    connection.Open();

                    rowsAffected = command.ExecuteNonQuery();
                }
                catch(Exception ex)
                {
                    throw new ApplicationException("Error Update Person !", ex);
                }

                return (rowsAffected > 0);
            }
        }
        
        public static bool DeletePerson(int PersonID)
        {
            int rowsAffected = 0;
            string connectionString = DataAccessSettings.ConnectionString;
            string Query = "DELETE FROM People WHERE PersonID = @PersonID;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(Query, connection))
            {
                command.Parameters.Add("@PersonID", SqlDbType.Int).Value = PersonID;

                try
                {
                    connection.Open();

                    rowsAffected = command.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    throw new ApplicationException($"Error Deleting Person With {PersonID} ID ", ex);
                }

                return (rowsAffected > 0);
            }
        }

        public static bool GetPersonInfoByID(int ID, ref string FirstName, ref string SecondName,
          ref string ThirdName, ref string LastName, ref string NationalNo, ref DateTime DateOfBirth,
          ref byte Gender, ref string Address, ref string Phone, ref string Email,
          ref int NationalityCountryID, ref string ImagePath)
        {
            bool IsFound = false;
            string connectionString = DataAccessSettings.ConnectionString;

            string Query = @"SELECT * FROM People WHERE PersonID = @PersonID;";

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
                            IsFound = true;

                            NationalNo = reader["NationalNo"].ToString();
                            FirstName = reader["FirstName"].ToString();
                            SecondName = reader["SecondName"].ToString();
                            ThirdName = reader["ThirdName"] != DBNull.Value ? reader["ThirdName"].ToString() : "";
                            LastName = reader["LastName"].ToString();
                            DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
                            Gender = Convert.ToByte(reader["Gender"]);
                            Address = reader["Address"].ToString();
                            Phone = reader["Phone"].ToString();
                            Email = reader["Email"] != DBNull.Value ? reader["Email"].ToString() : "";
                            NationalityCountryID = Convert.ToInt32(reader["NationalityCountryID"]);
                            ImagePath = reader["ImagePath"] != DBNull.Value ? reader["ImagePath"].ToString() : "";
                        }
                    }

                }
                catch (Exception ex)
                {
                    throw new ApplicationException("\"Error: Cannot find the person.\"\r\n", ex);
                }
            }

            return IsFound;
        }

        public static bool GetPersonInfoByNationalNo(string NationalNo, ref int ID, ref string FirstName, ref string SecondName,
        ref string ThirdName, ref string LastName, ref DateTime DateOfBirth,
        ref byte Gender, ref string Address, ref string Phone, ref string Email,
        ref int NationalityCountryID, ref string ImagePath)
        {
            string connectionString = DataAccessSettings.ConnectionString;
            string query = @"SELECT * FROM People WHERE NationalNo = @NationalNo;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                try
                {
                    command.Parameters.Add("@NationalNo", SqlDbType.NVarChar).Value = NationalNo;

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            ID = (int)reader["PersonID"];
                            NationalNo = reader["NationalNo"].ToString();
                            FirstName = reader["FirstName"].ToString();
                            SecondName = reader["SecondName"].ToString();
                            ThirdName = reader["ThirdName"] as string ?? "";
                            LastName = reader["LastName"].ToString();
                            DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
                            Gender = Convert.ToByte(reader["Gender"]);
                            Address = reader["Address"].ToString();
                            Phone = reader["Phone"].ToString();
                            Email = reader["Email"] as string ?? "";
                            NationalityCountryID = Convert.ToInt32(reader["NationalityCountryID"]);
                            ImagePath = reader["ImagePath"] as string ?? "";

                            return true;
                        }

                        return false;
                    }
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("Error: Cannot find the person.", ex);
                }
            }
        }
        public static DataTable GetAllPeople()
        {
            DataTable dataTable = new DataTable();
            string connectionString = DataAccessSettings.ConnectionString;
            string query = @"
                               SELECT 
                               People.PersonID, 
                               People.NationalNo,
                               People.FirstName, 
                               People.SecondName, 
                               People.ThirdName, 
                               People.LastName,
                               People.DateOfBirth, 
                               People.Gender,
                               CASE 
                                   WHEN People.Gender = 0 THEN 'Male'
                                   ELSE 'Female'
                               END AS GenderCaption,
                               People.Address, 
                               People.Phone, 
                               People.Email, 
                               People.NationalityCountryID, 
                               Countries.CountryName AS CountryName,
                               People.ImagePath
                           FROM 
                               People
                           INNER JOIN 
                               Countries ON People.NationalityCountryID = Countries.CountryID
                           ORDER BY 
                               People.FirstName DESC;";

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
                    throw new ApplicationException("Error Getting All People", ex);
                }

                return dataTable;
            }
        }

        public static bool IsPersonAssociatedWithUser(int personID)
        {
            string connectionString = DataAccessSettings.ConnectionString;

            const string query = @"SELECT 1
                                   FROM People p
                                   LEFT JOIN Users u ON p.PersonID = u.UserID 
                                   WHERE p.PersonID = @PersonID AND u.UserID IS NOT NULL;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@PersonID",SqlDbType.Int).Value = personID;

                try
                {
                    connection.Open();

                    object result = command.ExecuteScalar();
                    return (result != null);
                }
                catch(Exception ex)
                {
                    throw new ApplicationException("Error can't Find the Person !", ex);
                }
            }
        }

    }
}
