using __Subject_Loading_and_Room_Assignment_Monitoring_System.Core_Models;
using __Subject_Loading_and_Room_Assignment_Monitoring_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace __Subject_Loading_and_Room_Assignment_Monitoring_System.Interfaces
{
    public interface IFacultyManager
    {
        // Rule: Check if adding new units will exceed the teacher's limit
        bool IsOverloaded(int facultyId, int newUnits);

        // Rule: Ensure name and department are valid
        void Validate(Models.FacultyMember faculty);
    }
}
