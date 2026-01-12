using __Subject_Loading_and_Room_Assignment_Monitoring_System.Core_Models;
using __Subject_Loading_and_Room_Assignment_Monitoring_System.Interfaces;
using __Subject_Loading_and_Room_Assignment_Monitoring_System.Managers.OOMDemo.Managers;
using __Subject_Loading_and_Room_Assignment_Monitoring_System.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace __Subject_Loading_and_Room_Assignment_Monitoring_System.Managers
{
    public class ScheduleManager : BaseManager, IScheduleManager
    {
        ConnectionString connStr = new ConnectionString();

        public void Validate(ScheduleModel m)
        {
            if (m.LoadID <= 0) throw new Exception("Please select a Subject/Faculty assignment.");
            if (m.RoomID <= 0) throw new Exception("Please select a Room.");
            if (string.IsNullOrEmpty(m.DayOfWeek)) throw new Exception("Please select a Day.");
            if (m.StartTime >= m.EndTime) throw new Exception("End Time must be later than Start Time.");

            if (HasConflict(m))
            {
                throw new Exception("Schedule Conflict: The Room or Faculty is already occupied at this time.");
            }
        }

        public bool HasConflict(ScheduleModel m)
        {
            using (SqlConnection conn = new SqlConnection(connStr.connection))
            {
                string sql = @"SELECT COUNT(*) FROM tblSchedule 
                               WHERE DayOfWeek = @Day 
                               AND ScheduleID <> @ID
                               AND (RoomID = @RoomID OR LoadID = @LoadID)
                               AND (
                                    (@Start >= StartTime AND @Start < EndTime) OR 
                                    (@End > StartTime AND @End <= EndTime) OR 
                                    (StartTime >= @Start AND StartTime < @End)
                               )";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ID", m.ScheduleID);
                cmd.Parameters.AddWithValue("@Day", m.DayOfWeek);
                cmd.Parameters.AddWithValue("@RoomID", m.RoomID);
                cmd.Parameters.AddWithValue("@LoadID", m.LoadID);
                cmd.Parameters.AddWithValue("@Start", m.StartTime);
                cmd.Parameters.AddWithValue("@End", m.EndTime);

                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        public DataTable GetSubjectFacultyCombo()
        {
            return FetchData("SELECT L.LoadID, (sub.Title + ' — ' + F.FirstName + ' ' + F.LastName) AS DisplayText FROM tblFacultyLoading L JOIN tblsubjectOffering O ON L.offeringId = O.offeringId JOIN tblsubject sub ON O.subjectId = sub.subjectId JOIN tblFaculty F ON L.FacultyID = F.FacultyID");
        }

        // FIXED: Column name changed from 'Number' to 'RoomName' to match your database schema
        public DataTable GetRoomSectionCombo()
        {
            string query = @"
                SELECT DISTINCT 
                    RoomID, 
                    RoomName + ' - ' + 
                    CASE 
                        WHEN Campus = 'Visayan' THEN 'VC' 
                        ELSE Campus 
                    END AS DisplayText
                FROM tblRooms";

            return FetchData(query);
        }

        public DataTable GetGridData()
        {
            string sql = @"SELECT S.ScheduleID, S.LoadID, S.RoomID, sub.Title AS Subject, 
                           (F.FirstName + ' ' + F.LastName) AS Faculty, 
                           (R.RoomName + ' [' + R.Campus + ']') AS RoomName, 
                           L.Section, S.DayOfWeek, S.StartTime, S.EndTime 
                           FROM tblSchedule S 
                           JOIN tblFacultyLoading L ON S.LoadID = L.LoadID 
                           JOIN tblFaculty F ON L.FacultyID = F.FacultyID 
                           JOIN tblRooms R ON S.RoomID = R.RoomID 
                           JOIN tblsubjectOffering O ON L.offeringId = O.offeringId 
                           JOIN tblsubject sub ON O.subjectId = sub.subjectId";
            return FetchData(sql);
        }

        private DataTable FetchData(string sql)
        {
            using (SqlConnection conn = new SqlConnection(connStr.connection))
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public void Save(ScheduleModel m)
        {
            string sql = "INSERT INTO tblSchedule (LoadID, RoomID, DayOfWeek, StartTime, EndTime) VALUES (@LoadID, @RoomID, @Day, @Start, @End)";
            ExecuteCommand(sql, m);
        }

        public void Update(ScheduleModel m)
        {
            string sql = "UPDATE tblSchedule SET LoadID=@LoadID, RoomID=@RoomID, DayOfWeek=@Day, StartTime=@Start, EndTime=@End WHERE ScheduleID=@ID";
            ExecuteCommand(sql, m);
        }

        public void Remove(int id)
        {
            using (SqlConnection conn = new SqlConnection(connStr.connection))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM tblSchedule WHERE ScheduleID = @ID", conn);
                cmd.Parameters.AddWithValue("@ID", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private void ExecuteCommand(string sql, ScheduleModel m)
        {
            using (SqlConnection conn = new SqlConnection(connStr.connection))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ID", m.ScheduleID);
                cmd.Parameters.AddWithValue("@LoadID", m.LoadID);
                cmd.Parameters.AddWithValue("@RoomID", m.RoomID);
                cmd.Parameters.AddWithValue("@Day", m.DayOfWeek);
                cmd.Parameters.AddWithValue("@Start", m.StartTime);
                cmd.Parameters.AddWithValue("@End", m.EndTime);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}