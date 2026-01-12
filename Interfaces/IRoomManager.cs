using __Subject_Loading_and_Room_Assignment_Monitoring_System.Core_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace __Subject_Loading_and_Room_Assignment_Monitoring_System.Interfaces
{
    public interface IRoomManager
    {
        void Validate(Core_Models.Room room);
        void AddRoom(Core_Models.Room room);
        void UpdateRoom(Core_Models.Room room);
        void DeleteRoom(int roomId);
        object GetRoomsGrid();
    }
}
