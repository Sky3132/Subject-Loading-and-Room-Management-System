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
            this.label2 = new System.Windows.Forms.Label();
            this.lblSubjectId = new System.Windows.Forms.Label();
            this.dgvLoading = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.imgBackToMain2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtSubjectName = new System.Windows.Forms.TextBox();
            this.txtSubjectId = new System.Windows.Forms.TextBox();
            this.btnSearchLoad = new System.Windows.Forms.Button();
            this.btnCancelLoad = new System.Windows.Forms.Button();
            this.btnRemoveLoad = new System.Windows.Forms.Button();
            this.btnEditLoad = new System.Windows.Forms.Button();
            this.btnSaveLoad = new System.Windows.Forms.Button();
            this.lblFacultyID = new System.Windows.Forms.Label();
            this.txtFacultyId = new System.Windows.Forms.TextBox();
            this.lblFacultyName = new System.Windows.Forms.Label();
            this.txtFacultyName = new System.Windows.Forms.TextBox();
            this.lblSection = new System.Windows.Forms.Label();
            this.txtSection = new System.Windows.Forms.TextBox();
            this.txtSearchLoad = new System.Windows.Forms.TextBox();
            this.lblFacultyMembers = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoading)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgBackToMain2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(64, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 15);
            this.label2.TabIndex = 22;
            this.label2.Text = "Subject Name";
            // 
            // lblSubjectId
            // 
            this.lblSubjectId.AutoSize = true;
            this.lblSubjectId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubjectId.Location = new System.Drawing.Point(64, 76);
            this.lblSubjectId.Name = "lblSubjectId";
            this.lblSubjectId.Size = new System.Drawing.Size(80, 15);
            this.lblSubjectId.TabIndex = 20;
            this.lblSubjectId.Text = "Subject Code";
            // 
            // dgvLoading
            // 
            this.dgvLoading.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLoading.Location = new System.Drawing.Point(12, 289);
            this.dgvLoading.Name = "dgvLoading";
            this.dgvLoading.RowHeadersWidth = 51;
            this.dgvLoading.Size = new System.Drawing.Size(776, 149);
            this.dgvLoading.TabIndex = 19;
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
            this.label1.Location = new System.Drawing.Point(277, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(233, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "FACULTY LOADING";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(584, 86);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(204, 187);
            this.pictureBox1.TabIndex = 24;
            this.pictureBox1.TabStop = false;
            // 
            // txtSubjectName
            // 
            this.txtSubjectName.Location = new System.Drawing.Point(53, 132);
            this.txtSubjectName.Name = "txtSubjectName";
            this.txtSubjectName.Size = new System.Drawing.Size(100, 20);
            this.txtSubjectName.TabIndex = 23;
            // 
            // txtSubjectId
            // 
            this.txtSubjectId.Location = new System.Drawing.Point(53, 93);
            this.txtSubjectId.Name = "txtSubjectId";
            this.txtSubjectId.Size = new System.Drawing.Size(100, 20);
            this.txtSubjectId.TabIndex = 21;
            // 
            // btnSearchLoad
            // 
            this.btnSearchLoad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(201)))), ((int)(((byte)(76)))));
            this.btnSearchLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchLoad.Location = new System.Drawing.Point(338, 92);
            this.btnSearchLoad.Name = "btnSearchLoad";
            this.btnSearchLoad.Size = new System.Drawing.Size(79, 28);
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
            // lblFacultyID
            // 
            this.lblFacultyID.AutoSize = true;
            this.lblFacultyID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFacultyID.Location = new System.Drawing.Point(206, 74);
            this.lblFacultyID.Name = "lblFacultyID";
            this.lblFacultyID.Size = new System.Drawing.Size(60, 15);
            this.lblFacultyID.TabIndex = 26;
            this.lblFacultyID.Text = "Faculty ID";
            // 
            // txtFacultyId
            // 
            this.txtFacultyId.Location = new System.Drawing.Point(185, 92);
            this.txtFacultyId.Name = "txtFacultyId";
            this.txtFacultyId.Size = new System.Drawing.Size(100, 20);
            this.txtFacultyId.TabIndex = 27;
            // 
            // lblFacultyName
            // 
            this.lblFacultyName.AutoSize = true;
            this.lblFacultyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFacultyName.Location = new System.Drawing.Point(195, 115);
            this.lblFacultyName.Name = "lblFacultyName";
            this.lblFacultyName.Size = new System.Drawing.Size(82, 15);
            this.lblFacultyName.TabIndex = 28;
            this.lblFacultyName.Text = "Faculty Name";
            // 
            // txtFacultyName
            // 
            this.txtFacultyName.Location = new System.Drawing.Point(185, 132);
            this.txtFacultyName.Name = "txtFacultyName";
            this.txtFacultyName.Size = new System.Drawing.Size(100, 20);
            this.txtFacultyName.TabIndex = 29;
            // 
            // lblSection
            // 
            this.lblSection.AutoSize = true;
            this.lblSection.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSection.Location = new System.Drawing.Point(113, 167);
            this.lblSection.Name = "lblSection";
            this.lblSection.Size = new System.Drawing.Size(123, 15);
            this.lblSection.TabIndex = 30;
            this.lblSection.Text = "Program/Department";
            // 
            // txtSection
            // 
            this.txtSection.Location = new System.Drawing.Point(116, 185);
            this.txtSection.Name = "txtSection";
            this.txtSection.Size = new System.Drawing.Size(109, 20);
            this.txtSection.TabIndex = 31;
            // 
            // txtSearchLoad
            // 
            this.txtSearchLoad.Location = new System.Drawing.Point(435, 97);
            this.txtSearchLoad.Name = "txtSearchLoad";
            this.txtSearchLoad.Size = new System.Drawing.Size(108, 20);
            this.txtSearchLoad.TabIndex = 32;
            // 
            // lblFacultyMembers
            // 
            this.lblFacultyMembers.AutoSize = true;
            this.lblFacultyMembers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFacultyMembers.ForeColor = System.Drawing.Color.Blue;
            this.lblFacultyMembers.Location = new System.Drawing.Point(435, 242);
            this.lblFacultyMembers.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFacultyMembers.Name = "lblFacultyMembers";
            this.lblFacultyMembers.Size = new System.Drawing.Size(130, 20);
            this.lblFacultyMembers.TabIndex = 33;
            this.lblFacultyMembers.Text = "Faculty Members";
            this.lblFacultyMembers.Click += new System.EventHandler(this.lblFacultyMembers_Click);
            // 
            // FacultyLoading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 450);
            this.Controls.Add(this.lblFacultyMembers);
            this.Controls.Add(this.txtSearchLoad);
            this.Controls.Add(this.txtSection);
            this.Controls.Add(this.lblSection);
            this.Controls.Add(this.txtFacultyName);
            this.Controls.Add(this.lblFacultyName);
            this.Controls.Add(this.txtFacultyId);
            this.Controls.Add(this.lblFacultyID);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtSubjectName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSubjectId);
            this.Controls.Add(this.lblSubjectId);
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblSubjectId;
        private System.Windows.Forms.DataGridView dgvLoading;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtSubjectName;
        private System.Windows.Forms.TextBox txtSubjectId;
        private System.Windows.Forms.Button btnSearchLoad;
        private System.Windows.Forms.Button btnCancelLoad;
        private System.Windows.Forms.Button btnRemoveLoad;
        private System.Windows.Forms.Button btnEditLoad;
        private System.Windows.Forms.Button btnSaveLoad;
        private System.Windows.Forms.PictureBox imgBackToMain2;
        private System.Windows.Forms.Label lblFacultyID;
        private System.Windows.Forms.TextBox txtFacultyId;
        private System.Windows.Forms.Label lblFacultyName;
        private System.Windows.Forms.TextBox txtFacultyName;
        private System.Windows.Forms.Label lblSection;
        private System.Windows.Forms.TextBox txtSection;
        private System.Windows.Forms.TextBox txtSearchLoad;
        private System.Windows.Forms.Label lblFacultyMembers;
    }
}