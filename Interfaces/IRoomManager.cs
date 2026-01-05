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
        // Interface definition for validation
        void Validate(string name, string type, string capacity);
    }
}
