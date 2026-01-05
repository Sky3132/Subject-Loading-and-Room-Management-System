using __Subject_Loading_and_Room_Assignment_Monitoring_System.Core_Models;
using __Subject_Loading_and_Room_Assignment_Monitoring_System.Interfaces;
using __Subject_Loading_and_Room_Assignment_Monitoring_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace __Subject_Loading_and_Room_Assignment_Monitoring_System.Managers
{
    public class FacultyManager : OOMDemo.Managers.BaseManager, IFacultyManager
    {
        public void Validate(Models.FacultyMember faculty)
        {
            // Reusing helpers from BaseManager
            EnsureNotNull(faculty.FirstName, "First Name");
            EnsureNotNull(faculty.LastName, "Last Name");

            if (faculty.DepartmentID <= 0)
                throw new Exception("Please select a valid Department.");
        }

        public bool IsOverloaded(int facultyId, int newUnits)
        {
            using (DataClasses1DataContext db = new DataClasses1DataContext())
            {
                var faculty = db.tblFaculties.FirstOrDefault(f => f.FacultyID == facultyId);
                if (faculty == null) return false;

                // Calculate current load from the database
                int currentLoad = db.tblFacultyLoadings
                    .Where(l => l.FacultyID == facultyId)
                    .Sum(l => (int?)(l.tblsubjectOffering.tblsubject.LectureUnits +
                                    l.tblsubjectOffering.tblsubject.LaboratoryUnits)) ?? 0;

                // Check if (Current + New) > Max Allowed
                return (currentLoad + newUnits) > (faculty.MaxLoad ?? 18);
            }
        }
    }
}
