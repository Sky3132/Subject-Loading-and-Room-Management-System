using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using __Subject_Loading_and_Room_Assignment_Monitoring_System.Models;

namespace __Subject_Loading_and_Room_Assignment_Monitoring_System.Forms
{
    public partial class FacultyMembers : Form
    {
        // Initialize connection string class
        ConnectionString connect = new ConnectionString();

        public FacultyMembers()
        {
            InitializeComponent();
        }

        private void FacultyMembers_Load(object sender, EventArgs e)
        {
            // Set selection mode to full row for easier editing
            dgvFaculty.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            LoadComboBoxes();
            LoadFaculty();
        }

        private void LoadFaculty()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connect.connection))
                {
                    string query = "SELECT f.FacultyID, f.FirstName, f.LastName, d.DepartmentName, f.MaxLoad, f.DepartmentID " +
                                   "FROM tblFaculty f LEFT JOIN tblDepartment d ON f.DepartmentID = d.DepartmentID";

                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvFaculty.DataSource = dt;

                    // --- COLUMN VISIBILITY SETTINGS ---
                    if (dgvFaculty.Columns["FacultyID"] != null)
                    {
                        dgvFaculty.Columns["FacultyID"].Visible = true; // NOW VISIBLE
                        dgvFaculty.Columns["FacultyID"].HeaderText = "Faculty ID";
                        dgvFaculty.Columns["FacultyID"].DisplayIndex = 0; // Moves to first column
                    }

                    if (dgvFaculty.Columns["DepartmentID"] != null)
                        dgvFaculty.Columns["DepartmentID"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading faculty: " + ex.Message);
            }
        }

        public void SearchFaculty(string searchTerm)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connect.connection))
                {
                    // We reuse the same query as LoadFaculty
                    string query = "SELECT f.FacultyID, f.FirstName, f.LastName, d.DepartmentName, f.MaxLoad, f.DepartmentID " +
                                   "FROM tblFaculty f LEFT JOIN tblDepartment d ON f.DepartmentID = d.DepartmentID";

                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Apply the filter to the DataTable
                    // This searches ID, First Name, Last Name, and Department Name
                    DataView dv = dt.DefaultView;
                    dv.RowFilter = string.Format("FirstName LIKE '%{0}%' OR LastName LIKE '%{0}%' OR DepartmentName LIKE '%{0}%' OR Convert(FacultyID, 'System.String') LIKE '%{0}%'", searchTerm);

                    dgvFaculty.DataSource = dv.ToTable();

                    // Keep DepartmentID hidden after search
                    if (dgvFaculty.Columns["DepartmentID"] != null)
                        dgvFaculty.Columns["DepartmentID"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Search failed: " + ex.Message);
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

        // Logic for the ADD button
        private void btnFmembersAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtFmemberFname.Text) || cmbDepartment.SelectedValue == null)
                {
                    MessageBox.Show("Please fill up the First Name and select a Department.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (DataClasses1DataContext db = new DataClasses1DataContext())
                {
                    int deptID = Convert.ToInt32(cmbDepartment.SelectedValue);
                    int mLoad = string.IsNullOrEmpty(txtMaxLoad.Text) ? 18 : Convert.ToInt32(txtMaxLoad.Text);

                    tblFaculty newFaculty = new tblFaculty
                    {
                        FirstName = txtFmemberFname.Text,
                        LastName = txtFmemberLname.Text,
                        DepartmentID = deptID,
                        MaxLoad = mLoad
                    };

                    db.tblFaculties.InsertOnSubmit(newFaculty);
                    db.SubmitChanges();

                    MessageBox.Show("Faculty added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFields();
                    LoadFaculty();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Logic for the EDIT button
        private void btnEditMember_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvFaculty.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a record from the table to update.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtFmemberFname.Text) || cmbDepartment.SelectedValue == null)
                {
                    MessageBox.Show("Please ensure Name and Department are provided.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int facultyID = Convert.ToInt32(dgvFaculty.SelectedRows[0].Cells["FacultyID"].Value);

                using (DataClasses1DataContext db = new DataClasses1DataContext())
                {
                    var faculty = db.tblFaculties.FirstOrDefault(f => f.FacultyID == facultyID);
                    if (faculty != null)
                    {
                        faculty.FirstName = txtFmemberFname.Text;
                        faculty.LastName = txtFmemberLname.Text;
                        faculty.DepartmentID = Convert.ToInt32(cmbDepartment.SelectedValue);

                        if (int.TryParse(txtMaxLoad.Text, out int mLoad))
                            faculty.MaxLoad = mLoad;
                        else
                            faculty.MaxLoad = 18;

                        db.SubmitChanges();
                        MessageBox.Show("Updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearFields();
                        LoadFaculty();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Logic for clicking a cell in the Grid
        private void dgvFaculty_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvFaculty.Rows[e.RowIndex];

                // Fill text fields
                txtFacultyId.Text = row.Cells["FacultyID"].Value?.ToString();
                txtFmemberFname.Text = row.Cells["FirstName"].Value?.ToString();
                txtFmemberLname.Text = row.Cells["LastName"].Value?.ToString();
                txtMaxLoad.Text = row.Cells["MaxLoad"].Value?.ToString();

                // Fill ComboBox by ID (Better than .Text)
                if (row.Cells["DepartmentID"].Value != null)
                {
                    cmbDepartment.SelectedValue = row.Cells["DepartmentID"].Value;
                }
            }
        }

        private void btnRemoveMember_Click(object sender, EventArgs e)
        {
            if (dgvFaculty.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Are you sure you want to delete this faculty member?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int facultyID = Convert.ToInt32(dgvFaculty.SelectedRows[0].Cells["FacultyID"].Value);
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
            // Assuming your search textbox is named txtSearchMember or txtSearchLoad
            SearchFaculty(txtSearchMembers.Text.Trim());
        }
    }
}