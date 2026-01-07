namespace __Subject_Loading_and_Room_Assignment_Monitoring_System.Forms
{
    partial class ucDashboard
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Panel panel1;
            System.Windows.Forms.Panel panel2;
            System.Windows.Forms.Panel panel3;
            this.lblTotalSubjects = new System.Windows.Forms.Label();
            this.lblTotalRooms = new System.Windows.Forms.Label();
            this.lblTotalSchedules = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.flpNotifications = new System.Windows.Forms.FlowLayoutPanel();
            panel1 = new System.Windows.Forms.Panel();
            panel2 = new System.Windows.Forms.Panel();
            panel3 = new System.Windows.Forms.Panel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            panel1.BackColor = System.Drawing.Color.Blue;
            panel1.Controls.Add(this.lblTotalSubjects);
            panel1.ForeColor = System.Drawing.SystemColors.ControlText;
            panel1.Location = new System.Drawing.Point(18, 49);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(176, 152);
            panel1.TabIndex = 0;
            // 
            // lblTotalSubjects
            // 
            this.lblTotalSubjects.AutoSize = true;
            this.lblTotalSubjects.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalSubjects.ForeColor = System.Drawing.Color.Coral;
            this.lblTotalSubjects.Location = new System.Drawing.Point(73, 62);
            this.lblTotalSubjects.Name = "lblTotalSubjects";
            this.lblTotalSubjects.Size = new System.Drawing.Size(24, 25);
            this.lblTotalSubjects.TabIndex = 1;
            this.lblTotalSubjects.Text = "0";
            // 
            // panel2
            // 
            panel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            panel2.BackColor = System.Drawing.Color.Brown;
            panel2.Controls.Add(this.lblTotalRooms);
            panel2.ForeColor = System.Drawing.SystemColors.ControlText;
            panel2.Location = new System.Drawing.Point(227, 49);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(176, 152);
            panel2.TabIndex = 4;
            // 
            // lblTotalRooms
            // 
            this.lblTotalRooms.AutoSize = true;
            this.lblTotalRooms.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalRooms.ForeColor = System.Drawing.Color.Coral;
            this.lblTotalRooms.Location = new System.Drawing.Point(73, 62);
            this.lblTotalRooms.Name = "lblTotalRooms";
            this.lblTotalRooms.Size = new System.Drawing.Size(24, 25);
            this.lblTotalRooms.TabIndex = 1;
            this.lblTotalRooms.Text = "0";
            // 
            // panel3
            // 
            panel3.Anchor = System.Windows.Forms.AnchorStyles.None;
            panel3.BackColor = System.Drawing.Color.Yellow;
            panel3.Controls.Add(this.lblTotalSchedules);
            panel3.ForeColor = System.Drawing.SystemColors.ControlText;
            panel3.Location = new System.Drawing.Point(439, 49);
            panel3.Name = "panel3";
            panel3.Size = new System.Drawing.Size(176, 152);
            panel3.TabIndex = 5;
            // 
            // lblTotalSchedules
            // 
            this.lblTotalSchedules.AutoSize = true;
            this.lblTotalSchedules.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalSchedules.ForeColor = System.Drawing.Color.Coral;
            this.lblTotalSchedules.Location = new System.Drawing.Point(73, 62);
            this.lblTotalSchedules.Name = "lblTotalSchedules";
            this.lblTotalSchedules.Size = new System.Drawing.Size(24, 25);
            this.lblTotalSchedules.TabIndex = 1;
            this.lblTotalSchedules.Text = "0";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(74, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Total Subjects";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(277, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Total Rooms";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(480, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Active Schedules";
            // 
            // flpNotifications
            // 
            this.flpNotifications.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.flpNotifications.AutoScroll = true;
            this.flpNotifications.AutoSize = true;
            this.flpNotifications.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpNotifications.Location = new System.Drawing.Point(18, 236);
            this.flpNotifications.Name = "flpNotifications";
            this.flpNotifications.Size = new System.Drawing.Size(597, 140);
            this.flpNotifications.TabIndex = 7;
            this.flpNotifications.WrapContents = false;
            // 
            // ucDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.flpNotifications);
            this.Controls.Add(this.label3);
            this.Controls.Add(panel3);
            this.Controls.Add(panel2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(panel1);
            this.Name = "ucDashboard";
            this.Size = new System.Drawing.Size(637, 393);
            this.Load += new System.EventHandler(this.ucDashboard_Load);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTotalSubjects;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTotalRooms;
        private System.Windows.Forms.Label lblTotalSchedules;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FlowLayoutPanel flpNotifications;
    }
}
