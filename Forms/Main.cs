using __Subject_Loading_and_Room_Assignment_Monitoring_System.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace __Subject_Loading_and_Room_Assignment_Monitoring_System
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
        private void btnSubject_Click(object sender, EventArgs e)
        {
            Subject sub = new Subject();
            sub.Show();
            this.Hide();
        }
        private void btnFacultyLoading_Click(object sender, EventArgs e)
        {
            FacultyLoading facultyloading = new FacultyLoading();
            facultyloading.Show();
            this.Hide();
        }

        private void btnRooms_Click(object sender, EventArgs e)
        {
            Rooms roomassign = new Rooms();
            roomassign.Show();
            this.Hide();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            mainContentPanel.Controls.Clear();
            ucDashboard myDash = new ucDashboard();

            // This ensures the dashboard stretches WITH the panel
            myDash.Dock = DockStyle.Fill;

            mainContentPanel.Controls.Add(myDash);
            mainContentPanel.Visible = true;
            mainContentPanel.BringToFront();
        }

        private void imgHomeNoDashboard_Click(object sender, EventArgs e)
        {
            mainContentPanel.Visible = false;
        }

        private void btnSchedules_Click(object sender, EventArgs e)
        {
             Schedule sched = new Schedule();
            //sched.Tag = this; // This stores the Main form reference for the back button
            sched.Show();
            this.Hide();
        }
    }
}
