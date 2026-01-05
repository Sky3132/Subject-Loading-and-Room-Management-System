using __Subject_Loading_and_Room_Assignment_Monitoring_System.Managers;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace __Subject_Loading_and_Room_Assignment_Monitoring_System.Forms
{
    public partial class Rooms : Form
    {
        // Reference count will increase once this is built
        private RoomManager _roomMgr = new RoomManager();

        public Rooms()
        {
            InitializeComponent();
        }

        private void Rooms_Load(object sender, EventArgs e)
        {
            dgvRooms.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            LoadRooms();
        }

        private void LoadRooms()
        {
            try
            {
                using (DataClasses1DataContext db = new DataClasses1DataContext())
                {
                    var roomData = db.tblRooms.ToList();

                    dgvRooms.DataSource = roomData.Select(r => new {
                        ID = r.RoomID,
                        Number = r.RoomName,
                        Type = r.RoomType,
                        Capacity = r.Capacity
                    }).ToList();

                    if (dgvRooms.Columns["ID"] != null) dgvRooms.Columns["ID"].Visible = false;

                    cmbSearchRoom.DataSource = roomData.Select(r => r.RoomName).ToList();
                    cmbSearchRoom.SelectedIndex = -1;
                }
            }
            catch (Exception ex) { MessageBox.Show("Error loading rooms: " + ex.Message); }
        }

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            try
            {
                // Calling the Validate method in RoomManager
                _roomMgr.Validate(txtRoomNum.Text, txtRoomType.Text, txtRoomCapacity.Text);

                using (DataClasses1DataContext db = new DataClasses1DataContext())
                {
                    tblRoom room = new tblRoom
                    {
                        RoomName = txtRoomNum.Text.Trim(),
                        RoomType = txtRoomType.Text.Trim(),
                        Capacity = int.Parse(txtRoomCapacity.Text)
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
                if (dgvRooms.SelectedRows.Count == 0) throw new Exception("Please select a room to edit.");
                _roomMgr.Validate(txtRoomNum.Text, txtRoomType.Text, txtRoomCapacity.Text);

                int selectedId = (int)dgvRooms.SelectedRows[0].Cells["ID"].Value;

                using (DataClasses1DataContext db = new DataClasses1DataContext())
                {
                    var room = db.tblRooms.FirstOrDefault(r => r.RoomID == selectedId);
                    if (room != null)
                    {
                        room.RoomName = txtRoomNum.Text.Trim();
                        room.RoomType = txtRoomType.Text.Trim();
                        room.Capacity = int.Parse(txtRoomCapacity.Text);
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
                if (dgvRooms.SelectedRows.Count == 0) throw new Exception("Please select a room to remove.");
                if (MessageBox.Show("Delete this room?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int selectedId = (int)dgvRooms.SelectedRows[0].Cells["ID"].Value;
                    using (DataClasses1DataContext db = new DataClasses1DataContext())
                    {
                        var room = db.tblRooms.FirstOrDefault(r => r.RoomID == selectedId);
                        if (room != null)
                        {
                            db.tblRooms.DeleteOnSubmit(room);
                            db.SubmitChanges();
                            LoadRooms();
                            ClearInputs();
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void dgvRooms_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvRooms.Rows[e.RowIndex];
                txtRoomNum.Text = row.Cells["Number"].Value?.ToString();
                txtRoomName.Text = row.Cells["Number"].Value?.ToString();
                txtRoomType.Text = row.Cells["Type"].Value?.ToString();
                txtRoomCapacity.Text = row.Cells["Capacity"].Value?.ToString();
            }
        }

        private void txtRoomName_TextChanged(object sender, EventArgs e)
        {
            txtRoomNum.Text = txtRoomName.Text;
        }

        private void ClearInputs()
        {
            txtRoomNum.Clear();
            txtRoomName.Clear();
            txtRoomType.Clear();
            txtRoomCapacity.Clear();
            dgvRooms.ClearSelection();
        }

        private void imgBackToMain2_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            main.Show();
            this.Hide();
        }

        private void lblRoomAssignment_Click(object sender, EventArgs e)
        {
            RoomAssignment roomAssignForm = new RoomAssignment();

            // Show the RoomAssignment form
            roomAssignForm.Show();

            // Hide the current form (the Main menu or Dashboard)
            this.Hide();
        }
    }
}