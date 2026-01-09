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
                    // Get day of week name
                    string dayName = selectedDate.ToString("dddd");

                    // Get all rooms
                    var allRooms = db.tblRooms.ToList();

                    // Get assignments for this day
                    var assignmentsForDay = db.tblRoomAssignments
                        .Where(a => a.Day.Contains(dayName))
                        .ToList();

                    // Build room details list
                    var roomDetails = new List<dynamic>();

                    foreach (var room in allRooms)
                    {
                        // Filter by selected room if one is chosen
                        if (_selectedRoomId > 0 && room.RoomID != _selectedRoomId)
                            continue;

                        // Find assignments for this room
                        var roomAssignments = assignmentsForDay.Where(a => a.RoomID == room.RoomID).ToList();

                        if (roomAssignments.Count == 0)
                        {
                            // Room is available
                            roomDetails.Add(new
                            {
                                RoomName = room.RoomName,
                                RoomType = room.RoomType,
                                Capacity = room.Capacity.HasValue ? room.Capacity.Value : 0,
                                Faculty = "AVAILABLE",
                                Subject = "",
                                SubjectCode = "",
                                TimeSlot = "All Day",
                                Status = "Available"
                            });
                        }
                        else
                        {
                            // Room has assignments
                            foreach (var assignment in roomAssignments)
                            {
                                var facultyLoading = db.tblFacultyLoadings.FirstOrDefault(fl => fl.LoadID == assignment.LoadID);
                                var faculty = facultyLoading?.tblFaculty;
                                var subject = facultyLoading?.tblsubjectOffering?.tblsubject;

                                roomDetails.Add(new
                                {
                                    RoomName = room.RoomName,
                                    RoomType = room.RoomType,
                                    Capacity = room.Capacity.HasValue ? room.Capacity.Value : 0,
                                    Faculty = faculty != null ? $"{faculty.FirstName} {faculty.LastName}" : "Unknown",
                                    Subject = subject != null ? subject.Title : "Unknown",
                                    SubjectCode = subject != null ? subject.Code.ToString() : "",
                                    TimeSlot = $"{assignment.StartTime} - {assignment.EndTime}",
                                    Status = "Occupied"
                                });
                            }
                        }
                    }

                    // Display in DataGridView
                    dgvRoomDetails.DataSource = roomDetails.OrderBy(r => r.RoomName).ToList();

                    // Format DataGridView
                    dgvRoomDetails.AutoResizeColumns();
                    
                    // Color code based on status
                    foreach (DataGridViewRow row in dgvRoomDetails.Rows)
                    {
                        if (row.Cells["Status"].Value.ToString() == "Available")
                        {
                            row.DefaultCellStyle.BackColor = Color.LightGreen;
                        }
                        else
                        {
                            row.DefaultCellStyle.BackColor = Color.LightCoral;
                        }
                    }

                    // Update date label
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

        public int SelectedRoomId => _selectedRoomId;

        private void imgBackToMain2_Click(object sender, EventArgs e)
        {
            RoomAssignment assign = new RoomAssignment();
            assign.Show();
            this.Hide();
        }
    }
}