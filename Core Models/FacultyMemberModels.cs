using __Subject_Loading_and_Room_Assignment_Monitoring_System.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace __Subject_Loading_and_Room_Assignment_Monitoring_System.Models
{
    public class FacultyMember : Core_Models.User
    {
        // Encapsulated Fields
        private string _firstName;
        private string _lastName;

        public int FacultyID { get; set; }

        public string FirstName
        {
            get => _firstName;
            set => _firstName = value?.Trim();
        }

        public string LastName
        {
            get => _lastName;
            set => _lastName = value?.Trim();
        }

        public string Department { get; set; }
        public int CurrentLoad { get; set; }
        public int MaxLoad { get; set; }
        public int DepartmentID { get; set; }

        // Calculated Property (Logic inside Model)
        public string FullName => $"{FirstName} {LastName}";
    }
}