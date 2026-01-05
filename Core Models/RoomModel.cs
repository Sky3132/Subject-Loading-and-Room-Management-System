using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using __Subject_Loading_and_Room_Assignment_Monitoring_System.Interfaces;

namespace __Subject_Loading_and_Room_Assignment_Monitoring_System.Core_Models
{
    public class Room
    {
        public int RoomID { get; set; }
        public string RoomName { get; set; }
        public int Capacity { get; set; }
        public string RoomType { get; set; }
    }
}
