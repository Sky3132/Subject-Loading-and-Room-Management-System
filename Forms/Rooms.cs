using __Subject_Loading_and_Room_Assignment_Monitoring_System.Managers;
using __Subject_Loading_and_Room_Assignment_Monitoring_System.Core_Models;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace __Subject_Loading_and_Room_Assignment_Monitoring_System.Forms
{
    public partial class Rooms : Form
    {
        // OOP: Encapsulating logic within the Manager
        private RoomManager _roomMgr = new RoomManager();

        public Rooms()
        {
            InitializeComponent();
        }

        private void Rooms_Load(object sender, EventArgs e)
        {
            dgvRooms.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            LoadRoomTypes();
            RefreshGrid();
        }

        private void RefreshGrid()
        {
            try
            {
                // UI layer calling Business Logic layer
                dgvRooms.DataSource = _roomMgr.GetRoomsGrid();

                if (dgvRooms.Columns["ID"] != null)
                    dgvRooms.Columns["ID"].Visible = false;

                // Update search combobox based on current data
                using (var db = new DataClasses1DataContext())
                {
                    cmbSearchRoom.DataSource = db.tblRooms.Select(r => r.RoomName).ToList();
                    cmbSearchRoom.SelectedIndex = -1;
                }
            }
            catch (Exception ex) { MessageBox.Show("Error refreshing data: " + ex.Message); }
        }

        private void LoadRoomTypes()
        {
            cmbRoomType.Items.Clear();
            cmbRoomType.Items.AddRange(new object[] { "Classroom", "ChemLab", "ComLab", "Drawing Room", "Drafting Room" });
            cmbRoomType.SelectedIndex = -1;
        }

        private string GetSelectedCampus()
        {
            if (rbMain.Checked) return "Main";
            if (rbVisayan.Checked) return "Visayan";
            return null;
        }

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Pack UI data into the Model
                var newRoom = new Room
                {
                    RoomName = txtRoomName.Text.Trim(),
                    RoomType = cmbRoomType.SelectedItem?.ToString(),
                    Capacity = int.TryParse(txtRoomCapacity.Text, out int cap) ? cap : 0,
                    Campus = GetSelectedCampus()
                };

                // 2. Delegate logic to Manager (Validation + Duplicate Check + Saving)
                _roomMgr.Validate(newRoom);
                _roomMgr.AddRoom(newRoom);

                MessageBox.Show("Room added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshGrid();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEditRoom_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvRooms.SelectedRows.Count == 0)
                    throw new Exception("Please select a room to edit.");

                var updatedRoom = new Room
                {
                    RoomID = (int)dgvRooms.SelectedRows[0].Cells["ID"].Value,
                    RoomName = txtRoomName.Text.Trim(),
                    RoomType = cmbRoomType.SelectedItem?.ToString(),
                    Capacity = int.TryParse(txtRoomCapacity.Text, out int cap) ? cap : 0,
                    Campus = GetSelectedCampus()
                };

                _roomMgr.Validate(updatedRoom);
                _roomMgr.UpdateRoom(updatedRoom);

                MessageBox.Show("Room updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshGrid();
                ClearInputs();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private void btnRemoveRoom_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvRooms.SelectedRows.Count == 0)
                    throw new Exception("Please select a room to remove.");

                if (MessageBox.Show("Are you sure you want to delete this room?", "Confirm",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    int id = (int)dgvRooms.SelectedRows[0].Cells["ID"].Value;
                    _roomMgr.DeleteRoom(id);

                    MessageBox.Show("Room removed successfully.");
                    RefreshGrid();
                    ClearInputs();
                }
            }
            catch (Exception ex)
            {
                // Custom handling for Foreign Key conflicts
                if (ex.Message.Contains("FK_") || ex.Message.Contains("REFERENCE constraint"))
                {
                    MessageBox.Show("This room is currently in use in Room Assignments and cannot be deleted.",
                                    "Room In Use", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else { MessageBox.Show(ex.Message); }
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
            rbMain.Checked = false;
            rbVisayan.Checked = false;
            dgvRooms.ClearSelection();
        }

        private void imgBackToMain2_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            main.Show();
            this.Hide();
        }

        private void btnSearchRoom_Click(object sender, EventArgs e)
        {
            // You can move the search logic to RoomManager as well to be fully OOP
            RefreshGrid(); // For now, this resets/reloads. 
            // In a full OOP setup, you'd pass search params to _roomMgr.GetRoomsGrid(searchName, type, campus)
        }

        private void lblRoomAssignment_Click(object sender, EventArgs e)
        {
            RoomAssignment assign = new RoomAssignment();
            assign.Show();
            this.Hide();
        }
    }
}