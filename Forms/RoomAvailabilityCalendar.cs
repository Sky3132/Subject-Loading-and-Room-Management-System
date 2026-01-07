using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;

namespace __Subject_Loading_and_Room_Assignment_Monitoring_System.Forms
{
    /// <summary>
    /// Displays a visual calendar of room availability for the week
    /// FEATURE: Visual room availability calendar
    /// </summary>
    public partial class RoomAvailabilityCalendar : Form
    {
        private int _selectedRoomId = -1;
        private readonly string[] _days = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };
        private readonly string[] _timeSlots = { "08:00AM", "09:00AM", "10:00AM", "11:00AM", "12:00PM", "01:00PM", "02:00PM", "03:00PM", "04:00PM", "05:00PM" };

        public RoomAvailabilityCalendar(int roomId = -1)
        {
            InitializeComponent();
            _selectedRoomId = roomId;
        }

        private void RoomAvailabilityCalendar_Load(object sender, EventArgs e)
        {
            InitializeCalendarGrid();
            LoadRoomAvailability();
        }

        private void InitializeCalendarGrid()
        {
            dataGridViewCalendar.Columns.Clear();
            dataGridViewCalendar.ColumnCount = _days.Length + 1;
            dataGridViewCalendar.RowCount = _timeSlots.Length;

            // Set column headers to days of week
            dataGridViewCalendar.Columns[0].HeaderText = "Time Slot";
            for (int i = 0; i < _days.Length; i++)
            {
                dataGridViewCalendar.Columns[i + 1].HeaderText = _days[i];
                dataGridViewCalendar.Columns[i + 1].Width = 100;
            }

            // Set row headers to time slots
            for (int i = 0; i < _timeSlots.Length; i++)
            {
                dataGridViewCalendar.Rows[i].HeaderCell.Value = _timeSlots[i];
            }

            dataGridViewCalendar.AllowUserToAddRows = false;
            dataGridViewCalendar.AllowUserToDeleteRows = false;
            dataGridViewCalendar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCalendar.RowHeadersWidth = 80;
        }

        private void LoadRoomAvailability()
        {
            try
            {
                using (DataClasses1DataContext db = new DataClasses1DataContext())
                {
                    IQueryable<tblRoomAssignment> assignments = db.tblRoomAssignments;

                    if (_selectedRoomId > 0)
                    {
                        assignments = assignments.Where(a => a.RoomID == _selectedRoomId);
                        this.Text = $"Room Availability - {db.tblRooms.FirstOrDefault(r => r.RoomID == _selectedRoomId)?.RoomName}";
                    }

                    var assignmentList = assignments.ToList();

                    // Clear all cells
                    for (int row = 0; row < dataGridViewCalendar.RowCount; row++)
                    {
                        for (int col = 1; col < dataGridViewCalendar.ColumnCount; col++)
                        {
                            dataGridViewCalendar.Rows[row].Cells[col].Value = "Available";
                            dataGridViewCalendar.Rows[row].Cells[col].Style.BackColor = Color.LightGreen;
                            dataGridViewCalendar.Rows[row].Cells[col].Style.ForeColor = Color.Black;
                        }
                    }

                    // Mark occupied slots
                    foreach (var assignment in assignmentList)
                    {
                        var daysArray = assignment.Day.Split(',').Select(d => d.Trim()).ToList();
                        
                        foreach (string day in daysArray)
                        {
                            int dayCol = System.Array.IndexOf(_days, day) + 1;
                            if (dayCol > 0)
                            {
                                // Find time slots that conflict
                                for (int row = 0; row < _timeSlots.Length; row++)
                                {
                                    string timeSlot = _timeSlots[row];
                                    if (IsTimeInRange(timeSlot, assignment.StartTime, assignment.EndTime))
                                    {
                                        var cell = dataGridViewCalendar.Rows[row].Cells[dayCol];
                                        cell.Value = GetAssignmentDisplay(assignment, db);
                                        cell.Style.BackColor = Color.LightCoral;
                                        cell.Style.ForeColor = Color.White;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading availability: " + ex.Message);
            }
        }

        private bool IsTimeInRange(string timeSlot, string startTime, string endTime)
        {
            return string.Compare(timeSlot, startTime) >= 0 && string.Compare(timeSlot, endTime) < 0;
        }

        private string GetAssignmentDisplay(tblRoomAssignment assignment, DataClasses1DataContext db)
        {
            try
            {
                var faculty = db.tblFacultyLoadings.FirstOrDefault(fl => fl.LoadID == assignment.LoadID);
                if (faculty != null)
                {
                    return $"{faculty.tblFaculty.FirstName} {faculty.tblFaculty.LastName}";
                }
            }
            catch { }
            return "Occupied";
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadRoomAvailability();
            MessageBox.Show("Calendar refreshed!");
        }

        public int SelectedRoomId => _selectedRoomId;

        private void imgBackToMain2_Click(object sender, EventArgs e)
        {
            RoomAssignment assign = new RoomAssignment();
            assign.Show();
            this.Hide();
        }
    }
}