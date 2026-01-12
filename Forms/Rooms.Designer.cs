namespace __Subject_Loading_and_Room_Assignment_Monitoring_System.Forms
{
    partial class Rooms
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Rooms));
            this.lblRoomType = new System.Windows.Forms.Label();
            this.lblRoomCapacity = new System.Windows.Forms.Label();
            this.txtRoomCapacity = new System.Windows.Forms.TextBox();
            this.btnAddRoom = new System.Windows.Forms.Button();
            this.btnRemoveRoom = new System.Windows.Forms.Button();
            this.btnEditRoom = new System.Windows.Forms.Button();
            this.dgvRooms = new System.Windows.Forms.DataGridView();
            this.btnSearchRoom = new System.Windows.Forms.Button();
            this.cmbSearchRoom = new System.Windows.Forms.ComboBox();
            this.lblRoomAssignment = new System.Windows.Forms.Label();
            this.txtRoomName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.imgBackToMain2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cmbRoomType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rbMain = new System.Windows.Forms.RadioButton();
            this.rbVisayan = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRooms)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgBackToMain2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRoomType
            // 
            this.lblRoomType.AutoSize = true;
            this.lblRoomType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoomType.Location = new System.Drawing.Point(208, 149);
            this.lblRoomType.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRoomType.Name = "lblRoomType";
            this.lblRoomType.Size = new System.Drawing.Size(81, 17);
            this.lblRoomType.TabIndex = 18;
            this.lblRoomType.Text = "Room Type";
            // 
            // lblRoomCapacity
            // 
            this.lblRoomCapacity.AutoSize = true;
            this.lblRoomCapacity.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoomCapacity.Location = new System.Drawing.Point(214, 98);
            this.lblRoomCapacity.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRoomCapacity.Name = "lblRoomCapacity";
            this.lblRoomCapacity.Size = new System.Drawing.Size(62, 17);
            this.lblRoomCapacity.TabIndex = 19;
            this.lblRoomCapacity.Text = "Capacity";
            // 
            // txtRoomCapacity
            // 
            this.txtRoomCapacity.Location = new System.Drawing.Point(183, 116);
            this.txtRoomCapacity.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtRoomCapacity.Name = "txtRoomCapacity";
            this.txtRoomCapacity.Size = new System.Drawing.Size(120, 20);
            this.txtRoomCapacity.TabIndex = 22;
            // 
            // btnAddRoom
            // 
            this.btnAddRoom.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnAddRoom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(201)))), ((int)(((byte)(76)))));
            this.btnAddRoom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddRoom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddRoom.ForeColor = System.Drawing.Color.Black;
            this.btnAddRoom.Location = new System.Drawing.Point(41, 231);
            this.btnAddRoom.Name = "btnAddRoom";
            this.btnAddRoom.Size = new System.Drawing.Size(95, 40);
            this.btnAddRoom.TabIndex = 23;
            this.btnAddRoom.Text = "Add";
            this.btnAddRoom.UseVisualStyleBackColor = false;
            this.btnAddRoom.Click += new System.EventHandler(this.btnAddRoom_Click);
            // 
            // btnRemoveRoom
            // 
            this.btnRemoveRoom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveRoom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(201)))), ((int)(((byte)(76)))));
            this.btnRemoveRoom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveRoom.Location = new System.Drawing.Point(255, 231);
            this.btnRemoveRoom.Name = "btnRemoveRoom";
            this.btnRemoveRoom.Size = new System.Drawing.Size(84, 40);
            this.btnRemoveRoom.TabIndex = 25;
            this.btnRemoveRoom.Text = "Remove";
            this.btnRemoveRoom.UseVisualStyleBackColor = false;
            this.btnRemoveRoom.Click += new System.EventHandler(this.btnRemoveRoom_Click);
            // 
            // btnEditRoom
            // 
            this.btnEditRoom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditRoom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(201)))), ((int)(((byte)(76)))));
            this.btnEditRoom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditRoom.Location = new System.Drawing.Point(155, 231);
            this.btnEditRoom.Name = "btnEditRoom";
            this.btnEditRoom.Size = new System.Drawing.Size(84, 40);
            this.btnEditRoom.TabIndex = 24;
            this.btnEditRoom.Text = "Edit";
            this.btnEditRoom.UseVisualStyleBackColor = false;
            this.btnEditRoom.Click += new System.EventHandler(this.btnEditRoom_Click);
            // 
            // dgvRooms
            // 
            this.dgvRooms.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRooms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRooms.Location = new System.Drawing.Point(11, 286);
            this.dgvRooms.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvRooms.Name = "dgvRooms";
            this.dgvRooms.RowHeadersWidth = 51;
            this.dgvRooms.RowTemplate.Height = 24;
            this.dgvRooms.Size = new System.Drawing.Size(778, 153);
            this.dgvRooms.TabIndex = 26;
            this.dgvRooms.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRooms_CellClick);
            // 
            // btnSearchRoom
            // 
            this.btnSearchRoom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearchRoom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(201)))), ((int)(((byte)(76)))));
            this.btnSearchRoom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchRoom.Location = new System.Drawing.Point(355, 231);
            this.btnSearchRoom.Name = "btnSearchRoom";
            this.btnSearchRoom.Size = new System.Drawing.Size(84, 40);
            this.btnSearchRoom.TabIndex = 27;
            this.btnSearchRoom.Text = "Search";
            this.btnSearchRoom.UseVisualStyleBackColor = false;
            this.btnSearchRoom.Click += new System.EventHandler(this.btnSearchRoom_Click);
            // 
            // cmbSearchRoom
            // 
            this.cmbSearchRoom.FormattingEnabled = true;
            this.cmbSearchRoom.Location = new System.Drawing.Point(455, 242);
            this.cmbSearchRoom.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbSearchRoom.Name = "cmbSearchRoom";
            this.cmbSearchRoom.Size = new System.Drawing.Size(114, 21);
            this.cmbSearchRoom.TabIndex = 28;
            // 
            // lblRoomAssignment
            // 
            this.lblRoomAssignment.AutoSize = true;
            this.lblRoomAssignment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoomAssignment.ForeColor = System.Drawing.Color.Blue;
            this.lblRoomAssignment.Location = new System.Drawing.Point(624, 240);
            this.lblRoomAssignment.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRoomAssignment.Name = "lblRoomAssignment";
            this.lblRoomAssignment.Size = new System.Drawing.Size(140, 20);
            this.lblRoomAssignment.TabIndex = 29;
            this.lblRoomAssignment.Text = "Room Assignment";
            this.lblRoomAssignment.Click += new System.EventHandler(this.lblRoomAssignment_Click);
            // 
            // txtRoomName
            // 
            this.txtRoomName.Location = new System.Drawing.Point(49, 116);
            this.txtRoomName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtRoomName.Name = "txtRoomName";
            this.txtRoomName.Size = new System.Drawing.Size(120, 20);
            this.txtRoomName.TabIndex = 31;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(69, 98);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 17);
            this.label2.TabIndex = 30;
            this.label2.Text = "Room Name";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(25)))), ((int)(((byte)(46)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.imgBackToMain2);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(806, 63);
            this.panel1.TabIndex = 34;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Perpetua Titling MT", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(350, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 26);
            this.label1.TabIndex = 34;
            this.label1.Text = "ROOMS";
            // 
            // imgBackToMain2
            // 
            this.imgBackToMain2.Image = ((System.Drawing.Image)(resources.GetObject("imgBackToMain2.Image")));
            this.imgBackToMain2.Location = new System.Drawing.Point(722, 12);
            this.imgBackToMain2.Name = "imgBackToMain2";
            this.imgBackToMain2.Size = new System.Drawing.Size(81, 39);
            this.imgBackToMain2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgBackToMain2.TabIndex = 33;
            this.imgBackToMain2.TabStop = false;
            this.imgBackToMain2.Click += new System.EventHandler(this.imgBackToMain2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(495, 69);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(269, 154);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 35;
            this.pictureBox1.TabStop = false;
            // 
            // cmbRoomType
            // 
            this.cmbRoomType.FormattingEnabled = true;
            this.cmbRoomType.Location = new System.Drawing.Point(183, 167);
            this.cmbRoomType.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbRoomType.Name = "cmbRoomType";
            this.cmbRoomType.Size = new System.Drawing.Size(120, 21);
            this.cmbRoomType.TabIndex = 36;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(56, 155);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 17);
            this.label3.TabIndex = 37;
            this.label3.Text = "Campus";
            // 
            // rbMain
            // 
            this.rbMain.AutoSize = true;
            this.rbMain.Location = new System.Drawing.Point(49, 177);
            this.rbMain.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rbMain.Name = "rbMain";
            this.rbMain.Size = new System.Drawing.Size(48, 17);
            this.rbMain.TabIndex = 38;
            this.rbMain.TabStop = true;
            this.rbMain.Text = "Main";
            this.rbMain.UseVisualStyleBackColor = false;
            // 
            // rbVisayan
            // 
            this.rbVisayan.AutoSize = true;
            this.rbVisayan.Location = new System.Drawing.Point(49, 198);
            this.rbVisayan.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rbVisayan.Name = "rbVisayan";
            this.rbVisayan.Size = new System.Drawing.Size(62, 17);
            this.rbVisayan.TabIndex = 39;
            this.rbVisayan.TabStop = true;
            this.rbVisayan.Text = "Visayan";
            this.rbVisayan.UseVisualStyleBackColor = true;
            // 
            // Rooms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rbVisayan);
            this.Controls.Add(this.rbMain);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbRoomType);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtRoomName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblRoomAssignment);
            this.Controls.Add(this.cmbSearchRoom);
            this.Controls.Add(this.btnSearchRoom);
            this.Controls.Add(this.dgvRooms);
            this.Controls.Add(this.btnAddRoom);
            this.Controls.Add(this.btnRemoveRoom);
            this.Controls.Add(this.btnEditRoom);
            this.Controls.Add(this.txtRoomCapacity);
            this.Controls.Add(this.lblRoomCapacity);
            this.Controls.Add(this.lblRoomType);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Rooms";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rooms";
            this.Load += new System.EventHandler(this.Rooms_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRooms)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgBackToMain2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox imgBackToMain2;
        private System.Windows.Forms.Label lblRoomType;
        private System.Windows.Forms.Label lblRoomCapacity;
        private System.Windows.Forms.TextBox txtRoomCapacity;
        private System.Windows.Forms.Button btnAddRoom;
        private System.Windows.Forms.Button btnRemoveRoom;
        private System.Windows.Forms.Button btnEditRoom;
        private System.Windows.Forms.DataGridView dgvRooms;
        private System.Windows.Forms.Button btnSearchRoom;
        private System.Windows.Forms.ComboBox cmbSearchRoom;
        private System.Windows.Forms.Label lblRoomAssignment;
        private System.Windows.Forms.TextBox txtRoomName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox cmbRoomType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rbMain;
        private System.Windows.Forms.RadioButton rbVisayan;
    }
}