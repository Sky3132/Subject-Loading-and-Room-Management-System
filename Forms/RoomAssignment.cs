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



                using (DataClasses1DataContext db = new DataClasses1DataContext())

                {

                    tblRoomAssignment newAssign = new tblRoomAssignment

                    {

                        LoadID = (int)cmbFacultyAssign.SelectedValue,

                        RoomID = (int)cmbRoom.SelectedValue,

                        Day = "",

                        StartTime = "",

                        EndTime = ""

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



        private void btnEditAssign_Click_1(object sender, EventArgs e)

        {

            try

            {

                if (_selectedAssignmentId == -1) throw new Exception("Please select an assignment first.");



                using (DataClasses1DataContext db = new DataClasses1DataContext())

                {

                    var assign = db.tblRoomAssignments.FirstOrDefault(a => a.AssignmentID == _selectedAssignmentId);

                    if (assign != null)

                    {

                        assign.RoomID = (int)cmbRoom.SelectedValue;

                        assign.LoadID = (int)cmbFacultyAssign.SelectedValue;



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



                if (MessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)

                {

                    using (DataClasses1DataContext db = new DataClasses1DataContext())

                    {

                        var assign = db.tblRoomAssignments.FirstOrDefault(a => a.AssignmentID == _selectedAssignmentId);

                        if (assign != null)

                        {

                            db.tblRoomAssignments.DeleteOnSubmit(assign);

                            db.SubmitChanges();

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

                var list = db.tblRoomAssignments.ToList().Select(a => new

                {

                    ID = a.AssignmentID,

                    Room = a.tblRoom.RoomName + " - " + (a.tblRoom.Campus == "Visayan" ? "VC" : a.tblRoom.Campus.ToUpper()),

                    Faculty = a.tblFacultyLoading.tblFaculty.FirstName + " " + a.tblFacultyLoading.tblFaculty.LastName,

                    Subject = a.tblFacultyLoading.tblsubjectOffering.tblsubject.Code,

                    Schedule = string.Join(" / ", db.tblSchedules

                                    .Where(s => s.LoadID == a.LoadID)

                                    .ToList()

                                    .Select(s => $"{s.DayOfWeek} ({DateTime.Today.Add(s.StartTime).ToString("hh:mm tt")}-{DateTime.Today.Add(s.EndTime).ToString("hh:mm tt")})"))

                }).ToList();



                dgvAssignments.DataSource = list;

                FormatGrid();

            }

        }



        // Added this to avoid repeating formatting code

        private void FormatGrid()

        {

            if (dgvAssignments.Columns["ID"] != null)

                dgvAssignments.Columns["ID"].Visible = false;



            if (dgvAssignments.Columns["Room"] != null)

                dgvAssignments.Columns["Room"].HeaderText = "Room - Campus";



            if (dgvAssignments.Columns["Schedule"] != null)

                dgvAssignments.Columns["Schedule"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

        }



        private void ClearInputs()

        {

            _selectedAssignmentId = -1;

            cmbRoom.SelectedIndex = -1;

            cmbFacultyAssign.SelectedIndex = -1;

            dgvAssignments.ClearSelection();

        }



        private void imgBackToMain2_Click(object sender, EventArgs e)

        {

            Rooms room = new Rooms();

            room.Show();

            this.Hide();

        }



        // --- UPDATED SEARCH BUTTON LOGIC ---

        private void btnSearchAssign_Click(object sender, EventArgs e)

        {

            string keyword = txtSearchAssign.Text.Trim();



            if (string.IsNullOrEmpty(keyword))

            {

                LoadAssignmentsGrid();

                return;

            }



            using (DataClasses1DataContext db = new DataClasses1DataContext())

            {

                var filtered = db.tblRoomAssignments.ToList().Select(a => new

                {

                    ID = a.AssignmentID,

                    Room = a.tblRoom.RoomName + " - " + (a.tblRoom.Campus == "Visayan" ? "VC" : a.tblRoom.Campus.ToUpper()),

                    Faculty = a.tblFacultyLoading.tblFaculty.FirstName + " " + a.tblFacultyLoading.tblFaculty.LastName,

                    // Force the Subject to a string using .ToString()

                    Subject = a.tblFacultyLoading.tblsubjectOffering.tblsubject.Code.ToString(),

                    Schedule = string.Join(" / ", db.tblSchedules

                                    .Where(s => s.LoadID == a.LoadID)

                                    .ToList()

                                    .Select(s => $"{s.DayOfWeek} ({DateTime.Today.Add(s.StartTime).ToString("hh:mm tt")}-{DateTime.Today.Add(s.EndTime).ToString("hh:mm tt")})"))

                })

                .Where(x => x.Faculty.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0 ||

                            x.Subject.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0 || // Now works on string

                            x.Room.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0)

                .ToList();



                dgvAssignments.DataSource = filtered;

                FormatGrid();

            }

        }

        private void btnViewCalendar_Click_1(object sender, EventArgs e)
        {
            RoomAvailabilityCalendar calendar = new RoomAvailabilityCalendar();

            calendar.Show();

            this.Hide();
        }

        private void imgBackToMain2_Click_1(object sender, EventArgs e)
        {
            Rooms rooms = new Rooms();
            rooms.Show();
            this.Hide();
        }

        private void btnViewReport_Click(object sender, EventArgs e)
        {
            RoomUtilizationReport report = new RoomUtilizationReport();
            report.Show();
            this.Hide();
        }
    }

}