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
                if (string.IsNullOrWhiteSpace(txtTitle.Text) ||
                    string.IsNullOrWhiteSpace(txtCode.Text) ||
                    string.IsNullOrWhiteSpace(txtLectureUnits.Text) ||
                    string.IsNullOrWhiteSpace(txtLaboratoryUnits.Text))
                {
                    MessageBox.Show("Please fill up all the form",
                                    "Invalid Input",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return;
                }

                int code = Convert.ToInt32(txtCode.Text);
                string title = txtTitle.Text;
                string departmentName = cmbDepartment.Text;
                string programName = cmbProgram.Text;
                int lectureUnits = Convert.ToInt32(txtLectureUnits.Text);
                int laboratoryUnits = Convert.ToInt32(txtLaboratoryUnits.Text);

                DataClasses1DataContext db = new DataClasses1DataContext();

                db.InsertSubjects(code, title, programName, departmentName, lectureUnits, laboratoryUnits);
                db.SubmitChanges();

                MessageBox.Show("Subject added successfully!",
                                "Success",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                LoadSubjects();
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter valid numeric values.",
                                "Invalid Input",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }
            catch (SqlException ex)
            {
                if (ex.Number == 50001)
                {
                    MessageBox.Show(
                        ex.Message,
                        "Invalid Department",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                }
                else
                {
                    MessageBox.Show(ex.Message,
                                    "Database Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
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
                int subjectID = Convert.ToInt32(
                    dgvSubjects.SelectedRows[0].Cells["subjectId"].Value);

                DataClasses1DataContext db = new DataClasses1DataContext();

                db.UpdateSubject(
                    subjectID,
                    Convert.ToInt32(txtCode.Text),
                    txtTitle.Text,
                      cmbProgram.Text,
                   cmbDepartment.Text,
                         Convert.ToInt32(txtLectureUnits.Text),
                    Convert.ToInt32(txtLaboratoryUnits.Text)
               
                );

                MessageBox.Show("Updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadSubjects();
            }
            catch(SqlException ex)
            {
               MessageBox.Show(ex.Message, "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            }
        
        private void btnDeleteSubject_Click(object sender, EventArgs e)
        {
            if (dgvSubjects.SelectedRows.Count == 0)
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
            int subjectId = Convert.ToInt32(
                dgvSubjects.SelectedRows[0].Cells["subjectId"].Value
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
                    db.DeleteSubject(subjectId);
                    db.SubmitChanges();
                }

                MessageBox.Show(
                    "Subject deleted successfully.",
                    "Deleted",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                LoadSubjects(); // Refresh grid
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

        private void btnSearchSubject_Click(object sender, EventArgs e)
        {
            bool foundMatch = false;
            string searchValue = txtSearch.Text.Trim().ToLower();

            foreach (DataGridViewRow row in dgvSubjects.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.Style.BackColor = Color.White;
                }

                if (!string.IsNullOrEmpty(searchValue))
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.Value != null && cell.Value.ToString().ToLower().Contains(searchValue))
                        {
                            cell.Style.BackColor = Color.Yellow; 
                            foundMatch = true;
                        }
                    }
                }

            }
            if (!foundMatch)
            {
                MessageBox.Show("No match record found.", "Not found", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void txtSearch_KeyUp_1(object sender, KeyEventArgs e)
        {

            string searchValue = txtSearch.Text.Trim().ToLower();

            foreach (DataGridViewRow row in dgvSubjects.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.Style.BackColor = Color.White;
                }

                if (!string.IsNullOrEmpty(searchValue))
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.Value != null && cell.Value.ToString().ToLower().Contains(searchValue))
                        {
                            cell.Style.BackColor = Color.Yellow; 
                        }
                    }
                }

            }
        }

        private void lblSubjectOffering_Click(object sender, EventArgs e)
        {    
            SubjectOffering subject = new SubjectOffering();
            subject.Show();
            this.Hide();
        }

        private void cmbProgram_SelectedIndexChanged(object sender, EventArgs e)
        {

      
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