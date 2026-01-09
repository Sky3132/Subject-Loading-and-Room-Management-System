namespace __Subject_Loading_and_Room_Assignment_Monitoring_System.Forms
{
    partial class FacultyMembers
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FacultyMembers));
            this.lblFmembersDept = new System.Windows.Forms.Label();
            this.txtFmemberFname = new System.Windows.Forms.TextBox();
            this.lblFmemberFname = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvFaculty = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.imgBackToMain2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRemoveLoad = new System.Windows.Forms.Button();
            this.btnEditLoad = new System.Windows.Forms.Button();
            this.txtSearchMembers = new System.Windows.Forms.TextBox();
            this.btnFmembersAdd = new System.Windows.Forms.Button();
            this.txtFmemberLname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbDepartment = new System.Windows.Forms.ComboBox();
            this.btnSearchMember = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFaculty)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgBackToMain2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFmembersDept
            // 
            this.lblFmembersDept.AutoSize = true;
            this.lblFmembersDept.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFmembersDept.Location = new System.Drawing.Point(273, 86);
            this.lblFmembersDept.Name = "lblFmembersDept";
            this.lblFmembersDept.Size = new System.Drawing.Size(85, 18);
            this.lblFmembersDept.TabIndex = 48;
            this.lblFmembersDept.Text = "Department";
            // 
            // txtFmemberFname
            // 
            this.txtFmemberFname.Location = new System.Drawing.Point(48, 107);
            this.txtFmemberFname.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtFmemberFname.Name = "txtFmemberFname";
            this.txtFmemberFname.Size = new System.Drawing.Size(181, 22);
            this.txtFmemberFname.TabIndex = 59;
            // 
            // lblFmemberFname
            // 
            this.lblFmemberFname.AutoSize = true;
            this.lblFmemberFname.Location = new System.Drawing.Point(46, 90);
            this.lblFmemberFname.Name = "lblFmemberFname";
            this.lblFmemberFname.Size = new System.Drawing.Size(72, 16);
            this.lblFmemberFname.TabIndex = 1;
            this.lblFmemberFname.Text = "First Name";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 0;
            // 
            // dgvFaculty
            // 
            this.dgvFaculty.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFaculty.Location = new System.Drawing.Point(15, 356);
            this.dgvFaculty.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvFaculty.Name = "dgvFaculty";
            this.dgvFaculty.RowHeadersWidth = 51;
            this.dgvFaculty.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFaculty.Size = new System.Drawing.Size(1035, 185);
            this.dgvFaculty.TabIndex = 57;
            this.dgvFaculty.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFaculty_CellClick);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(25)))), ((int)(((byte)(46)))));
            this.panel3.Controls.Add(this.imgBackToMain2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Location = new System.Drawing.Point(1, 1);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1063, 78);
            this.panel3.TabIndex = 58;
            // 
            // imgBackToMain2
            // 
            this.imgBackToMain2.Image = ((System.Drawing.Image)(resources.GetObject("imgBackToMain2.Image")));
            this.imgBackToMain2.Location = new System.Drawing.Point(955, 12);
            this.imgBackToMain2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.imgBackToMain2.Name = "imgBackToMain2";
            this.imgBackToMain2.Size = new System.Drawing.Size(108, 48);
            this.imgBackToMain2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgBackToMain2.TabIndex = 0;
            this.imgBackToMain2.TabStop = false;
            this.imgBackToMain2.Click += new System.EventHandler(this.imgBackToMain2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Perpetua Titling MT", 15.75F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(391, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(296, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "FACULTY MEMBERS";
            // 
            // btnRemoveLoad
            // 
            this.btnRemoveLoad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(201)))), ((int)(((byte)(76)))));
            this.btnRemoveLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveLoad.Location = new System.Drawing.Point(344, 289);
            this.btnRemoveLoad.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRemoveLoad.Name = "btnRemoveLoad";
            this.btnRemoveLoad.Size = new System.Drawing.Size(127, 49);
            this.btnRemoveLoad.TabIndex = 56;
            this.btnRemoveLoad.Text = "Remove";
            this.btnRemoveLoad.UseVisualStyleBackColor = false;
            this.btnRemoveLoad.Click += new System.EventHandler(this.btnRemoveMember_Click);
            // 
            // btnEditLoad
            // 
            this.btnEditLoad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(201)))), ((int)(((byte)(76)))));
            this.btnEditLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditLoad.Location = new System.Drawing.Point(196, 289);
            this.btnEditLoad.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEditLoad.Name = "btnEditLoad";
            this.btnEditLoad.Size = new System.Drawing.Size(127, 49);
            this.btnEditLoad.TabIndex = 55;
            this.btnEditLoad.Text = "Edit";
            this.btnEditLoad.UseVisualStyleBackColor = false;
            this.btnEditLoad.Click += new System.EventHandler(this.btnEditMember_Click);
            // 
            // txtSearchMembers
            // 
            this.txtSearchMembers.Location = new System.Drawing.Point(641, 303);
            this.txtSearchMembers.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSearchMembers.Name = "txtSearchMembers";
            this.txtSearchMembers.Size = new System.Drawing.Size(180, 22);
            this.txtSearchMembers.TabIndex = 52;
            // 
            // btnFmembersAdd
            // 
            this.btnFmembersAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(201)))), ((int)(((byte)(76)))));
            this.btnFmembersAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFmembersAdd.Location = new System.Drawing.Point(48, 289);
            this.btnFmembersAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnFmembersAdd.Name = "btnFmembersAdd";
            this.btnFmembersAdd.Size = new System.Drawing.Size(127, 49);
            this.btnFmembersAdd.TabIndex = 54;
            this.btnFmembersAdd.Text = "Add";
            this.btnFmembersAdd.UseVisualStyleBackColor = false;
            this.btnFmembersAdd.Click += new System.EventHandler(this.btnFmembersAdd_Click);
            // 
            // txtFmemberLname
            // 
            this.txtFmemberLname.Location = new System.Drawing.Point(48, 163);
            this.txtFmemberLname.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtFmemberLname.Name = "txtFmemberLname";
            this.txtFmemberLname.Size = new System.Drawing.Size(181, 22);
            this.txtFmemberLname.TabIndex = 65;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Last Name";
            // 
            // cmbDepartment
            // 
            this.cmbDepartment.FormattingEnabled = true;
            this.cmbDepartment.Location = new System.Drawing.Point(275, 107);
            this.cmbDepartment.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbDepartment.Name = "cmbDepartment";
            this.cmbDepartment.Size = new System.Drawing.Size(183, 24);
            this.cmbDepartment.TabIndex = 53;
            // 
            // btnSearchMember
            // 
            this.btnSearchMember.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(201)))), ((int)(((byte)(76)))));
            this.btnSearchMember.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchMember.Location = new System.Drawing.Point(496, 289);
            this.btnSearchMember.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSearchMember.Name = "btnSearchMember";
            this.btnSearchMember.Size = new System.Drawing.Size(127, 49);
            this.btnSearchMember.TabIndex = 63;
            this.btnSearchMember.Text = "Search";
            this.btnSearchMember.UseVisualStyleBackColor = false;
            this.btnSearchMember.Click += new System.EventHandler(this.btnSearchMember_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(671, 85);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(371, 188);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 62;
            this.pictureBox1.TabStop = false;
            // 
            // FacultyMembers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1057, 554);
            this.Controls.Add(this.btnSearchMember);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblFmemberFname);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblFmembersDept);
            this.Controls.Add(this.txtSearchMembers);
            this.Controls.Add(this.cmbDepartment);
            this.Controls.Add(this.btnFmembersAdd);
            this.Controls.Add(this.btnEditLoad);
            this.Controls.Add(this.btnRemoveLoad);
            this.Controls.Add(this.dgvFaculty);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.txtFmemberFname);
            this.Controls.Add(this.txtFmemberLname);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FacultyMembers";
            this.Text = "Faculty Members";
            this.Load += new System.EventHandler(this.FacultyMembers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFaculty)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgBackToMain2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblFmembersDept;
        private System.Windows.Forms.TextBox txtFmemberFname;
        private System.Windows.Forms.Label lblFmemberFname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvFaculty;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox imgBackToMain2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRemoveLoad;
        private System.Windows.Forms.Button btnEditLoad;
        private System.Windows.Forms.TextBox txtSearchMembers;
        private System.Windows.Forms.Button btnFmembersAdd;
        private System.Windows.Forms.TextBox txtFmemberLname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbDepartment;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnSearchMember;
    }
}