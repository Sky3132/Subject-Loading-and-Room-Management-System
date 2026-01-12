namespace __Subject_Loading_and_Room_Assignment_Monitoring_System.Forms
{
    partial class FacultyDashboardForm
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.mainContentPanel = new System.Windows.Forms.Panel();
            this.btnFaculty = new System.Windows.Forms.Button();
            this.btnSchedules = new System.Windows.Forms.Button();
            this.btnRequestChange = new System.Windows.Forms.Button();
            this.btnViewRooms = new System.Windows.Forms.Button();
            this.btnViewSchedule = new System.Windows.Forms.Button();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.AutoSize = true;
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(25)))), ((int)(((byte)(46)))));
            this.panel3.Controls.Add(this.btnSchedules);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Location = new System.Drawing.Point(-19, 12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(838, 56);
            this.panel3.TabIndex = 20;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(325, 13);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(276, 26);
            this.label9.TabIndex = 36;
            this.label9.Text = "FACULTY DASHBOARD";
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
            // mainContentPanel
            // 
            this.mainContentPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainContentPanel.AutoSize = true;
            this.mainContentPanel.Location = new System.Drawing.Point(241, 74);
            this.mainContentPanel.Name = "mainContentPanel";
            this.mainContentPanel.Size = new System.Drawing.Size(564, 380);
            this.mainContentPanel.TabIndex = 21;
            this.mainContentPanel.Visible = false;
            // 
            // btnFaculty
            // 
            this.btnFaculty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(201)))), ((int)(((byte)(76)))));
            this.btnFaculty.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFaculty.Location = new System.Drawing.Point(43, 78);
            this.btnFaculty.Name = "btnFaculty";
            this.btnFaculty.Size = new System.Drawing.Size(143, 40);
            this.btnFaculty.TabIndex = 10;
            this.btnFaculty.Text = "Faculty ";
            this.btnFaculty.UseVisualStyleBackColor = false;
            // 
            // btnSchedules
            // 
            this.btnSchedules.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnSchedules.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSchedules.Location = new System.Drawing.Point(723, 13);
            this.btnSchedules.Name = "btnSchedules";
            this.btnSchedules.Size = new System.Drawing.Size(84, 25);
            this.btnSchedules.TabIndex = 9;
            this.btnSchedules.Text = "LOG OUT";
            this.btnSchedules.UseVisualStyleBackColor = false;
            // 
            // btnRequestChange
            // 
            this.btnRequestChange.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(201)))), ((int)(((byte)(76)))));
            this.btnRequestChange.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRequestChange.Location = new System.Drawing.Point(43, 216);
            this.btnRequestChange.Name = "btnRequestChange";
            this.btnRequestChange.Size = new System.Drawing.Size(143, 40);
            this.btnRequestChange.TabIndex = 8;
            this.btnRequestChange.Text = "Request Schedule Change";
            this.btnRequestChange.UseVisualStyleBackColor = false;
            // 
            // btnViewRooms
            // 
            this.btnViewRooms.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(201)))), ((int)(((byte)(76)))));
            this.btnViewRooms.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewRooms.Location = new System.Drawing.Point(43, 170);
            this.btnViewRooms.Name = "btnViewRooms";
            this.btnViewRooms.Size = new System.Drawing.Size(143, 40);
            this.btnViewRooms.TabIndex = 7;
            this.btnViewRooms.Text = "View Room Assignments";
            this.btnViewRooms.UseVisualStyleBackColor = false;
            // 
            // btnViewSchedule
            // 
            this.btnViewSchedule.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(201)))), ((int)(((byte)(76)))));
            this.btnViewSchedule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewSchedule.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewSchedule.ForeColor = System.Drawing.Color.Black;
            this.btnViewSchedule.Location = new System.Drawing.Point(43, 124);
            this.btnViewSchedule.Name = "btnViewSchedule";
            this.btnViewSchedule.Size = new System.Drawing.Size(143, 40);
            this.btnViewSchedule.TabIndex = 6;
            this.btnViewSchedule.Text = "View My Schedule ";
            this.btnViewSchedule.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnViewSchedule.UseVisualStyleBackColor = false;
            // 
            // FacultyDashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnFaculty);
            this.Controls.Add(this.mainContentPanel);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.btnRequestChange);
            this.Controls.Add(this.btnViewRooms);
            this.Controls.Add(this.btnViewSchedule);
            this.Name = "FacultyDashboardForm";
            this.Text = "FacultyDashboardForm";
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel mainContentPanel;
        private System.Windows.Forms.Button btnSchedules;
        private System.Windows.Forms.Button btnFaculty;
        private System.Windows.Forms.Button btnRequestChange;
        private System.Windows.Forms.Button btnViewRooms;
        private System.Windows.Forms.Button btnViewSchedule;
    }
}