using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;

using HotelReservationProjectUpgraded.Controller;
using HotelReservationProjectUpgraded.Model;
using HotelReservationProjectUpgraded.Model.Entities;
using HotelReservationProjectUpgraded.Model.Utility;

namespace HotelReservationProjectUpgraded.View
{
	public partial class ApplicationView 
		: Form, IView
	{
		const Int32		NUMBER_OF_LIST_VIEW_COLUMNS = 3;
		const String	EMPTY_DATE					= ""; 

		private ApplicationController appController;

		private void CustomizeComboBoxes()
		{
			this.hotelClassComboBox.DropDownStyle	= ComboBoxStyle.DropDownList;
			this.hotelComboBox.DropDownStyle		= ComboBoxStyle.DropDownList;
			this.roomClassComboBox.DropDownStyle	= ComboBoxStyle.DropDownList;
			this.roomComboBox.DropDownStyle			= ComboBoxStyle.DropDownList;
		}

		public ApplicationView()
		{
			InitializeComponent();
		}

		public void SetController(ApplicationController controllerParam)
		{
			this.appController = controllerParam;
		}

		public void InitializeClientArea()
		{
			this.CustomizeComboBoxes();

			this.mainTabControl.Visible		= false;
			this.logOutButton.Enabled	= false;

			this.mainTabControl.TabPages[0].Text = "Reserve new";
			this.mainTabControl.TabPages[1].Text = "Manage my reservations";

			this.firstNameTextBox.Select();

			this.confirmReservationButton.Enabled = false;
		}

		public void ReportError(String message, String caption)
		{
			MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		public void ClearUserAuthorizationTextBoxes()
		{
			this.firstNameTextBox.Text	= String.Empty;
			this.lastNameTextBox.Text	= String.Empty;
			this.emailTextBox.Text		= String.Empty;

			this.firstNameTextBox.Select();
		}

		public void SetClientAreaAsAuthorized()
		{
			this.firstNameTextBox.Enabled	= false;
			this.lastNameTextBox.Enabled	= false;
			this.emailTextBox.Enabled		= false;
			this.logInButton.Enabled		= false;

			this.logInButton.Enabled	= false;
			this.logOutButton.Enabled	= true;

			this.mainTabControl.Visible = true;
		}

		public void SetClientAreaAsUnauthorized()
		{
			this.firstNameTextBox.Enabled	= true;
			this.lastNameTextBox.Enabled	= true;
			this.emailTextBox.Enabled		= true;
			this.logInButton.Enabled		= true;

			this.firstNameTextBox.Select();

			this.logInButton.Enabled = true;
			this.logOutButton.Enabled = false;

			this.mainTabControl.Visible = false;
		}

		public void InitializeMyCurrentReservationsListView()
		{
			this.myCurrentReservationsListView.View = System.Windows.Forms.View.Details;
			this.myCurrentReservationsListView.LabelEdit = false;
			this.myCurrentReservationsListView.AllowColumnReorder = false;
			this.myCurrentReservationsListView.CheckBoxes = false;
			this.myCurrentReservationsListView.FullRowSelect = true;
			this.myCurrentReservationsListView.GridLines = true;
			this.myCurrentReservationsListView.MultiSelect = false;
			this.myCurrentReservationsListView.Sorting = SortOrder.None;
			this.myCurrentReservationsListView.HideSelection = false;

			Int32 columnWidth = this.myCurrentReservationsListView.Width / ApplicationView.NUMBER_OF_LIST_VIEW_COLUMNS;

			this.date.Width			= columnWidth;
			this.hotel.Width		= columnWidth;
			this.room.Width			= columnWidth;
		}

		public void DisplayMyCurrentReservations(IEnumerable<Reservation> myCurrentReservations)
		{
			this.myCurrentReservationsListView.Items.Clear();

			foreach (var currReservation in myCurrentReservations)
			{
				var newItem = new ListViewItem(currReservation.RequiredDateOfReservation.ToShortDateString());
				newItem.SubItems.Add(currReservation.HotelName);
				newItem.SubItems.Add(currReservation.RoomNumber.ToString());

				this.myCurrentReservationsListView.Items.Add(newItem);
			}
		}

		public void EnablePrintAndCancelButtons()
		{
			this.printButton.Enabled				= true;
			this.cancelReservationButton.Enabled	= true;
		}

		public void DisablePrintAndCancelButtons()
		{
			this.printButton.Enabled				= false;
			this.cancelReservationButton.Enabled	= false;
		}


		public void FillHotelClassComboBox(IEnumerable<String> valueRange)
		{
			this.hotelClassComboBox.Items.Clear();
			this.hotelClassComboBox.Items.AddRange(valueRange.ToArray());
		}

		public void FillHotelComboBox(IEnumerable<String> valueRange)
		{
			this.hotelComboBox.Items.Clear();
			this.hotelComboBox.Items.AddRange(valueRange.ToArray());
		}

		public void FillRoomClassComboBox(IEnumerable<String> valueRange)
		{
			this.roomClassComboBox.Items.Clear();
			this.roomClassComboBox.Items.AddRange(valueRange.ToArray());
		}

		public void FillRoomComboBox(IEnumerable<String> valueRange)
		{
			this.roomComboBox.Items.Clear();
			this.roomComboBox.Items.AddRange(valueRange.ToArray());
		}


		public void SetHotelClassPanelEnabled(Boolean shouldEnable)
		{
			this.hotelClassLabel.Enabled = shouldEnable;
			this.hotelClassComboBox.Enabled = shouldEnable;
		}

		public void SetHotelPanelEnabled(Boolean shouldEnable)
		{
			this.hotelLabel.Enabled = shouldEnable;
			this.hotelComboBox.Enabled = shouldEnable;
		}

		public void SetRoomClassPanelEnabled(Boolean shouldEnable)
		{
			this.roomClassLabel.Enabled = shouldEnable;
			this.roomClassComboBox.Enabled = shouldEnable;
		}

		public void SetRoomPanelEnabled(Boolean shouldEnable)
		{
			this.roomLabel.Enabled = shouldEnable;
			this.roomComboBox.Enabled = shouldEnable;
		}

		public void SetNoAvailableRoomLabelVisible(Boolean shouldEnable)
		{
			this.noAvailableRoomLabel.Visible = shouldEnable;
		}

		public void SetConfirmButtonEnabled(Boolean shouldEnable)
		{
			this.confirmReservationButton.Enabled = shouldEnable;
		}

		public void RemoveSelectedReservationFromListView(Int32 selectedIndex)
		{
			this.myCurrentReservationsListView.Items.RemoveAt(selectedIndex);
		}

		public void ResetHotelClassComboBoxSelectedIndex()
		{
			this.hotelClassComboBox.SelectedIndex = -1;
		}

		public void ResetHotelComboBoxSelectedIndex()
		{
			this.hotelComboBox.SelectedIndex = -1;
		}

		public void ResetRoomClassComboBoxSelectedIndex()
		{
			this.roomClassComboBox.SelectedIndex = -1;
		}

		public void ResetRoomComboBoxSelectedIndex()
		{
			this.roomComboBox.SelectedIndex = -1;
		}

		public DialogResult ShowPrintDialog(out PrinterSettings printerSettings)
		{
			var d = new PrintDialog();
			var dres = d.ShowDialog();

			printerSettings = d.PrinterSettings;
			return dres;
		}

		public String GetSelectedHotelClassStr()
		{
			if (this.hotelClassComboBox.SelectedIndex > -1)
			{
				return this.hotelClassComboBox.Items[this.hotelClassComboBox.SelectedIndex].ToString();
			}
			else
			{
				return null;
			}
		}

		public String GetSelectedHotelStr()
		{
			if (this.hotelComboBox.SelectedIndex > -1)
			{
				return this.hotelComboBox.Items[this.hotelComboBox.SelectedIndex].ToString();
			}
			else
			{
				return null;
			}
		}

		public String GetSelectedRoomClassStr()
		{
			if (this.roomClassComboBox.SelectedIndex > -1)
			{
				return this.roomClassComboBox.Items[this.roomClassComboBox.SelectedIndex].ToString();
			}
			else
			{
				return null;
			}
		}

		public String GetSelectedRoomStr()
		{
			if (this.roomComboBox.SelectedIndex > -1)
			{
				return this.roomComboBox.Items[this.roomComboBox.SelectedIndex].ToString();
			}
			else
			{
				return null;
			}
		}

		private void logInButton_Click(object sender, EventArgs e)
		{
			this.appController.AuthorizeUser(new UserAuthorizationInput 
				{ 
					FirstName	= this.firstNameTextBox.Text,
					LastName	= this.lastNameTextBox.Text,
					Email		= this.emailTextBox.Text
				});
		}

		private void logOutButton_Click(object sender, EventArgs e)
		{
			this.appController.UnauthorizeUser();
		}

		private void confirmReservationButton_Click(object sender, EventArgs e)
		{
			this.appController.AddNewReservation();
		}

		private void dateTimePicker_ValueChanged(object sender, EventArgs e)
		{
			//var dateTimePicker = sender as DateTimePicker;
			this.appController.HandleNewDateSelected((sender as DateTimePicker).Value.Date);
		}

		private void hotelClassComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.appController.HandleNewHotelClassSelected();
		}

		private void hotelComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.appController.HandleNewHotelSelected();
		}

		private void roomClassComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.appController.HandleNewRoomClassSelected();
		}

		private void roomComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.appController.HandleNewRoomSelected();
		}

		private void myCurrentReservationsListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
		{
			this.appController.HandleItemSelection((e.IsSelected) ? e.ItemIndex : -1);
		}

		private void cancelReservationButton_Click(object sender, EventArgs e)
		{
			this.appController.CancelSelectedReservation();
		}

		private void printButton_Click(object sender, EventArgs e)
		{
			this.appController.PrintSelectedReservation();
		}

		private void myCurrentReservationsListView_Resize(object sender, EventArgs e)
		{
			this.date.Width		= this.myCurrentReservationsListView.Width / ApplicationView.NUMBER_OF_LIST_VIEW_COLUMNS;
			this.hotel.Width	= this.myCurrentReservationsListView.Width / ApplicationView.NUMBER_OF_LIST_VIEW_COLUMNS;
			this.room.Width		= this.myCurrentReservationsListView.Width / ApplicationView.NUMBER_OF_LIST_VIEW_COLUMNS;
		}

		private void monthCalendar_DateSelected(object sender, DateRangeEventArgs e)
		{
			this.appController.HandleNewDateSelected(e.Start);
		}
	}
}
