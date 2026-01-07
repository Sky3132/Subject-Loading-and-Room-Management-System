using System;

namespace __Subject_Loading_and_Room_Assignment_Monitoring_System
{
    partial class Subject
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Subject));
            this.btnSearchSubject = new System.Windows.Forms.Button();
            this.btnDeleteSubject = new System.Windows.Forms.Button();
            this.btnEditSubject = new System.Windows.Forms.Button();
            this.btnAddSubject = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.imgBackToMain = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvSubjects = new System.Windows.Forms.DataGridView();
            this.lblSubjectCode = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.lblSubjectTitle = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblSubjectDepartment = new System.Windows.Forms.Label();
            this.lblSubjectProgram = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSubjectOffering = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLaboratoryUnits = new System.Windows.Forms.TextBox();
            this.txtLectureUnits = new System.Windows.Forms.TextBox();
            this.cmbDepartment = new System.Windows.Forms.ComboBox();
            this.cmbProgram = new System.Windows.Forms.ComboBox();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgBackToMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubjects)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSearchSubject
            // 
            this.btnSearchSubject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearchSubject.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(201)))), ((int)(((byte)(76)))));
            this.btnSearchSubject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchSubject.Location = new System.Drawing.Point(387, 233);
            this.btnSearchSubject.Name = "btnSearchSubject";
            this.btnSearchSubject.Size = new System.Drawing.Size(95, 40);
            this.btnSearchSubject.TabIndex = 5;
            this.btnSearchSubject.Text = "Search";
            this.btnSearchSubject.UseVisualStyleBackColor = false;
            this.btnSearchSubject.Click += new System.EventHandler(this.btnSearchSubject_Click);
            // 
            // btnDeleteSubject
            // 
            this.btnDeleteSubject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteSubject.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(201)))), ((int)(((byte)(76)))));
            this.btnDeleteSubject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteSubject.Location = new System.Drawing.Point(272, 233);
            this.btnDeleteSubject.Name = "btnDeleteSubject";
            this.btnDeleteSubject.Size = new System.Drawing.Size(95, 40);
            this.btnDeleteSubject.TabIndex = 2;
            this.btnDeleteSubject.Text = "Delete";
            this.btnDeleteSubject.UseVisualStyleBackColor = false;
            this.btnDeleteSubject.Click += new System.EventHandler(this.btnDeleteSubject_Click);
            // 
            // btnEditSubject
            // 
            this.btnEditSubject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditSubject.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(201)))), ((int)(((byte)(76)))));
            this.btnEditSubject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditSubject.Location = new System.Drawing.Point(157, 233);
            this.btnEditSubject.Name = "btnEditSubject";
            this.btnEditSubject.Size = new System.Drawing.Size(95, 40);
            this.btnEditSubject.TabIndex = 1;
            this.btnEditSubject.Text = "Edit";
            this.btnEditSubject.UseVisualStyleBackColor = false;
            this.btnEditSubject.Click += new System.EventHandler(this.btnEditSubject_Click_1);
            // 
            // btnAddSubject
            // 
            this.btnAddSubject.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnAddSubject.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(201)))), ((int)(((byte)(76)))));
            this.btnAddSubject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddSubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddSubject.ForeColor = System.Drawing.Color.Black;
            this.btnAddSubject.Location = new System.Drawing.Point(42, 233);
            this.btnAddSubject.Name = "btnAddSubject";
            this.btnAddSubject.Size = new System.Drawing.Size(95, 40);
            this.btnAddSubject.TabIndex = 0;
            this.btnAddSubject.Text = "Add";
            this.btnAddSubject.UseVisualStyleBackColor = false;
            this.btnAddSubject.Click += new System.EventHandler(this.btnAddSubject_Click);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(25)))), ((int)(((byte)(46)))));
            this.panel3.Controls.Add(this.imgBackToMain);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Location = new System.Drawing.Point(-3, -1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(806, 63);
            this.panel3.TabIndex = 3;
            // 
            // imgBackToMain
            // 
            this.imgBackToMain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.imgBackToMain.Image = ((System.Drawing.Image)(resources.GetObject("imgBackToMain.Image")));
            this.imgBackToMain.Location = new System.Drawing.Point(743, 13);
            this.imgBackToMain.Name = "imgBackToMain";
            this.imgBackToMain.Size = new System.Drawing.Size(60, 35);
            this.imgBackToMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgBackToMain.TabIndex = 31;
            this.imgBackToMain.TabStop = false;
            this.imgBackToMain.Click += new System.EventHandler(this.imgBackToMain_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Perpetua Titling MT", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(345, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "SUBJECT";
            // 
            // dgvSubjects
            // 
            this.dgvSubjects.AllowUserToAddRows = false;
            this.dgvSubjects.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSubjects.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSubjects.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSubjects.Location = new System.Drawing.Point(12, 289);
            this.dgvSubjects.Name = "dgvSubjects";
            this.dgvSubjects.RowHeadersWidth = 51;
            this.dgvSubjects.Size = new System.Drawing.Size(776, 149);
            this.dgvSubjects.TabIndex = 6;
            this.dgvSubjects.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSubjects_CellClick);
            // 
            // lblSubjectCode
            // 
            this.lblSubjectCode.AutoSize = true;
            this.lblSubjectCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubjectCode.Location = new System.Drawing.Point(34, 78);
            this.lblSubjectCode.Name = "lblSubjectCode";
            this.lblSubjectCode.Size = new System.Drawing.Size(36, 15);
            this.lblSubjectCode.TabIndex = 7;
            this.lblSubjectCode.Text = "Code";
            this.lblSubjectCode.Click += new System.EventHandler(this.lblSubjectCode_Click);
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(127, 77);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(140, 20);
            this.txtCode.TabIndex = 8;
            this.txtCode.TextChanged += new System.EventHandler(this.txtCode_TextChanged);
            // 
            // lblSubjectTitle
            // 
            this.lblSubjectTitle.AutoSize = true;
            this.lblSubjectTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubjectTitle.Location = new System.Drawing.Point(34, 114);
            this.lblSubjectTitle.Name = "lblSubjectTitle";
            this.lblSubjectTitle.Size = new System.Drawing.Size(30, 15);
            this.lblSubjectTitle.TabIndex = 9;
            this.lblSubjectTitle.Text = "Title";
            this.lblSubjectTitle.Click += new System.EventHandler(this.lblSubjectTitle_Click);
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(127, 113);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(140, 20);
            this.txtTitle.TabIndex = 10;
            this.txtTitle.TextChanged += new System.EventHandler(this.txtTitle_TextChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(500, 68);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(263, 159);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // lblSubjectDepartment
            // 
            this.lblSubjectDepartment.AutoSize = true;
            this.lblSubjectDepartment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubjectDepartment.Location = new System.Drawing.Point(34, 150);
            this.lblSubjectDepartment.Name = "lblSubjectDepartment";
            this.lblSubjectDepartment.Size = new System.Drawing.Size(72, 15);
            this.lblSubjectDepartment.TabIndex = 13;
            this.lblSubjectDepartment.Text = "Department";
            this.lblSubjectDepartment.Click += new System.EventHandler(this.lblSubjectDepartment_Click);
            // 
            // lblSubjectProgram
            // 
            this.lblSubjectProgram.AutoSize = true;
            this.lblSubjectProgram.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubjectProgram.Location = new System.Drawing.Point(34, 183);
            this.lblSubjectProgram.Name = "lblSubjectProgram";
            this.lblSubjectProgram.Size = new System.Drawing.Size(55, 15);
            this.lblSubjectProgram.TabIndex = 14;
            this.lblSubjectProgram.Text = "Program";
            this.lblSubjectProgram.Click += new System.EventHandler(this.lblSubjectProgram_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Location = new System.Drawing.Point(488, 246);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(137, 20);
            this.txtSearch.TabIndex = 18;
            // 
            // lblSubjectOffering
            // 
            this.lblSubjectOffering.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblSubjectOffering.AutoSize = true;
            this.lblSubjectOffering.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSubjectOffering.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubjectOffering.ForeColor = System.Drawing.Color.Blue;
            this.lblSubjectOffering.Location = new System.Drawing.Point(656, 244);
            this.lblSubjectOffering.Name = "lblSubjectOffering";
            this.lblSubjectOffering.Size = new System.Drawing.Size(124, 20);
            this.lblSubjectOffering.TabIndex = 19;
            this.lblSubjectOffering.Text = "Subject Offering";
            this.lblSubjectOffering.Click += new System.EventHandler(this.lblSubjectOffering_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(286, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Lecture Units";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(286, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Laboratory Units";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // txtLaboratoryUnits
            // 
            this.txtLaboratoryUnits.Location = new System.Drawing.Point(390, 118);
            this.txtLaboratoryUnits.Name = "txtLaboratoryUnits";
            this.txtLaboratoryUnits.Size = new System.Drawing.Size(100, 20);
            this.txtLaboratoryUnits.TabIndex = 24;
            this.txtLaboratoryUnits.TextChanged += new System.EventHandler(this.txtLaboratoryUnits_TextChanged);
            // 
            // txtLectureUnits
            // 
            this.txtLectureUnits.Location = new System.Drawing.Point(390, 82);
            this.txtLectureUnits.Name = "txtLectureUnits";
            this.txtLectureUnits.Size = new System.Drawing.Size(100, 20);
            this.txtLectureUnits.TabIndex = 25;
            this.txtLectureUnits.TextChanged += new System.EventHandler(this.txtLectureUnits_TextChanged);
            // 
            // cmbDepartment
            // 
            this.cmbDepartment.FormattingEnabled = true;
            this.cmbDepartment.Location = new System.Drawing.Point(127, 150);
            this.cmbDepartment.Name = "cmbDepartment";
            this.cmbDepartment.Size = new System.Drawing.Size(140, 21);
            this.cmbDepartment.TabIndex = 26;
            this.cmbDepartment.SelectedIndexChanged += new System.EventHandler(this.cmbDepartment_SelectedIndexChanged);
            this.cmbDepartment.SelectionChangeCommitted += new System.EventHandler(this.cmbDepartment_SelectionChangeCommitted_1);
            // 
            // cmbProgram
            // 
            this.cmbProgram.FormattingEnabled = true;
            this.cmbProgram.Location = new System.Drawing.Point(127, 186);
            this.cmbProgram.Name = "cmbProgram";
            this.cmbProgram.Size = new System.Drawing.Size(140, 21);
            this.cmbProgram.TabIndex = 27;
            this.cmbProgram.SelectedIndexChanged += new System.EventHandler(this.cmbProgram_SelectedIndexChanged);
            // 
            // Subject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cmbProgram);
            this.Controls.Add(this.cmbDepartment);
            this.Controls.Add(this.txtLectureUnits);
            this.Controls.Add(this.txtLaboratoryUnits);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblSubjectOffering);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblSubjectProgram);
            this.Controls.Add(this.lblSubjectDepartment);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.lblSubjectTitle);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.lblSubjectCode);
            this.Controls.Add(this.dgvSubjects);
            this.Controls.Add(this.btnSearchSubject);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.btnAddSubject);
            this.Controls.Add(this.btnDeleteSubject);
            this.Controls.Add(this.btnEditSubject);
            this.Name = "Subject";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Subject";
            this.Load += new System.EventHandler(this.Subject_Load_1);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgBackToMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubjects)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void Subject_Load(object sender, EventArgs e)
        {
        }

        #endregion
        private System.Windows.Forms.Button btnSearchSubject;
        private System.Windows.Forms.Button btnDeleteSubject;
        private System.Windows.Forms.Button btnEditSubject;
        private System.Windows.Forms.Button btnAddSubject;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvSubjects;
        private System.Windows.Forms.Label lblSubjectCode;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label lblSubjectTitle;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblSubjectDepartment;
        private System.Windows.Forms.Label lblSubjectProgram;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSubjectOffering;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLaboratoryUnits;
        private System.Windows.Forms.TextBox txtLectureUnits;
        private System.Windows.Forms.ComboBox cmbDepartment;
        private System.Windows.Forms.ComboBox cmbProgram;
        private System.Windows.Forms.PictureBox imgBackToMain;
    }
}