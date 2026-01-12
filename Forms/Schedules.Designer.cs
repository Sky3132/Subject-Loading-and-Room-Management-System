namespace __Subject_Loading_and_Room_Assignment_Monitoring_System.Forms
{
    partial class Schedules
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Schedules));
            this.panel3 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.imgBackToMain2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbSchedDay = new System.Windows.Forms.ComboBox();
            this.dgvSchedMain = new System.Windows.Forms.DataGridView();
            this.btnSchedUpdate = new System.Windows.Forms.Button();
            this.btnSchedSave = new System.Windows.Forms.Button();
            this.btnSchedRemove = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbSchedStart = new System.Windows.Forms.ComboBox();
            this.cmbSchedEnd = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbSchedSubject = new System.Windows.Forms.ComboBox();
            this.cmbSchedFaculty = new System.Windows.Forms.ComboBox();
            this.cmbSchedRoom = new System.Windows.Forms.ComboBox();
            this.cmbSchedSection = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblOpenClassSched = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgBackToMain2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchedMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.AutoSize = true;
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(25)))), ((int)(((byte)(46)))));
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.imgBackToMain2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Location = new System.Drawing.Point(-19, -1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(838, 55);
            this.panel3.TabIndex = 18;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(363, 13);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(141, 26);
            this.label9.TabIndex = 35;
            this.label9.Text = "SCHEDULE";
            // 
            // imgBackToMain2
            // 
            this.imgBackToMain2.Image = ((System.Drawing.Image)(resources.GetObject("imgBackToMain2.Image")));
            this.imgBackToMain2.Location = new System.Drawing.Point(737, 13);
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
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(301, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = " ";
            // 
            // cmbSchedDay
            // 
            this.cmbSchedDay.FormattingEnabled = true;
            this.cmbSchedDay.Location = new System.Drawing.Point(12, 90);
            this.cmbSchedDay.Name = "cmbSchedDay";
            this.cmbSchedDay.Size = new System.Drawing.Size(121, 21);
            this.cmbSchedDay.TabIndex = 19;
            // 
            // dgvSchedMain
            // 
            this.dgvSchedMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSchedMain.Location = new System.Drawing.Point(12, 283);
            this.dgvSchedMain.Margin = new System.Windows.Forms.Padding(2);
            this.dgvSchedMain.Name = "dgvSchedMain";
            this.dgvSchedMain.RowHeadersWidth = 51;
            this.dgvSchedMain.RowTemplate.Height = 24;
            this.dgvSchedMain.Size = new System.Drawing.Size(775, 156);
            this.dgvSchedMain.TabIndex = 27;
            // 
            // btnSchedUpdate
            // 
            this.btnSchedUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSchedUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(201)))), ((int)(((byte)(76)))));
            this.btnSchedUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSchedUpdate.Location = new System.Drawing.Point(164, 227);
            this.btnSchedUpdate.Name = "btnSchedUpdate";
            this.btnSchedUpdate.Size = new System.Drawing.Size(95, 40);
            this.btnSchedUpdate.TabIndex = 28;
            this.btnSchedUpdate.Text = "Update";
            this.btnSchedUpdate.UseVisualStyleBackColor = false;
            this.btnSchedUpdate.Click += new System.EventHandler(this.btnSchedUpdate_Click_1);
            // 
            // btnSchedSave
            // 
            this.btnSchedSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSchedSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(201)))), ((int)(((byte)(76)))));
            this.btnSchedSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSchedSave.Location = new System.Drawing.Point(40, 227);
            this.btnSchedSave.Name = "btnSchedSave";
            this.btnSchedSave.Size = new System.Drawing.Size(95, 40);
            this.btnSchedSave.TabIndex = 30;
            this.btnSchedSave.Text = "Save";
            this.btnSchedSave.UseVisualStyleBackColor = false;
            this.btnSchedSave.Click += new System.EventHandler(this.btnSchedSave_Click_1);
            // 
            // btnSchedRemove
            // 
            this.btnSchedRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSchedRemove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(201)))), ((int)(((byte)(76)))));
            this.btnSchedRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSchedRemove.Location = new System.Drawing.Point(291, 227);
            this.btnSchedRemove.Name = "btnSchedRemove";
            this.btnSchedRemove.Size = new System.Drawing.Size(95, 40);
            this.btnSchedRemove.TabIndex = 31;
            this.btnSchedRemove.Text = "Remove";
            this.btnSchedRemove.UseVisualStyleBackColor = false;
            this.btnSchedRemove.Click += new System.EventHandler(this.btnSchedRemove_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 70);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 17);
            this.label2.TabIndex = 32;
            this.label2.Text = "Day";
            // 
            // cmbSchedStart
            // 
            this.cmbSchedStart.FormattingEnabled = true;
            this.cmbSchedStart.Location = new System.Drawing.Point(139, 90);
            this.cmbSchedStart.Name = "cmbSchedStart";
            this.cmbSchedStart.Size = new System.Drawing.Size(121, 21);
            this.cmbSchedStart.TabIndex = 33;
            // 
            // cmbSchedEnd
            // 
            this.cmbSchedEnd.FormattingEnabled = true;
            this.cmbSchedEnd.Location = new System.Drawing.Point(266, 90);
            this.cmbSchedEnd.Name = "cmbSchedEnd";
            this.cmbSchedEnd.Size = new System.Drawing.Size(121, 21);
            this.cmbSchedEnd.TabIndex = 34;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(136, 70);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 17);
            this.label3.TabIndex = 35;
            this.label3.Text = "Start Time";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(263, 70);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 17);
            this.label4.TabIndex = 36;
            this.label4.Text = " End Time";
            // 
            // cmbSchedSubject
            // 
            this.cmbSchedSubject.FormattingEnabled = true;
            this.cmbSchedSubject.Location = new System.Drawing.Point(14, 184);
            this.cmbSchedSubject.Name = "cmbSchedSubject";
            this.cmbSchedSubject.Size = new System.Drawing.Size(121, 21);
            this.cmbSchedSubject.TabIndex = 37;
            // 
            // cmbSchedFaculty
            // 
            this.cmbSchedFaculty.FormattingEnabled = true;
            this.cmbSchedFaculty.Location = new System.Drawing.Point(141, 184);
            this.cmbSchedFaculty.Name = "cmbSchedFaculty";
            this.cmbSchedFaculty.Size = new System.Drawing.Size(121, 21);
            this.cmbSchedFaculty.TabIndex = 38;
            // 
            // cmbSchedRoom
            // 
            this.cmbSchedRoom.FormattingEnabled = true;
            this.cmbSchedRoom.Location = new System.Drawing.Point(268, 184);
            this.cmbSchedRoom.Name = "cmbSchedRoom";
            this.cmbSchedRoom.Size = new System.Drawing.Size(121, 21);
            this.cmbSchedRoom.TabIndex = 39;
            // 
            // cmbSchedSection
            // 
            this.cmbSchedSection.FormattingEnabled = true;
            this.cmbSchedSection.Location = new System.Drawing.Point(395, 184);
            this.cmbSchedSection.Name = "cmbSchedSection";
            this.cmbSchedSection.Size = new System.Drawing.Size(121, 21);
            this.cmbSchedSection.TabIndex = 40;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(11, 164);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 17);
            this.label5.TabIndex = 41;
            this.label5.Text = "Subject";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(138, 164);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 17);
            this.label6.TabIndex = 42;
            this.label6.Text = "Faculty";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(268, 164);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 17);
            this.label7.TabIndex = 43;
            this.label7.Text = "Room";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(392, 164);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 17);
            this.label8.TabIndex = 44;
            this.label8.Text = "Section";
            // 
            // lblOpenClassSched
            // 
            this.lblOpenClassSched.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblOpenClassSched.AutoSize = true;
            this.lblOpenClassSched.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblOpenClassSched.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOpenClassSched.ForeColor = System.Drawing.Color.Blue;
            this.lblOpenClassSched.Location = new System.Drawing.Point(702, 247);
            this.lblOpenClassSched.Name = "lblOpenClassSched";
            this.lblOpenClassSched.Size = new System.Drawing.Size(84, 20);
            this.lblOpenClassSched.TabIndex = 45;
            this.lblOpenClassSched.Text = "Schedules";
            this.lblOpenClassSched.Click += new System.EventHandler(this.lblOpenClassSched_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(525, 70);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(263, 159);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 46;
            this.pictureBox1.TabStop = false;
            // 
            // Schedules
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblOpenClassSched);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbSchedSection);
            this.Controls.Add(this.cmbSchedRoom);
            this.Controls.Add(this.cmbSchedFaculty);
            this.Controls.Add(this.cmbSchedSubject);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbSchedEnd);
            this.Controls.Add(this.cmbSchedStart);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSchedRemove);
            this.Controls.Add(this.btnSchedSave);
            this.Controls.Add(this.btnSchedUpdate);
            this.Controls.Add(this.dgvSchedMain);
            this.Controls.Add(this.cmbSchedDay);
            this.Controls.Add(this.panel3);
            this.Name = "Schedules";
            this.Text = "Schedules";
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgBackToMain2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchedMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox imgBackToMain2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbSchedDay;
        private System.Windows.Forms.DataGridView dgvSchedMain;
        private System.Windows.Forms.Button btnSchedUpdate;
        private System.Windows.Forms.Button btnSchedSave;
        private System.Windows.Forms.Button btnSchedRemove;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbSchedStart;
        private System.Windows.Forms.ComboBox cmbSchedEnd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbSchedSubject;
        private System.Windows.Forms.ComboBox cmbSchedFaculty;
        private System.Windows.Forms.ComboBox cmbSchedRoom;
        private System.Windows.Forms.ComboBox cmbSchedSection;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblOpenClassSched;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}