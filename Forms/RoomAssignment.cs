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
                    var rooms = db.tblRooms.ToList().Select(r => new {
                        r.RoomID,
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
                    DateTime newStart = DateTime.Parse(txtStartTime.Text);
                    DateTime newEnd = DateTime.Parse(txtEndTime.Text);
                    string selectedDays = string.Join(",", chkListDays.CheckedItems.Cast<string>());

                    foreach (string day in chkListDays.CheckedItems)
                    {
                        var roomAssignments = db.tblRoomAssignments
                            .Where(a => a.RoomID == selectedRoomId && a.Day.Contains(day))
                            .ToList();

                        bool conflict = roomAssignments.Any(a => {
                            DateTime existStart = DateTime.Parse(a.StartTime);
                            DateTime existEnd = DateTime.Parse(a.EndTime);
                            return (newStart < existEnd && newEnd > existStart);
                        });

                        if (conflict)
                        {
                            MessageBox.Show($"CONFLICT DETECTED: {day} - This room is already occupied during this time.",
                                            "Scheduling Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    tblRoomAssignment newAssign = new tblRoomAssignment
                    {
                        LoadID = (int)cmbFacultyAssign.SelectedValue,
                        RoomID = selectedRoomId,
                        Day = selectedDays,
                        StartTime = txtStartTime.Text,
                        EndTime = txtEndTime.Text
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
                        DateTime newStart = DateTime.Parse(txtStartTime.Text);
                        DateTime newEnd = DateTime.Parse(txtEndTime.Text);
                        string selectedDays = string.Join(",", chkListDays.CheckedItems.Cast<string>());

                        foreach (string day in chkListDays.CheckedItems)
                        {
                            var roomAssignments = db.tblRoomAssignments
                                .Where(a => a.AssignmentID != _selectedAssignmentId && a.RoomID == roomId && a.Day.Contains(day))
                                .ToList();

                            bool conflict = roomAssignments.Any(a => {
                                DateTime existStart = DateTime.Parse(a.StartTime);
                                DateTime existEnd = DateTime.Parse(a.EndTime);
                                return (newStart < existEnd && newEnd > existStart);
                            });

                            if (conflict)
                            {
                                MessageBox.Show($"Conflict detected on {day}! Room is busy at this new time.");
                                return;
                            }
                        }

                        assign.RoomID = roomId;
                        assign.LoadID = (int)cmbFacultyAssign.SelectedValue;
                        assign.Day = selectedDays;
                        assign.StartTime = txtStartTime.Text;
                        assign.EndTime = txtEndTime.Text;

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

                string daysInRow = row.Cells["Day"].Value?.ToString();
                UncheckAllDays();

                if (!string.IsNullOrEmpty(daysInRow))
                {
                    var daysList = daysInRow.Split(',').Select(d => d.Trim()).ToList();
                    foreach (string day in daysList)
                    {
                        int dayIndex = chkListDays.Items.IndexOf(day);
                        if (dayIndex >= 0)
                            chkListDays.SetItemChecked(dayIndex, true);
                    }
                }

                string timePeriod = row.Cells["TimePeriod"].Value?.ToString();
                if (!string.IsNullOrEmpty(timePeriod) && timePeriod.Contains("-"))
                {
                    var times = timePeriod.Split('-');
                    txtStartTime.Text = times[0].Trim();
                    txtEndTime.Text = times[1].Trim();
                }

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

        private void btnViewCalendar_Click(object sender, EventArgs e)
        {
            RoomAvailabilityCalendar calendar = new RoomAvailabilityCalendar();
            calendar.Show();
            this.Hide();
        }

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