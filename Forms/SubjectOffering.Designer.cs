namespace __Subject_Loading_and_Room_Assignment_Monitoring_System.Forms
{
    partial class SubjectOffering
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SubjectOffering));
            this.panel3 = new System.Windows.Forms.Panel();
            this.imgBackToSub = new System.Windows.Forms.PictureBox();
            this.lblSubjectOffering = new System.Windows.Forms.Label();
            this.cmbSemester = new System.Windows.Forms.ComboBox();
            this.cmbSchoolYear = new System.Windows.Forms.ComboBox();
            this.lblSchoolYear = new System.Windows.Forms.Label();
            this.lblCodeTitle = new System.Windows.Forms.Label();
            this.cmbCode = new System.Windows.Forms.ComboBox();
            this.dgvSubjectOffering = new System.Windows.Forms.DataGridView();
            this.lblSemester = new System.Windows.Forms.Label();
            this.btnAddOffering = new System.Windows.Forms.Button();
            this.btnDeleteOffering = new System.Windows.Forms.Button();
            this.btnEditOffering = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgBackToSub)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubjectOffering)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(25)))), ((int)(((byte)(46)))));
            this.panel3.Controls.Add(this.imgBackToSub);
            this.panel3.Controls.Add(this.lblSubjectOffering);
            this.panel3.Location = new System.Drawing.Point(0, -7);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1075, 84);
            this.panel3.TabIndex = 24;
            // 
            // imgBackToSub
            // 
            this.imgBackToSub.Image = ((System.Drawing.Image)(resources.GetObject("imgBackToSub.Image")));
            this.imgBackToSub.Location = new System.Drawing.Point(968, 22);
            this.imgBackToSub.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.imgBackToSub.Name = "imgBackToSub";
            this.imgBackToSub.Size = new System.Drawing.Size(103, 43);
            this.imgBackToSub.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgBackToSub.TabIndex = 32;
            this.imgBackToSub.TabStop = false;
            this.imgBackToSub.Click += new System.EventHandler(this.imgBackToSub_Click);
            // 
            // lblSubjectOffering
            // 
            this.lblSubjectOffering.AutoSize = true;
            this.lblSubjectOffering.BackColor = System.Drawing.Color.Transparent;
            this.lblSubjectOffering.Font = new System.Drawing.Font("Perpetua Titling MT", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubjectOffering.ForeColor = System.Drawing.Color.White;
            this.lblSubjectOffering.Location = new System.Drawing.Point(379, 33);
            this.lblSubjectOffering.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSubjectOffering.Name = "lblSubjectOffering";
            this.lblSubjectOffering.Size = new System.Drawing.Size(287, 32);
            this.lblSubjectOffering.TabIndex = 0;
            this.lblSubjectOffering.Text = "SUBJECT OFFERING";
            // 
            // cmbSemester
            // 
            this.cmbSemester.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSemester.FormattingEnabled = true;
            this.cmbSemester.Items.AddRange(new object[] {
            "1st Sem",
            "2nd Sem",
            "Summer"});
            this.cmbSemester.Location = new System.Drawing.Point(235, 154);
            this.cmbSemester.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbSemester.Name = "cmbSemester";
            this.cmbSemester.Size = new System.Drawing.Size(211, 28);
            this.cmbSemester.TabIndex = 19;
            // 
            // cmbSchoolYear
            // 
            this.cmbSchoolYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSchoolYear.FormattingEnabled = true;
            this.cmbSchoolYear.Items.AddRange(new object[] {
            "2020-2021",
            "2022-2023",
            "2024-2025",
            "2025-2026"});
            this.cmbSchoolYear.Location = new System.Drawing.Point(235, 218);
            this.cmbSchoolYear.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbSchoolYear.Name = "cmbSchoolYear";
            this.cmbSchoolYear.Size = new System.Drawing.Size(211, 28);
            this.cmbSchoolYear.TabIndex = 18;
            // 
            // lblSchoolYear
            // 
            this.lblSchoolYear.AutoSize = true;
            this.lblSchoolYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSchoolYear.Location = new System.Drawing.Point(104, 222);
            this.lblSchoolYear.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSchoolYear.Name = "lblSchoolYear";
            this.lblSchoolYear.Size = new System.Drawing.Size(99, 20);
            this.lblSchoolYear.TabIndex = 17;
            this.lblSchoolYear.Text = "School Year";
            // 
            // lblCodeTitle
            // 
            this.lblCodeTitle.AutoSize = true;
            this.lblCodeTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodeTitle.Location = new System.Drawing.Point(104, 98);
            this.lblCodeTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCodeTitle.Name = "lblCodeTitle";
            this.lblCodeTitle.Size = new System.Drawing.Size(96, 20);
            this.lblCodeTitle.TabIndex = 15;
            this.lblCodeTitle.Text = "Code - Title";
            // 
            // cmbCode
            // 
            this.cmbCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCode.FormattingEnabled = true;
            this.cmbCode.Location = new System.Drawing.Point(235, 95);
            this.cmbCode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbCode.Name = "cmbCode";
            this.cmbCode.Size = new System.Drawing.Size(211, 28);
            this.cmbCode.TabIndex = 14;
            // 
            // dgvSubjectOffering
            // 
            this.dgvSubjectOffering.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSubjectOffering.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSubjectOffering.Location = new System.Drawing.Point(16, 354);
            this.dgvSubjectOffering.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvSubjectOffering.Name = "dgvSubjectOffering";
            this.dgvSubjectOffering.RowHeadersWidth = 51;
            this.dgvSubjectOffering.Size = new System.Drawing.Size(1035, 185);
            this.dgvSubjectOffering.TabIndex = 13;
            this.dgvSubjectOffering.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSubjectOffering_CellClick);
            // 
            // lblSemester
            // 
            this.lblSemester.AutoSize = true;
            this.lblSemester.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSemester.Location = new System.Drawing.Point(104, 158);
            this.lblSemester.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSemester.Name = "lblSemester";
            this.lblSemester.Size = new System.Drawing.Size(81, 20);
            this.lblSemester.TabIndex = 16;
            this.lblSemester.Text = "Semester";
            // 
            // btnAddOffering
            // 
            this.btnAddOffering.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(201)))), ((int)(((byte)(76)))));
            this.btnAddOffering.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddOffering.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddOffering.ForeColor = System.Drawing.Color.Black;
            this.btnAddOffering.Location = new System.Drawing.Point(79, 287);
            this.btnAddOffering.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAddOffering.Name = "btnAddOffering";
            this.btnAddOffering.Size = new System.Drawing.Size(127, 49);
            this.btnAddOffering.TabIndex = 25;
            this.btnAddOffering.Text = "Add";
            this.btnAddOffering.UseVisualStyleBackColor = false;
            this.btnAddOffering.Click += new System.EventHandler(this.btnAddOffering_Click);
            // 
            // btnDeleteOffering
            // 
            this.btnDeleteOffering.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(201)))), ((int)(((byte)(76)))));
            this.btnDeleteOffering.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteOffering.Location = new System.Drawing.Point(385, 287);
            this.btnDeleteOffering.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDeleteOffering.Name = "btnDeleteOffering";
            this.btnDeleteOffering.Size = new System.Drawing.Size(127, 49);
            this.btnDeleteOffering.TabIndex = 27;
            this.btnDeleteOffering.Text = "Delete";
            this.btnDeleteOffering.UseVisualStyleBackColor = false;
            this.btnDeleteOffering.Click += new System.EventHandler(this.btnDeleteOffering_Click);
            // 
            // btnEditOffering
            // 
            this.btnEditOffering.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(201)))), ((int)(((byte)(76)))));
            this.btnEditOffering.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditOffering.Location = new System.Drawing.Point(232, 287);
            this.btnEditOffering.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEditOffering.Name = "btnEditOffering";
            this.btnEditOffering.Size = new System.Drawing.Size(127, 49);
            this.btnEditOffering.TabIndex = 26;
            this.btnEditOffering.Text = "Edit";
            this.btnEditOffering.UseVisualStyleBackColor = false;
            this.btnEditOffering.Click += new System.EventHandler(this.btnEditOffering_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(599, 111);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(408, 206);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 28;
            this.pictureBox1.TabStop = false;
            // 
            // SubjectOffering
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnAddOffering);
            this.Controls.Add(this.btnDeleteOffering);
            this.Controls.Add(this.btnEditOffering);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.cmbSemester);
            this.Controls.Add(this.cmbSchoolYear);
            this.Controls.Add(this.lblSchoolYear);
            this.Controls.Add(this.lblSemester);
            this.Controls.Add(this.lblCodeTitle);
            this.Controls.Add(this.cmbCode);
            this.Controls.Add(this.dgvSubjectOffering);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "SubjectOffering";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.Load += new System.EventHandler(this.SubjectOffering_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgBackToSub)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubjectOffering)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblSubjectOffering;
        private System.Windows.Forms.ComboBox cmbSemester;
        private System.Windows.Forms.ComboBox cmbSchoolYear;
        private System.Windows.Forms.Label lblSchoolYear;
        private System.Windows.Forms.Label lblCodeTitle;
        private System.Windows.Forms.ComboBox cmbCode;
        private System.Windows.Forms.DataGridView dgvSubjectOffering;
        private System.Windows.Forms.Label lblSemester;
        private System.Windows.Forms.Button btnAddOffering;
        private System.Windows.Forms.Button btnDeleteOffering;
        private System.Windows.Forms.Button btnEditOffering;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox imgBackToSub;
    }
}