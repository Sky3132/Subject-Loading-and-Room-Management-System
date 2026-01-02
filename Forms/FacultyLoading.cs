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
    public partial class FacultyLoading : Form
    {
        private int selectedLoadID = 0;

        public FacultyLoading()
        {
            InitializeComponent();
        }

        private void FacultyLoading_Load(object sender, EventArgs e)
        {
            dgvLoading.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            LoadDataGrid();
        }

        private void imgBackToMain2_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            main.Show();
            this.Hide();
        }

        public void LoadDataGrid()
        {
            using (DataClasses1DataContext db = new DataClasses1DataContext())
            {
                var data = from load in db.tblFacultyLoadings
                           select new
                           {
                               load.LoadID,
                               Faculty = load.tblFaculty.FirstName + " " + load.tblFaculty.LastName,
                               SubjectCode = load.tblsubjectOffering.tblsubject.Code,
                               SubjectTitle = load.tblsubjectOffering.tblsubject.Title,
                               Units = (load.tblsubjectOffering.tblsubject.LectureUnits) +
                                       (load.tblsubjectOffering.tblsubject.LaboratoryUnits),
                               Section = load.Section,
                               load.Status,
                               FacultyID = load.FacultyID,
                               OfferingID = load.offeringId
                           };

                dgvLoading.DataSource = data.ToList();

                if (dgvLoading.Columns["FacultyID"] != null) dgvLoading.Columns["FacultyID"].Visible = false;
                if (dgvLoading.Columns["OfferingID"] != null) dgvLoading.Columns["OfferingID"].Visible = false;
            }
        }

        public void SearchData(string searchTerm)
        {
            using (DataClasses1DataContext db = new DataClasses1DataContext())
            {
                var data = from load in db.tblFacultyLoadings
                               // We create a variable for the full name to make searching easier
                           let fullName = load.tblFaculty.FirstName + " " + load.tblFaculty.LastName
                           where fullName.Contains(searchTerm) ||
                                 load.tblsubjectOffering.tblsubject.Code.ToString().Contains(searchTerm) ||
                                 load.Section.Contains(searchTerm)
                           select new
                           {
                               load.LoadID,
                               Faculty = fullName,
                               SubjectCode = load.tblsubjectOffering.tblsubject.Code,
                               SubjectTitle = load.tblsubjectOffering.tblsubject.Title,
                               Units = (load.tblsubjectOffering.tblsubject.LectureUnits) +
                                       (load.tblsubjectOffering.tblsubject.LaboratoryUnits),
                               load.Section,
                               load.Status,
                               load.FacultyID,
                               OfferingID = load.offeringId
                           };

                dgvLoading.DataSource = data.ToList();
            }
        }

        // --- NEW: AUTO-LOOKUP FACULTY ---
        private void txtFacultyId_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(txtFacultyId.Text, out int fID))
            {
                using (DataClasses1DataContext db = new DataClasses1DataContext())
                {
                    var faculty = db.tblFaculties.FirstOrDefault(f => f.FacultyID == fID);
                    txtFacultyName.Text = faculty != null ? $"{faculty.FirstName} {faculty.LastName}" : "Not Found";
                }
            }
            else { txtFacultyName.Clear(); }
        }

        // --- NEW: AUTO-LOOKUP SUBJECT ---
        private void txtSubjectCode_TextChanged(object sender, EventArgs e)
        {
            using (DataClasses1DataContext db = new DataClasses1DataContext())
            {
                // We add .ToString() to the Code because the database column is an Integer
                var offering = db.tblsubjectOfferings.FirstOrDefault(o => o.tblsubject.Code.ToString() == txtSubjectId.Text);

                if (offering != null)
                {
                    txtSubjectName.Text = offering.tblsubject.Title;
                }
                else
                {
                    txtSubjectName.Text = "Invalid Code";
                }
            }
        }

        private void btnSaveLoad_Click(object sender, EventArgs e)
        {
            using (DataClasses1DataContext db = new DataClasses1DataContext())
            {
                if (!int.TryParse(txtFacultyId.Text, out int fID))
                {
                    MessageBox.Show("Please enter a valid numeric Faculty ID.");
                    return;
                }

                // --- NEW VALIDATION CHECK ---
                // Check if the Faculty ID actually exists in the Faculty table
                var facultyExists = db.tblFaculties.Any(f => f.FacultyID == fID);
                if (!facultyExists)
                {
                    MessageBox.Show("Invalid Faculty ID. This ID does not exist in the system.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var offering = db.tblsubjectOfferings.FirstOrDefault(o =>
                    o.tblsubject.Code.ToString().Trim() == txtSubjectId.Text.Trim());

                if (offering == null)
                {
                    MessageBox.Show("Subject Code not found.");
                    return;
                }

                tblFacultyLoading record;
                if (selectedLoadID == 0)
                {
                    record = new tblFacultyLoading();
                    db.tblFacultyLoadings.InsertOnSubmit(record);
                }
                else
                {
                    record = db.tblFacultyLoadings.First(l => l.LoadID == selectedLoadID);
                }

                record.FacultyID = fID;
                record.offeringId = offering.offeringId;
                record.Section = txtSection.Text;
                record.Status = "Approved";

                try
                {
                    db.SubmitChanges();
                    MessageBox.Show("Faculty Load saved successfully!");
                    ClearFields();
                    LoadDataGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while saving: " + ex.Message);
                }
            }
        }

        private void dgvLoading_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvLoading.Rows[e.RowIndex];
                selectedLoadID = Convert.ToInt32(row.Cells["LoadID"].Value);

                txtFacultyId.Text = row.Cells["FacultyID"].Value?.ToString();
                txtSubjectId.Text = row.Cells["SubjectCode"].Value?.ToString();
                txtSection.Text = row.Cells["Section"].Value?.ToString();

                btnSaveLoad.Text = "Update";
            }
        }

        private void btnRemoveLoad_Click(object sender, EventArgs e)
        {
            if (dgvLoading.CurrentRow == null) return;

            int idToDelete = (int)dgvLoading.CurrentRow.Cells["LoadID"].Value;

            if (MessageBox.Show("Remove this assignment?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (DataClasses1DataContext db = new DataClasses1DataContext())
                {
                    var record = db.tblFacultyLoadings.FirstOrDefault(l => l.LoadID == idToDelete);
                    if (record != null)
                    {
                        db.tblFacultyLoadings.DeleteOnSubmit(record);
                        db.SubmitChanges();
                    }
                }
                LoadDataGrid();
                ClearFields();
            }
        }

        private void ClearFields()
        {
            selectedLoadID = 0;
            txtFacultyId.Clear();
            txtSubjectId.Clear();
            txtFacultyName.Clear();
            txtSubjectName.Clear();
            txtSection.Clear();
            btnSaveLoad.Text = "Save";
        }

        private void btnCancelLoad_Click(object sender, EventArgs e) => ClearFields();

        private void lblFacultyMembers_Click(object sender, EventArgs e)
        {
            FacultyMembers facultyForm = new FacultyMembers();
            facultyForm.Show();
            this.Hide();
        }

        private void btnEditLoad_Click(object sender, EventArgs e)
        {
            if (dgvLoading.CurrentRow != null)
            {
                DataGridViewRow row = dgvLoading.CurrentRow;
                selectedLoadID = Convert.ToInt32(row.Cells["LoadID"].Value);

                txtFacultyId.Text = row.Cells["FacultyID"].Value?.ToString();
                // Use SubjectCode because that's what the user types into txtSubjectId
                txtSubjectId.Text = row.Cells["SubjectCode"].Value?.ToString();
                txtSection.Text = row.Cells["Section"].Value?.ToString();

                btnSaveLoad.Text = "Update";
            }
            else
            {
                MessageBox.Show("Please select a record from the list first.");
            }
        }

        private void btnSearchLoad_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearchLoad.Text.Trim();

            if (string.IsNullOrEmpty(searchTerm))
            {
                // If the search box is empty, just reload everything
                LoadDataGrid();
            }
            else
            {
                SearchData(searchTerm);
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}