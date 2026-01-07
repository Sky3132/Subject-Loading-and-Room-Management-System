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
                        Type = r.RoomType,
                        AssignmentsCount = assignments.Count(a => a.RoomID == r.RoomID),
                        TotalHoursAssigned = CalculateTotalHours(r.RoomID, assignments),
                        UtilizationPercentage = CalculateUtilization(r.RoomID, assignments),
                        AssignedDays = GetAssignedDays(r.RoomID, assignments)
                    }).OrderByDescending(x => x.UtilizationPercentage).ToList();

                    dgvUtilization.DataSource = utilization;

                    // Format columns
                    if (dgvUtilization.Columns["UtilizationPercentage"] != null)
                    {
                        dgvUtilization.Columns["UtilizationPercentage"].DefaultCellStyle.Format = "0.00\"%\"";
                    }

                    // Calculate summary statistics
                    DisplaySummaryStatistics(utilization);
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
                    if (string.IsNullOrEmpty(assignment.Day))
                        continue;

                    var days = assignment.Day.Split(',').Length;
                    var startTime = TimeSpan.Parse(ConvertTo24Hour(assignment.StartTime));
                    var endTime = TimeSpan.Parse(ConvertTo24Hour(assignment.EndTime));
                    var hours = endTime.TotalHours - startTime.TotalHours;
                    totalHours += hours * days;
                }
                catch { }
            }

            return totalHours;
        }

        private string ConvertTo24Hour(string time12Hour)
        {
            try
            {
                if (string.IsNullOrEmpty(time12Hour))
                    return "00:00";

                return System.DateTime.Parse(time12Hour).ToString("HH:mm");
            }
            catch
            {
                return time12Hour ?? "00:00";
            }
        }

        private double CalculateUtilization(int roomId, List<tblRoomAssignment> assignments)
        {
            int assignmentCount = assignments.Count(a => a.RoomID == roomId);
            int maxCapacity = assignments.Count > 0 ? assignments.Count : 1;

            return (assignmentCount * 100.0) / maxCapacity;
        }

        private int GetAssignedDays(int roomId, List<tblRoomAssignment> assignments)
        {
            var daysSet = new HashSet<string>();
            foreach (var assignment in assignments.Where(a => a.RoomID == roomId))
            {
                if (!string.IsNullOrEmpty(assignment.Day))
                {
                    var days = assignment.Day.Split(',').Select(d => d.Trim());
                    foreach (var day in days)
                    {
                        daysSet.Add(day);
                    }
                }
            }
            return daysSet.Count;
        }

        private void DisplaySummaryStatistics(List<RoomUtilizationData> utilization)
        {
            try
            {
                if (utilization.Count == 0)
                {
                    txtSummary.Text = "No data available.";
                    return;
                }

                double avgUtilization = utilization.Average(x => x.UtilizationPercentage);
                double maxUtilization = utilization.Max(x => x.UtilizationPercentage);
                double minUtilization = utilization.Min(x => x.UtilizationPercentage);
                long totalAssignments = utilization.Aggregate(0L, (acc, x) => acc + x.AssignmentsCount);

                string summary = string.Format("Summary Statistics:\n\n" +
                    "Average Utilization: {0:F2}%\n" +
                    "Maximum Utilization: {1:F2}%\n" +
                    "Minimum Utilization: {2:F2}%\n" +
                    "Total Assignments: {3}\n" +
                    "Total Rooms: {4}",
                    avgUtilization, maxUtilization, minUtilization, totalAssignments, utilization.Count);

                txtSummary.Text = summary;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error calculating summary: " + ex.Message);
            }
        }

        private void btnExportReport_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "CSV files (*.csv)|*.csv",
                    DefaultExt = "csv"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ExportToCSV(saveFileDialog.FileName);
                    MessageBox.Show("Report exported successfully!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error exporting report: " + ex.Message);
            }
        }

        private void ExportToCSV(string filePath)
        {
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(filePath))
            {
                // Write header
                foreach (DataGridViewColumn column in dgvUtilization.Columns)
                {
                    sw.Write(column.HeaderText + ",");
                }
                sw.WriteLine();

                // Write rows
                foreach (DataGridViewRow row in dgvUtilization.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        sw.Write("\"" + (cell.Value ?? "").ToString().Replace("\"", "\"\"") + "\",");
                    }
                    sw.WriteLine();
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadRoomUtilizationData();
            MessageBox.Show("Report refreshed!");
        }

        private void imgBackToMain2_Click(object sender, EventArgs e)
        {
            RoomAssignment assign = new RoomAssignment();
            assign.Show();
            this.Hide();
        }
    }
}