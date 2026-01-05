using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace __Subject_Loading_and_Room_Assignment_Monitoring_System.Forms
{
    public partial class RoomAssignment : Form
    {
        // Variable to track which assignment is selected for Editing/Removing
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
                    // FEATURE: Room inventory management
                    cmbRoom.DataSource = db.tblRooms.Select(r => new {
                        r.RoomID,
                        DisplayName = $"{r.RoomName} ({r.RoomType} - Cap: {r.Capacity})"
                    }).ToList();
                    cmbRoom.DisplayMember = "DisplayName";
                    cmbRoom.ValueMember = "RoomID";

                    // Loading Faculty Loading Data
                    var loadingData = db.tblFacultyLoadings.Select(fl => new {
                        fl.LoadID,
                        DisplayText = fl.tblFaculty.FirstName + " " + fl.tblFaculty.LastName +
                                      " | " + fl.tblsubjectOffering.tblsubject.Code
                    }).ToList();

                    cmbFacultyAssign.DataSource = loadingData;
                    cmbFacultyAssign.DisplayMember = "DisplayText";
                    cmbFacultyAssign.ValueMember = "LoadID";

                    cmbRoom.SelectedIndex = -1;
                    cmbFacultyAssign.SelectedIndex = -1;
                }
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private void btnSaveAssign_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbFacultyAssign.SelectedValue == null || cmbRoom.SelectedValue == null)
                    throw new Exception("Please select both a Room and Faculty Load.");

                using (DataClasses1DataContext db = new DataClasses1DataContext())
                {
                    int selectedRoomId = (int)cmbRoom.SelectedValue;
                    string day = cmbDay.Text;
                    string start = txtStartTime.Text;
                    string end = txtEndTime.Text;

                    // FEATURE: Conflict detection system
                    var conflict = db.tblRoomAssignments.Any(a =>
                        a.RoomID == selectedRoomId &&
                        a.Day == day &&
                        ((start.CompareTo(a.StartTime) >= 0 && start.CompareTo(a.EndTime) < 0) ||
                         (end.CompareTo(a.StartTime) > 0 && end.CompareTo(a.EndTime) <= 0)));

                    if (conflict)
                    {
                        MessageBox.Show("CONFLICT DETECTED: This room is already occupied during this time.",
                                        "Scheduling Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    tblRoomAssignment newAssign = new tblRoomAssignment
                    {
                        LoadID = (int)cmbFacultyAssign.SelectedValue,
                        RoomID = selectedRoomId,
                        Day = day,
                        StartTime = start,
                        EndTime = end
                    };

                    db.tblRoomAssignments.InsertOnSubmit(newAssign);
                    db.SubmitChanges();

                    MessageBox.Show("Room successfully assigned!");
                    LoadAssignmentsGrid();
                    ClearInputs();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        // --- NEW: EDIT LOGIC ---
        private void btnEditAssign_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (_selectedAssignmentId == -1) throw new Exception("Please select an assignment from the list first.");

                using (DataClasses1DataContext db = new DataClasses1DataContext())
                {
                    var assign = db.tblRoomAssignments.FirstOrDefault(a => a.AssignmentID == _selectedAssignmentId);
                    if (assign != null)
                    {
                        int roomId = (int)cmbRoom.SelectedValue;
                        string day = cmbDay.Text;
                        string start = txtStartTime.Text;
                        string end = txtEndTime.Text;

                        // Conflict Check (Ignores the record we are currently editing)
                        var conflict = db.tblRoomAssignments.Any(a =>
                            a.AssignmentID != _selectedAssignmentId &&
                            a.RoomID == roomId &&
                            a.Day == day &&
                            ((start.CompareTo(a.StartTime) >= 0 && start.CompareTo(a.EndTime) < 0) ||
                             (end.CompareTo(a.StartTime) > 0 && end.CompareTo(a.EndTime) <= 0)));

                        if (conflict)
                        {
                            MessageBox.Show("Conflict detected! Room is busy at this new time.");
                            return;
                        }

                        assign.RoomID = roomId;
                        assign.LoadID = (int)cmbFacultyAssign.SelectedValue;
                        assign.Day = day;
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

        // --- NEW: REMOVE LOGIC ---
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

        // --- NEW: SELECTION LOGIC ---
        private void dgvAssignments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvAssignments.Rows[e.RowIndex];
                _selectedAssignmentId = (int)row.Cells["ID"].Value;

                // Set the controls to match the selected row
                cmbDay.Text = row.Cells["Day"].Value?.ToString();

                string fullTime = row.Cells["Time"].Value?.ToString();
                if (!string.IsNullOrEmpty(fullTime) && fullTime.Contains(" - "))
                {
                    var times = fullTime.Split(new string[] { " - " }, StringSplitOptions.None);
                    txtStartTime.Text = times[0];
                    txtEndTime.Text = times[1];
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
                    Time = a.StartTime + " - " + a.EndTime
                }).OrderBy(x => x.Day).ThenBy(x => x.Time).ToList();

                if (dgvAssignments.Columns["ID"] != null) dgvAssignments.Columns["ID"].Visible = false;
            }
        }

        private void ClearInputs()
        {
            _selectedAssignmentId = -1;
            cmbRoom.SelectedIndex = -1;
            cmbFacultyAssign.SelectedIndex = -1;
            cmbDay.SelectedIndex = -1;
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

        private void lblRoomAssignment_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}