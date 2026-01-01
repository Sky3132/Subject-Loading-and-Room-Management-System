using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace __Subject_Loading_and_Room_Assignment_Monitoring_System.Core_Models
{
    // MODULE 2: Subject (Based on your Subject.cs fields)
    public class SubjectModel
    {
        public int SubjectID { get; set; }
        public int Code { get; set; }
        public string Title { get; set; }
        public int LectureUnits { get; set; }
        public int LaboratoryUnits { get; set; }
        public string ProgramName { get; set; }
        public string DepartmentName { get; set; }
    }
}
