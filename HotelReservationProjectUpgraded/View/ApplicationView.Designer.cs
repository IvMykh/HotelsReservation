namespace HotelReservationProjectUpgraded.View
{
	partial class ApplicationView
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
			this.userSelectionGroupBox = new System.Windows.Forms.GroupBox();
			this.panel4 = new System.Windows.Forms.Panel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.logInButton = new System.Windows.Forms.Button();
			this.logOutButton = new System.Windows.Forms.Button();
			this.emailLabel = new System.Windows.Forms.Label();
			this.lastNameLabel = new System.Windows.Forms.Label();
			this.firstNameLabel = new System.Windows.Forms.Label();
			this.emailTextBox = new System.Windows.Forms.TextBox();
			this.lastNameTextBox = new System.Windows.Forms.TextBox();
			this.firstNameTextBox = new System.Windows.Forms.TextBox();
			this.mainTabControl = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.reserveNewGroupBox = new System.Windows.Forms.GroupBox();
			this.panel7 = new System.Windows.Forms.Panel();
			this.hotelClassPanel = new System.Windows.Forms.Panel();
			this.hotelClassLabel = new System.Windows.Forms.Label();
			this.hotelClassComboBox = new System.Windows.Forms.ComboBox();
			this.hotelPanel = new System.Windows.Forms.Panel();
			this.hotelComboBox = new System.Windows.Forms.ComboBox();
			this.hotelLabel = new System.Windows.Forms.Label();
			this.roomClassPanel = new System.Windows.Forms.Panel();
			this.roomClassComboBox = new System.Windows.Forms.ComboBox();
			this.roomClassLabel = new System.Windows.Forms.Label();
			this.roomPanel = new System.Windows.Forms.Panel();
			this.roomComboBox = new System.Windows.Forms.ComboBox();
			this.roomLabel = new System.Windows.Forms.Label();
			this.panel6 = new System.Windows.Forms.Panel();
			this.requiredDatelabel = new System.Windows.Forms.Label();
			this.monthCalendar = new System.Windows.Forms.MonthCalendar();
			this.confirmReservationButton = new System.Windows.Forms.Button();
			this.noAvailableRoomLabel = new System.Windows.Forms.Label();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.myCurrentReservationsListView = new System.Windows.Forms.ListView();
			this.date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.hotel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.room = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.panel5 = new System.Windows.Forms.Panel();
			this.printButton = new System.Windows.Forms.Button();
			this.cancelReservationButton = new System.Windows.Forms.Button();
			this.userSelectionGroupBox.SuspendLayout();
			this.panel4.SuspendLayout();
			this.panel1.SuspendLayout();
			this.mainTabControl.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.reserveNewGroupBox.SuspendLayout();
			this.panel7.SuspendLayout();
			this.hotelClassPanel.SuspendLayout();
			this.hotelPanel.SuspendLayout();
			this.roomClassPanel.SuspendLayout();
			this.roomPanel.SuspendLayout();
			this.panel6.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.panel5.SuspendLayout();
			this.SuspendLayout();
			// 
			// userSelectionGroupBox
			// 
			this.userSelectionGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.userSelectionGroupBox.AutoSize = true;
			this.userSelectionGroupBox.Controls.Add(this.panel4);
			this.userSelectionGroupBox.Location = new System.Drawing.Point(12, 12);
			this.userSelectionGroupBox.Name = "userSelectionGroupBox";
			this.userSelectionGroupBox.Size = new System.Drawing.Size(581, 110);
			this.userSelectionGroupBox.TabIndex = 2;
			this.userSelectionGroupBox.TabStop = false;
			this.userSelectionGroupBox.Text = "User selection";
			// 
			// panel4
			// 
			this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel4.Controls.Add(this.panel1);
			this.panel4.Controls.Add(this.emailLabel);
			this.panel4.Controls.Add(this.lastNameLabel);
			this.panel4.Controls.Add(this.firstNameLabel);
			this.panel4.Controls.Add(this.emailTextBox);
			this.panel4.Controls.Add(this.lastNameTextBox);
			this.panel4.Controls.Add(this.firstNameTextBox);
			this.panel4.Location = new System.Drawing.Point(6, 19);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(555, 72);
			this.panel4.TabIndex = 7;
			// 
			// panel1
			// 
			this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.panel1.Controls.Add(this.logInButton);
			this.panel1.Controls.Add(this.logOutButton);
			this.panel1.Location = new System.Drawing.Point(447, 3);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(105, 61);
			this.panel1.TabIndex = 10;
			// 
			// logInButton
			// 
			this.logInButton.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.logInButton.Location = new System.Drawing.Point(1, 3);
			this.logInButton.Name = "logInButton";
			this.logInButton.Size = new System.Drawing.Size(101, 29);
			this.logInButton.TabIndex = 3;
			this.logInButton.Text = "Log in";
			this.logInButton.UseVisualStyleBackColor = true;
			this.logInButton.Click += new System.EventHandler(this.logInButton_Click);
			// 
			// logOutButton
			// 
			this.logOutButton.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.logOutButton.Location = new System.Drawing.Point(1, 32);
			this.logOutButton.Name = "logOutButton";
			this.logOutButton.Size = new System.Drawing.Size(101, 29);
			this.logOutButton.TabIndex = 4;
			this.logOutButton.Text = "Log out";
			this.logOutButton.UseVisualStyleBackColor = true;
			this.logOutButton.Click += new System.EventHandler(this.logOutButton_Click);
			// 
			// emailLabel
			// 
			this.emailLabel.AutoSize = true;
			this.emailLabel.Location = new System.Drawing.Point(3, 51);
			this.emailLabel.Name = "emailLabel";
			this.emailLabel.Size = new System.Drawing.Size(38, 13);
			this.emailLabel.TabIndex = 9;
			this.emailLabel.Text = "E-mail:";
			// 
			// lastNameLabel
			// 
			this.lastNameLabel.AutoSize = true;
			this.lastNameLabel.Location = new System.Drawing.Point(3, 29);
			this.lastNameLabel.Name = "lastNameLabel";
			this.lastNameLabel.Size = new System.Drawing.Size(59, 13);
			this.lastNameLabel.TabIndex = 5;
			this.lastNameLabel.Text = "Last name:";
			// 
			// firstNameLabel
			// 
			this.firstNameLabel.AutoSize = true;
			this.firstNameLabel.Location = new System.Drawing.Point(3, 6);
			this.firstNameLabel.Name = "firstNameLabel";
			this.firstNameLabel.Size = new System.Drawing.Size(58, 13);
			this.firstNameLabel.TabIndex = 1;
			this.firstNameLabel.Text = "First name:";
			// 
			// emailTextBox
			// 
			this.emailTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.emailTextBox.Location = new System.Drawing.Point(67, 48);
			this.emailTextBox.Name = "emailTextBox";
			this.emailTextBox.Size = new System.Drawing.Size(206, 20);
			this.emailTextBox.TabIndex = 2;
			// 
			// lastNameTextBox
			// 
			this.lastNameTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.lastNameTextBox.Location = new System.Drawing.Point(67, 26);
			this.lastNameTextBox.Name = "lastNameTextBox";
			this.lastNameTextBox.Size = new System.Drawing.Size(206, 20);
			this.lastNameTextBox.TabIndex = 1;
			// 
			// firstNameTextBox
			// 
			this.firstNameTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.firstNameTextBox.Location = new System.Drawing.Point(67, 3);
			this.firstNameTextBox.Name = "firstNameTextBox";
			this.firstNameTextBox.Size = new System.Drawing.Size(206, 20);
			this.firstNameTextBox.TabIndex = 0;
			// 
			// mainTabControl
			// 
			this.mainTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.mainTabControl.Controls.Add(this.tabPage1);
			this.mainTabControl.Controls.Add(this.tabPage2);
			this.mainTabControl.Location = new System.Drawing.Point(12, 128);
			this.mainTabControl.Name = "mainTabControl";
			this.mainTabControl.SelectedIndex = 0;
			this.mainTabControl.Size = new System.Drawing.Size(581, 375);
			this.mainTabControl.TabIndex = 3;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.reserveNewGroupBox);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(573, 349);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "New Reservation";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// reserveNewGroupBox
			// 
			this.reserveNewGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.reserveNewGroupBox.Controls.Add(this.panel7);
			this.reserveNewGroupBox.Controls.Add(this.panel6);
			this.reserveNewGroupBox.Controls.Add(this.confirmReservationButton);
			this.reserveNewGroupBox.Controls.Add(this.noAvailableRoomLabel);
			this.reserveNewGroupBox.ForeColor = System.Drawing.SystemColors.ControlText;
			this.reserveNewGroupBox.Location = new System.Drawing.Point(11, 6);
			this.reserveNewGroupBox.Name = "reserveNewGroupBox";
			this.reserveNewGroupBox.Size = new System.Drawing.Size(546, 337);
			this.reserveNewGroupBox.TabIndex = 1;
			this.reserveNewGroupBox.TabStop = false;
			// 
			// panel7
			// 
			this.panel7.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.panel7.Controls.Add(this.hotelClassPanel);
			this.panel7.Controls.Add(this.hotelPanel);
			this.panel7.Controls.Add(this.roomClassPanel);
			this.panel7.Controls.Add(this.roomPanel);
			this.panel7.Location = new System.Drawing.Point(285, 65);
			this.panel7.Name = "panel7";
			this.panel7.Size = new System.Drawing.Size(160, 238);
			this.panel7.TabIndex = 5;
			// 
			// hotelClassPanel
			// 
			this.hotelClassPanel.Controls.Add(this.hotelClassLabel);
			this.hotelClassPanel.Controls.Add(this.hotelClassComboBox);
			this.hotelClassPanel.Location = new System.Drawing.Point(3, 3);
			this.hotelClassPanel.Name = "hotelClassPanel";
			this.hotelClassPanel.Size = new System.Drawing.Size(154, 53);
			this.hotelClassPanel.TabIndex = 13;
			// 
			// hotelClassLabel
			// 
			this.hotelClassLabel.AutoSize = true;
			this.hotelClassLabel.Location = new System.Drawing.Point(3, 8);
			this.hotelClassLabel.Name = "hotelClassLabel";
			this.hotelClassLabel.Size = new System.Drawing.Size(93, 13);
			this.hotelClassLabel.TabIndex = 2;
			this.hotelClassLabel.Text = "Select hotel class:";
			// 
			// hotelClassComboBox
			// 
			this.hotelClassComboBox.FormattingEnabled = true;
			this.hotelClassComboBox.Location = new System.Drawing.Point(3, 24);
			this.hotelClassComboBox.Name = "hotelClassComboBox";
			this.hotelClassComboBox.Size = new System.Drawing.Size(151, 21);
			this.hotelClassComboBox.TabIndex = 8;
			this.hotelClassComboBox.SelectedIndexChanged += new System.EventHandler(this.hotelClassComboBox_SelectedIndexChanged);
			// 
			// hotelPanel
			// 
			this.hotelPanel.Controls.Add(this.hotelComboBox);
			this.hotelPanel.Controls.Add(this.hotelLabel);
			this.hotelPanel.Location = new System.Drawing.Point(3, 62);
			this.hotelPanel.Name = "hotelPanel";
			this.hotelPanel.Size = new System.Drawing.Size(154, 53);
			this.hotelPanel.TabIndex = 14;
			// 
			// hotelComboBox
			// 
			this.hotelComboBox.FormattingEnabled = true;
			this.hotelComboBox.Location = new System.Drawing.Point(5, 29);
			this.hotelComboBox.Name = "hotelComboBox";
			this.hotelComboBox.Size = new System.Drawing.Size(149, 21);
			this.hotelComboBox.TabIndex = 9;
			this.hotelComboBox.SelectedIndexChanged += new System.EventHandler(this.hotelComboBox_SelectedIndexChanged);
			// 
			// hotelLabel
			// 
			this.hotelLabel.AutoSize = true;
			this.hotelLabel.Location = new System.Drawing.Point(2, 13);
			this.hotelLabel.Name = "hotelLabel";
			this.hotelLabel.Size = new System.Drawing.Size(66, 13);
			this.hotelLabel.TabIndex = 4;
			this.hotelLabel.Text = "Select hotel:";
			// 
			// roomClassPanel
			// 
			this.roomClassPanel.Controls.Add(this.roomClassComboBox);
			this.roomClassPanel.Controls.Add(this.roomClassLabel);
			this.roomClassPanel.Location = new System.Drawing.Point(3, 121);
			this.roomClassPanel.Name = "roomClassPanel";
			this.roomClassPanel.Size = new System.Drawing.Size(154, 53);
			this.roomClassPanel.TabIndex = 15;
			// 
			// roomClassComboBox
			// 
			this.roomClassComboBox.FormattingEnabled = true;
			this.roomClassComboBox.Location = new System.Drawing.Point(5, 29);
			this.roomClassComboBox.Name = "roomClassComboBox";
			this.roomClassComboBox.Size = new System.Drawing.Size(149, 21);
			this.roomClassComboBox.TabIndex = 10;
			this.roomClassComboBox.SelectedIndexChanged += new System.EventHandler(this.roomClassComboBox_SelectedIndexChanged);
			// 
			// roomClassLabel
			// 
			this.roomClassLabel.AutoSize = true;
			this.roomClassLabel.Location = new System.Drawing.Point(3, 13);
			this.roomClassLabel.Name = "roomClassLabel";
			this.roomClassLabel.Size = new System.Drawing.Size(93, 13);
			this.roomClassLabel.TabIndex = 6;
			this.roomClassLabel.Text = "Select room class:";
			// 
			// roomPanel
			// 
			this.roomPanel.Controls.Add(this.roomComboBox);
			this.roomPanel.Controls.Add(this.roomLabel);
			this.roomPanel.Location = new System.Drawing.Point(3, 180);
			this.roomPanel.Name = "roomPanel";
			this.roomPanel.Size = new System.Drawing.Size(154, 53);
			this.roomPanel.TabIndex = 15;
			// 
			// roomComboBox
			// 
			this.roomComboBox.FormattingEnabled = true;
			this.roomComboBox.Location = new System.Drawing.Point(5, 29);
			this.roomComboBox.Name = "roomComboBox";
			this.roomComboBox.Size = new System.Drawing.Size(149, 21);
			this.roomComboBox.TabIndex = 11;
			this.roomComboBox.SelectedIndexChanged += new System.EventHandler(this.roomComboBox_SelectedIndexChanged);
			// 
			// roomLabel
			// 
			this.roomLabel.AutoSize = true;
			this.roomLabel.Location = new System.Drawing.Point(3, 13);
			this.roomLabel.Name = "roomLabel";
			this.roomLabel.Size = new System.Drawing.Size(66, 13);
			this.roomLabel.TabIndex = 8;
			this.roomLabel.Text = "Select room:";
			// 
			// panel6
			// 
			this.panel6.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.panel6.Controls.Add(this.requiredDatelabel);
			this.panel6.Controls.Add(this.monthCalendar);
			this.panel6.Location = new System.Drawing.Point(94, 65);
			this.panel6.Name = "panel6";
			this.panel6.Size = new System.Drawing.Size(168, 174);
			this.panel6.TabIndex = 17;
			// 
			// requiredDatelabel
			// 
			this.requiredDatelabel.AutoSize = true;
			this.requiredDatelabel.Location = new System.Drawing.Point(3, 0);
			this.requiredDatelabel.Name = "requiredDatelabel";
			this.requiredDatelabel.Size = new System.Drawing.Size(105, 13);
			this.requiredDatelabel.TabIndex = 1;
			this.requiredDatelabel.Text = "Select required date:";
			// 
			// monthCalendar
			// 
			this.monthCalendar.Location = new System.Drawing.Point(3, 15);
			this.monthCalendar.MaxSelectionCount = 1;
			this.monthCalendar.Name = "monthCalendar";
			this.monthCalendar.ShowToday = false;
			this.monthCalendar.TabIndex = 16;
			this.monthCalendar.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar_DateSelected);
			// 
			// confirmReservationButton
			// 
			this.confirmReservationButton.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.confirmReservationButton.Location = new System.Drawing.Point(131, 250);
			this.confirmReservationButton.Name = "confirmReservationButton";
			this.confirmReservationButton.Size = new System.Drawing.Size(101, 29);
			this.confirmReservationButton.TabIndex = 5;
			this.confirmReservationButton.Text = "Confirm";
			this.confirmReservationButton.UseVisualStyleBackColor = true;
			this.confirmReservationButton.Click += new System.EventHandler(this.confirmReservationButton_Click);
			// 
			// noAvailableRoomLabel
			// 
			this.noAvailableRoomLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.noAvailableRoomLabel.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.noAvailableRoomLabel.ForeColor = System.Drawing.Color.Red;
			this.noAvailableRoomLabel.Location = new System.Drawing.Point(58, 14);
			this.noAvailableRoomLabel.Name = "noAvailableRoomLabel";
			this.noAvailableRoomLabel.Size = new System.Drawing.Size(420, 22);
			this.noAvailableRoomLabel.TabIndex = 12;
			this.noAvailableRoomLabel.Text = "Unfortunately, no available room satisfies your requirements";
			this.noAvailableRoomLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.myCurrentReservationsListView);
			this.tabPage2.Controls.Add(this.panel5);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(573, 349);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "View Reservations";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// myCurrentReservationsListView
			// 
			this.myCurrentReservationsListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.myCurrentReservationsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.date,
            this.hotel,
            this.room});
			this.myCurrentReservationsListView.Location = new System.Drawing.Point(6, 6);
			this.myCurrentReservationsListView.Name = "myCurrentReservationsListView";
			this.myCurrentReservationsListView.Size = new System.Drawing.Size(561, 286);
			this.myCurrentReservationsListView.TabIndex = 5;
			this.myCurrentReservationsListView.UseCompatibleStateImageBehavior = false;
			this.myCurrentReservationsListView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.myCurrentReservationsListView_ItemSelectionChanged);
			this.myCurrentReservationsListView.Resize += new System.EventHandler(this.myCurrentReservationsListView_Resize);
			// 
			// date
			// 
			this.date.Text = "Date";
			// 
			// hotel
			// 
			this.hotel.Text = "Hotel";
			// 
			// room
			// 
			this.room.Text = "Room";
			// 
			// panel5
			// 
			this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel5.Controls.Add(this.printButton);
			this.panel5.Controls.Add(this.cancelReservationButton);
			this.panel5.Location = new System.Drawing.Point(6, 298);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(561, 45);
			this.panel5.TabIndex = 6;
			// 
			// printButton
			// 
			this.printButton.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.printButton.Location = new System.Drawing.Point(282, 8);
			this.printButton.Name = "printButton";
			this.printButton.Size = new System.Drawing.Size(127, 31);
			this.printButton.TabIndex = 11;
			this.printButton.Text = "Print reservation ...";
			this.printButton.UseVisualStyleBackColor = true;
			this.printButton.Click += new System.EventHandler(this.printButton_Click);
			// 
			// cancelReservationButton
			// 
			this.cancelReservationButton.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.cancelReservationButton.Location = new System.Drawing.Point(155, 8);
			this.cancelReservationButton.Name = "cancelReservationButton";
			this.cancelReservationButton.Size = new System.Drawing.Size(121, 31);
			this.cancelReservationButton.TabIndex = 9;
			this.cancelReservationButton.Text = "Cancel reservation";
			this.cancelReservationButton.UseVisualStyleBackColor = true;
			this.cancelReservationButton.Click += new System.EventHandler(this.cancelReservationButton_Click);
			// 
			// ApplicationView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(605, 515);
			this.Controls.Add(this.userSelectionGroupBox);
			this.Controls.Add(this.mainTabControl);
			this.MinimumSize = new System.Drawing.Size(500, 500);
			this.Name = "ApplicationView";
			this.Text = "Hotel Reservation App";
			this.userSelectionGroupBox.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.panel4.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.mainTabControl.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.reserveNewGroupBox.ResumeLayout(false);
			this.panel7.ResumeLayout(false);
			this.hotelClassPanel.ResumeLayout(false);
			this.hotelClassPanel.PerformLayout();
			this.hotelPanel.ResumeLayout(false);
			this.hotelPanel.PerformLayout();
			this.roomClassPanel.ResumeLayout(false);
			this.roomClassPanel.PerformLayout();
			this.roomPanel.ResumeLayout(false);
			this.roomPanel.PerformLayout();
			this.panel6.ResumeLayout(false);
			this.panel6.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			this.panel5.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox userSelectionGroupBox;
		private System.Windows.Forms.Label emailLabel;
		private System.Windows.Forms.TextBox emailTextBox;
		private System.Windows.Forms.TextBox firstNameTextBox;
		private System.Windows.Forms.Button logInButton;
		private System.Windows.Forms.Label firstNameLabel;
		private System.Windows.Forms.TabControl mainTabControl;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.GroupBox reserveNewGroupBox;
		private System.Windows.Forms.ComboBox roomComboBox;
		private System.Windows.Forms.Label roomLabel;
		private System.Windows.Forms.ComboBox hotelComboBox;
		private System.Windows.Forms.Label roomClassLabel;
		private System.Windows.Forms.ComboBox roomClassComboBox;
		private System.Windows.Forms.Label hotelLabel;
		private System.Windows.Forms.ComboBox hotelClassComboBox;
		private System.Windows.Forms.Label hotelClassLabel;
		private System.Windows.Forms.Label requiredDatelabel;
		private System.Windows.Forms.Button printButton;
		private System.Windows.Forms.Button cancelReservationButton;
		private System.Windows.Forms.ListView myCurrentReservationsListView;
		private System.Windows.Forms.Button confirmReservationButton;
		private System.Windows.Forms.ColumnHeader date;
		private System.Windows.Forms.ColumnHeader hotel;
		private System.Windows.Forms.ColumnHeader room;
		private System.Windows.Forms.Label noAvailableRoomLabel;
		private System.Windows.Forms.Panel hotelClassPanel;
		private System.Windows.Forms.Panel hotelPanel;
		private System.Windows.Forms.Panel roomClassPanel;
		private System.Windows.Forms.Panel roomPanel;
		private System.Windows.Forms.Label lastNameLabel;
		private System.Windows.Forms.TextBox lastNameTextBox;
		private System.Windows.Forms.Button logOutButton;
		private System.Windows.Forms.MonthCalendar monthCalendar;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.Panel panel1;
	}
}

