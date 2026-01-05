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
            private int _lectureUnits;
            private int _labUnits;

            public int SubjectID { get; set; }
            public int Code { get; set; }
            public string Title { get; set; }

            // ENCAPSULATION: Logic inside the property
            public int LectureUnits
            {
                get => _lectureUnits;
                set => _lectureUnits = (value < 0) ? 0 : value;
            }

            public int LaboratoryUnits
            {
                get => _labUnits;
                set => _labUnits = (value < 0) ? 0 : value;
            }

            public string ProgramName { get; set; }
            public string DepartmentName { get; set; }
        }
}

