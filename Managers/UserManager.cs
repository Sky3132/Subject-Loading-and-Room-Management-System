using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.PerformanceData;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace __Subject_Loading_and_Room_Assignment_Monitoring_System.Managers
{
    public abstract class UserManager
    {
        public int UserId { get; }
        public int RoleID { get; }

        protected UserManager(int userId, int roleId)
        {
            UserId = userId;
            RoleID = roleId;
        }

        public abstract Form GetForm();

        //public bool Register(string username, string password)
        //{
        //    using (SqlConnection con = new SqlConnection(connectionString))
        //    {
        //        con.Open();
        //        string query = "SELECT COUNT(*) FROM log_in WHERE Username=@Username";
        //        using (SqlCommand cmd = new SqlCommand(query, con))
        //        {
        //            cmd.Parameters.AddWithValue("@Username", username);
        //            int count = (int)cmd.ExecuteScalar();

        //            if (count > 0)
        //            {
        //                return false; // Username exists, but password is incorrect
        //            }
        //        }
        //        string insertQuery = "INSERT INTO log_in (Username, Password) VALUES (@username, @password)";
        //        using (SqlCommand cmd = new SqlCommand(query, con))
        //        {
        //            cmd.Parameters.AddWithValue("@username", username);
        //            cmd.Parameters.AddWithValue("@password", password);
        //            cmd.ExecuteNonQuery();
        //        }

        //        return true;
        //    }
        //}
    }
}

