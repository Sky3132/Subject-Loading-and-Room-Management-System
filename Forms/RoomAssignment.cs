using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace __Subject_Loading_and_Room_Assignment_Monitoring_System.Forms
{
    public partial class RoomAssignment : Form
    {
        private int _selectedAssignmentId = -1;

        public RoomAssignment()
        {
            InitializeComponent();
        }

        private void RoomAssignment_Load(object sender, EventArgs e)
        {
            LoadComboBoxes();
            LoadAssignmentsGrid();
        }

        private void LoadComboBoxes()
        {
            try
            {
                using (DataClasses1DataContext db = new DataClasses1DataContext())
                {
                    // We use .ToList() first to bring data into memory so C# can handle the "VC" string formatting
                    var rooms = db.tblRooms.ToList().Select(r => new {
                        r.RoomID,
                        // Formats the display as "ROOM1 - MAIN" or "ROOM2 - VC"
                        DisplayName = r.RoomName + " - " + (r.Campus == "Visayan" ? "VC" : r.Campus.ToUpper())
                    }).ToList();

                    cmbRoom.DataSource = rooms;
                    cmbRoom.DisplayMember = "DisplayName";
                    cmbRoom.ValueMember = "RoomID";

                    var loadingData = db.tblFacultyLoadings.Select(fl => new {
                        fl.LoadID,
                        DisplayText = fl.tblFaculty.FirstName + " " + fl.tblFaculty.LastName +
                                      " (" + fl.tblsubjectOffering.tblsubject.Code + ")"
                    }).ToList();

                    cmbFacultyAssign.DataSource = loadingData;
                    cmbFacultyAssign.DisplayMember = "DisplayText";
                    cmbFacultyAssign.ValueMember = "LoadID";

                    cmbRoom.SelectedIndex = -1;
                    cmbFacultyAssign.SelectedIndex = -1;
                }
            }
            catch (Exception ex) { MessageBox.Show("Error loading dropdowns: " + ex.Message); }
        }

        private void btnSaveAssign_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbFacultyAssign.SelectedValue == null || cmbRoom.SelectedValue == null)
                    throw new Exception("Please select both a Room and Faculty Load.");

                if (chkListDays.CheckedItems.Count == 0)
                    throw new Exception("Please select at least one day.");

                using (DataClasses1DataContext db = new DataClasses1DataContext())
                {
                    int selectedRoomId = (int)cmbRoom.SelectedValue;
                    string start = txtStartTime.Text;
                    string end = txtEndTime.Text;

                    // Combine all selected days into a single string (e.g., "Monday,Tuesday,Wednesday")
                    string selectedDays = string.Join(",", chkListDays.CheckedItems.Cast<string>());

                    // FEATURE: Conflict detection system - Check each selected day for conflicts
                    foreach (string day in chkListDays.CheckedItems)
                    {
                        var conflict = db.tblRoomAssignments.Any(a =>
                            a.RoomID == selectedRoomId &&
                            a.Day.Contains(day) &&
                            ((start.CompareTo(a.StartTime) >= 0 && start.CompareTo(a.EndTime) < 0) ||
                             (end.CompareTo(a.StartTime) > 0 && end.CompareTo(a.EndTime) <= 0)));

                        if (conflict)
                        {
                            MessageBox.Show($"CONFLICT DETECTED: {day} - This room is already occupied during this time.",
                                            "Scheduling Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // Create a SINGLE assignment with all days combined
                    tblRoomAssignment newAssign = new tblRoomAssignment
                    {
                        LoadID = (int)cmbFacultyAssign.SelectedValue,
                        RoomID = selectedRoomId,
                        Day = selectedDays,  // Store as comma-separated: "Monday,Tuesday,Wednesday"
                        StartTime = start,
                        EndTime = end
                    };

                    db.tblRoomAssignments.InsertOnSubmit(newAssign);
                    db.SubmitChanges();

                    MessageBox.Show("Room successfully assigned for selected days!");
                    LoadAssignmentsGrid();
                    ClearInputs();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnEditAssign_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (_selectedAssignmentId == -1) throw new Exception("Please select an assignment from the list first.");

                if (chkListDays.CheckedItems.Count == 0)
                    throw new Exception("Please select at least one day.");

                using (DataClasses1DataContext db = new DataClasses1DataContext())
                {
                    var assign = db.tblRoomAssignments.FirstOrDefault(a => a.AssignmentID == _selectedAssignmentId);
                    if (assign != null)
                    {
                        int roomId = (int)cmbRoom.SelectedValue;
                        string start = txtStartTime.Text;
                        string end = txtEndTime.Text;
                        string selectedDays = string.Join(",", chkListDays.CheckedItems.Cast<string>());

                        // Conflict Check for new days (Ignores the record we are currently editing)
                        foreach (string day in chkListDays.CheckedItems)
                        {
                            var conflict = db.tblRoomAssignments.Any(a =>
                                a.AssignmentID != _selectedAssignmentId &&
                                a.RoomID == roomId &&
                                a.Day.Contains(day) &&
                                ((start.CompareTo(a.StartTime) >= 0 && start.CompareTo(a.EndTime) < 0) ||
                                 (end.CompareTo(a.StartTime) > 0 && end.CompareTo(a.EndTime) <= 0)));

                            if (conflict)
                            {
                                MessageBox.Show($"Conflict detected on {day}! Room is busy at this new time.");
                                return;
                            }
                        }

                        assign.RoomID = roomId;
                        assign.LoadID = (int)cmbFacultyAssign.SelectedValue;
                        assign.Day = selectedDays;  // Update with new days
                        assign.StartTime = start;
                        assign.EndTime = end;

                        db.SubmitChanges();
                        MessageBox.Show("Assignment updated successfully!");
                        LoadAssignmentsGrid();
                        ClearInputs();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnRemoveAssign_Click(object sender, EventArgs e)
        {
            try
            {
                if (_selectedAssignmentId == -1) throw new Exception("Please select an assignment to remove.");

                if (MessageBox.Show("Are you sure you want to delete this assignment?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    using (DataClasses1DataContext db = new DataClasses1DataContext())
                    {
                        var assign = db.tblRoomAssignments.FirstOrDefault(a => a.AssignmentID == _selectedAssignmentId);
                        if (assign != null)
                        {
                            db.tblRoomAssignments.DeleteOnSubmit(assign);
                            db.SubmitChanges();
                            MessageBox.Show("Assignment removed.");
                            LoadAssignmentsGrid();
                            ClearInputs();
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void dgvAssignments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvAssignments.Rows[e.RowIndex];
                _selectedAssignmentId = (int)row.Cells["ID"].Value;

                // Get the days from the selected row (e.g., "Monday,Tuesday,Wednesday")
                string daysInRow = row.Cells["Day"].Value?.ToString();
                UncheckAllDays();
                
                if (!string.IsNullOrEmpty(daysInRow))
                {
                    // Split the days and check each one
                    var daysList = daysInRow.Split(',').Select(d => d.Trim()).ToList();
                    foreach (string day in daysList)
                    {
                        int dayIndex = chkListDays.Items.IndexOf(day);
                        if (dayIndex >= 0)
                            chkListDays.SetItemChecked(dayIndex, true);
                    }
                }

                // Parse the merged Time Period column (e.g., "10:00AM-12:00PM")
                string timePeriod = row.Cells["TimePeriod"].Value?.ToString();
                if (!string.IsNullOrEmpty(timePeriod) && timePeriod.Contains("-"))
                {
                    var times = timePeriod.Split('-');
                    txtStartTime.Text = times[0].Trim();
                    txtEndTime.Text = times[1].Trim();
                }

                // Match the ComboBoxes to the database values
                using (DataClasses1DataContext db = new DataClasses1DataContext())
                {
                    var assign = db.tblRoomAssignments.FirstOrDefault(a => a.AssignmentID == _selectedAssignmentId);
                    if (assign != null)
                    {
                        cmbRoom.SelectedValue = assign.RoomID;
                        cmbFacultyAssign.SelectedValue = assign.LoadID;
                    }
                }
            }
        }

        private void LoadAssignmentsGrid()
        {
            using (DataClasses1DataContext db = new DataClasses1DataContext())
            {
                dgvAssignments.DataSource = db.tblRoomAssignments.Select(a => new
                {
                    ID = a.AssignmentID,
                    Room = a.tblRoom.RoomName,
                    Faculty = a.tblFacultyLoading.tblFaculty.FirstName + " " + a.tblFacultyLoading.tblFaculty.LastName,
                    Subject = a.tblFacultyLoading.tblsubjectOffering.tblsubject.Code,
                    Day = a.Day,
                    TimePeriod = a.StartTime + "-" + a.EndTime
                }).OrderBy(x => x.Day).ThenBy(x => x.TimePeriod).ToList();

                if (dgvAssignments.Columns["ID"] != null) dgvAssignments.Columns["ID"].Visible = false;
            }
        }

        /// <summary>
        /// Opens the room availability calendar for visual scheduling
        /// FEATURE: Visual room availability calendar
        /// </summary>
        private void btnViewCalendar_Click(object sender, EventArgs e)
        {
            RoomAvailabilityCalendar calendar = new RoomAvailabilityCalendar();
            calendar.Show();
            this.Hide();
        }

        /// <summary>
        /// Opens the room utilization report
        /// FEATURE: Room utilization reports
        /// </summary>
        private void btnViewReport_Click(object sender, EventArgs e)
        {
           RoomUtilizationReport report = new RoomUtilizationReport();
            report.Show();
            this.Hide();
        }

        private void UncheckAllDays()
        {
            for (int i = 0; i < chkListDays.Items.Count; i++)
            {
                chkListDays.SetItemChecked(i, false);
            }
        }

        private void ClearInputs()
        {
            _selectedAssignmentId = -1;
            cmbRoom.SelectedIndex = -1;
            cmbFacultyAssign.SelectedIndex = -1;
            UncheckAllDays();
            txtStartTime.Clear();
            txtEndTime.Clear();
            dgvAssignments.ClearSelection();
        }

        private void imgBackToMain2_Click(object sender, EventArgs e)
        {
            Rooms rooms = new Rooms();
            rooms.Show();
            this.Hide();
        }
    }
}