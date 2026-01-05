using __Subject_Loading_and_Room_Assignment_Monitoring_System.Managers.OOMDemo.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace __Subject_Loading_and_Room_Assignment_Monitoring_System.Managers
{
    public class RoomManager : BaseManager, Interfaces.IRoomManager
    {
        public void Validate(string name, string type, string capacity)
        {
            // Validates that fields aren't empty
            EnsureNotNull(name, "Room Name/Number");
            EnsureNotNull(type, "Room Type");

            // Ensures capacity is a real number
            if (!int.TryParse(capacity, out int cap) || cap <= 0)
            {
                throw new Exception("Capacity must be a valid number greater than 0.");
            }
        }
    }
}
