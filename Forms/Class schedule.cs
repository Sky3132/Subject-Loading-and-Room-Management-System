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
    public partial class Class_schedule : Form
    {
            string connStr = @"Server=DESKTOP-CL62R53; Database=Schooldb; Integrated Security=True;";
        public ClassSched()
        {
            InitializeComponent();
            // This makes the data appear without needing to click anything
            RefreshClassSchedGrid();
        }
        private void RefreshClassSchedGrid()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                // This is the FIX: You MUST have "INNER JOIN tblFacultyLoading L" 
                // before you can use "L.Section"
                string sql = @"SELECT sub.Title AS [Subject], 
                       (F.FirstName + ' ' + F.LastName) AS [Faculty], 
                       L.Section, R.RoomName AS [Room], S.DayOfWeek, 
                       S.StartTime, S.EndTime 
                       FROM tblSchedule S
                       INNER JOIN tblFacultyLoading L ON S.LoadID = L.LoadID 
                       INNER JOIN tblFaculty F ON L.FacultyID = F.FacultyID 
                       INNER JOIN tblRooms R ON S.RoomID = R.RoomID 
                       INNER JOIN tblsubjectOffering O ON L.offeringId = O.offeringId 
                       INNER JOIN tblsubject sub ON O.subjectId = sub.subjectId";

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Ensure the DataGrid on this second form is named dgvClassSched
                dgvClassSched.DataSource = dt;
            }
        }
        private void imgBackToMain2_Click(object sender, EventArgs e)
        {
            // Find the original Schedules form we stored in the Tag
            if (this.Tag is Form mainSched)
            {
                mainSched.Show(); // Bring the first form back
            }
            this.Close(); // Close this viewing form
        }
    }
    }
    
        
    
    
    
    
