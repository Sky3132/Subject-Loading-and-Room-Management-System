using __Subject_Loading_and_Room_Assignment_Monitoring_System.Managers.OOMDemo.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using __Subject_Loading_and_Room_Assignment_Monitoring_System.Core_Models;

namespace __Subject_Loading_and_Room_Assignment_Monitoring_System.Managers
{
    public class RoomManager : OOMDemo.Managers.BaseManager, Interfaces.IRoomManager
    {
        // Fix for Dashboard: Added GetCount method
        public int GetCount()
        {
            using (var db = new DataClasses1DataContext())
            {
                return db.tblRooms.Count();
            }
        }

        public void Validate(Room room)
        {
            EnsureNotNull(room.RoomName, "Room Name");
            EnsureNotNull(room.RoomType, "Room Type");
            EnsureNotNull(room.Campus, "Campus");

            if (room.Capacity <= 0)
                throw new Exception("Capacity must be greater than 0.");
        }

        public object GetRoomsGrid()
        {
            using (var db = new DataClasses1DataContext())
            {
                // Note: 'Number' in this anonymous object is what the 
                // DataGridView uses as the Column Name.
                return db.tblRooms.Select(r => new {
                    ID = r.RoomID,
                    Number = r.RoomName,
                    Type = r.RoomType,
                    Capacity = r.Capacity,
                    Campus = r.Campus
                }).ToList();
            }
        }

        public void AddRoom(Room room)
        {
            using (var db = new DataClasses1DataContext())
            {
                // Check for duplicates within the same campus
                if (db.tblRooms.Any(r => r.RoomName.ToLower() == room.RoomName.ToLower() && r.Campus == room.Campus))
                    throw new Exception($"Room '{room.RoomName}' already exists in {room.Campus}.");

                tblRoom dbEntry = new tblRoom
                {
                    RoomName = room.RoomName,
                    RoomType = room.RoomType,
                    Capacity = room.Capacity,
                    Campus = room.Campus
                };
                db.tblRooms.InsertOnSubmit(dbEntry);
                db.SubmitChanges();
            }
        }

        public void UpdateRoom(Room room)
        {
            using (var db = new DataClasses1DataContext())
            {
                var entry = db.tblRooms.FirstOrDefault(r => r.RoomID == room.RoomID);
                if (entry == null) throw new Exception("Room not found.");

                entry.RoomName = room.RoomName;
                entry.RoomType = room.RoomType;
                entry.Capacity = room.Capacity;
                entry.Campus = room.Campus;
                db.SubmitChanges();
            }
        }

        public void DeleteRoom(int roomId)
        {
            using (var db = new DataClasses1DataContext())
            {
                var entry = db.tblRooms.FirstOrDefault(r => r.RoomID == roomId);
                if (entry != null)
                {
                    db.tblRooms.DeleteOnSubmit(entry);
                    db.SubmitChanges();
                }
            }
        }
    }
}