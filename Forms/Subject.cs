using __Subject_Loading_and_Room_Assignment_Monitoring_System.Core_Models;
using __Subject_Loading_and_Room_Assignment_Monitoring_System.Forms;
using __Subject_Loading_and_Room_Assignment_Monitoring_System.Managers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq.Mapping;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace __Subject_Loading_and_Room_Assignment_Monitoring_System
{
    public partial class Subject : Form
    {
        public Subject()
        {
            InitializeComponent();
        }


        ConnectionString connect = new ConnectionString();
        private SubjectManager _subjectManager = new SubjectManager();

        private void LoadSubjects()
        {
            using (SqlConnection con = new SqlConnection(connect.connection))
            {
                SqlCommand cmd = new SqlCommand("GetSubjectsWithDepartment", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvSubjects.DataSource = dt;

                dgvSubjects.Columns["subjectId"].Visible = false;
                dgvSubjects.Columns["ProgramID"].Visible = false;
                dgvSubjects.Columns["DepartmentID"].Visible = false;


                using (var db = new DataClasses1DataContext())
                {
                    cmbDepartment.DisplayMember = "DepartmentName";
                    cmbDepartment.ValueMember = "DepartmentID";
                    cmbDepartment.DataSource = db.GetDepartments();

                    cmbDepartment.SelectedIndex = -1; // nothing selected yet
                    cmbProgram.DataSource = null;     // program empty initially
                }
            }
        }
        private void Subject_Load_1(object sender, EventArgs e)
        {
            LoadComboBoxes();
            LoadSubjects();

            dgvSubjects.Columns["subjectId"].Visible = false;
        }

        private void dgvSubjects_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSubjects.Rows[e.RowIndex];
                txtCode.Text = row.Cells["Code"].Value.ToString();
                txtTitle.Text = row.Cells["Title"].Value.ToString();
                cmbProgram.Text = dgvSubjects.CurrentRow.Cells["ProgramName"].Value.ToString();
                cmbDepartment.Text = dgvSubjects.CurrentRow.Cells["DepartmentName"].Value.ToString();
                txtLaboratoryUnits.Text = row.Cells["LaboratoryUnits"].Value.ToString();
                txtLectureUnits.Text = row.Cells["LectureUnits"].Value.ToString();
            }
        }
        private void LoadComboBoxes()
        {
            using (SqlConnection con = new SqlConnection(connect.connection))
            {
                SqlCommand cmd = new SqlCommand("GetSubjectsWithDepartment", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                DataTable deptTable = dt.DefaultView.ToTable(
                    true,
                    "DepartmentID",
                    "DepartmentName"
                );

                cmbDepartment.DataSource = deptTable;
                cmbDepartment.DisplayMember = "DepartmentName";
                cmbDepartment.ValueMember = "DepartmentID";
                cmbDepartment.SelectedIndex = -1;

                DataTable progTable = dt.DefaultView.ToTable(
                    true,
                    "ProgramID",
                    "ProgramName"
                );

                cmbProgram.DataSource = progTable;
                cmbProgram.DisplayMember = "ProgramName";
                cmbProgram.ValueMember = "ProgramID";
                cmbProgram.SelectedIndex = -1;
            }
        }
        private void btnAddSubject_Click(object sender, EventArgs e)
        {
           try
            {
                // 1. Pack the UI data into your SubjectModel
                SubjectModel sub = new SubjectModel
                {
                    Code = Convert.ToInt32(txtCode.Text),
                    Title = txtTitle.Text,
                    DepartmentName = cmbDepartment.Text,
                    ProgramName = cmbProgram.Text,
                    LectureUnits = Convert.ToInt32(txtLectureUnits.Text),
                    LaboratoryUnits = Convert.ToInt32(txtLaboratoryUnits.Text)
                };

                // 2. Pass the model to your Manager for validation
                _subjectManager.Validate(sub);

                // 3. Pass the model properties to your DataContext
                using (DataClasses1DataContext db = new DataClasses1DataContext())
                {
                    db.InsertSubjects(
                        sub.Code,
                        sub.Title,
                        sub.ProgramName,
                        sub.DepartmentName,
                        sub.LectureUnits,
                        sub.LaboratoryUnits
                    );
                    db.SubmitChanges();
                }

                MessageBox.Show("Subject added successfully!");
                LoadSubjects();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnEditSubject_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (dgvSubjects.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a record to update.");
                    return;
                }

                // 1. Pack UI data into your SubjectModel
                var sub = new SubjectModel
                {
                    SubjectID = Convert.ToInt32(dgvSubjects.SelectedRows[0].Cells["subjectId"].Value),
                    Code = Convert.ToInt32(txtCode.Text),
                    Title = txtTitle.Text,
                    ProgramName = cmbProgram.Text,
                    DepartmentName = cmbDepartment.Text,
                    LectureUnits = Convert.ToInt32(txtLectureUnits.Text),
                    LaboratoryUnits = Convert.ToInt32(txtLaboratoryUnits.Text)
                };

                // 2. IMPORTANT: Use the Manager to validate the edited data
                // This ensures the same rules apply for both Add and Edit
                _subjectManager.Validate(sub);

                // 3. Save via DataContext
                using (DataClasses1DataContext db = new DataClasses1DataContext())
                {
                    db.UpdateSubject(
                        sub.SubjectID,
                        sub.Code,
                        sub.Title,
                        sub.ProgramName,
                        sub.DepartmentName,
                        sub.LectureUnits,
                        sub.LaboratoryUnits
                    );
                    db.SubmitChanges();
                }

                MessageBox.Show("Updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadSubjects();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Catches validation errors from the SubjectManager
                MessageBox.Show(ex.Message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDeleteSubject_Click(object sender, EventArgs e)
        {
            if (dgvSubjects.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 1. Get ID from selected row
            int subjectId = Convert.ToInt32(dgvSubjects.SelectedRows[0].Cells["subjectId"].Value);

            // 2. Confirmation
            DialogResult result = MessageBox.Show("Are you sure you want to delete this subject?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result != DialogResult.Yes) return;

            try
            {
                // 3. Ask Manager if it's safe to delete (Feature 2: Subject Management)
                // This is where you'd check if the subject is linked to a schedule
                _subjectManager.ValidateDelete(subjectId);

                using (DataClasses1DataContext db = new DataClasses1DataContext())
                {
                    db.DeleteSubject(subjectId);
                    db.SubmitChanges();
                }

                MessageBox.Show("Subject deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadSubjects(); // Refresh grid
            }
            catch (Exception ex)
            {
                // Catch validation errors from Manager OR SQL Errors
                MessageBox.Show(ex.Message, "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearchSubject_Click(object sender, EventArgs e)
        {
            string searchValue = txtSearch.Text.Trim().ToLower();

            foreach (DataGridViewRow row in dgvSubjects.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                    cell.Style.BackColor = Color.White;
            }

            if (string.IsNullOrEmpty(searchValue)) return;

            // 2. Ask the Manager if the search term is valid (Feature 2 logic)
            // The Manager handles the "logic" of the search
            bool foundMatch = _subjectManager.PerformVisualSearch(dgvSubjects, searchValue);

            if (!foundMatch)
            {
                MessageBox.Show("No match record found.", "Not found", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void lblSubjectOffering_Click(object sender, EventArgs e)
        {    
            SubjectOffering subject = new SubjectOffering();
            subject.Show();
            this.Hide();
        }

        private void cmbDepartment_SelectionChangeCommitted_1(object sender, EventArgs e)
        {
            if (!(cmbDepartment.SelectedValue is int departmentId))
                return;

            using (var db = new DataClasses1DataContext())
            {
                cmbProgram.DisplayMember = "ProgramName";
                cmbProgram.ValueMember = "ProgramID";
                cmbProgram.DataSource = db.GetProgramsByDepartment(departmentId);

                cmbProgram.SelectedIndex = -1;
            }
        }

        private void imgBackToMain_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            main.Show();
            this.Hide();
        }
    }   
}