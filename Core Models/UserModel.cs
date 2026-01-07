using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace __Subject_Loading_and_Room_Assignment_Monitoring_System.Core_Models
{
    public abstract class User { 
        public int UserID { get; set; }
        public string Username { get; set; } 
        public string Role { get; set; } 
    }
    public class Admin : User { public Admin() => Role = "Admin"; }
    public class FacultyUser : User { public FacultyUser() => Role = "Faculty"; }
    //public class RegistrarUser : User { public RegistrarUser() => Role = "Registrar"; }
}