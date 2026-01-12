using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using __Subject_Loading_and_Room_Assignment_Monitoring_System.Models;
using __Subject_Loading_and_Room_Assignment_Monitoring_System.Managers;

namespace __Subject_Loading_and_Room_Assignment_Monitoring_System.Forms
{
    public partial class FacultyMembers : Form
    {
        ConnectionString connect = new ConnectionString();
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
                                          f.FirstName,
                                          f.LastName,
                                          Department = d.DepartmentName,
                                          // Logic: Sum of units = Hours
                                          TotalUnits = db.tblFacultyLoadings
                                              .Where(load => load.FacultyID == f.FacultyID)
                                              .Sum(load => (int?)(load.tblsubjectOffering.tblsubject.LectureUnits +
                                                                 load.tblsubjectOffering.tblsubject.LaboratoryUnits)) ?? 0,
                                          MaxLoad = (int?)(f.MaxLoad) ?? 18,
                                          f.DepartmentID
                                      };

                    var facultyData = facultyList.ToList();

                    dgvFaculty.DataSource = facultyData.Select(f => new
                    {
                        f.ID,
                        f.FirstName,
                        f.LastName,
                        f.Department,
                        CurrentLoad = f.TotalUnits,
                        f.MaxLoad,
                        // Per your request: Hours equals the total units
                        Hours = f.TotalUnits,
                        RemainingUnits = f.MaxLoad - f.TotalUnits,
                        f.DepartmentID
                    }).ToList();

                    // Hide configuration columns
                    if (dgvFaculty.Columns["ID"] != null) dgvFaculty.Columns["ID"].Visible = false;
                    if (dgvFaculty.Columns["DepartmentID"] != null) dgvFaculty.Columns["DepartmentID"].Visible = false;
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
                                   // FIX: Added (int?) cast to prevent CS0019 error
                                   TotalUnits = db.tblFacultyLoadings
                                        .Where(l => l.FacultyID == f.FacultyID)
                                        .Sum(l => (int?)(l.tblsubjectOffering.tblsubject.LectureUnits +
                                                         l.tblsubjectOffering.tblsubject.LaboratoryUnits)) ?? 0,
                                   MaxLoad = f.MaxLoad,
                                   DepartmentID = f.DepartmentID
                               };

                var filteredData = filtered.ToList();

                // Transform to include Hours and Remaining Units
                var filteredFinal = filteredData.Select(f => new
                {
                    f.ID,
                    f.FirstName,
                    f.LastName,
                    f.Department,
                    CurrentLoad = f.TotalUnits,
                    // Total Units = Hours per your requirement
                    Hours = f.TotalUnits,
                    f.MaxLoad,
                    RemainingUnits = f.MaxLoad - f.TotalUnits,
                    f.DepartmentID
                }).ToList();

                dgvFaculty.DataSource = filteredFinal;

                // Hide configuration columns
                if (dgvFaculty.Columns["ID"] != null) dgvFaculty.Columns["ID"].Visible = false;
                if (dgvFaculty.Columns["MaxLoad"] != null) dgvFaculty.Columns["MaxLoad"].Visible = false;
                if (dgvFaculty.Columns["DepartmentID"] != null) dgvFaculty.Columns["DepartmentID"].Visible = false;
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
                string fName = txtFmemberFname.Text.Trim();
                string lName = txtFmemberLname.Text.Trim();

                using (DataClasses1DataContext db = new DataClasses1DataContext())
                {
                    // 1. DUPLICATE CHECK: Look for existing name
                    bool exists = db.tblFaculties.Any(f => f.FirstName.ToLower() == fName.ToLower()
                                                        && f.LastName.ToLower() == lName.ToLower());

                    if (exists)
                    {
                        MessageBox.Show("This faculty member already exists!", "Duplicate Detected",
                                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return; // Stop the method here
                    }

                    // 2. Prepare the data if no duplicate is found
                    FacultyMember newMember = new FacultyMember
                    {
                        FirstName = fName,
                        LastName = lName,
                        DepartmentID = cmbDepartment.SelectedValue != null ? Convert.ToInt32(cmbDepartment.SelectedValue) : 0,
                        MaxLoad = 18
                    };

                    _facultyMgr.Validate(newMember);

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
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEditMember_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvFaculty.SelectedRows.Count == 0)
                    throw new Exception("Please select a faculty member to edit.");

                int facultyID = Convert.ToInt32(dgvFaculty.SelectedRows[0].Cells["ID"].Value);

                FacultyMember updatedData = new FacultyMember
                {
                    FirstName = txtFmemberFname.Text,
                    LastName = txtFmemberLname.Text,
                    DepartmentID = cmbDepartment.SelectedValue != null ? Convert.ToInt32(cmbDepartment.SelectedValue) : 0
                };

                _facultyMgr.Validate(updatedData);

                using (DataClasses1DataContext db = new DataClasses1DataContext())
                {
                    var faculty = db.tblFaculties.FirstOrDefault(f => f.FacultyID == facultyID);
                    if (faculty != null)
                    {
                        faculty.FirstName = updatedData.FirstName;
                        faculty.LastName = updatedData.LastName;
                        faculty.DepartmentID = updatedData.DepartmentID;

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
                txtFmemberFname.Text = row.Cells["FirstName"].Value?.ToString();
                txtFmemberLname.Text = row.Cells["LastName"].Value?.ToString();

                if (row.Cells["DepartmentID"].Value != null)
                    cmbDepartment.SelectedValue = row.Cells["DepartmentID"].Value;
            }
        }

        private void btnRemoveMember_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvFaculty.SelectedRows.Count == 0)
                    throw new Exception("Please select a faculty member to delete.");

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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ClearFields()
        {
            txtFmemberFname.Clear();
            txtFmemberLname.Clear();
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