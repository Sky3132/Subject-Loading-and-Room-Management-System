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
                    // 1. Get the day of the week for the selected calendar date
                    string dayName = selectedDate.ToString("dddd");
                    var allRooms = db.tblRooms.ToList();

                    // 2. Fetch all assignments and their associated schedules
                    var roomDetails = new List<dynamic>();

                    foreach (var room in allRooms)
                    {
                        if (_selectedRoomId > 0 && room.RoomID != _selectedRoomId)
                            continue;

                        // 3. Find assignments for this specific room where the schedule matches the selected day
                        var activeAssignments = (from ra in db.tblRoomAssignments
                                                 join s in db.tblSchedules on ra.LoadID equals s.LoadID
                                                 where ra.RoomID == room.RoomID && s.DayOfWeek == dayName
                                                 select new { ra, s }).ToList();

                        string displayRoomName = $"{room.RoomName} ({room.Campus})";

                        if (activeAssignments.Count == 0)
                        {
                            // Available Logic
                            roomDetails.Add(new
                            {
                                Room = displayRoomName,
                                RoomType = room.RoomType,
                                Capacity = room.Capacity ?? 0,
                                Faculty = "AVAILABLE",
                                Subject = "",
                                TimeSlot = "",
                                Status = "Available"
                            });
                        }
                        else
                        {
                            // Occupied Logic - will trigger red formatting
                            foreach (var item in activeAssignments)
                            {
                                var facultyLoading = db.tblFacultyLoadings.FirstOrDefault(fl => fl.LoadID == item.ra.LoadID);
                                var faculty = facultyLoading?.tblFaculty;
                                var subjectObj = facultyLoading?.tblsubjectOffering?.tblsubject;

                                string mergedSubject = subjectObj != null ? $"{subjectObj.Code} - {subjectObj.Title}" : "Unknown";

                                // Format times from the Schedule table
                                string timeRange = $"{DateTime.Today.Add(item.s.StartTime):hh:mm tt} - {DateTime.Today.Add(item.s.EndTime):hh:mm tt}";

                                roomDetails.Add(new
                                {
                                    Room = displayRoomName,
                                    RoomType = room.RoomType,
                                    Capacity = room.Capacity ?? 0,
                                    Faculty = faculty != null ? $"{faculty.FirstName} {faculty.LastName}" : "Unknown",
                                    Subject = mergedSubject,
                                    TimeSlot = timeRange,
                                    Status = "Occupied"
                                });
                            }
                        }
                    }

                    dgvRoomDetails.DataSource = roomDetails.OrderBy(r => r.Room).ToList();

                    // 4. Apply the colors (Green for Available, Red for Occupied)
                    foreach (DataGridViewRow row in dgvRoomDetails.Rows)
                    {
                        if (row.Cells["Status"].Value.ToString() == "Available")
                        {
                            row.DefaultCellStyle.BackColor = Color.LightGreen;
                            row.DefaultCellStyle.ForeColor = Color.Black;
                        }
                        else
                        {
                            row.DefaultCellStyle.BackColor = Color.LightCoral; // This is the "Red" light-up
                            row.DefaultCellStyle.ForeColor = Color.White;
                        }
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