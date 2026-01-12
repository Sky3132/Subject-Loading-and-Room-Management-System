using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using __Subject_Loading_and_Room_Assignment_Monitoring_System.Managers;


namespace __Subject_Loading_and_Room_Assignment_Monitoring_System.Core_Models
{
    using System;
    using System.Data.SqlClient;

    public class AuthService
    {
        private const int ADMIN_ROLE_ID = 1;

        public UserManager Login(string email, string password)
        {
            using (SqlConnection conn = DbConnectionFactory.Create())
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(
                    @"SELECT UserId, Password, Roleid
                  FROM Users
                  WHERE Username = @Username", conn))
                {
                    cmd.Parameters.AddWithValue("@Username", email);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (!reader.Read())
                            throw new Exception("Invalid credentials");

                        int userId = reader.GetInt32(0);
                        string hash = reader.GetString(1);
                        int roleId = reader.GetInt32(2);

                        if (!VerifyPassword(password, hash))
                            throw new Exception("Invalid credentials");

                        return roleId == ADMIN_ROLE_ID
                            ? (UserManager)new AdminModel(userId, roleId)
                            : new FacultyUserModel(userId, roleId);
                    }
                }
            }
        }

        private bool VerifyPassword(string password, string hash)
        {
            return password == hash;
        }
    }

}
