using __Subject_Loading_and_Room_Assignment_Monitoring_System.Managers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.CompilerServices.RuntimeHelpers;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace __Subject_Loading_and_Room_Assignment_Monitoring_System.Forms
{
    public partial class SubjectOffering : Form
    {
        public int currentOfferingId = 0;
        public SubjectOffering()
        {
            InitializeComponent();
            dgvSubjectOffering.AllowUserToAddRows = false;
        }

        ConnectionString connect = new ConnectionString();

        private void SubjectOffering_Load(object sender, EventArgs e)
        {
            SubjectOfferingLoad();

            dgvSubjectOffering.Columns["subjectId"].Visible = false;
            dgvSubjectOffering.Columns["offeringId"].Visible = false;
        }

        void SubjectOfferingLoad()
        {




            using (SqlConnection con = new SqlConnection(connect.connection))
            {

                SqlCommand cmd = new SqlCommand("GetSubjectOffering", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvSubjectOffering.DataSource = dt;



                LoadSubjectsCombo();
            }
        }

        private void LoadSubjectsCombo()
        {
            using (var db = new DataClasses1DataContext())
            {   
                var data = db.GetCodeandTitle().ToList();

                cmbCode.DataSource = data;
                cmbCode.DisplayMember = "DisplayText"; 
                cmbCode.ValueMember = "subjectId";  
            }
        }
        private void btnAddOffering_Click(object sender, EventArgs e)
        {
            int subjectId = (int)cmbCode.SelectedValue;
            string schoolyear = cmbSchoolYear.Text;
            string semester = cmbSemester.Text;

            DataClasses1DataContext db = new DataClasses1DataContext();
            db.InsertSubjectOffering(
                     semester,
                schoolyear,
                subjectId
                );
            MessageBox.Show("Successfully added SubjectOfferings", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information );
            db.SubmitChanges();
            SubjectOfferingLoad();
            cmbSemester.SelectedIndex = -1;
            cmbSchoolYear.SelectedIndex = -1;
            cmbCode.SelectedIndex = -1;
        }





        private void dgvSubjectOffering_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; 

            DataGridViewRow row = dgvSubjectOffering.Rows[e.RowIndex];

  
            cmbSemester.Text = row.Cells["Semester"].Value.ToString();

            cmbSchoolYear.Text = row.Cells["SchoolYear"].Value.ToString();

            cmbCode.SelectedValue =
                Convert.ToInt32(row.Cells["subjectId"].Value);
        }

        private void btnEditOffering_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvSubjectOffering.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a record to update.");
                    return;
                }
          

                int offeringId = Convert.ToInt32(
                dgvSubjectOffering.SelectedRows[0].Cells["offeringId"].Value);

                int subjectId = (int)cmbCode.SelectedValue;


                DataClasses1DataContext db = new DataClasses1DataContext();

                db.UpdateSubjectOffering(
                    offeringId,
                      subjectId,
                   cmbSemester.Text,
                   cmbSchoolYear.Text    
                );

                MessageBox.Show("Updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SubjectOfferingLoad();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


        }

        private void btnDeleteOffering_Click(object sender, EventArgs e)
        {
            if (dgvSubjectOffering.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Please select a row to delete.",
                    "No Selection",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            // Get SubjectID from selected row
            int offeringId = Convert.ToInt32(
                dgvSubjectOffering.SelectedRows[0].Cells["offeringId"].Value
            );

            // Confirmation
            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this subject?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result != DialogResult.Yes)
                return;

            try
            {
                using (DataClasses1DataContext db = new DataClasses1DataContext())
                {
                    db.DeleteSubjectOffering(offeringId);
                    db.SubmitChanges();
                }

                MessageBox.Show(
                    "Subject deleted successfully.",
                    "Deleted",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                SubjectOfferingLoad(); // Refresh grid
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void imgBackToSub_Click(object sender, EventArgs e)
        {
            Subject subject = new Subject();
            subject.Show();
            this.Hide();
        }
    }
}

