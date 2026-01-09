using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using __Subject_Loading_and_Room_Assignment_Monitoring_System.Core_Models;

namespace __Subject_Loading_and_Room_Assignment_Monitoring_System.Forms
{
    /// <summary>
    /// Generates and displays room utilization reports
    /// FEATURE: Room utilization reports
    /// </summary>
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
                        Capacity = r.Capacity.HasValue ? r.Capacity.Value : 0,
                        Type = !string.IsNullOrEmpty(r.RoomType) ? r.RoomType : "Unknown",
                        AssignmentsCount = assignments.Count(a => a.RoomID == r.RoomID),
                        TotalHoursAssigned = CalculateTotalHours(r.RoomID, assignments),
                        UtilizationPercentage = CalculateUtilization(r.RoomID, assignments),
                        AssignedDays = GetAssignedDays(r.RoomID, assignments)
                    }).OrderByDescending(x => x.UtilizationPercentage).ToList();

                    // Bind data to grid
                    dgvUtilization.DataSource = null; // Clear previous data
                    dgvUtilization.DataSource = utilization;

                    // Format columns
                    if (dgvUtilization.Columns["UtilizationPercentage"] != null)
                    {
                        dgvUtilization.Columns["UtilizationPercentage"].DefaultCellStyle.Format = "0.00\"%\"";
                    }

                    // Make grid read-only
                    dgvUtilization.ReadOnly = true;
                    dgvUtilization.AllowUserToAddRows = false;
                    dgvUtilization.AllowUserToDeleteRows = false;

                    // Auto-fit columns
                    dgvUtilization.AutoResizeColumns();

                    // Calculate summary statistics
                    DisplaySummaryStatistics(utilization);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading utilization data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    // Validate assignment data
                    if (string.IsNullOrEmpty(assignment.Day) || 
                        string.IsNullOrEmpty(assignment.StartTime) || 
                        string.IsNullOrEmpty(assignment.EndTime))
                        continue;

                    var days = assignment.Day.Split(',').Length;
                    var startTime = TimeSpan.Parse(ConvertTo24Hour(assignment.StartTime));
                    var endTime = TimeSpan.Parse(ConvertTo24Hour(assignment.EndTime));
                    
                    double hours = endTime.TotalHours - startTime.TotalHours;
                    
                    // Only count positive hours
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
                if (string.IsNullOrEmpty(time12Hour))
                    return "00:00";

                time12Hour = time12Hour.Trim();
                return DateTime.Parse(time12Hour).ToString("HH:mm");
            }
            catch
            {
                return "00:00";
            }
        }

        private double CalculateUtilization(int roomId, List<tblRoomAssignment> assignments)
        {
            try
            {
                int assignmentCount = assignments.Count(a => a.RoomID == roomId);
                int totalAssignments = assignments.Count;

                if (totalAssignments == 0)
                    return 0.0;

                return (assignmentCount * 100.0) / totalAssignments;
            }
            catch
            {
                return 0.0;
            }
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
                        // Split days and add to set
                        var days = assignment.Day.Split(',').Select(d => d.Trim());
                        foreach (var day in days)
                        {
                            if (!string.IsNullOrEmpty(day))
                            {
                                daysSet.Add(day);
                            }
                        }
                    }
                }

                return daysSet.Count;
            }
            catch
            {
                return 0;
            }
        }

        private void DisplaySummaryStatistics(List<RoomUtilizationData> utilization)
        {
            try
            {
                if (utilization == null || utilization.Count == 0)
                {
                    txtSummary.Text = "No data available.";
                    return;
                }

                // Calculate statistics
                double avgUtilization = utilization.Average(x => x.UtilizationPercentage);
                double maxUtilization = utilization.Max(x => x.UtilizationPercentage);
                double minUtilization = utilization.Min(x => x.UtilizationPercentage);
                long totalAssignments = utilization.Sum(x => (long)x.AssignmentsCount);
                double totalHours = utilization.Sum(x => x.TotalHoursAssigned);

                string summary = string.Format(
                    "SUMMARY STATISTICS\n\n" +
                    "?????????????????????????????\n" +
                    "Total Rooms: {0}\n" +
                    "Total Assignments: {1}\n" +
                    "Total Hours Assigned: {2:F2}\n\n" +
                    "Average Utilization: {3:F2}%\n" +
                    "Maximum Utilization: {4:F2}%\n" +
                    "Minimum Utilization: {5:F2}%\n" +
                    "?????????????????????????????",
                    utilization.Count,
                    totalAssignments,
                    totalHours,
                    avgUtilization,
                    maxUtilization,
                    minUtilization);

                txtSummary.Text = summary;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error calculating summary: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                    Filter = "CSV files (*.csv)|*.csv|Excel files (*.xlsx)|*.xlsx",
                    DefaultExt = "csv",
                    FileName = $"RoomUtilizationReport_{DateTime.Now:yyyy-MM-dd}"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ExportToCSV(saveFileDialog.FileName);
                    MessageBox.Show("Report exported successfully to:\n" + saveFileDialog.FileName, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    // Write header
                    var headers = new List<string>();
                    foreach (DataGridViewColumn column in dgvUtilization.Columns)
                    {
                        headers.Add(column.HeaderText);
                    }
                    sw.WriteLine(string.Join(",", headers.Select(h => $"\"{h}\"")));

                    // Write rows
                    foreach (DataGridViewRow row in dgvUtilization.Rows)
                    {
                        var cells = new List<string>();
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            string value = cell.Value?.ToString() ?? "";
                            // Escape quotes and wrap in quotes
                            value = $"\"{value.Replace("\"", "\"\"")}\"";
                            cells.Add(value);
                        }
                        sw.WriteLine(string.Join(",", cells));
                    }

                    // Write summary
                    sw.WriteLine("");
                    sw.WriteLine("SUMMARY");
                    sw.WriteLine(txtSummary.Text.Replace("\n", " | "));
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