using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace __Subject_Loading_and_Room_Assignment_Monitoring_System.Forms
{
    public partial class Schedules : Form
    {       
            string connStr = @"Server=DESKTOP-CL62R53; Database=Schooldb; Integrated Security=True;";

            public Schedules()
            {
                InitializeComponent();
                LoadAllComboBoxes();
                RefreshScheduleGrid();
            }

            public void LoadAllComboBoxes()
            {
                // --- TIME SLOT CONFIGURATION ---
                cmbSchedDay.Items.Clear();
                cmbSchedDay.Items.AddRange(new string[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" });

                cmbSchedStart.Items.Clear();
                cmbSchedEnd.Items.Clear();
                for (int h = 7; h <= 19; h++)
                {
                    string t = $"{h:D2}:00";
                    cmbSchedStart.Items.Add(t);
                    cmbSchedEnd.Items.Add(t);
                }

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    // Load Subjects
                    SqlDataAdapter daSub = new SqlDataAdapter("SELECT subjectId, Title FROM tblsubject", conn);
                    DataTable dtSub = new DataTable();
                    daSub.Fill(dtSub);
                    cmbSchedSubject.DataSource = dtSub;
                    cmbSchedSubject.DisplayMember = "Title";
                    cmbSchedSubject.ValueMember = "subjectId";

                    // Load Rooms
                    SqlDataAdapter daRoom = new SqlDataAdapter("SELECT RoomID, RoomName FROM tblRooms", conn);
                    DataTable dtRoom = new DataTable();
                    daRoom.Fill(dtRoom);
                    cmbSchedRoom.DataSource = dtRoom;
                    cmbSchedRoom.DisplayMember = "RoomName";
                    cmbSchedRoom.ValueMember = "RoomID";

                    // Load Faculty
                    SqlDataAdapter daFac = new SqlDataAdapter("SELECT FacultyID, (FirstName + ' ' + LastName) as FullName FROM tblFaculty", conn);
                    DataTable dtFac = new DataTable();
                    daFac.Fill(dtFac);
                    cmbSchedFaculty.DataSource = dtFac;
                    cmbSchedFaculty.DisplayMember = "FullName";
                    cmbSchedFaculty.ValueMember = "FacultyID";

                    // Load Sections
                    SqlDataAdapter daSec = new SqlDataAdapter("SELECT DISTINCT Section FROM tblFacultyLoading", conn);
                    DataTable dtSec = new DataTable();
                    daSec.Fill(dtSec);
                    cmbSchedSection.DataSource = dtSec;
                    cmbSchedSection.DisplayMember = "Section";
                }
                ClearInputs();
            }

            private void ClearInputs()
            {
            // Setting SelectedIndex to -1 clears the visible text
            cmbSchedDay.SelectedIndex = -1;
            cmbSchedStart.SelectedIndex = -1;
            cmbSchedEnd.SelectedIndex = -1;
            cmbSchedSubject.SelectedIndex = -1;
            cmbSchedFaculty.SelectedIndex = -1;
            cmbSchedRoom.SelectedIndex = -1;
            cmbSchedSection.SelectedIndex = -1;

            // This forces the display text to be empty
            cmbSchedSection.Text = string.Empty;
        }

        // --- CONFLICT CHECKING ALGORITHM ---
        private bool IsConflict(int roomID, int facultyID, string section, string day, string start, string end, int currentID = 0)
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    // Logic: Checks for overlaps in Room, Faculty, OR Section (Students)
                    string sql = @"SELECT COUNT(*) FROM tblSchedule S
                               JOIN tblFacultyLoading L ON S.LoadID = L.LoadID
                               WHERE S.DayOfWeek = @Day AND S.ScheduleID != @ID
                               AND (S.RoomID = @RID OR L.FacultyID = @FID OR L.Section = @Sect)
                               AND ((@Start >= S.StartTime AND @Start < S.EndTime) 
                               OR (@End > S.StartTime AND @End <= S.EndTime)
                               OR (S.StartTime >= @Start AND S.StartTime < @End))";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@Day", day);
                    cmd.Parameters.AddWithValue("@RID", roomID);
                    cmd.Parameters.AddWithValue("@FID", facultyID);
                    cmd.Parameters.AddWithValue("@Sect", section);
                    cmd.Parameters.AddWithValue("@Start", start);
                    cmd.Parameters.AddWithValue("@End", end);
                    cmd.Parameters.AddWithValue("@ID", currentID);
                    conn.Open();
                    return (int)cmd.ExecuteScalar() > 0;
                }
            }

            private int GetLoadID()
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    string sql = @"SELECT L.LoadID FROM tblFacultyLoading L 
                              JOIN tblsubjectOffering O ON L.offeringId = O.offeringId 
                              WHERE L.FacultyID = @FID AND O.subjectId = @SID AND L.Section = @Sect";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@FID", cmbSchedFaculty.SelectedValue ?? 0);
                    cmd.Parameters.AddWithValue("@SID", cmbSchedSubject.SelectedValue ?? 0);
                    cmd.Parameters.AddWithValue("@Sect", cmbSchedSection.Text);
                    conn.Open();
                    object res = cmd.ExecuteScalar();
                    return res != null ? (int)res : 0;
                }
            }

            private void ExecuteNonQuery(string sql, int lid, int sid)
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    if (sql.Contains("@LID")) cmd.Parameters.AddWithValue("@LID", lid);
                    if (sql.Contains("@RID")) cmd.Parameters.AddWithValue("@RID", cmbSchedRoom.SelectedValue);
                    if (sql.Contains("@Day")) cmd.Parameters.AddWithValue("@Day", cmbSchedDay.Text);
                    if (sql.Contains("@Start")) cmd.Parameters.AddWithValue("@Start", cmbSchedStart.Text);
                    if (sql.Contains("@End")) cmd.Parameters.AddWithValue("@End", cmbSchedEnd.Text);
                    cmd.Parameters.AddWithValue("@ID", sid);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                RefreshScheduleGrid();
            }

            private void RefreshScheduleGrid()
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    string sql = @"SELECT S.ScheduleID, sub.Title AS [Subject], (F.FirstName + ' ' + F.LastName) AS [Faculty], 
                               L.Section, R.RoomName AS [Room], S.DayOfWeek, S.StartTime, S.EndTime 
                               FROM tblSchedule S 
                               JOIN tblFacultyLoading L ON S.LoadID = L.LoadID 
                               JOIN tblFaculty F ON L.FacultyID = F.FacultyID 
                               JOIN tblRooms R ON S.RoomID = R.RoomID 
                               JOIN tblsubjectOffering O ON L.offeringId = O.offeringId 
                               JOIN tblsubject sub ON O.subjectId = sub.subjectId";
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvSchedMain.DataSource = dt;
                }
            }

        // --- SAVE BUTTON ---
        private void btnSchedSave_Click_1(object sender, EventArgs e)
        {
            int loadID = GetLoadID();
            if (loadID == 0) { MessageBox.Show("Loading record not found!"); return; }

            if (IsConflict((int)cmbSchedRoom.SelectedValue, (int)cmbSchedFaculty.SelectedValue, cmbSchedSection.Text, cmbSchedDay.Text, cmbSchedStart.Text, cmbSchedEnd.Text))
            {
                MessageBox.Show("Conflict detected! Room, Faculty, or Students are busy.");
                return;
            }

            ExecuteNonQuery("INSERT INTO tblSchedule (LoadID, RoomID, DayOfWeek, StartTime, EndTime) VALUES (@LID, @RID, @Day, @Start, @End)", loadID, 0);
            MessageBox.Show("Saved to Grid!");
            ClearInputs();
        }
        // --- UPDATE BUTTON ---
        private void btnSchedUpdate_Click_1(object sender, EventArgs e)
        {
            if (dgvSchedMain.CurrentRow == null) return;
            int id = (int)dgvSchedMain.CurrentRow.Cells["ScheduleID"].Value;
            int lid = GetLoadID();

            if (IsConflict((int)cmbSchedRoom.SelectedValue, (int)cmbSchedFaculty.SelectedValue, cmbSchedSection.Text, cmbSchedDay.Text, cmbSchedStart.Text, cmbSchedEnd.Text, id))
            {
                MessageBox.Show("Update failed: Conflict detected.");
                return;
            }

            ExecuteNonQuery("UPDATE tblSchedule SET LoadID=@LID, RoomID=@RID, DayOfWeek=@Day, StartTime=@Start, EndTime=@End WHERE ScheduleID=@ID", lid, id);
            MessageBox.Show("Update successful!");
            ClearInputs();
        }
        // --- REMOVE BUTTON ---
        private void btnSchedRemove_Click_1(object sender, EventArgs e)
        {
            if (dgvSchedMain.CurrentRow == null) return;
            int id = (int)dgvSchedMain.CurrentRow.Cells["ScheduleID"].Value;

            if (MessageBox.Show("Delete this schedule?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ExecuteNonQuery("DELETE FROM tblSchedule WHERE ScheduleID=@ID", 0, id);
                ClearInputs();
            }
        }

        private void imgBackToMain2_Click(object sender, EventArgs e)
        {
            if (this.Tag is Form mainForm) mainForm.Show();
            this.Close();
        }

        private void lblOpenClassSched_Click(object sender, EventArgs e)
        {
            // Use the full namespace so the computer finds the ClassSched form
            __Subject_Loading_and_Room_Assignment_Monitoring_System.Forms.ClassSched classForm =
                new __Subject_Loading_and_Room_Assignment_Monitoring_System.Forms.ClassSched();

            classForm.Tag = this; // Save this form so the back button works
            classForm.Show();
            this.Hide();
        }
    }
    }
    
    
    
    
 






