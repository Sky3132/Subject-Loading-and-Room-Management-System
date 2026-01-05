using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.PerformanceData;
using System.Security.Cryptography.X509Certificates;

namespace __Subject_Loading_and_Room_Assignment_Monitoring_System.Managers
{
    public class UserManager
    {
        private string connectionString = @"Data Source=pogitayo;Initial Catalog=Schooldb;Integrated Security=True";

        public bool Register(string username, string password)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "SELECT COUNT(*) FROM log_in WHERE Username=@username";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    int count = (int)cmd.ExecuteScalar();

                    if (count > 0)
                    {
                        return false; // Username exists, but password is incorrect
                    }
                }
                string insertQuery = "INSERT INTO log_in (Username, Password) VALUES (@username, @password)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.ExecuteNonQuery();
                }

                return true;
            }
        }
    }
}

