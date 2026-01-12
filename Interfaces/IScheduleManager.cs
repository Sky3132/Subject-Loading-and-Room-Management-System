using __Subject_Loading_and_Room_Assignment_Monitoring_System.Core_Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace __Subject_Loading_and_Room_Assignment_Monitoring_System.Interfaces
{
    public interface IScheduleManager
    {
        void Validate(ScheduleModel model);
        DataTable GetSubjectFacultyCombo();
        DataTable GetRoomSectionCombo();
        DataTable GetGridData();
        void Save(ScheduleModel model);
        void Update(ScheduleModel model);
        void Remove(int scheduleID);
    }

}
