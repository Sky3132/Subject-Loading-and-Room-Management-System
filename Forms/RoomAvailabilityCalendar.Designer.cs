namespace __Subject_Loading_and_Room_Assignment_Monitoring_System.Forms
{
    partial class RoomAvailabilityCalendar
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RoomAvailabilityCalendar));
            this.monthCalendarRooms = new System.Windows.Forms.MonthCalendar();
            this.dgvRoomDetails = new System.Windows.Forms.DataGridView();
            this.lblMonthYear = new System.Windows.Forms.Label();
            this.lblSelectedDate = new System.Windows.Forms.Label();
            this.btnPreviousMonth = new System.Windows.Forms.Button();
            this.btnNextMonth = new System.Windows.Forms.Button();
            this.btnToday = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoomDetails)).BeginInit();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // monthCalendarRooms
            // 
            this.monthCalendarRooms.Location = new System.Drawing.Point(9, 81);
            this.monthCalendarRooms.Margin = new System.Windows.Forms.Padding(7);
            this.monthCalendarRooms.Name = "monthCalendarRooms";
            this.monthCalendarRooms.TabIndex = 1;
            this.monthCalendarRooms.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendarRooms_DateSelected);
            // 
            // dgvRoomDetails
            // 
            this.dgvRoomDetails.AllowUserToAddRows = false;
            this.dgvRoomDetails.AllowUserToDeleteRows = false;
            this.dgvRoomDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRoomDetails.Location = new System.Drawing.Point(265, 81);
            this.dgvRoomDetails.Margin = new System.Windows.Forms.Padding(2);
            this.dgvRoomDetails.Name = "dgvRoomDetails";
            this.dgvRoomDetails.ReadOnly = true;
            this.dgvRoomDetails.RowHeadersWidth = 51;
            this.dgvRoomDetails.Size = new System.Drawing.Size(545, 325);
            this.dgvRoomDetails.TabIndex = 8;
            this.dgvRoomDetails.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRoomDetails_CellContentClick);
            // 
            // lblMonthYear
            // 
            this.lblMonthYear.AutoSize = true;
            this.lblMonthYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonthYear.Location = new System.Drawing.Point(9, 61);
            this.lblMonthYear.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMonthYear.Name = "lblMonthYear";
            this.lblMonthYear.Size = new System.Drawing.Size(117, 20);
            this.lblMonthYear.TabIndex = 2;
            this.lblMonthYear.Text = "January 2025";
            // 
            // lblSelectedDate
            // 
            this.lblSelectedDate.AutoSize = true;
            this.lblSelectedDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedDate.Location = new System.Drawing.Point(281, 59);
            this.lblSelectedDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSelectedDate.Name = "lblSelectedDate";
            this.lblSelectedDate.Size = new System.Drawing.Size(172, 18);
            this.lblSelectedDate.TabIndex = 7;
            this.lblSelectedDate.Text = "Date: January 1, 2025";
            // 
            // btnPreviousMonth
            // 
            this.btnPreviousMonth.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(201)))), ((int)(((byte)(76)))));
            this.btnPreviousMonth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPreviousMonth.Location = new System.Drawing.Point(9, 259);
            this.btnPreviousMonth.Margin = new System.Windows.Forms.Padding(2);
            this.btnPreviousMonth.Name = "btnPreviousMonth";
            this.btnPreviousMonth.Size = new System.Drawing.Size(75, 28);
            this.btnPreviousMonth.TabIndex = 3;
            this.btnPreviousMonth.Text = "< Previous";
            this.btnPreviousMonth.UseVisualStyleBackColor = false;
            this.btnPreviousMonth.Click += new System.EventHandler(this.btnPreviousMonth_Click);
            // 
            // btnNextMonth
            // 
            this.btnNextMonth.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(201)))), ((int)(((byte)(76)))));
            this.btnNextMonth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNextMonth.Location = new System.Drawing.Point(88, 259);
            this.btnNextMonth.Margin = new System.Windows.Forms.Padding(2);
            this.btnNextMonth.Name = "btnNextMonth";
            this.btnNextMonth.Size = new System.Drawing.Size(75, 28);
            this.btnNextMonth.TabIndex = 4;
            this.btnNextMonth.Text = "Next >";
            this.btnNextMonth.UseVisualStyleBackColor = false;
            this.btnNextMonth.Click += new System.EventHandler(this.btnNextMonth_Click);
            // 
            // btnToday
            // 
            this.btnToday.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(201)))), ((int)(((byte)(76)))));
            this.btnToday.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToday.ForeColor = System.Drawing.Color.Black;
            this.btnToday.Location = new System.Drawing.Point(13, 309);
            this.btnToday.Margin = new System.Windows.Forms.Padding(2);
            this.btnToday.Name = "btnToday";
            this.btnToday.Size = new System.Drawing.Size(75, 28);
            this.btnToday.TabIndex = 5;
            this.btnToday.Text = "Today";
            this.btnToday.UseVisualStyleBackColor = false;
            this.btnToday.Click += new System.EventHandler(this.btnToday_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(201)))), ((int)(((byte)(76)))));
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.ForeColor = System.Drawing.Color.Black;
            this.btnRefresh.Location = new System.Drawing.Point(92, 309);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(2);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 28);
            this.btnRefresh.TabIndex = 6;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Perpetua Titling MT", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(279, 16);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(388, 26);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "ROOM AVAILABILITY CALENDAR";
            // 
            // pnlHeader
            // 
            this.pnlHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlHeader.AutoSize = true;
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(25)))), ((int)(((byte)(46)))));
            this.pnlHeader.Controls.Add(this.pictureBox1);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(2);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(828, 57);
            this.pnlHeader.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(744, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(81, 39);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 34;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // RoomAvailabilityCalendar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 422);
            this.Controls.Add(this.dgvRoomDetails);
            this.Controls.Add(this.lblSelectedDate);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnToday);
            this.Controls.Add(this.btnNextMonth);
            this.Controls.Add(this.btnPreviousMonth);
            this.Controls.Add(this.lblMonthYear);
            this.Controls.Add(this.monthCalendarRooms);
            this.Controls.Add(this.pnlHeader);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "RoomAvailabilityCalendar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Room Availability Calendar";
            this.Load += new System.EventHandler(this.RoomAvailabilityCalendar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoomDetails)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

       

        private System.Windows.Forms.MonthCalendar monthCalendarRooms;
        private System.Windows.Forms.DataGridView dgvRoomDetails;
        private System.Windows.Forms.Label lblMonthYear;
        private System.Windows.Forms.Label lblSelectedDate;
        private System.Windows.Forms.Button btnPreviousMonth;
        private System.Windows.Forms.Button btnNextMonth;
        private System.Windows.Forms.Button btnToday;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}