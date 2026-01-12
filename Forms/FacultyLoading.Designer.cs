namespace __Subject_Loading_and_Room_Assignment_Monitoring_System.Forms
{
    partial class FacultyLoading
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FacultyLoading));
            this.lblSubject = new System.Windows.Forms.Label();
            this.dgvLoading = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.imgBackToMain2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearchLoad = new System.Windows.Forms.Button();
            this.btnCancelLoad = new System.Windows.Forms.Button();
            this.btnRemoveLoad = new System.Windows.Forms.Button();
            this.btnEditLoad = new System.Windows.Forms.Button();
            this.btnSaveLoad = new System.Windows.Forms.Button();
            this.lblFaculty = new System.Windows.Forms.Label();
            this.lblSection = new System.Windows.Forms.Label();
            this.txtSearchLoad = new System.Windows.Forms.TextBox();
            this.lblFacultyMembers = new System.Windows.Forms.Label();
            this.cmbSubject = new System.Windows.Forms.ComboBox();
            this.cmbFaculty = new System.Windows.Forms.ComboBox();
            this.cmbProgram = new System.Windows.Forms.ComboBox();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.cmbDepartment = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoading)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgBackToMain2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSubject
            // 
            this.lblSubject.AutoSize = true;
            this.lblSubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubject.Location = new System.Drawing.Point(52, 91);
            this.lblSubject.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(137, 18);
            this.lblSubject.TabIndex = 20;
            this.lblSubject.Text = "Subject Code - Title";
            // 
            // dgvLoading
            // 
            this.dgvLoading.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLoading.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLoading.Location = new System.Drawing.Point(16, 356);
            this.dgvLoading.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvLoading.Name = "dgvLoading";
            this.dgvLoading.RowHeadersWidth = 51;
            this.dgvLoading.Size = new System.Drawing.Size(1025, 183);
            this.dgvLoading.TabIndex = 19;
            this.dgvLoading.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLoading_CellClick);
            // 
            // panel3
            // 
            this.panel3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(25)))), ((int)(((byte)(46)))));
            this.panel3.Controls.Add(this.imgBackToMain2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Location = new System.Drawing.Point(-9, -1);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1075, 78);
            this.panel3.TabIndex = 15;
            // 
            // imgBackToMain2
            // 
            this.imgBackToMain2.Image = ((System.Drawing.Image)(resources.GetObject("imgBackToMain2.Image")));
            this.imgBackToMain2.Location = new System.Drawing.Point(967, 16);
            this.imgBackToMain2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.imgBackToMain2.Name = "imgBackToMain2";
            this.imgBackToMain2.Size = new System.Drawing.Size(108, 48);
            this.imgBackToMain2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgBackToMain2.TabIndex = 33;
            this.imgBackToMain2.TabStop = false;
            this.imgBackToMain2.Click += new System.EventHandler(this.imgBackToMain2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Perpetua Titling MT", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(401, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(294, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "FACULTY LOADING";
            // 
            // btnSearchLoad
            // 
            this.btnSearchLoad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(201)))), ((int)(((byte)(76)))));
            this.btnSearchLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchLoad.Location = new System.Drawing.Point(581, 287);
            this.btnSearchLoad.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSearchLoad.Name = "btnSearchLoad";
            this.btnSearchLoad.Size = new System.Drawing.Size(121, 49);
            this.btnSearchLoad.TabIndex = 18;
            this.btnSearchLoad.Text = "Search";
            this.btnSearchLoad.UseVisualStyleBackColor = false;
            this.btnSearchLoad.Click += new System.EventHandler(this.btnSearchLoad_Click);
            // 
            // btnCancelLoad
            // 
            this.btnCancelLoad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(201)))), ((int)(((byte)(76)))));
            this.btnCancelLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelLoad.Location = new System.Drawing.Point(312, 287);
            this.btnCancelLoad.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancelLoad.Name = "btnCancelLoad";
            this.btnCancelLoad.Size = new System.Drawing.Size(127, 49);
            this.btnCancelLoad.TabIndex = 17;
            this.btnCancelLoad.Text = "Cancel";
            this.btnCancelLoad.UseVisualStyleBackColor = false;
            // 
            // btnRemoveLoad
            // 
            this.btnRemoveLoad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(201)))), ((int)(((byte)(76)))));
            this.btnRemoveLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveLoad.Location = new System.Drawing.Point(447, 287);
            this.btnRemoveLoad.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRemoveLoad.Name = "btnRemoveLoad";
            this.btnRemoveLoad.Size = new System.Drawing.Size(127, 49);
            this.btnRemoveLoad.TabIndex = 14;
            this.btnRemoveLoad.Text = "Remove";
            this.btnRemoveLoad.UseVisualStyleBackColor = false;
            this.btnRemoveLoad.Click += new System.EventHandler(this.btnRemoveLoad_Click);
            // 
            // btnEditLoad
            // 
            this.btnEditLoad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(201)))), ((int)(((byte)(76)))));
            this.btnEditLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditLoad.Location = new System.Drawing.Point(177, 287);
            this.btnEditLoad.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEditLoad.Name = "btnEditLoad";
            this.btnEditLoad.Size = new System.Drawing.Size(127, 49);
            this.btnEditLoad.TabIndex = 13;
            this.btnEditLoad.Text = "Edit";
            this.btnEditLoad.UseVisualStyleBackColor = false;
            this.btnEditLoad.Click += new System.EventHandler(this.btnEditLoad_Click);
            // 
            // btnSaveLoad
            // 
            this.btnSaveLoad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(201)))), ((int)(((byte)(76)))));
            this.btnSaveLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveLoad.Location = new System.Drawing.Point(43, 287);
            this.btnSaveLoad.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSaveLoad.Name = "btnSaveLoad";
            this.btnSaveLoad.Size = new System.Drawing.Size(127, 49);
            this.btnSaveLoad.TabIndex = 16;
            this.btnSaveLoad.Text = "Save";
            this.btnSaveLoad.UseVisualStyleBackColor = false;
            this.btnSaveLoad.Click += new System.EventHandler(this.btnSaveLoad_Click);
            // 
            // lblFaculty
            // 
            this.lblFaculty.AutoSize = true;
            this.lblFaculty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFaculty.Location = new System.Drawing.Point(52, 134);
            this.lblFaculty.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFaculty.Name = "lblFaculty";
            this.lblFaculty.Size = new System.Drawing.Size(126, 18);
            this.lblFaculty.TabIndex = 26;
            this.lblFaculty.Text = "Faculty ID - Name";
            // 
            // lblSection
            // 
            this.lblSection.AutoSize = true;
            this.lblSection.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSection.Location = new System.Drawing.Point(52, 224);
            this.lblSection.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSection.Name = "lblSection";
            this.lblSection.Size = new System.Drawing.Size(66, 18);
            this.lblSection.TabIndex = 30;
            this.lblSection.Text = "Program";
            // 
            // txtSearchLoad
            // 
            this.txtSearchLoad.Location = new System.Drawing.Point(711, 300);
            this.txtSearchLoad.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSearchLoad.Name = "txtSearchLoad";
            this.txtSearchLoad.Size = new System.Drawing.Size(143, 22);
            this.txtSearchLoad.TabIndex = 32;
            // 
            // lblFacultyMembers
            // 
            this.lblFacultyMembers.AutoSize = true;
            this.lblFacultyMembers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFacultyMembers.ForeColor = System.Drawing.Color.Blue;
            this.lblFacultyMembers.Location = new System.Drawing.Point(868, 298);
            this.lblFacultyMembers.Name = "lblFacultyMembers";
            this.lblFacultyMembers.Size = new System.Drawing.Size(162, 25);
            this.lblFacultyMembers.TabIndex = 33;
            this.lblFacultyMembers.Text = "Faculty Members";
            this.lblFacultyMembers.Click += new System.EventHandler(this.lblFacultyMembers_Click_1);
            // 
            // cmbSubject
            // 
            this.cmbSubject.FormattingEnabled = true;
            this.cmbSubject.Location = new System.Drawing.Point(235, 90);
            this.cmbSubject.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbSubject.Name = "cmbSubject";
            this.cmbSubject.Size = new System.Drawing.Size(185, 24);
            this.cmbSubject.TabIndex = 34;
            // 
            // cmbFaculty
            // 
            this.cmbFaculty.FormattingEnabled = true;
            this.cmbFaculty.Location = new System.Drawing.Point(235, 133);
            this.cmbFaculty.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbFaculty.Name = "cmbFaculty";
            this.cmbFaculty.Size = new System.Drawing.Size(185, 24);
            this.cmbFaculty.TabIndex = 35;
            // 
            // cmbProgram
            // 
            this.cmbProgram.FormattingEnabled = true;
            this.cmbProgram.Location = new System.Drawing.Point(235, 223);
            this.cmbProgram.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbProgram.Name = "cmbProgram";
            this.cmbProgram.Size = new System.Drawing.Size(185, 24);
            this.cmbProgram.TabIndex = 36;
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDepartment.Location = new System.Drawing.Point(52, 177);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(85, 18);
            this.lblDepartment.TabIndex = 37;
            this.lblDepartment.Text = "Department";
            // 
            // cmbDepartment
            // 
            this.cmbDepartment.FormattingEnabled = true;
            this.cmbDepartment.Location = new System.Drawing.Point(235, 175);
            this.cmbDepartment.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbDepartment.Name = "cmbDepartment";
            this.cmbDepartment.Size = new System.Drawing.Size(185, 24);
            this.cmbDepartment.TabIndex = 38;
            this.cmbDepartment.SelectedIndexChanged += new System.EventHandler(this.cmbDepartment_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(672, 91);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(369, 188);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 24;
            this.pictureBox1.TabStop = false;
            // 
            // FacultyLoading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1057, 554);
            this.Controls.Add(this.cmbDepartment);
            this.Controls.Add(this.lblDepartment);
            this.Controls.Add(this.cmbProgram);
            this.Controls.Add(this.cmbFaculty);
            this.Controls.Add(this.cmbSubject);
            this.Controls.Add(this.lblFacultyMembers);
            this.Controls.Add(this.txtSearchLoad);
            this.Controls.Add(this.lblSection);
            this.Controls.Add(this.lblFaculty);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblSubject);
            this.Controls.Add(this.dgvLoading);
            this.Controls.Add(this.btnSearchLoad);
            this.Controls.Add(this.btnCancelLoad);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.btnSaveLoad);
            this.Controls.Add(this.btnRemoveLoad);
            this.Controls.Add(this.btnEditLoad);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FacultyLoading";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FacultyLoading";
            this.Load += new System.EventHandler(this.FacultyLoading_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoading)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgBackToMain2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblSubject;
        private System.Windows.Forms.DataGridView dgvLoading;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnSearchLoad;
        private System.Windows.Forms.Button btnCancelLoad;
        private System.Windows.Forms.Button btnRemoveLoad;
        private System.Windows.Forms.Button btnEditLoad;
        private System.Windows.Forms.Button btnSaveLoad;
        private System.Windows.Forms.PictureBox imgBackToMain2;
        private System.Windows.Forms.Label lblFaculty;
        private System.Windows.Forms.Label lblSection;
        private System.Windows.Forms.TextBox txtSearchLoad;
        private System.Windows.Forms.Label lblFacultyMembers;
        private System.Windows.Forms.ComboBox cmbSubject;
        private System.Windows.Forms.ComboBox cmbFaculty;
        private System.Windows.Forms.ComboBox cmbProgram;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.ComboBox cmbDepartment;
    }
}