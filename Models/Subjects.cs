using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace __Subject_Loading_and_Room_Assignment_Monitoring_System
{
    internal class Subjects
    {
        public int SubjectId { get; set; }
        public int Code { get; set; }
        public string Title { get; set; }
        public string Department { get; set; }
        public string Program { get; set; }

        public int LectureUnits { get; set; }
        public int LaboratoryUnits { get; set; }

        public int TotalUnits => LectureUnits + LaboratoryUnits;

        public string DisplayName => $"{Code} - {Title} ({TotalUnits} Units)";
        public Subjects()
        {



        }
    }
    }

