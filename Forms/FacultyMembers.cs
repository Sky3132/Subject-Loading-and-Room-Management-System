using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using __Subject_Loading_and_Room_Assignment_Monitoring_System.Models;
// Import the Managers namespace to use FacultyManager
using __Subject_Loading_and_Room_Assignment_Monitoring_System.Managers;

namespace __Subject_Loading_and_Room_Assignment_Monitoring_System.Forms
{
    public partial class FacultyMembers : Form
    {
        ConnectionString connect = new ConnectionString();
        // Initialize the FacultyManager to handle validation rules
        FacultyManager _facultyMgr = new FacultyManager();

        public FacultyMembers()
        {
            InitializeComponent();
        }

        private void FacultyMembers_Load(object sender, EventArgs e)
        {
            dgvFaculty.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFaculty.AutoGenerateColumns = true;

            LoadComboBoxes();
            LoadFaculty();
        }

        private void LoadFaculty()
        {
            try
            {
                using (DataClasses1DataContext db = new DataClasses1DataContext())
                {
                    var facultyList = from f in db.tblFaculties
                                      join d in db.tblDepartments on f.DepartmentID equals d.DepartmentID
                                      select new
                                      {
                                          ID = f.FacultyID,
                                          FirstName = f.FirstName,
                                          LastName = f.LastName,
                                          Department = d.DepartmentName,
                                          CurrentLoad = db.tblFacultyLoadings
                                              .Where(load => load.FacultyID == f.FacultyID)
                                              .Sum(load => (int?)(load.tblsubjectOffering.tblsubject.LectureUnits +
                                                                 load.tblsubjectOffering.tblsubject.LaboratoryUnits)) ?? 0,
                                          MaxLoad = f.MaxLoad ?? 18,
                                          DepartmentID = f.DepartmentID
                                      };

                    dgvFaculty.DataSource = facultyList.ToList();

                    if (dgvFaculty.Columns["DepartmentID"] != null)
                        dgvFaculty.Columns["DepartmentID"].Visible = false;
                }
            }
            catch (Exception ex) { MessageBox.Show("Error loading faculty: " + ex.Message); }
        }

        public void SearchFaculty(string searchTerm)
        {
            using (DataClasses1DataContext db = new DataClasses1DataContext())
            {
                var filtered = from f in db.tblFaculties
                               join d in db.tblDepartments on f.DepartmentID equals d.DepartmentID
                               where f.FirstName.Contains(searchTerm) || f.LastName.Contains(searchTerm)
                               select new
                               {
                                   ID = f.FacultyID,
                                   FirstName = f.FirstName,
                                   LastName = f.LastName,
                                   Department = d.DepartmentName,
                                   CurrentLoad = db.tblFacultyLoadings
                                        .Where(l => l.FacultyID == f.FacultyID)
                                        .Sum(l => (int?)(l.tblsubjectOffering.tblsubject.LectureUnits +
                                                        l.tblsubjectOffering.tblsubject.LaboratoryUnits)) ?? 0,
                                   MaxLoad = f.MaxLoad ?? 18,
                                   DepartmentID = f.DepartmentID
                               };

                dgvFaculty.DataSource = filtered.ToList();

                if (dgvFaculty.Columns["DepartmentID"] != null)
                    dgvFaculty.Columns["DepartmentID"].Visible = false;
            }
        }

        private void LoadComboBoxes()
        {
            using (var db = new DataClasses1DataContext())
            {
                cmbDepartment.DisplayMember = "DepartmentName";
                cmbDepartment.ValueMember = "DepartmentID";
                cmbDepartment.DataSource = db.tblDepartments.ToList();
                cmbDepartment.SelectedIndex = -1;
            }
        }

        private void btnFmembersAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Pack UI data into the Model
                FacultyMember newMember = new FacultyMember
                {
                    FirstName = txtFmemberFname.Text,
                    LastName = txtFmemberLname.Text,
                    DepartmentID = cmbDepartment.SelectedValue != null ? Convert.ToInt32(cmbDepartment.SelectedValue) : 0,
                    MaxLoad = string.IsNullOrEmpty(txtMaxLoad.Text) ? 18 : Convert.ToInt32(txtMaxLoad.Text)
                };

                // 2. USE THE MANAGER: Validate the data before saving
                // This will throw an exception if names are null or department is invalid
                _facultyMgr.Validate(newMember);

                // 3. Save to Database if validation passes
                using (DataClasses1DataContext db = new DataClasses1DataContext())
                {
                    tblFaculty dbEntry = new tblFaculty
                    {
                        FirstName = newMember.FirstName,
                        LastName = newMember.LastName,
                        DepartmentID = newMember.DepartmentID,
                        MaxLoad = newMember.MaxLoad
                    };

                    db.tblFaculties.InsertOnSubmit(dbEntry);
                    db.SubmitChanges();

                    MessageBox.Show("Faculty added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadFaculty();
                    ClearFields();
                }
            }
            catch (Exception ex)
            {
                // Any 'throw new Exception' from FacultyManager will be caught here
                MessageBox.Show(ex.Message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEditMember_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvFaculty.SelectedRows.Count == 0) return;

                int facultyID = Convert.ToInt32(dgvFaculty.SelectedRows[0].Cells["ID"].Value);

                // 1. Pack UI data for validation
                FacultyMember updatedData = new FacultyMember
                {
                    FirstName = txtFmemberFname.Text,
                    LastName = txtFmemberLname.Text,
                    DepartmentID = cmbDepartment.SelectedValue != null ? Convert.ToInt32(cmbDepartment.SelectedValue) : 0
                };

                // 2. USE THE MANAGER: Validate the updated data
                _facultyMgr.Validate(updatedData);

                using (DataClasses1DataContext db = new DataClasses1DataContext())
                {
                    var faculty = db.tblFaculties.FirstOrDefault(f => f.FacultyID == facultyID);
                    if (faculty != null)
                    {
                        faculty.FirstName = updatedData.FirstName;
                        faculty.LastName = updatedData.LastName;
                        faculty.DepartmentID = updatedData.DepartmentID;
                        faculty.MaxLoad = int.TryParse(txtMaxLoad.Text, out int mLoad) ? mLoad : 18;

                        db.SubmitChanges();
                        MessageBox.Show("Updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadFaculty();
                        ClearFields();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvFaculty_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvFaculty.Rows[e.RowIndex];
                txtFacultyId.Text = row.Cells["ID"].Value?.ToString();
                txtFmemberFname.Text = row.Cells["FirstName"].Value?.ToString();
                txtFmemberLname.Text = row.Cells["LastName"].Value?.ToString();
                txtMaxLoad.Text = row.Cells["MaxLoad"].Value?.ToString();

                if (row.Cells["DepartmentID"].Value != null)
                    cmbDepartment.SelectedValue = row.Cells["DepartmentID"].Value;
            }
        }

        private void btnRemoveMember_Click(object sender, EventArgs e)
        {
            if (dgvFaculty.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Delete this faculty?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int facultyID = Convert.ToInt32(dgvFaculty.SelectedRows[0].Cells["ID"].Value);
                    using (DataClasses1DataContext db = new DataClasses1DataContext())
                    {
                        var faculty = db.tblFaculties.FirstOrDefault(f => f.FacultyID == facultyID);
                        if (faculty != null)
                        {
                            db.tblFaculties.DeleteOnSubmit(faculty);
                            db.SubmitChanges();
                            LoadFaculty();
                            ClearFields();
                        }
                    }
                }
            }
        }

        private void ClearFields()
        {
            txtFacultyId.Clear();
            txtFmemberFname.Clear();
            txtFmemberLname.Clear();
            txtMaxLoad.Clear();
            cmbDepartment.SelectedIndex = -1;
        }

        private void imgBackToMain2_Click(object sender, EventArgs e)
        {
            FacultyLoading facultyLoading = new FacultyLoading();
            facultyLoading.Show();
            this.Hide();
        }

        private void btnSearchMember_Click(object sender, EventArgs e)
        {
            SearchFaculty(txtSearchMembers.Text.Trim());
        }
    }
}