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
                cmbFaculty.DataSource = db.tblFaculties
                    .Select(f => new { f.FacultyID, Name = f.FirstName + " " + f.LastName })
                    .ToList();
                cmbFaculty.DisplayMember = "Name";
                cmbFaculty.ValueMember = "FacultyID";
                cmbFaculty.SelectedIndex = -1;

                cmbSubject.DataSource = db.tblsubjectOfferings
                    .Select(o => new { o.offeringId, Title = o.tblsubject.Code + " - " + o.tblsubject.Title })
                    .ToList();
                cmbSubject.DisplayMember = "Title";
                cmbSubject.ValueMember = "offeringId";
                cmbSubject.SelectedIndex = -1;

                cmbDepartment.DataSource = db.tblDepartments.ToList();
                cmbDepartment.DisplayMember = "DepartmentName";
                cmbDepartment.ValueMember = "DepartmentID";
                cmbDepartment.SelectedIndex = -1;

                cmbProgram.DataSource = null;
            }
        }

        private void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDepartment.SelectedValue != null && cmbDepartment.SelectedValue is int deptId)
            {
                using (DataClasses1DataContext db = new DataClasses1DataContext())
                {
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
                               Units = (int)load.tblsubjectOffering.tblsubject.LectureUnits +
                                       (int)load.tblsubjectOffering.tblsubject.LaboratoryUnits,
                               Section = load.Section,
                               FacultyID = load.FacultyID,
                               OfferingID = load.offeringId
                           };

                dgvLoading.DataSource = data.ToList();

                if (dgvLoading.Columns["LoadID"] != null) dgvLoading.Columns["LoadID"].Visible = false;
                if (dgvLoading.Columns["FacultyID"] != null) dgvLoading.Columns["FacultyID"].Visible = false;
                if (dgvLoading.Columns["OfferingID"] != null) dgvLoading.Columns["OfferingID"].Visible = false;
            }
        }

        private void btnSaveLoad_Click(object sender, EventArgs e)
        {
            if (cmbFaculty.SelectedValue == null ||
                cmbSubject.SelectedValue == null ||
                cmbProgram.SelectedValue == null)
            {
                MessageBox.Show("Please complete all selections (Faculty, Subject, and Program).");
                return;
            }

            using (DataClasses1DataContext db = new DataClasses1DataContext())
            {
                int facultyID = (int)cmbFaculty.SelectedValue;
                int offeringID = (int)cmbSubject.SelectedValue;

                var subjectOffering = db.tblsubjectOfferings
                    .Where(o => o.offeringId == offeringID)
                    .Select(o => o.tblsubject)
                    .FirstOrDefault();

                if (subjectOffering == null)
                {
                    MessageBox.Show("Selected subject not found.");
                    return;
                }

                int newSubjectUnits = (int)subjectOffering.LectureUnits + (int)subjectOffering.LaboratoryUnits;

                var faculty = db.tblFaculties.FirstOrDefault(f => f.FacultyID == facultyID);
                if (faculty == null)
                {
                    MessageBox.Show("Selected faculty not found.");
                    return;
                }

                int maxLoad = faculty.MaxLoad ?? 18;

                int currentLoad = db.tblFacultyLoadings
                    .Where(l => l.FacultyID == facultyID && l.LoadID != selectedLoadID)
                    .Sum(l => (int?)(l.tblsubjectOffering.tblsubject.LectureUnits +
                                     l.tblsubjectOffering.tblsubject.LaboratoryUnits)) ?? 0;

                int projectedLoad = currentLoad + newSubjectUnits;

                if (projectedLoad > maxLoad)
                {
                    MessageBox.Show(
                        $"Cannot assign this subject. Faculty load will exceed maximum.\n\n" +
                        $"Faculty: {faculty.FirstName} {faculty.LastName}\n" +
                        $"Current Load: {currentLoad} units\n" +
                        $"New Subject Units: {newSubjectUnits} units\n" +
                        $"Projected Total: {projectedLoad} units\n" +
                        $"Maximum Allowed: {maxLoad} units\n\n" +
                        $"Excess: {projectedLoad - maxLoad} units",
                        "Load Exceeds Maximum",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
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

            cmbSubject.Focus();
        }

        private void dgvLoading_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvLoading.Rows[e.RowIndex];
            selectedLoadID = Convert.ToInt32(row.Cells["LoadID"].Value);

            if (row.Cells["FacultyID"].Value != null)
                cmbFaculty.SelectedValue = row.Cells["FacultyID"].Value;

            if (row.Cells["OfferingID"].Value != null)
                cmbSubject.SelectedValue = row.Cells["OfferingID"].Value;

            using (DataClasses1DataContext db = new DataClasses1DataContext())
            {
                string programName = row.Cells["Section"].Value?.ToString();
                var programRecord = db.tblPrograms.FirstOrDefault(p => p.ProgramName == programName);

                if (programRecord != null)
                {
                    cmbDepartment.SelectedValue = programRecord.DepartmentID;
                    cmbProgram.SelectedValue = programRecord.ProgramID;
                }
            }

            btnSaveLoad.Text = "Update";
        }

        private void ClearFields()
        {
            selectedLoadID = 0;
            cmbFaculty.SelectedIndex = -1;
            cmbSubject.SelectedIndex = -1;
            cmbDepartment.SelectedIndex = -1;
            cmbProgram.DataSource = null;
            btnSaveLoad.Text = "Save";
        }

        public void SearchData(string searchTerm)
        {
            using (DataClasses1DataContext db = new DataClasses1DataContext())
            {
                var data = from load in db.tblFacultyLoadings
                           let firstName = load.tblFaculty.FirstName ?? ""
                           let lastName = load.tblFaculty.LastName ?? ""
                           let fullName = firstName + " " + lastName
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
                               Units = (int)load.tblsubjectOffering.tblsubject.LectureUnits +
                                       (int)load.tblsubjectOffering.tblsubject.LaboratoryUnits,
                               Section = load.Section,
                               FacultyID = load.FacultyID,
                               OfferingID = load.offeringId
                           };

                dgvLoading.DataSource = data.ToList();

                if (dgvLoading.Columns["LoadID"] != null) dgvLoading.Columns["LoadID"].Visible = false;
                if (dgvLoading.Columns["FacultyID"] != null) dgvLoading.Columns["FacultyID"].Visible = false;
                if (dgvLoading.Columns["OfferingID"] != null) dgvLoading.Columns["OfferingID"].Visible = false;
            }
        }

        private void btnCancelLoad_Click(object sender, EventArgs e) => ClearFields();

        private void imgBackToMain2_Click(object sender, EventArgs e)
        {
            new Main().Show();
            Hide();
        }

        private void lblFacultyMembers_Click(object sender, EventArgs e)
        {
            new FacultyMembers().Show();
            Hide();
        }

        private void btnRemoveLoad_Click(object sender, EventArgs e)
        {
            if (selectedLoadID == 0)
            {
                MessageBox.Show("Please select a record from the list to remove.");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to remove this faculty load?",
                "Confirm Deletion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes) return;

            try
            {
                using (DataClasses1DataContext db = new DataClasses1DataContext())
                {
                    var recordToDelete = db.tblFacultyLoadings
                        .SingleOrDefault(l => l.LoadID == selectedLoadID);

                    if (recordToDelete != null)
                    {
                        db.tblFacultyLoadings.DeleteOnSubmit(recordToDelete);
                        db.SubmitChanges();
                        MessageBox.Show("Faculty load removed successfully.");
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

        private void btnSearchLoad_Click(object sender, EventArgs e)
        {
            string term = txtSearchLoad.Text.Trim();
            if (string.IsNullOrEmpty(term))
                LoadDataGrid();
            else
                SearchData(term);
        }

        private void lblDepartment_Click(object sender, EventArgs e)
        {
        }
    }
}