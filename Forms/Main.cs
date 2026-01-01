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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void btnDepartments_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSchedules_Click(object sender, EventArgs e)
        {

        }
    }
}
