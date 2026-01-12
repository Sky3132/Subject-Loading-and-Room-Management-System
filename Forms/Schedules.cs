using __Subject_Loading_and_Room_Assignment_Monitoring_System.Core_Models;
using __Subject_Loading_and_Room_Assignment_Monitoring_System.Managers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace __Subject_Loading_and_Room_Assignment_Monitoring_System.Forms
{
    public partial class Schedule : Form
    {
        public Schedule() { InitializeComponent(); }
        ConnectionString connStr = new ConnectionString();
        private ScheduleManager _manager = new ScheduleManager();
        private int selectedScheduleID = 0;
        // This will store the RoomID automatically retrieved from assignments
        private int automaticallyAssignedRoomID = 0;

        private void LoadDayAndTimeCombos()
        {
            cmbSchedDay.Items.Clear();
            cmbSchedDay.Items.AddRange(new string[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" });

            cmbSchedStart.Items.Clear();
            cmbSchedEnd.Items.Clear();
            for (int hour = 7; hour <= 23; hour++)
            {
                string time = DateTime.Today.AddHours(hour).ToString("h:mm tt");
                cmbSchedStart.Items.Add(time);
                cmbSchedEnd.Items.Add(time);
            }
        }

        private void Schedules_Load(object sender, EventArgs e)
        {
            LoadDayAndTimeCombos();

            // Load Subject/Faculty list
            cmbSchedSubject.DataSource = _manager.GetSubjectFacultyCombo();
            cmbSchedSubject.DisplayMember = "DisplayText";
            cmbSchedSubject.ValueMember = "LoadID";
            cmbSchedSubject.SelectedIndex = -1;

            RefreshGrid();
        }

        // Triggered when user selects a Subject - this finds the correct room automatically
        private void cmbSchedSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSchedSubject.SelectedValue != null && cmbSchedSubject.SelectedValue is int loadID)
            {
                using (var db = new DataClasses1DataContext())
                {
                    // Find the room assigned to this specific Faculty Loading
                    var assignment = db.tblRoomAssignments.FirstOrDefault(a => a.LoadID == loadID);
                    if (assignment != null)
                    {
                        automaticallyAssignedRoomID = (int)assignment.RoomID;
                    }
                    else
                    {
                        automaticallyAssignedRoomID = 0;
                        // Optional: MessageBox.Show("This subject has no room assigned yet. Please assign a room first.");
                    }
                }
            }
        }

        private void RefreshGrid()
        {
            dgvSchedule.DataSource = _manager.GetGridData();

            // HIDE the Room and Campus column in the DataGridView
            if (dgvSchedule.Columns["RoomName"] != null)
            {
                dgvSchedule.Columns["RoomName"].Visible = false;
            }

            if (dgvSchedule.Columns.Count > 0)
            {
                dgvSchedule.Columns["ScheduleID"].Visible = false;
                dgvSchedule.Columns["LoadID"].Visible = false;
                dgvSchedule.Columns["RoomID"].Visible = false;
            }
        }

        private ScheduleModel GetModelFromUI()
        {
            if (cmbSchedSubject.SelectedValue == null || automaticallyAssignedRoomID == 0)
            {
                throw new Exception("Please select a Subject that has a Room Assignment.");
            }

            if (string.IsNullOrEmpty(cmbSchedStart.Text) || string.IsNullOrEmpty(cmbSchedEnd.Text))
            {
                throw new Exception("Please select both Start and End times.");
            }

            return new ScheduleModel
            {
                ScheduleID = selectedScheduleID,
                LoadID = (int)cmbSchedSubject.SelectedValue,
                RoomID = automaticallyAssignedRoomID, // Use the ID found by the system
                DayOfWeek = cmbSchedDay.Text,
                StartTime = DateTime.Parse(cmbSchedStart.Text).TimeOfDay,
                EndTime = DateTime.Parse(cmbSchedEnd.Text).TimeOfDay
            };
        }

        // ... Keep btnSchedSave, btnSchedUpdate, btnSchedRemove the same ...

        private void dgvSchedule_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSchedule.Rows[e.RowIndex];
                selectedScheduleID = Convert.ToInt32(row.Cells["ScheduleID"].Value);

                cmbSchedSubject.SelectedValue = row.Cells["LoadID"].Value;
                // No need to set cmbSchedRoom as it is hidden
                cmbSchedDay.Text = row.Cells["DayOfWeek"].Value.ToString();

                if (row.Cells["StartTime"].Value is TimeSpan start &&
                    row.Cells["EndTime"].Value is TimeSpan end)
                {
                    cmbSchedStart.Text = DateTime.Today.Add(start).ToString("h:mm tt");
                    cmbSchedEnd.Text = DateTime.Today.Add(end).ToString("h:mm tt");
                }
            }
        }

        private void imgBackToMain2_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            main.Show();
            this.Hide();
        }
    }
}