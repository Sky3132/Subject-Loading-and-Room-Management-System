namespace __Subject_Loading_and_Room_Assignment_Monitoring_System.Forms
{
    partial class RoomAssignment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RoomAssignment));
            this.panel3 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.imgBackToMain2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnViewReport = new System.Windows.Forms.Button();
            this.btnViewCalendar = new System.Windows.Forms.Button();
            this.lblAssignName = new System.Windows.Forms.Label();
            this.lblFacultyName = new System.Windows.Forms.Label();
            this.cmbFacultyAssign = new System.Windows.Forms.ComboBox();
            this.cmbRoom = new System.Windows.Forms.ComboBox();
            this.dgvAssignments = new System.Windows.Forms.DataGridView();
            this.btnSaveAssign = new System.Windows.Forms.Button();
            this.btnRemoveAssign = new System.Windows.Forms.Button();
            this.btnEditAssign = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtSearchAssign = new System.Windows.Forms.TextBox();
            this.btnSearchAssign = new System.Windows.Forms.Button();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgBackToMain2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAssignments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.AutoSize = true;
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(25)))), ((int)(((byte)(46)))));
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.imgBackToMain2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Location = new System.Drawing.Point(0, 1);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1075, 82);
            this.panel3.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Perpetua Titling MT", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(401, 32);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(315, 32);
            this.label5.TabIndex = 35;
            this.label5.Text = "ROOMS ASSIGNMENT";
            // 
            // imgBackToMain2
            // 
            this.imgBackToMain2.Image = ((System.Drawing.Image)(resources.GetObject("imgBackToMain2.Image")));
            this.imgBackToMain2.Location = new System.Drawing.Point(963, 16);
            this.imgBackToMain2.Margin = new System.Windows.Forms.Padding(4);
            this.imgBackToMain2.Name = "imgBackToMain2";
            this.imgBackToMain2.Size = new System.Drawing.Size(108, 48);
            this.imgBackToMain2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgBackToMain2.TabIndex = 33;
            this.imgBackToMain2.TabStop = false;
            this.imgBackToMain2.Click += new System.EventHandler(this.imgBackToMain2_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Perpetua Titling MT", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(401, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = " ";
            // 
            // btnViewReport
            // 
            this.btnViewReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(201)))), ((int)(((byte)(76)))));
            this.btnViewReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewReport.ForeColor = System.Drawing.Color.Black;
            this.btnViewReport.Location = new System.Drawing.Point(872, 306);
            this.btnViewReport.Margin = new System.Windows.Forms.Padding(4);
            this.btnViewReport.Name = "btnViewReport";
            this.btnViewReport.Size = new System.Drawing.Size(144, 36);
            this.btnViewReport.TabIndex = 38;
            this.btnViewReport.Text = "View Report";
            this.btnViewReport.UseVisualStyleBackColor = false;
            this.btnViewReport.Click += new System.EventHandler(this.btnViewReport_Click);
            // 
            // btnViewCalendar
            // 
            this.btnViewCalendar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(201)))), ((int)(((byte)(76)))));
            this.btnViewCalendar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewCalendar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewCalendar.ForeColor = System.Drawing.Color.Black;
            this.btnViewCalendar.Location = new System.Drawing.Point(707, 306);
            this.btnViewCalendar.Margin = new System.Windows.Forms.Padding(4);
            this.btnViewCalendar.Name = "btnViewCalendar";
            this.btnViewCalendar.Size = new System.Drawing.Size(144, 36);
            this.btnViewCalendar.TabIndex = 37;
            this.btnViewCalendar.Text = "View Calendar";
            this.btnViewCalendar.UseVisualStyleBackColor = false;
            this.btnViewCalendar.Click += new System.EventHandler(this.btnViewCalendar_Click_1);
            // 
            // lblAssignName
            // 
            this.lblAssignName.AutoSize = true;
            this.lblAssignName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAssignName.Location = new System.Drawing.Point(61, 117);
            this.lblAssignName.Name = "lblAssignName";
            this.lblAssignName.Size = new System.Drawing.Size(201, 20);
            this.lblAssignName.TabIndex = 18;
            this.lblAssignName.Text = "Room Name and Campus";
            // 
            // lblFacultyName
            // 
            this.lblFacultyName.AutoSize = true;
            this.lblFacultyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFacultyName.Location = new System.Drawing.Point(61, 175);
            this.lblFacultyName.Name = "lblFacultyName";
            this.lblFacultyName.Size = new System.Drawing.Size(139, 20);
            this.lblFacultyName.TabIndex = 19;
            this.lblFacultyName.Text = "Faculty and Code";
            // 
            // cmbFacultyAssign
            // 
            this.cmbFacultyAssign.FormattingEnabled = true;
            this.cmbFacultyAssign.Location = new System.Drawing.Point(65, 197);
            this.cmbFacultyAssign.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbFacultyAssign.Name = "cmbFacultyAssign";
            this.cmbFacultyAssign.Size = new System.Drawing.Size(152, 24);
            this.cmbFacultyAssign.TabIndex = 21;
            // 
            // cmbRoom
            // 
            this.cmbRoom.FormattingEnabled = true;
            this.cmbRoom.Location = new System.Drawing.Point(65, 139);
            this.cmbRoom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbRoom.Name = "cmbRoom";
            this.cmbRoom.Size = new System.Drawing.Size(197, 24);
            this.cmbRoom.TabIndex = 22;
            // 
            // dgvAssignments
            // 
            this.dgvAssignments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAssignments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAssignments.Location = new System.Drawing.Point(15, 354);
            this.dgvAssignments.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvAssignments.Name = "dgvAssignments";
            this.dgvAssignments.RowHeadersWidth = 51;
            this.dgvAssignments.RowTemplate.Height = 24;
            this.dgvAssignments.Size = new System.Drawing.Size(1037, 186);
            this.dgvAssignments.TabIndex = 23;
            // 
            // btnSaveAssign
            // 
            this.btnSaveAssign.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnSaveAssign.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(201)))), ((int)(((byte)(76)))));
            this.btnSaveAssign.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveAssign.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveAssign.ForeColor = System.Drawing.Color.Black;
            this.btnSaveAssign.Location = new System.Drawing.Point(27, 293);
            this.btnSaveAssign.Margin = new System.Windows.Forms.Padding(4);
            this.btnSaveAssign.Name = "btnSaveAssign";
            this.btnSaveAssign.Size = new System.Drawing.Size(127, 49);
            this.btnSaveAssign.TabIndex = 26;
            this.btnSaveAssign.Text = "Save";
            this.btnSaveAssign.UseVisualStyleBackColor = false;
            // 
            // btnRemoveAssign
            // 
            this.btnRemoveAssign.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveAssign.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(201)))), ((int)(((byte)(76)))));
            this.btnRemoveAssign.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveAssign.Location = new System.Drawing.Point(289, 293);
            this.btnRemoveAssign.Margin = new System.Windows.Forms.Padding(4);
            this.btnRemoveAssign.Name = "btnRemoveAssign";
            this.btnRemoveAssign.Size = new System.Drawing.Size(127, 49);
            this.btnRemoveAssign.TabIndex = 28;
            this.btnRemoveAssign.Text = "Remove";
            this.btnRemoveAssign.UseVisualStyleBackColor = false;
            // 
            // btnEditAssign
            // 
            this.btnEditAssign.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditAssign.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(201)))), ((int)(((byte)(76)))));
            this.btnEditAssign.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditAssign.Location = new System.Drawing.Point(162, 293);
            this.btnEditAssign.Margin = new System.Windows.Forms.Padding(4);
            this.btnEditAssign.Name = "btnEditAssign";
            this.btnEditAssign.Size = new System.Drawing.Size(119, 49);
            this.btnEditAssign.TabIndex = 27;
            this.btnEditAssign.Text = "Edit";
            this.btnEditAssign.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(667, 87);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(351, 196);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 36;
            this.pictureBox1.TabStop = false;
            // 
            // txtSearchAssign
            // 
            this.txtSearchAssign.Location = new System.Drawing.Point(558, 314);
            this.txtSearchAssign.Name = "txtSearchAssign";
            this.txtSearchAssign.Size = new System.Drawing.Size(140, 22);
            this.txtSearchAssign.TabIndex = 39;
            // 
            // btnSearchAssign
            // 
            this.btnSearchAssign.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearchAssign.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(201)))), ((int)(((byte)(76)))));
            this.btnSearchAssign.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchAssign.Location = new System.Drawing.Point(424, 294);
            this.btnSearchAssign.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearchAssign.Name = "btnSearchAssign";
            this.btnSearchAssign.Size = new System.Drawing.Size(127, 49);
            this.btnSearchAssign.TabIndex = 40;
            this.btnSearchAssign.Text = "Search";
            this.btnSearchAssign.UseVisualStyleBackColor = false;
            this.btnSearchAssign.Click += new System.EventHandler(this.btnSearchAssign_Click);
            // 
            // RoomAssignment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.btnSearchAssign);
            this.Controls.Add(this.txtSearchAssign);
            this.Controls.Add(this.btnViewReport);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnViewCalendar);
            this.Controls.Add(this.btnSaveAssign);
            this.Controls.Add(this.btnRemoveAssign);
            this.Controls.Add(this.btnEditAssign);
            this.Controls.Add(this.dgvAssignments);
            this.Controls.Add(this.cmbRoom);
            this.Controls.Add(this.cmbFacultyAssign);
            this.Controls.Add(this.lblFacultyName);
            this.Controls.Add(this.lblAssignName);
            this.Controls.Add(this.panel3);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "RoomAssignment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RoomAssignment";
            this.Load += new System.EventHandler(this.RoomAssignment_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgBackToMain2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAssignments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox imgBackToMain2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblAssignName;
        private System.Windows.Forms.Label lblFacultyName;
        private System.Windows.Forms.ComboBox cmbFacultyAssign;
        private System.Windows.Forms.ComboBox cmbRoom;
        private System.Windows.Forms.DataGridView dgvAssignments;
        private System.Windows.Forms.Button btnSaveAssign;
        private System.Windows.Forms.Button btnRemoveAssign;
        private System.Windows.Forms.Button btnEditAssign;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnViewCalendar;
        private System.Windows.Forms.Button btnViewReport;
        private System.Windows.Forms.TextBox txtSearchAssign;
        private System.Windows.Forms.Button btnSearchAssign;
    }
}