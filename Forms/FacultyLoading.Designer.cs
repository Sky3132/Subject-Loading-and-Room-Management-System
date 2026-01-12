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
            this.lblSubject.Location = new System.Drawing.Point(39, 74);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(113, 15);
            this.lblSubject.TabIndex = 20;
            this.lblSubject.Text = "Subject Code - Title";
            // 
            // dgvLoading
            // 
            this.dgvLoading.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLoading.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLoading.Location = new System.Drawing.Point(12, 289);
            this.dgvLoading.Name = "dgvLoading";
            this.dgvLoading.RowHeadersWidth = 51;
            this.dgvLoading.Size = new System.Drawing.Size(769, 149);
            this.dgvLoading.TabIndex = 19;
            this.dgvLoading.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLoading_CellClick);
            // 
            // panel3
            // 
            this.panel3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(25)))), ((int)(((byte)(46)))));
            this.panel3.Controls.Add(this.imgBackToMain2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Location = new System.Drawing.Point(-7, -1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(806, 63);
            this.panel3.TabIndex = 15;
            // 
            // imgBackToMain2
            // 
            this.imgBackToMain2.Image = ((System.Drawing.Image)(resources.GetObject("imgBackToMain2.Image")));
            this.imgBackToMain2.Location = new System.Drawing.Point(725, 13);
            this.imgBackToMain2.Name = "imgBackToMain2";
            this.imgBackToMain2.Size = new System.Drawing.Size(81, 39);
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
            this.label1.Location = new System.Drawing.Point(301, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(233, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "FACULTY LOADING";
            // 
            // btnSearchLoad
            // 
            this.btnSearchLoad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(201)))), ((int)(((byte)(76)))));
            this.btnSearchLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchLoad.Location = new System.Drawing.Point(436, 233);
            this.btnSearchLoad.Name = "btnSearchLoad";
            this.btnSearchLoad.Size = new System.Drawing.Size(91, 40);
            this.btnSearchLoad.TabIndex = 18;
            this.btnSearchLoad.Text = "Search";
            this.btnSearchLoad.UseVisualStyleBackColor = false;
            this.btnSearchLoad.Click += new System.EventHandler(this.btnSearchLoad_Click);
            // 
            // btnCancelLoad
            // 
            this.btnCancelLoad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(201)))), ((int)(((byte)(76)))));
            this.btnCancelLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelLoad.Location = new System.Drawing.Point(234, 233);
            this.btnCancelLoad.Name = "btnCancelLoad";
            this.btnCancelLoad.Size = new System.Drawing.Size(95, 40);
            this.btnCancelLoad.TabIndex = 17;
            this.btnCancelLoad.Text = "Cancel";
            this.btnCancelLoad.UseVisualStyleBackColor = false;
            this.btnCancelLoad.Click += new System.EventHandler(this.btnCancelLoad_Click);
            // 
            // btnRemoveLoad
            // 
            this.btnRemoveLoad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(201)))), ((int)(((byte)(76)))));
            this.btnRemoveLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveLoad.Location = new System.Drawing.Point(335, 233);
            this.btnRemoveLoad.Name = "btnRemoveLoad";
            this.btnRemoveLoad.Size = new System.Drawing.Size(95, 40);
            this.btnRemoveLoad.TabIndex = 14;
            this.btnRemoveLoad.Text = "Remove";
            this.btnRemoveLoad.UseVisualStyleBackColor = false;
            this.btnRemoveLoad.Click += new System.EventHandler(this.btnRemoveLoad_Click);
            // 
            // btnEditLoad
            // 
            this.btnEditLoad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(201)))), ((int)(((byte)(76)))));
            this.btnEditLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditLoad.Location = new System.Drawing.Point(133, 233);
            this.btnEditLoad.Name = "btnEditLoad";
            this.btnEditLoad.Size = new System.Drawing.Size(95, 40);
            this.btnEditLoad.TabIndex = 13;
            this.btnEditLoad.Text = "Edit";
            this.btnEditLoad.UseVisualStyleBackColor = false;
            this.btnEditLoad.Click += new System.EventHandler(this.btnEditLoad_Click);
            // 
            // btnSaveLoad
            // 
            this.btnSaveLoad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(201)))), ((int)(((byte)(76)))));
            this.btnSaveLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveLoad.Location = new System.Drawing.Point(32, 233);
            this.btnSaveLoad.Name = "btnSaveLoad";
            this.btnSaveLoad.Size = new System.Drawing.Size(95, 40);
            this.btnSaveLoad.TabIndex = 16;
            this.btnSaveLoad.Text = "Save";
            this.btnSaveLoad.UseVisualStyleBackColor = false;
            this.btnSaveLoad.Click += new System.EventHandler(this.btnSaveLoad_Click);
            // 
            // lblFaculty
            // 
            this.lblFaculty.AutoSize = true;
            this.lblFaculty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFaculty.Location = new System.Drawing.Point(39, 109);
            this.lblFaculty.Name = "lblFaculty";
            this.lblFaculty.Size = new System.Drawing.Size(104, 15);
            this.lblFaculty.TabIndex = 26;
            this.lblFaculty.Text = "Faculty ID - Name";
            // 
            // lblSection
            // 
            this.lblSection.AutoSize = true;
            this.lblSection.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSection.Location = new System.Drawing.Point(39, 182);
            this.lblSection.Name = "lblSection";
            this.lblSection.Size = new System.Drawing.Size(55, 15);
            this.lblSection.TabIndex = 30;
            this.lblSection.Text = "Program";
            // 
            // txtSearchLoad
            // 
            this.txtSearchLoad.Location = new System.Drawing.Point(533, 244);
            this.txtSearchLoad.Name = "txtSearchLoad";
            this.txtSearchLoad.Size = new System.Drawing.Size(108, 20);
            this.txtSearchLoad.TabIndex = 32;
            // 
            // lblFacultyMembers
            // 
            this.lblFacultyMembers.AutoSize = true;
            this.lblFacultyMembers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFacultyMembers.ForeColor = System.Drawing.Color.Blue;
            this.lblFacultyMembers.Location = new System.Drawing.Point(651, 242);
            this.lblFacultyMembers.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFacultyMembers.Name = "lblFacultyMembers";
            this.lblFacultyMembers.Size = new System.Drawing.Size(130, 20);
            this.lblFacultyMembers.TabIndex = 33;
            this.lblFacultyMembers.Text = "Faculty Members";
            this.lblFacultyMembers.Click += new System.EventHandler(this.lblFacultyMembers_Click);
            // 
            // cmbSubject
            // 
            this.cmbSubject.FormattingEnabled = true;
            this.cmbSubject.Location = new System.Drawing.Point(176, 73);
            this.cmbSubject.Margin = new System.Windows.Forms.Padding(2);
            this.cmbSubject.Name = "cmbSubject";
            this.cmbSubject.Size = new System.Drawing.Size(140, 21);
            this.cmbSubject.TabIndex = 34;
            // 
            // cmbFaculty
            // 
            this.cmbFaculty.FormattingEnabled = true;
            this.cmbFaculty.Location = new System.Drawing.Point(176, 108);
            this.cmbFaculty.Margin = new System.Windows.Forms.Padding(2);
            this.cmbFaculty.Name = "cmbFaculty";
            this.cmbFaculty.Size = new System.Drawing.Size(140, 21);
            this.cmbFaculty.TabIndex = 35;
            // 
            // cmbProgram
            // 
            this.cmbProgram.FormattingEnabled = true;
            this.cmbProgram.Location = new System.Drawing.Point(176, 181);
            this.cmbProgram.Margin = new System.Windows.Forms.Padding(2);
            this.cmbProgram.Name = "cmbProgram";
            this.cmbProgram.Size = new System.Drawing.Size(140, 21);
            this.cmbProgram.TabIndex = 36;
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDepartment.Location = new System.Drawing.Point(39, 144);
            this.lblDepartment.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(72, 15);
            this.lblDepartment.TabIndex = 37;
            this.lblDepartment.Text = "Department";
            this.lblDepartment.Click += new System.EventHandler(this.lblDepartment_Click);
            // 
            // cmbDepartment
            // 
            this.cmbDepartment.FormattingEnabled = true;
            this.cmbDepartment.Location = new System.Drawing.Point(176, 142);
            this.cmbDepartment.Margin = new System.Windows.Forms.Padding(2);
            this.cmbDepartment.Name = "cmbDepartment";
            this.cmbDepartment.Size = new System.Drawing.Size(140, 21);
            this.cmbDepartment.TabIndex = 38;
            this.cmbDepartment.SelectedIndexChanged += new System.EventHandler(this.cmbDepartment_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(504, 74);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(277, 153);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 24;
            this.pictureBox1.TabStop = false;
            // 
            // FacultyLoading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 450);
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