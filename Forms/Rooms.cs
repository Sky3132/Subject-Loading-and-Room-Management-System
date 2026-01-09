using __Subject_Loading_and_Room_Assignment_Monitoring_System.Managers;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace __Subject_Loading_and_Room_Assignment_Monitoring_System.Forms
{
    public partial class Rooms : Form
    {
        private RoomManager _roomMgr = new RoomManager();

        public Rooms()
        {
            InitializeComponent();
        }

        private void Rooms_Load(object sender, EventArgs e)
        {
            dgvRooms.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            LoadRoomTypes();
            LoadRooms();
        }

        private void LoadRoomTypes()
        {
            try
            {
                cmbRoomType.Items.Clear();
                cmbRoomType.Items.AddRange(new object[] { "Classroom", "ChemLab", "ComLab", "Drawing Room", "Drafting Room" });
                cmbRoomType.SelectedIndex = -1;
            }
            catch (Exception ex) { MessageBox.Show("Error loading room types: " + ex.Message); }
        }

        private void LoadRooms()
        {
            try
            {
                using (DataClasses1DataContext db = new DataClasses1DataContext())
                {
                    var roomData = db.tblRooms.ToList();

                    // UPDATED: Added Campus to the DataGrid display
                    dgvRooms.DataSource = roomData.Select(r => new {
                        ID = r.RoomID,
                        Number = r.RoomName,
                        Type = r.RoomType,
                        Capacity = r.Capacity,
                        Campus = r.Campus // Displays "Main" or "Visayan" in the table
                    }).ToList();

                    if (dgvRooms.Columns["ID"] != null) dgvRooms.Columns["ID"].Visible = false;

                    cmbSearchRoom.DataSource = roomData.Select(r => r.RoomName).ToList();
                    cmbSearchRoom.SelectedIndex = -1;
                }
            }
            catch (Exception ex) { MessageBox.Show("Error loading rooms: " + ex.Message); }
        }

        // Helper to get text from RadioButtons
        private string GetSelectedCampus()
        {
            if (rbMain.Checked) return "Main";
            if (rbVisayan.Checked) return "Visayan";
            return "";
        }

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbRoomType.SelectedIndex == -1)
                    throw new Exception("Please select a room type.");

                if (!rbMain.Checked && !rbVisayan.Checked)
                    throw new Exception("Please select a campus (Main or Visayan).");

                _roomMgr.Validate(txtRoomName.Text, cmbRoomType.SelectedItem.ToString(), txtRoomCapacity.Text);

                using (DataClasses1DataContext db = new DataClasses1DataContext())
                {
                    tblRoom room = new tblRoom
                    {
                        RoomName = txtRoomName.Text.Trim(),
                        RoomType = cmbRoomType.SelectedItem.ToString(),
                        Capacity = int.Parse(txtRoomCapacity.Text),
                        Campus = GetSelectedCampus() // SAVES CAMPUS TO DB
                    };
                    db.tblRooms.InsertOnSubmit(room);
                    db.SubmitChanges();

                    MessageBox.Show("Room added successfully.");
                    LoadRooms();
                    ClearInputs();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnEditRoom_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvRooms.SelectedRows.Count == 0)
                    throw new Exception("Please select a room to edit.");

                int selectedId = (int)dgvRooms.SelectedRows[0].Cells["ID"].Value;

                using (DataClasses1DataContext db = new DataClasses1DataContext())
                {
                    var room = db.tblRooms.FirstOrDefault(r => r.RoomID == selectedId);
                    if (room != null)
                    {
                        room.RoomName = txtRoomName.Text.Trim();
                        room.RoomType = cmbRoomType.SelectedItem.ToString();
                        room.Capacity = int.Parse(txtRoomCapacity.Text);
                        room.Campus = GetSelectedCampus(); // UPDATES CAMPUS IN DB

                        db.SubmitChanges();
                        MessageBox.Show("Room updated successfully.");
                        LoadRooms();
                        ClearInputs();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnRemoveRoom_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvRooms.SelectedRows.Count == 0)
                    throw new Exception("Please select a room from the list to remove.");

                if (MessageBox.Show("Are you sure you want to delete this room?", "Confirm Deletion",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    int selectedId = (int)dgvRooms.SelectedRows[0].Cells["ID"].Value;

                    using (DataClasses1DataContext db = new DataClasses1DataContext())
                    {
                        var room = db.tblRooms.FirstOrDefault(r => r.RoomID == selectedId);
                        if (room != null)
                        {
                            db.tblRooms.DeleteOnSubmit(room);
                            db.SubmitChanges();

                            MessageBox.Show("Room removed successfully.");
                            LoadRooms();
                            ClearInputs();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // UPDATED: Custom message for Foreign Key conflicts
                if (ex.Message.Contains("FK_") || ex.Message.Contains("REFERENCE constraint"))
                {
                    MessageBox.Show("This room cannot be deleted because it is currently assigned to a class in Room Assignments. " +
                                    "\n\nPlease remove those assignments first.",
                                    "Room In Use", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }

        private void dgvRooms_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvRooms.Rows[e.RowIndex];
                txtRoomName.Text = row.Cells["Number"].Value?.ToString();
                cmbRoomType.SelectedItem = row.Cells["Type"].Value?.ToString();
                txtRoomCapacity.Text = row.Cells["Capacity"].Value?.ToString();

                // UPDATED: Selects the correct RadioButton based on the row clicked
                string campus = row.Cells["Campus"].Value?.ToString();
                if (campus == "Main") rbMain.Checked = true;
                else if (campus == "Visayan") rbVisayan.Checked = true;
            }
        }

        private void ClearInputs()
        {
            txtRoomName.Clear();
            cmbRoomType.SelectedIndex = -1;
            txtRoomCapacity.Clear();
            rbMain.Checked = false;   // Resets Campus selection
            rbVisayan.Checked = false;
            dgvRooms.ClearSelection();
        }

        // ... Navigation and other events remain the same ...
        private void imgBackToMain2_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            main.Show();
            this.Hide();
        }

        private void lblRoomAssignment_Click(object sender, EventArgs e)
        {
            RoomAssignment roomAssignForm = new RoomAssignment();
            roomAssignForm.Show();
            this.Hide();
        }

        private void btnSearchRoom_Click(object sender, EventArgs e)
        {
            try
            {
                using (DataClasses1DataContext db = new DataClasses1DataContext())
                {
                    // Start with all rooms
                    var query = db.tblRooms.AsQueryable();

                    // 1. Filter by Room Name (from ComboBox or Text)
                    string searchName = cmbSearchRoom.Text.Trim();
                    if (!string.IsNullOrEmpty(searchName))
                    {
                        query = query.Where(r => r.RoomName.Contains(searchName));
                    }

                    // 2. Filter by Room Type
                    if (cmbRoomType.SelectedIndex != -1)
                    {
                        string searchType = cmbRoomType.SelectedItem.ToString();
                        query = query.Where(r => r.RoomType == searchType);
                    }

                    // 3. Filter by Campus
                    string selectedCampus = GetSelectedCampus();
                    if (!string.IsNullOrEmpty(selectedCampus))
                    {
                        query = query.Where(r => r.Campus == selectedCampus);
                    }

                    // Execute search
                    var results = query.ToList();

                    if (results.Count == 0)
                    {
                        MessageBox.Show("No rooms found matching those criteria.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadRooms(); // Reset to show all if nothing found
                        return;
                    }

                    // Bind results to grid
                    dgvRooms.DataSource = results.Select(r => new {
                        ID = r.RoomID,
                        Number = r.RoomName,
                        Type = r.RoomType,
                        Capacity = r.Capacity,
                        Campus = r.Campus
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during multi-criteria search: " + ex.Message);
            }
        }
    }
}