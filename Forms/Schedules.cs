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


        // KEEP THIS - It works perfectly for your UI
        private void LoadDayAndTimeCombos()
        {
            cmbSchedDay.Items.AddRange(new string[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" });

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

            // Load Combined Data
            cmbSchedSubject.DataSource = _manager.GetSubjectFacultyCombo();
            cmbSchedSubject.DisplayMember = "DisplayText";
            cmbSchedSubject.ValueMember = "LoadID";

            cmbSchedRoom.DataSource = _manager.GetRoomSectionCombo();
            cmbSchedRoom.DisplayMember = "DisplayText";
            cmbSchedRoom.ValueMember = "RoomID";

            RefreshGrid();
        }


        private void btnSchedSave_Click(object sender, EventArgs e)
        {
            try
            {
                var model = GetModelFromUI();

                // This triggers the HasConflict check inside the manager
                _manager.Validate(model);

                _manager.Save(model);

                MessageBox.Show("Schedule saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshGrid();
                selectedScheduleID = 0;
            }
            catch (Exception ex)
            {
                // This shows the "Duplicate/Conflict Detected" message with a Warning Icon
                MessageBox.Show(ex.Message, "Schedule Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnSchedUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedScheduleID == 0)
                {
                    MessageBox.Show("Please select a schedule from the list to update.");
                    return;
                }

                var model = GetModelFromUI();

                // 1. Validate logic (Conflict check)
                _manager.Validate(model);

                // 2. Call Update
                _manager.Update(model);

                MessageBox.Show("Schedule updated successfully!", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshGrid();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnSchedRemove_Click(object sender, EventArgs e)
        {
            if (selectedScheduleID == 0)
            {
                MessageBox.Show("Please select a schedule to remove.");
                return;
            }

            var result = MessageBox.Show("Are you sure you want to remove this schedule?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    _manager.Remove(selectedScheduleID);
                    selectedScheduleID = 0; // Reset after delete
                    RefreshGrid();
                    MessageBox.Show("Schedule removed.");
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }


        private void RefreshGrid()
        {
            //Load the data
            dgvSchedule.DataSource = _manager.GetGridData();
            // Formats the StartTime column (adjust the index/name to match your grid)
            dgvSchedule.Columns["StartTime"].DefaultCellStyle.Format = "hh:mm tt";
            dgvSchedule.Columns["EndTime"].DefaultCellStyle.Format = "hh:mm tt";
            // HIDE THE IDs (Use the Column Names from your SQL/DataTable)
            if (dgvSchedule.Columns.Count > 0)
            {
                dgvSchedule.Columns["ScheduleID"].Visible = false;
                dgvSchedule.Columns["LoadID"].Visible = false;
                dgvSchedule.Columns["RoomID"].Visible = false;
            }
        }

        private ScheduleModel GetModelFromUI()
        {
            return new ScheduleModel
            {
                ScheduleID = selectedScheduleID,
                LoadID = (int)cmbSchedSubject.SelectedValue,
                RoomID = (int)cmbSchedRoom.SelectedValue,
                DayOfWeek = cmbSchedDay.Text,
                StartTime = DateTime.Parse(cmbSchedStart.Text).TimeOfDay,
                EndTime   = DateTime.Parse(cmbSchedEnd.Text).TimeOfDay
            };
        }

        private void lblOpenClassSched_Click(object sender, EventArgs e)
        {
            Class_schedule classSched = new Class_schedule();
            classSched.Show();
            this.Hide();
        }

        private void dgvSchedule_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Check if we are formatting the StartTime or EndTime columns
            if (dgvSchedule.Columns[e.ColumnIndex].Name == "StartTime" ||
                dgvSchedule.Columns[e.ColumnIndex].Name == "EndTime")
            {
                if (e.Value is TimeSpan ts)
                {
                    // Convert TimeSpan to a dummy DateTime to use AM/PM formatting
                    e.Value = DateTime.Today.Add(ts).ToString("h:mm tt");
                    e.FormattingApplied = true;
                }
            }
        }

        private void dgvSchedule_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSchedule.Rows[e.RowIndex];

                // 1. Capture the ID
                selectedScheduleID = Convert.ToInt32(row.Cells["ScheduleID"].Value);

                // 2. Set the Combos
                cmbSchedSubject.SelectedValue = row.Cells["LoadID"].Value;
                cmbSchedRoom.SelectedValue = row.Cells["RoomID"].Value;
                cmbSchedDay.Text = row.Cells["DayOfWeek"].Value.ToString();

                // 3. Format the Times back to strings
                if (row.Cells["StartTime"].Value is TimeSpan start &&
                    row.Cells["EndTime"].Value is TimeSpan end)
                {
                    // Using .ToLower() matches "7:00 am" exactly as it appears in your ComboBox
                    cmbSchedStart.Text = DateTime.Today.Add(start).ToString("h:mm tt").ToLower();
                    cmbSchedEnd.Text = DateTime.Today.Add(end).ToString("h:mm tt").ToLower();
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












