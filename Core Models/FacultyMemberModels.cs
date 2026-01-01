using __Subject_Loading_and_Room_Assignment_Monitoring_System.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace __Subject_Loading_and_Room_Assignment_Monitoring_System.Models
{
    // MODULE 2 & 3: Faculty and Loading
    public class FacultyMember : User
    {
        public int FacultyID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int MaxLoad { get; set; }
        public int CurrentLoad { get; set; }
        public int DepartmentID { get; set; }
    }
}