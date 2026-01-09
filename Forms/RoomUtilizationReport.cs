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
                    var rooms = db.tblRooms.ToList();
                    var assignments = db.tblRoomAssignments.ToList();

                    var utilization = rooms.Select(r => new RoomUtilizationData
                    {
                        RoomID = r.RoomID,
                        RoomName = r.RoomName,
                        Campus = r.Campus ?? "N/A", // Pulls Campus from database
                        Capacity = r.Capacity ?? 0,
                        Type = !string.IsNullOrEmpty(r.RoomType) ? r.RoomType : "Unknown",
                        AssignmentsCount = assignments.Count(a => a.RoomID == r.RoomID),
                        TotalHoursAssigned = CalculateTotalHours(r.RoomID, assignments),
                        UtilizationPercentage = CalculateUtilization(r.RoomID, assignments),
                        AssignedDays = GetAssignedDays(r.RoomID, assignments)
                    }).OrderByDescending(x => x.UtilizationPercentage).ToList();

                    // Bind data to grid
                    dgvUtilization.DataSource = null;
                    dgvUtilization.DataSource = utilization;

                    // 1. Hide the RoomID column
                    if (dgvUtilization.Columns["RoomID"] != null)
                    {
                        dgvUtilization.Columns["RoomID"].Visible = false;
                    }

                    // 2. Position Campus next to Room Name
                    if (dgvUtilization.Columns["Campus"] != null)
                    {
                        dgvUtilization.Columns["Campus"].DisplayIndex = 1;
                    }

                    // 3. Rename the column to clarify the "42 hours" calculation
                    if (dgvUtilization.Columns["TotalHoursAssigned"] != null)
                    {
                        dgvUtilization.Columns["TotalHoursAssigned"].HeaderText = "TotalHoursAssigned(Weekly)";
                    }

                    // 4. Format percentage column
                    if (dgvUtilization.Columns["UtilizationPercentage"] != null)
                    {
                        dgvUtilization.Columns["UtilizationPercentage"].DefaultCellStyle.Format = "0.00\"%\"";
                    }

                    dgvUtilization.AutoResizeColumns();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading utilization data: " + ex.Message);
            }
        }

        private double CalculateTotalHours(int roomId, List<tblRoomAssignment> assignments)
        {
            double totalHours = 0;
            var roomAssignments = assignments.Where(a => a.RoomID == roomId).ToList();

            foreach (var assignment in roomAssignments)
            {
                try
                {
                    if (string.IsNullOrEmpty(assignment.Day) ||
                        string.IsNullOrEmpty(assignment.StartTime) ||
                        string.IsNullOrEmpty(assignment.EndTime))
                        continue;

                    var days = assignment.Day.Split(',').Length;
                    var startTime = TimeSpan.Parse(ConvertTo24Hour(assignment.StartTime));
                    var endTime = TimeSpan.Parse(ConvertTo24Hour(assignment.EndTime));

                    double hours = endTime.TotalHours - startTime.TotalHours;

                    if (hours > 0)
                    {
                        totalHours += hours * days;
                    }
                }
                catch { }
            }
            return Math.Round(totalHours, 2);
        }

        private string ConvertTo24Hour(string time12Hour)
        {
            try
            {
                if (string.IsNullOrEmpty(time12Hour)) return "00:00";
                return DateTime.Parse(time12Hour.Trim()).ToString("HH:mm");
            }
            catch { return "00:00"; }
        }

        private double CalculateUtilization(int roomId, List<tblRoomAssignment> assignments)
        {
            try
            {
                int assignmentCount = assignments.Count(a => a.RoomID == roomId);
                int totalAssignments = assignments.Count;
                return totalAssignments == 0 ? 0.0 : (assignmentCount * 100.0) / totalAssignments;
            }
            catch { return 0.0; }
        }

        private int GetAssignedDays(int roomId, List<tblRoomAssignment> assignments)
        {
            try
            {
                var daysSet = new HashSet<string>();
                var roomAssignments = assignments.Where(a => a.RoomID == roomId).ToList();

                foreach (var assignment in roomAssignments)
                {
                    if (!string.IsNullOrEmpty(assignment.Day))
                    {
                        var days = assignment.Day.Split(',').Select(d => d.Trim());
                        foreach (var day in days)
                        {
                            if (!string.IsNullOrEmpty(day)) daysSet.Add(day);
                        }
                    }
                }
                return daysSet.Count;
            }
            catch { return 0; }
        }

        private void btnExportReport_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvUtilization.Rows.Count == 0)
                {
                    MessageBox.Show("No data to export.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "CSV files (*.csv)|*.csv",
                    DefaultExt = "csv",
                    FileName = $"RoomUtilizationReport_{DateTime.Now:yyyy-MM-dd}"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ExportToCSV(saveFileDialog.FileName);
                    MessageBox.Show("Report exported successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error exporting report: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportToCSV(string filePath)
        {
            try
            {
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(filePath, false, System.Text.Encoding.UTF8))
                {
                    var headers = new List<string>();
                    foreach (DataGridViewColumn column in dgvUtilization.Columns)
                    {
                        headers.Add(column.HeaderText);
                    }
                    sw.WriteLine(string.Join(",", headers.Select(h => $"\"{h}\"")));

                    foreach (DataGridViewRow row in dgvUtilization.Rows)
                    {
                        var cells = new List<string>();
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            string value = cell.Value?.ToString() ?? "";
                            value = $"\"{value.Replace("\"", "\"\"")}\"";
                            cells.Add(value);
                        }
                        sw.WriteLine(string.Join(",", cells));
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("CSV export failed: " + ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadRoomUtilizationData();
            MessageBox.Show("Report refreshed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void imgBackToMain2_Click(object sender, EventArgs e)
        {
            RoomAssignment assign = new RoomAssignment();
            assign.Show();
            this.Hide();
        }
    }
}