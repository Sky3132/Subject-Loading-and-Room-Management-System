using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace __Subject_Loading_and_Room_Assignment_Monitoring_System.Core_Models
{
    public class SubjectOfferingModel
    {
        public int OfferingID { get; set; }
        public Subject Subject { get; set; }
        public int FacultyID { get; set; }
        //public Room Room { get; set; }
        public string Section { get; set; }
        public string Day { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}
