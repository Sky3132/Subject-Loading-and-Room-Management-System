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

        private void LoadDayAndTimeCombos()
        {
            // Clears existing items to prevent duplicates if method is called twice
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

            // UPDATED: This now loads the unique rooms in "ROOM - CAMPUS" format
            // Ensure your ScheduleManager.GetRoomSectionCombo() uses 'DISTINCT' in its SQL
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
                _manager.Validate(model);
                _manager.Save(model);

                MessageBox.Show("Schedule saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshGrid();
                selectedScheduleID = 0;
            }
            catch (Exception ex)
            {
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
                _manager.Validate(model);
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
                    selectedScheduleID = 0;
                    RefreshGrid();
                    MessageBox.Show("Schedule removed.");
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        private void RefreshGrid()
        {
            dgvSchedule.DataSource = _manager.GetGridData();

            // Formatting the RoomName column in the grid
            if (dgvSchedule.Columns["RoomName"] != null)
            {
                dgvSchedule.Columns["RoomName"].HeaderText = "Room & Campus";
                dgvSchedule.Columns["RoomName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

            dgvSchedule.Columns["StartTime"].DefaultCellStyle.Format = "hh:mm tt";
            dgvSchedule.Columns["EndTime"].DefaultCellStyle.Format = "hh:mm tt";

            if (dgvSchedule.Columns.Count > 0)
            {
                dgvSchedule.Columns["ScheduleID"].Visible = false;
                dgvSchedule.Columns["LoadID"].Visible = false;
                dgvSchedule.Columns["RoomID"].Visible = false;
            }
        }

        private ScheduleModel GetModelFromUI()
        {
            // Validates selections before processing to prevent crashes
            if (cmbSchedSubject.SelectedValue == null || cmbSchedRoom.SelectedValue == null)
            {
                throw new Exception("Please ensure both a Subject and a Room are selected.");
            }

            if (string.IsNullOrEmpty(cmbSchedStart.Text) || string.IsNullOrEmpty(cmbSchedEnd.Text))
            {
                throw new Exception("Please select both Start and End times.");
            }

            return new ScheduleModel
            {
                ScheduleID = selectedScheduleID,
                LoadID = (int)cmbSchedSubject.SelectedValue,
                RoomID = (int)cmbSchedRoom.SelectedValue,
                DayOfWeek = cmbSchedDay.Text,
                StartTime = DateTime.Parse(cmbSchedStart.Text).TimeOfDay,
                EndTime = DateTime.Parse(cmbSchedEnd.Text).TimeOfDay
            };
        }

        private void dgvSchedule_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvSchedule.Columns[e.ColumnIndex].Name == "StartTime" ||
                dgvSchedule.Columns[e.ColumnIndex].Name == "EndTime")
            {
                if (e.Value is TimeSpan ts)
                {
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
                selectedScheduleID = Convert.ToInt32(row.Cells["ScheduleID"].Value);

                cmbSchedSubject.SelectedValue = row.Cells["LoadID"].Value;
                cmbSchedRoom.SelectedValue = row.Cells["RoomID"].Value;
                cmbSchedDay.Text = row.Cells["DayOfWeek"].Value.ToString();

                if (row.Cells["StartTime"].Value is TimeSpan start &&
                    row.Cells["EndTime"].Value is TimeSpan end)
                {
                    // Match the case-sensitive "am/pm" format of your dropdown items
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