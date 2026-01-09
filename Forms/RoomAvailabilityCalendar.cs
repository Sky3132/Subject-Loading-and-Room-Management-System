using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;

namespace __Subject_Loading_and_Room_Assignment_Monitoring_System.Forms
{
    /// <summary>
    /// Displays a monthly calendar with room availability
    /// Click on any date to see available rooms and current assignments
    /// FEATURE: Visual room availability calendar
    /// </summary>
    public partial class RoomAvailabilityCalendar : Form
    {
        private DateTime _currentDate;
        private int _selectedRoomId = -1;

        public RoomAvailabilityCalendar(int roomId = -1)
        {
            InitializeComponent();
            _selectedRoomId = roomId;
            _currentDate = DateTime.Now;
        }

        private void RoomAvailabilityCalendar_Load(object sender, EventArgs e)
        {
            LoadCalendar();
        }

        private void LoadCalendar()
        {
            try
            {
                // Set the MonthCalendar to current date
                monthCalendarRooms.SelectionStart = _currentDate;
                monthCalendarRooms.SelectionEnd = _currentDate;

                // Display current month/year
                lblMonthYear.Text = _currentDate.ToString("MMMM yyyy");

                // Load details for today by default
                LoadRoomDetailsForDate(_currentDate);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading calendar: " + ex.Message);
            }
        }

        /// <summary>
        /// Loads room availability and assignment details for the selected date
        /// </summary>
        private void LoadRoomDetailsForDate(DateTime selectedDate)
        {
            try
            {
                using (DataClasses1DataContext db = new DataClasses1DataContext())
                {
                    string dayName = selectedDate.ToString("dddd");
                    var allRooms = db.tblRooms.ToList();
                    var assignmentsForDay = db.tblRoomAssignments
                        .Where(a => a.Day.Contains(dayName))
                        .ToList();

                    var roomDetails = new List<dynamic>();

                    foreach (var room in allRooms)
                    {
                        if (_selectedRoomId > 0 && room.RoomID != _selectedRoomId)
                            continue;

                        var roomAssignments = assignmentsForDay.Where(a => a.RoomID == room.RoomID).ToList();

                        // Format the Room Name to include Campus
                        string displayRoomName = $"{room.RoomName} ({room.Campus})";

                        if (roomAssignments.Count == 0)
                        {
                            // Available Room logic
                            roomDetails.Add(new
                            {
                                Room = displayRoomName, // Updated with Campus
                                RoomType = room.RoomType,
                                Capacity = room.Capacity ?? 0,
                                Faculty = "AVAILABLE",
                                Subject = "",           // Merged field remains empty
                                TimeSlot = "",          // Requirement: Blank if available
                                Status = "Available"
                            });
                        }
                        else
                        {
                            // Occupied Room logic
                            foreach (var assignment in roomAssignments)
                            {
                                var facultyLoading = db.tblFacultyLoadings.FirstOrDefault(fl => fl.LoadID == assignment.LoadID);
                                var faculty = facultyLoading?.tblFaculty;
                                var subjectObj = facultyLoading?.tblsubjectOffering?.tblsubject;

                                // Requirement: Merge Code and Title (e.g., IT20 - 3099)
                                string mergedSubject = subjectObj != null ? $"{subjectObj.Code} - {subjectObj.Title}" : "Unknown";

                                roomDetails.Add(new
                                {
                                    Room = displayRoomName, // Updated with Campus
                                    RoomType = room.RoomType,
                                    Capacity = room.Capacity ?? 0,
                                    Faculty = faculty != null ? $"{faculty.FirstName} {faculty.LastName}" : "Unknown",
                                    Subject = mergedSubject,
                                    TimeSlot = $"{assignment.StartTime} - {assignment.EndTime}",
                                    Status = "Occupied"
                                });
                            }
                        }
                    }

                    dgvRoomDetails.DataSource = roomDetails.OrderBy(r => r.Room).ToList();

                    // Apply conditional formatting
                    foreach (DataGridViewRow row in dgvRoomDetails.Rows)
                    {
                        if (row.Cells["Status"].Value.ToString() == "Available")
                            row.DefaultCellStyle.BackColor = Color.LightGreen;
                        else
                            row.DefaultCellStyle.BackColor = Color.LightCoral;
                    }

                    lblSelectedDate.Text = $"Date: {selectedDate:dddd, MMMM dd, yyyy}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading room details: " + ex.Message);
            }
        }

        private void monthCalendarRooms_DateSelected(object sender, DateRangeEventArgs e)
        {
            _currentDate = e.Start;
            LoadRoomDetailsForDate(_currentDate);
        }

        private void btnPreviousMonth_Click(object sender, EventArgs e)
        {
            _currentDate = _currentDate.AddMonths(-1);
            LoadCalendar();
        }

        private void btnNextMonth_Click(object sender, EventArgs e)
        {
            _currentDate = _currentDate.AddMonths(1);
            LoadCalendar();
        }

        private void btnToday_Click(object sender, EventArgs e)
        {
            _currentDate = DateTime.Now;
            LoadCalendar();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadRoomDetailsForDate(_currentDate);
            MessageBox.Show("Calendar refreshed!");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            RoomAssignment assign = new RoomAssignment();
            assign.Show();
            this.Hide();
        }
    }
}