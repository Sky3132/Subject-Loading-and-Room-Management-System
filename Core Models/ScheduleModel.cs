using __Subject_Loading_and_Room_Assignment_Monitoring_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace __Subject_Loading_and_Room_Assignment_Monitoring_System.Core_Models
{
    public class ScheduleModel
    {
        public int ScheduleID { get; set; }
        public int LoadID { get; set; }
        public int RoomID { get; set; }
        public string DayOfWeek { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        // Logic to check if the time range is valid
        public bool IsTimeValid => EndTime > StartTime;
    }
}

