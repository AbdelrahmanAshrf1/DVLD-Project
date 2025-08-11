using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccessLayer
{
    public class LDLApplicationData
    {
        public static DataTable GetAllApplications()
        {
            DataTable dataTable = new DataTable();
            string connectionString = DataAccessSettings.ConnectionString;
            string query = "SELECT * FROM LocalDrivingLicenseApplications_View;";

            using(SqlConnection connection = new SqlConnection(connectionString))
            using(SqlCommand command = new SqlCommand(query, connection))
            {
                try
                {
                    connection.Open();
                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        dataTable.Load(reader);
                    }
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("Error : " + ex.Message);
                }
            }
            return dataTable;
        }
    }
}
