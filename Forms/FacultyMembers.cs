using System;

using System.Data;

using System.Linq;

using System.Windows.Forms;

using __Subject_Loading_and_Room_Assignment_Monitoring_System.Models;

using __Subject_Loading_and_Room_Assignment_Monitoring_System.Managers;



namespace __Subject_Loading_and_Room_Assignment_Monitoring_System.Forms

{

    public partial class FacultyMembers : Form

    {

        // Encapsulation: Using the Manager to handle logic

        private FacultyManager _facultyMgr = new FacultyManager();



        public FacultyMembers()

        {

            InitializeComponent();

        }



        private void FacultyMembers_Load(object sender, EventArgs e)

        {

            dgvFaculty.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            LoadComboBoxes();

            RefreshGrid();

        }



        private void RefreshGrid()

        {

            // Logic handled by Manager to keep Form clean

            dgvFaculty.DataSource = _facultyMgr.GetFacultyGridData();



            if (dgvFaculty.Columns["ID"] != null) dgvFaculty.Columns["ID"].Visible = false;

            if (dgvFaculty.Columns["DepartmentID"] != null) dgvFaculty.Columns["DepartmentID"].Visible = false;

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

                // 1. Pack UI data into the Model (OOP: Object Creation)

                var newMember = new FacultyMember

                {

                    FirstName = txtFmemberFname.Text.Trim(),

                    LastName = txtFmemberLname.Text.Trim(),

                    DepartmentID = cmbDepartment.SelectedValue != null ? Convert.ToInt32(cmbDepartment.SelectedValue) : 0,

                    MaxLoad = 18 // Default

                };



                // 2. Validate and Save via Manager (Separation of Concerns)

                _facultyMgr.Validate(newMember);

                _facultyMgr.AddFaculty(newMember);



                MessageBox.Show("Faculty added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                RefreshGrid();

                ClearFields();

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

                if (dgvFaculty.SelectedRows.Count == 0) return;



                var updatedMember = new FacultyMember

                {

                    FacultyID = Convert.ToInt32(dgvFaculty.SelectedRows[0].Cells["ID"].Value),

                    FirstName = txtFmemberFname.Text.Trim(),

                    LastName = txtFmemberLname.Text.Trim(),

                    DepartmentID = cmbDepartment.SelectedValue != null ? Convert.ToInt32(cmbDepartment.SelectedValue) : 0

                };



                _facultyMgr.Validate(updatedMember);

                _facultyMgr.UpdateFaculty(updatedMember);



                MessageBox.Show("Updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                RefreshGrid();

            }

            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }



        private void btnRemoveMember_Click(object sender, EventArgs e)

        {

            if (dgvFaculty.SelectedRows.Count == 0) return;



            if (MessageBox.Show("Delete this faculty?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)

            {

                int id = Convert.ToInt32(dgvFaculty.SelectedRows[0].Cells["ID"].Value);

                _facultyMgr.DeleteFaculty(id);

                RefreshGrid();

                ClearFields();

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

            FacultyLoading load = new FacultyLoading();

            load.Show();

            this.Hide();

        }

    }

}

