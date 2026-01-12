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

                               Section = load.tblProgram.tblDepartment.DepartmentName + " - " + load.tblProgram.ProgramName,

                               load.FacultyID,

                               OfferingID = load.offeringId,

                               load.ProgramID

                           };



                dgvLoading.DataSource = data.ToList();



                string[] hideCols = { "LoadID", "FacultyID", "OfferingID", "ProgramID" };

                foreach (var col in hideCols)

                    if (dgvLoading.Columns[col] != null) dgvLoading.Columns[col].Visible = false;

            }

        }



        // SAVE BUTTON: Only for NEW entries

        private void btnSaveLoad_Click(object sender, EventArgs e)

        {

            if (cmbFaculty.SelectedValue == null || cmbSubject.SelectedValue == null || cmbProgram.SelectedValue == null)

            {

                MessageBox.Show("Please complete all selections to save a new record.");

                return;

            }



            using (DataClasses1DataContext db = new DataClasses1DataContext())

            {

                int facultyId = (int)cmbFaculty.SelectedValue;

                int offeringId = (int)cmbSubject.SelectedValue;

                int programId = (int)cmbProgram.SelectedValue;



                // NEW: GLOBAL SUBJECT ASSIGNMENT CHECK

                // This ensures the subject isn't already assigned to ANY faculty member

                bool isAlreadyAssigned = db.tblFacultyLoadings.Any(l => l.offeringId == offeringId);

                if (isAlreadyAssigned)

                {

                    MessageBox.Show("This subject offering is already assigned to a faculty member. It cannot be assigned again.");

                    return;

                }



                // OVERLOAD CHECK

                var subjectUnits = db.tblsubjectOfferings

                    .Where(o => o.offeringId == offeringId)

                    .Select(o => (int)o.tblsubject.LectureUnits + (int)o.tblsubject.LaboratoryUnits)

                    .FirstOrDefault();



                if (_facultyMgr.IsOverloaded(facultyId, subjectUnits))

                {

                    MessageBox.Show("Cannot assign subject. This will exceed the faculty member's maximum unit load!");

                    return;

                }



                // SAVE RECORD

                tblFacultyLoading record = new tblFacultyLoading

                {

                    FacultyID = facultyId,

                    offeringId = offeringId,

                    ProgramID = programId,

                    Section = cmbProgram.Text

                };



                db.tblFacultyLoadings.InsertOnSubmit(record);

                db.SubmitChanges();



                MessageBox.Show("New record saved successfully!");

                ClearFields();

                LoadDataGrid();

            }

        }



        // EDIT BUTTON: Now handles the UPDATE logic

        private void btnEditLoad_Click(object sender, EventArgs e)

        {

            // 1. Check if a record is selected in the DataGrid

            if (selectedLoadID == 0)

            {

                MessageBox.Show("Please select a record from the list to update.");

                return;

            }



            // 2. FIXED: Check for nulls BEFORE assigning to variables to prevent NullReferenceException

            if (cmbFaculty.SelectedValue == null || cmbSubject.SelectedValue == null || cmbProgram.SelectedValue == null)

            {

                MessageBox.Show("Please complete all selections before updating.");

                return;

            }



            using (DataClasses1DataContext db = new DataClasses1DataContext())

            {

                // Safe to cast now because we verified they are not null

                int facultyId = (int)cmbFaculty.SelectedValue;

                int offeringId = (int)cmbSubject.SelectedValue;

                int programId = (int)cmbProgram.SelectedValue;



                // 3. GLOBAL CHECK: Is ANOTHER record using this subject?

                bool isTakenByOther = db.tblFacultyLoadings.Any(l =>

                    l.offeringId == offeringId &&

                    l.LoadID != selectedLoadID);



                if (isTakenByOther)

                {

                    MessageBox.Show("Cannot update. This subject is already assigned to another faculty member.");

                    return;

                }



                // 4. OVERLOAD CHECK

                var subjectUnits = db.tblsubjectOfferings

                    .Where(o => o.offeringId == offeringId)

                    .Select(o => (int)o.tblsubject.LectureUnits + (int)o.tblsubject.LaboratoryUnits)

                    .FirstOrDefault();



                if (_facultyMgr.IsOverloaded(facultyId, subjectUnits))

                {

                    MessageBox.Show("Update blocked: This assignment exceeds the faculty member's maximum units.");

                    return;

                }



                // 5. UPDATE RECORD

                var record = db.tblFacultyLoadings.FirstOrDefault(l => l.LoadID == selectedLoadID);

                if (record != null)

                {

                    record.FacultyID = facultyId;

                    record.offeringId = offeringId;

                    record.ProgramID = programId;

                    record.Section = cmbProgram.Text;



                    db.SubmitChanges();

                    MessageBox.Show("Record updated successfully!");

                    ClearFields();

                    LoadDataGrid();

                }

            }

        }



        private void dgvLoading_CellClick(object sender, DataGridViewCellEventArgs e)

        {

            if (e.RowIndex < 0) return;



            DataGridViewRow row = dgvLoading.Rows[e.RowIndex];

            selectedLoadID = Convert.ToInt32(row.Cells["LoadID"].Value);



            cmbFaculty.SelectedValue = row.Cells["FacultyID"].Value;

            cmbSubject.SelectedValue = row.Cells["OfferingID"].Value;



            if (row.Cells["ProgramID"].Value != null)

            {

                int progID = (int)row.Cells["ProgramID"].Value;

                using (DataClasses1DataContext db = new DataClasses1DataContext())

                {

                    var prog = db.tblPrograms.FirstOrDefault(p => p.ProgramID == progID);

                    if (prog != null)

                    {

                        cmbDepartment.SelectedValue = prog.DepartmentID;

                        cmbProgram.SelectedValue = prog.ProgramID;

                    }

                }

            }

            // Removed the line that changes Save button text to "Update"

        }



        public void SearchData(string searchTerm)

        {

            using (DataClasses1DataContext db = new DataClasses1DataContext())

            {

                var data = from load in db.tblFacultyLoadings

                           let fullName = load.tblFaculty.FirstName + " " + load.tblFaculty.LastName

                           let deptProg = load.tblProgram.tblDepartment.DepartmentName + " - " + load.tblProgram.ProgramName

                           let subCode = load.tblsubjectOffering.tblsubject.Code.ToString()



                           where fullName.Contains(searchTerm) ||

                                 subCode.Contains(searchTerm) ||

                                 deptProg.Contains(searchTerm)



                           select new

                           {

                               load.LoadID,

                               Faculty = fullName,

                               SubjectCode = subCode,

                               SubjectTitle = load.tblsubjectOffering.tblsubject.Title,

                               Units = (int)load.tblsubjectOffering.tblsubject.LectureUnits +

                                       (int)load.tblsubjectOffering.tblsubject.LaboratoryUnits,

                               Section = deptProg,

                               load.FacultyID,

                               OfferingID = load.offeringId,

                               load.ProgramID

                           };



                dgvLoading.DataSource = data.ToList();



                string[] ids = { "LoadID", "FacultyID", "OfferingID", "ProgramID" };

                foreach (var id in ids)

                    if (dgvLoading.Columns[id] != null) dgvLoading.Columns[id].Visible = false;

            }

        }



        private void ClearFields()

        {

            selectedLoadID = 0;

            cmbFaculty.SelectedIndex = -1;

            cmbSubject.SelectedIndex = -1;

            cmbDepartment.SelectedIndex = -1;

            cmbProgram.DataSource = null;

        }



        private void btnCancelLoad_Click(object sender, EventArgs e) => ClearFields();



        private void btnRemoveLoad_Click(object sender, EventArgs e)

        {

            if (selectedLoadID == 0) return;

            if (MessageBox.Show("Remove this load?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)

            {

                using (DataClasses1DataContext db = new DataClasses1DataContext())

                {

                    var record = db.tblFacultyLoadings.FirstOrDefault(l => l.LoadID == selectedLoadID);

                    if (record != null)

                    {

                        db.tblFacultyLoadings.DeleteOnSubmit(record);

                        db.SubmitChanges();

                        LoadDataGrid();

                        ClearFields();

                    }

                }

            }

        }



        private void btnSearchLoad_Click(object sender, EventArgs e)

        {

            if (string.IsNullOrEmpty(txtSearchLoad.Text.Trim())) LoadDataGrid();

            else SearchData(txtSearchLoad.Text.Trim());

        }



        private void imgBackToMain2_Click(object sender, EventArgs e) { new Main().Show(); Hide(); }

        private void lblFacultyMembers_Click(object sender, EventArgs e) { new FacultyMembers().Show(); Hide(); }



        private void lblDepartment_Click(object sender, EventArgs e)

        {

            // Keeps designer from crashing due to CS1061

        }

        private void lblFacultyMembers_Click_1(object sender, EventArgs e)
        {
            FacultyMembers members = new FacultyMembers();
            members.Show();
            this.Hide();
        }
    }

}