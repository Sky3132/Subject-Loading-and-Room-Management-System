using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using __Subject_Loading_and_Room_Assignment_Monitoring_System.Core_Models;

namespace __Subject_Loading_and_Room_Assignment_Monitoring_System.Forms
{
    public partial class RoomUtilizationReport : Form
    {
        public RoomUtilizationReport()
        {
            InitializeComponent();
        }

        private void RoomUtilizationReport_Load(object sender, EventArgs e)
        {
            LoadRoomUtilizationData();
        }

        private void LoadRoomUtilizationData()
        {
            try
            {
                using (DataClasses1DataContext db = new DataClasses1DataContext())
                {
                    // 1. Fetch all rooms
                    var rooms = db.tblRooms.ToList();

                    // 2. Fetch all schedule data linked to assignments
                    var scheduleData = (from ra in db.tblRoomAssignments
                                        join s in db.tblSchedules on ra.LoadID equals s.LoadID
                                        select new
                                        {
                                            ra.RoomID,
                                            s.DayOfWeek,
                                            s.StartTime,
                                            s.EndTime
                                        }).ToList();

                    // 3. Process the data for the report
                    var utilization = rooms.Select(r =>
                    {
                        var roomScheds = scheduleData.Where(s => s.RoomID == r.RoomID).ToList();

                        double totalHours = 0;
                        var daysSet = new HashSet<string>();

                        foreach (var s in roomScheds)
                        {
                            // Calculate duration in hours
                            double diff = (s.EndTime - s.StartTime).TotalHours;
                            if (diff > 0) totalHours += diff;
                            if (!string.IsNullOrEmpty(s.DayOfWeek)) daysSet.Add(s.DayOfWeek);
                        }

                        // Assuming a standard 60-hour academic week (12 hours/day * 5 days)
                        double weeklyCapacity = 60.0;
                        double percentage = (totalHours / weeklyCapacity) * 100;

                        return new RoomUtilizationData
                        {
                            RoomID = r.RoomID,
                            RoomName = r.RoomName,
                            Campus = r.Campus ?? "N/A",
                            Capacity = r.Capacity ?? 0,
                            Type = !string.IsNullOrEmpty(r.RoomType) ? r.RoomType : "Unknown",
                            AssignmentsCount = roomScheds.Count,
                            TotalHoursAssigned = Math.Round(totalHours, 2),
                            UtilizationPercentage = percentage > 100 ? 100 : Math.Round(percentage, 2),
                            AssignedDays = daysSet.Count
                        };
                    }).OrderByDescending(x => x.UtilizationPercentage).ToList();

                    // 4. Bind and Format
                    dgvUtilization.DataSource = null;
                    dgvUtilization.DataSource = utilization;
                    FormatGridView();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading utilization data: " + ex.Message);
            }
        }

        private void FormatGridView()
        {
            if (dgvUtilization.Columns["RoomID"] != null)
                dgvUtilization.Columns["RoomID"].Visible = false;

            if (dgvUtilization.Columns["Campus"] != null)
                dgvUtilization.Columns["Campus"].DisplayIndex = 1;

            if (dgvUtilization.Columns["TotalHoursAssigned"] != null)
                dgvUtilization.Columns["TotalHoursAssigned"].HeaderText = "Weekly Hours";

            if (dgvUtilization.Columns["UtilizationPercentage"] != null)
            {
                dgvUtilization.Columns["UtilizationPercentage"].HeaderText = "Utilization %";
                dgvUtilization.Columns["UtilizationPercentage"].DefaultCellStyle.Format = "0.00'%'";
            }

            dgvUtilization.AutoResizeColumns();
        }

        // --- Event Handlers ---

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadRoomUtilizationData();
            MessageBox.Show("Report refreshed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnExportReport_Click(object sender, EventArgs e)
        {
            if (dgvUtilization.Rows.Count == 0) return;

            SaveFileDialog sfd = new SaveFileDialog { Filter = "CSV|*.csv", FileName = $"Utilization_{DateTime.Now:yyyyMMdd}" };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                ExportToCSV(sfd.FileName);
                MessageBox.Show("Export Complete!");
            }
        }

        private void ExportToCSV(string filePath)
        {
            using (var sw = new System.IO.StreamWriter(filePath))
            {
                var headers = dgvUtilization.Columns.Cast<DataGridViewColumn>().Select(c => $"\"{c.HeaderText}\"");
                sw.WriteLine(string.Join(",", headers));

                foreach (DataGridViewRow row in dgvUtilization.Rows)
                {
                    var cells = row.Cells.Cast<DataGridViewCell>().Select(c => $"\"{c.Value?.ToString().Replace("\"", "\"\"")}\"");
                    sw.WriteLine(string.Join(",", cells));
                }
            }
        }

        private void imgBackToMain2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new RoomAssignment().Show();
        }
    }
}