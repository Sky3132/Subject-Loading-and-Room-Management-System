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
                // Load room types into combo box
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
                // Validate inputs: RoomName is required, Type and Capacity are required
                if (cmbRoomType.SelectedIndex == -1)
                    throw new Exception("Please select a room type.");

                _roomMgr.Validate(txtRoomName.Text, cmbRoomType.SelectedItem.ToString(), txtRoomCapacity.Text);

                using (DataClasses1DataContext db = new DataClasses1DataContext())
                {
                    tblRoom room = new tblRoom
                    {
                        RoomName = txtRoomName.Text.Trim(),
                        RoomType = cmbRoomType.SelectedItem.ToString(),
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
                if (dgvRooms.SelectedRows.Count == 0) 
                    throw new Exception("Please select a room to edit.");

                if (cmbRoomType.SelectedIndex == -1)
                    throw new Exception("Please select a room type.");

                _roomMgr.Validate(txtRoomName.Text, cmbRoomType.SelectedItem.ToString(), txtRoomCapacity.Text);

                int selectedId = (int)dgvRooms.SelectedRows[0].Cells["ID"].Value;

                using (DataClasses1DataContext db = new DataClasses1DataContext())
                {
                    var room = db.tblRooms.FirstOrDefault(r => r.RoomID == selectedId);
                    if (room != null)
                    {
                        room.RoomName = txtRoomName.Text.Trim();
                        room.RoomType = cmbRoomType.SelectedItem.ToString();
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
                if (dgvRooms.SelectedRows.Count == 0) 
                    throw new Exception("Please select a room to remove.");

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
                txtRoomName.Text = row.Cells["Number"].Value?.ToString();
                cmbRoomType.SelectedItem = row.Cells["Type"].Value?.ToString();
                txtRoomCapacity.Text = row.Cells["Capacity"].Value?.ToString();
            }
        }

        private void ClearInputs()
        {
            txtRoomName.Clear();
            cmbRoomType.SelectedIndex = -1;
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
            roomAssignForm.Show();
            this.Hide();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}