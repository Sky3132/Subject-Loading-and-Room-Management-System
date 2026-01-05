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
            this.lblRoomAssignment = new System.Windows.Forms.Label();
            this.imgBackToMain2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblAssignName = new System.Windows.Forms.Label();
            this.lblFacultyName = new System.Windows.Forms.Label();
            this.cmbFacultyAssign = new System.Windows.Forms.ComboBox();
            this.cmbRoom = new System.Windows.Forms.ComboBox();
            this.dgvAssignments = new System.Windows.Forms.DataGridView();
            this.btnSaveAssign = new System.Windows.Forms.Button();
            this.btnRemoveAssign = new System.Windows.Forms.Button();
            this.btnEditAssign = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbDay = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtStartTime = new System.Windows.Forms.TextBox();
            this.txtEndTime = new System.Windows.Forms.TextBox();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgBackToMain2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAssignments)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.AutoSize = true;
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(25)))), ((int)(((byte)(46)))));
            this.panel3.Controls.Add(this.lblRoomAssignment);
            this.panel3.Controls.Add(this.imgBackToMain2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Location = new System.Drawing.Point(0, 1);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1117, 78);
            this.panel3.TabIndex = 17;
            // 
            // lblRoomAssignment
            // 
            this.lblRoomAssignment.AutoSize = true;
            this.lblRoomAssignment.Font = new System.Drawing.Font("Perpetua Titling MT", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoomAssignment.ForeColor = System.Drawing.Color.Transparent;
            this.lblRoomAssignment.Location = new System.Drawing.Point(401, 16);
            this.lblRoomAssignment.Name = "lblRoomAssignment";
            this.lblRoomAssignment.Size = new System.Drawing.Size(326, 33);
            this.lblRoomAssignment.TabIndex = 34;
            this.lblRoomAssignment.Text = "ROOMS ASSIGNMENT";
            // 
            // imgBackToMain2
            // 
            this.imgBackToMain2.Image = ((System.Drawing.Image)(resources.GetObject("imgBackToMain2.Image")));
            this.imgBackToMain2.Location = new System.Drawing.Point(967, 16);
            this.imgBackToMain2.Margin = new System.Windows.Forms.Padding(4);
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
            this.label1.Location = new System.Drawing.Point(401, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = " ";
            // 
            // lblAssignName
            // 
            this.lblAssignName.AutoSize = true;
            this.lblAssignName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAssignName.Location = new System.Drawing.Point(28, 119);
            this.lblAssignName.Name = "lblAssignName";
            this.lblAssignName.Size = new System.Drawing.Size(102, 20);
            this.lblAssignName.TabIndex = 18;
            this.lblAssignName.Text = "Room Name";
            // 
            // lblFacultyName
            // 
            this.lblFacultyName.AutoSize = true;
            this.lblFacultyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFacultyName.Location = new System.Drawing.Point(213, 119);
            this.lblFacultyName.Name = "lblFacultyName";
            this.lblFacultyName.Size = new System.Drawing.Size(112, 20);
            this.lblFacultyName.TabIndex = 19;
            this.lblFacultyName.Text = "Faculty Name";
            // 
            // cmbFacultyAssign
            // 
            this.cmbFacultyAssign.FormattingEnabled = true;
            this.cmbFacultyAssign.Location = new System.Drawing.Point(217, 142);
            this.cmbFacultyAssign.Name = "cmbFacultyAssign";
            this.cmbFacultyAssign.Size = new System.Drawing.Size(152, 24);
            this.cmbFacultyAssign.TabIndex = 21;
            // 
            // cmbRoom
            // 
            this.cmbRoom.FormattingEnabled = true;
            this.cmbRoom.Location = new System.Drawing.Point(32, 142);
            this.cmbRoom.Name = "cmbRoom";
            this.cmbRoom.Size = new System.Drawing.Size(152, 24);
            this.cmbRoom.TabIndex = 22;
            // 
            // dgvAssignments
            // 
            this.dgvAssignments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAssignments.Location = new System.Drawing.Point(0, 361);
            this.dgvAssignments.Name = "dgvAssignments";
            this.dgvAssignments.RowHeadersWidth = 51;
            this.dgvAssignments.RowTemplate.Height = 24;
            this.dgvAssignments.Size = new System.Drawing.Size(1113, 236);
            this.dgvAssignments.TabIndex = 23;
            this.dgvAssignments.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAssignments_CellClick);
            // 
            // btnSaveAssign
            // 
            this.btnSaveAssign.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnSaveAssign.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(201)))), ((int)(((byte)(76)))));
            this.btnSaveAssign.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveAssign.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveAssign.ForeColor = System.Drawing.Color.Black;
            this.btnSaveAssign.Location = new System.Drawing.Point(32, 285);
            this.btnSaveAssign.Margin = new System.Windows.Forms.Padding(4);
            this.btnSaveAssign.Name = "btnSaveAssign";
            this.btnSaveAssign.Size = new System.Drawing.Size(127, 49);
            this.btnSaveAssign.TabIndex = 26;
            this.btnSaveAssign.Text = "Save";
            this.btnSaveAssign.UseVisualStyleBackColor = false;
            this.btnSaveAssign.Click += new System.EventHandler(this.btnSaveAssign_Click);
            // 
            // btnRemoveAssign
            // 
            this.btnRemoveAssign.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveAssign.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(201)))), ((int)(((byte)(76)))));
            this.btnRemoveAssign.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveAssign.Location = new System.Drawing.Point(339, 285);
            this.btnRemoveAssign.Margin = new System.Windows.Forms.Padding(4);
            this.btnRemoveAssign.Name = "btnRemoveAssign";
            this.btnRemoveAssign.Size = new System.Drawing.Size(127, 49);
            this.btnRemoveAssign.TabIndex = 28;
            this.btnRemoveAssign.Text = "Remove";
            this.btnRemoveAssign.UseVisualStyleBackColor = false;
            this.btnRemoveAssign.Click += new System.EventHandler(this.btnRemoveAssign_Click);
            // 
            // btnEditAssign
            // 
            this.btnEditAssign.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditAssign.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(201)))), ((int)(((byte)(76)))));
            this.btnEditAssign.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditAssign.Location = new System.Drawing.Point(185, 285);
            this.btnEditAssign.Margin = new System.Windows.Forms.Padding(4);
            this.btnEditAssign.Name = "btnEditAssign";
            this.btnEditAssign.Size = new System.Drawing.Size(127, 49);
            this.btnEditAssign.TabIndex = 27;
            this.btnEditAssign.Text = "Edit";
            this.btnEditAssign.UseVisualStyleBackColor = false;
            this.btnEditAssign.Click += new System.EventHandler(this.btnEditAssign_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(391, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 20);
            this.label2.TabIndex = 29;
            this.label2.Text = "Day";
            // 
            // cmbDay
            // 
            this.cmbDay.FormattingEnabled = true;
            this.cmbDay.Location = new System.Drawing.Point(395, 142);
            this.cmbDay.Name = "cmbDay";
            this.cmbDay.Size = new System.Drawing.Size(152, 24);
            this.cmbDay.TabIndex = 30;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(28, 187);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 20);
            this.label3.TabIndex = 31;
            this.label3.Text = "Start TIme";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(213, 187);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 20);
            this.label4.TabIndex = 32;
            this.label4.Text = "End Time";
            // 
            // txtStartTime
            // 
            this.txtStartTime.Location = new System.Drawing.Point(32, 210);
            this.txtStartTime.Name = "txtStartTime";
            this.txtStartTime.Size = new System.Drawing.Size(105, 22);
            this.txtStartTime.TabIndex = 33;
            // 
            // txtEndTime
            // 
            this.txtEndTime.Location = new System.Drawing.Point(217, 210);
            this.txtEndTime.Name = "txtEndTime";
            this.txtEndTime.Size = new System.Drawing.Size(105, 22);
            this.txtEndTime.TabIndex = 34;
            // 
            // RoomAssignment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1113, 594);
            this.Controls.Add(this.txtEndTime);
            this.Controls.Add(this.txtStartTime);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbDay);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSaveAssign);
            this.Controls.Add(this.btnRemoveAssign);
            this.Controls.Add(this.btnEditAssign);
            this.Controls.Add(this.dgvAssignments);
            this.Controls.Add(this.cmbRoom);
            this.Controls.Add(this.cmbFacultyAssign);
            this.Controls.Add(this.lblFacultyName);
            this.Controls.Add(this.lblAssignName);
            this.Controls.Add(this.panel3);
            this.Name = "RoomAssignment";
            this.Text = "RoomAssignment";
            this.Load += new System.EventHandler(this.RoomAssignment_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgBackToMain2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAssignments)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblRoomAssignment;
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbDay;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtStartTime;
        private System.Windows.Forms.TextBox txtEndTime;
    }
}