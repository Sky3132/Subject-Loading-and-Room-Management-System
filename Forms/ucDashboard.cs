using __Subject_Loading_and_Room_Assignment_Monitoring_System.Managers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace __Subject_Loading_and_Room_Assignment_Monitoring_System.Forms
{
    public partial class ucDashboard : UserControl
    {
        public ucDashboard()
        {
            InitializeComponent();
        }

        private void ucDashboard_Load(object sender, EventArgs e)
        {
            // Managers handle the logic of counting your data
            SubjectManager subMan = new SubjectManager();
            RoomManager roomMan = new RoomManager();
            //ScheduleManager schedMan = new ScheduleManager();

            // Update your UI labels with real counts
            lblTotalSubjects.Text = subMan.GetCount().ToString();
            lblTotalRooms.Text = roomMan.GetCount().ToString();
            //lblTotalSchedules.Text = schedMan.GetCount().ToString();
            
            // Clear old alerts
            flpNotifications.Controls.Clear();

            // 1. Example: Check for Room Conflicts
            // You will eventually call your ScheduleManager for this
            bool hasConflict = true; // Temporary placeholder logic
            if (hasConflict)
            {
                AddNotification("ALERT: Conflict detected in Room 301!", Color.Firebrick);
            }

            // 2. Example: General System Status
            AddNotification("System Status: All Subject Loadings are synced.", Color.SeaGreen);
        }
        // Inside ucDashboard.cs
        public void AddNotification(string message, Color backColor)
        {
            // Create a small panel to act as the 'card'
            Panel alertCard = new Panel();
            alertCard.Size = new Size(flpNotifications.Width - 25, 50);
            alertCard.BackColor = backColor;
            alertCard.Margin = new Padding(5);

            // Create a label to show the message
            Label lblMessage = new Label();
            lblMessage.Text = message;
            lblMessage.ForeColor = Color.White;
            lblMessage.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblMessage.Dock = DockStyle.Fill;
            lblMessage.TextAlign = ContentAlignment.MiddleCenter;

            // Add label to card, and card to the FlowLayoutPanel
            alertCard.Controls.Add(lblMessage);
            flpNotifications.Controls.Add(alertCard);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
