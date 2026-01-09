using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace __Subject_Loading_and_Room_Assignment_Monitoring_System.Core_Models
{
    /// <summary>
    /// Represents room utilization analytics data
    /// Used by RoomUtilizationReport for generating reports
    /// </summary>
    public class RoomUtilizationData
    {
        public int RoomID { get; set; }
        public string RoomName { get; set; }
        public string Campus { get; set; }
        public int Capacity { get; set; }
        public string Type { get; set; }
        public int AssignmentsCount { get; set; }
        public double TotalHoursAssigned { get; set; }
        public double UtilizationPercentage { get; set; }
        public int AssignedDays { get; set; }
    }
}