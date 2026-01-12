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
        void Validate(Models.FacultyMember faculty);
        bool IsOverloaded(int facultyId, int newUnits);
        void AddFaculty(Models.FacultyMember model);
        void UpdateFaculty(Models.FacultyMember model);
    }
}
