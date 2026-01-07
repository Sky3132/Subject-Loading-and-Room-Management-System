using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using __Subject_Loading_and_Room_Assignment_Monitoring_System.Managers;

namespace __Subject_Loading_and_Room_Assignment_Monitoring_System.Forms
{
    public partial class FacultyLoading : Form
    {
        private int selectedLoadID = 0;
        private FacultyManager _facultyMgr = new FacultyManager();

        public FacultyLoading()
        {
            InitializeComponent();
        }

        private void FacultyLoading_Load(object sender, EventArgs e)
        {
            dgvLoading.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            FillComboBoxes();
            LoadDataGrid();
        }

        private void FillComboBoxes()
        {
            using (DataClasses1DataContext db = new DataClasses1DataContext())
            {
                // 1. Populate Faculty
                cmbFaculty.DataSource = db.tblFaculties
                    .Select(f => new { f.FacultyID, Name = f.FirstName + " " + f.LastName }).ToList();
                cmbFaculty.DisplayMember = "Name";
                cmbFaculty.ValueMember = "FacultyID";
                cmbFaculty.SelectedIndex = -1;

                // 2. Populate Subject Offerings
                cmbSubject.DataSource = db.tblsubjectOfferings
                    .Select(o => new { o.offeringId, Title = o.tblsubject.Code + " - " + o.tblsubject.Title }).ToList();
                cmbSubject.DisplayMember = "Title";
                cmbSubject.ValueMember = "offeringId";
                cmbSubject.SelectedIndex = -1;

                // 3. Populate Department (The Parent)
                // This will trigger the SelectedIndexChanged event if an item is selected
                cmbDepartment.DataSource = db.tblDepartments.ToList();
                cmbDepartment.DisplayMember = "DepartmentName";
                cmbDepartment.ValueMember = "DepartmentID";
                cmbDepartment.SelectedIndex = -1;

                // 4. Ensure Program is empty at start
                cmbProgram.DataSource = null;
            }
        }

        // --- NEW EVENT FOR FILTERING PROGRAMS ---
        private void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            // We check if an ID is actually selected
            if (cmbDepartment.SelectedValue != null && cmbDepartment.SelectedValue is int deptId)
            {
                using (DataClasses1DataContext db = new DataClasses1DataContext())
                {
                    // Filter programs by the selected DepartmentID
                    var programList = db.tblPrograms
                        .Where(p => p.DepartmentID == deptId)
                        .ToList();

                    cmbProgram.DataSource = programList;
                    cmbProgram.DisplayMember = "ProgramName";
                    cmbProgram.ValueMember = "ProgramID";
                    cmbProgram.SelectedIndex = -1;
                }
            }
            else
            {
                cmbProgram.DataSource = null;
            }
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

                // Hide unnecessary columns
                if (dgvLoading.Columns["LoadID"] != null) dgvLoading.Columns["LoadID"].Visible = false;
                if (dgvLoading.Columns["FacultyID"] != null) dgvLoading.Columns["FacultyID"].Visible = false;
                if (dgvLoading.Columns["OfferingID"] != null) dgvLoading.Columns["OfferingID"].Visible = false;
            }
        }

        private void btnSaveLoad_Click(object sender, EventArgs e)
        {
            if (cmbFaculty.SelectedValue == null || cmbSubject.SelectedValue == null || cmbProgram.SelectedValue == null)
            {
                MessageBox.Show("Please complete all selections (Faculty, Subject, and Program).");
                return;
            }

            using (DataClasses1DataContext db = new DataClasses1DataContext())
            {
                int facultyID = (int)cmbFaculty.SelectedValue;
                int offeringID = (int)cmbSubject.SelectedValue;

                // Get the subject units for the subject being assigned
                var subjectOffering = db.tblsubjectOfferings
                    .Where(o => o.offeringId == offeringID)
                    .Select(o => o.tblsubject)
                    .FirstOrDefault();

                if (subjectOffering == null)
                {
                    MessageBox.Show("Selected subject not found.");
                    return;
                }

                int newSubjectUnits = subjectOffering.LectureUnits + subjectOffering.LaboratoryUnits;

                // Get faculty information
                var faculty = db.tblFaculties.FirstOrDefault(f => f.FacultyID == facultyID);
                if (faculty == null)
                {
                    MessageBox.Show("Selected faculty not found.");
                    return;
                }

                int maxLoad = faculty.MaxLoad ?? 18;

                // Calculate current load (excluding the record being edited, if applicable)
                int currentLoad = db.tblFacultyLoadings
                    .Where(l => l.FacultyID == facultyID && l.LoadID != selectedLoadID)
                    .Sum(l => (int?)(l.tblsubjectOffering.tblsubject.LectureUnits +
                                    l.tblsubjectOffering.tblsubject.LaboratoryUnits)) ?? 0;

                // Calculate what the total would be after this assignment
                int projectedLoad = currentLoad + newSubjectUnits;

                // Check if faculty would exceed maximum load
                if (projectedLoad > maxLoad)
                {
                    MessageBox.Show(
                        $"Cannot assign this subject. Faculty load will exceed maximum.\n\n" +
                        $"Faculty: {faculty.FirstName} {faculty.LastName}\n" +
                        $"Current Load (other subjects): {currentLoad} units\n" +
                        $"New Subject Units: {newSubjectUnits} units\n" +
                        $"Projected Total: {projectedLoad} units\n" +
                        $"Maximum Allowed: {maxLoad} units\n\n" +
                        $"Excess: {projectedLoad - maxLoad} units",
                        "Load Exceeds Maximum",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                // Validation passed - proceed with save
                tblFacultyLoading record;
                if (selectedLoadID == 0)
                {
                    // Adding new record
                    record = new tblFacultyLoading();
                    db.tblFacultyLoadings.InsertOnSubmit(record);
                }
                else
                {
                    // Editing existing record
                    record = db.tblFacultyLoadings.FirstOrDefault(l => l.LoadID == selectedLoadID);
                    if (record == null)
                    {
                        MessageBox.Show("Record not found.");
                        return;
                    }
                }

                record.FacultyID = facultyID;
                record.offeringId = offeringID;
                record.Section = cmbProgram.Text;
                record.Status = "Approved";

                try
                {
                    db.SubmitChanges();
                    MessageBox.Show("Saved successfully!");
                    ClearFields();
                    LoadDataGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving record: " + ex.Message);
                }
            }
        }

        private void btnEditLoad_Click(object sender, EventArgs e)
        {
            if (selectedLoadID == 0)
            {
                MessageBox.Show("Please select a record from the table first.");
                return;
            }

            // Just move focus to the first field. 
            // The CellClick already filled the data for you!
            cmbSubject.Focus();
        }

        private void dgvLoading_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvLoading.Rows[e.RowIndex];

                // 1. Store the ID of the record we are currently viewing/editing
                selectedLoadID = Convert.ToInt32(row.Cells["LoadID"].Value);

                // 2. Update Faculty ComboBox using the hidden FacultyID column
                if (row.Cells["FacultyID"].Value != null)
                {
                    cmbFaculty.SelectedValue = row.Cells["FacultyID"].Value;
                }

                // 3. Update Subject ComboBox using the hidden OfferingID column
                if (row.Cells["OfferingID"].Value != null)
                {
                    cmbSubject.SelectedValue = row.Cells["OfferingID"].Value;
                }

                // 4. Update Department and Program (The Cascading Part)
                using (DataClasses1DataContext db = new DataClasses1DataContext())
                {
                    // Get the Program Name (stored in the 'Section' column of your grid)
                    string programName = row.Cells["Section"].Value?.ToString();

                    // Find the Program in the database to get its Department link
                    var programRecord = db.tblPrograms.FirstOrDefault(p => p.ProgramName == programName);

                    if (programRecord != null)
                    {
                        // This triggers the cmbDepartment_SelectedIndexChanged event automatically
                        cmbDepartment.SelectedValue = programRecord.DepartmentID;

                        // Now we can select the specific Program ID
                        cmbProgram.SelectedValue = programRecord.ProgramID;
                    }
                }

                // 5. Change Save button text to "Update" to indicate we are in Edit Mode
                btnSaveLoad.Text = "Update";
            }
        }

        private void ClearFields()
        {
            selectedLoadID = 0;
            cmbFaculty.SelectedIndex = -1;
            cmbSubject.SelectedIndex = -1;
            cmbDepartment.SelectedIndex = -1; // Reset Dept
            cmbProgram.DataSource = null;     // Clear Program
            btnSaveLoad.Text = "Save";
        }

        public void SearchData(string searchTerm)
        {
            using (DataClasses1DataContext db = new DataClasses1DataContext())
            {
                var data = from load in db.tblFacultyLoadings
                               // Convert Code and Name to strings for searching
                           let firstName = load.tblFaculty.FirstName ?? ""
                           let lastName = load.tblFaculty.LastName ?? ""
                           let fullName = firstName + " " + lastName

                           // Use SqlFunctions or Convert to String for numeric columns
                           let subjectCode = load.tblsubjectOffering.tblsubject.Code.ToString()
                           let programName = load.Section ?? ""

                           where fullName.Contains(searchTerm) ||
                                 subjectCode.Contains(searchTerm) ||
                                 programName.Contains(searchTerm)

                           select new
                           {
                               load.LoadID,
                               Faculty = fullName,
                               SubjectCode = subjectCode,
                               SubjectTitle = load.tblsubjectOffering.tblsubject.Title,
                               Units = (load.tblsubjectOffering.tblsubject.LectureUnits) +
                                       (load.tblsubjectOffering.tblsubject.LaboratoryUnits),
                               Section = load.Section,
                               load.Status,
                               FacultyID = load.FacultyID,
                               OfferingID = load.offeringId
                           };

                dgvLoading.DataSource = data.ToList();

                // Hide unnecessary columns
                if (dgvLoading.Columns["LoadID"] != null) dgvLoading.Columns["LoadID"].Visible = false;
                if (dgvLoading.Columns["FacultyID"] != null) dgvLoading.Columns["FacultyID"].Visible = false;
                if (dgvLoading.Columns["OfferingID"] != null) dgvLoading.Columns["OfferingID"].Visible = false;
            }
        }

        private void btnCancelLoad_Click(object sender, EventArgs e) => ClearFields();

        private void imgBackToMain2_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            main.Show();
            this.Hide();
        }

        private void lblFacultyMembers_Click(object sender, EventArgs e)
        {
            FacultyMembers facultyForm = new FacultyMembers();
            facultyForm.Show();
            this.Hide();
        }

        private void btnRemoveLoad_Click(object sender, EventArgs e)
        {
            if (selectedLoadID == 0)
            {
                MessageBox.Show("Please select a record from the list to remove.");
                return;
            }

            // 2. Ask for confirmation to prevent accidental deletion
            DialogResult result = MessageBox.Show("Are you sure you want to remove this faculty load?",
                "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (DataClasses1DataContext db = new DataClasses1DataContext())
                    {
                        // 3. Find the record in tblFacultyLoadings
                        var recordToDelete = db.tblFacultyLoadings.SingleOrDefault(l => l.LoadID == selectedLoadID);

                        if (recordToDelete != null)
                        {
                            db.tblFacultyLoadings.DeleteOnSubmit(recordToDelete);
                            db.SubmitChanges();

                            MessageBox.Show("Faculty load removed successfully.");

                            // 4. Refresh the UI
                            ClearFields();
                            LoadDataGrid();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting record: " + ex.Message);
                }
            }
        }

        private void btnSearchLoad_Click(object sender, EventArgs e)
        {
            string term = txtSearchLoad.Text.Trim();

            if (string.IsNullOrEmpty(term))
            {
                LoadDataGrid();
            }
            else
            {
                SearchData(term);
            }
        }

        private void lblDepartment_Click(object sender, EventArgs e)
        {

        }
    }
}