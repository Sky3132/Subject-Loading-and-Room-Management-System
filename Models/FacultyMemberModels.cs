using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace __Subject_Loading_and_Room_Assignment_Monitoring_System.Models
{
    public class FacultyMembersModels
    {
        // 1. DATA PROPERTIES (Matching your Database Columns)
        public int FacultyID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? MaxLoad { get; set; }

        // Added DepartmentID to link faculty to their specific department
        public int DepartmentID { get; set; }

        // 2. COMPUTED PROPERTIES (Logic based on data)
        // This follows the style of your Subjects.DisplayName property
        public string FullName => $"{FirstName} {LastName}";

        public string DisplayInfo => $"{FullName} (Max Units: {MaxLoad ?? 18})";

        // 3. CONSTRUCTOR
        public FacultyMembersModels()
        {
            // Initializes a blank faculty object
        }
    }
}