using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace __Subject_Loading_and_Room_Assignment_Monitoring_System.Core_Models
{
    public static class DbConnectionFactory
    {
        public static SqlConnection Create()
        {
            return new SqlConnection(
                "Server=pogitayo;Database=Schooldb;Trusted_Connection=True;"
            );
        }
    }
}
