using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Windows.Forms;
using HotelReservationProjectUpgraded.Controller;
using HotelReservationProjectUpgraded.Model;
using HotelReservationProjectUpgraded.Model.Entities;

namespace HotelReservationProjectUpgraded.View
{
	public interface IView
	{
		void SetController(ApplicationController controllerParam);
		void InitializeClientArea();

		void ReportError(String message, String caption);

		void ClearUserAuthorizationTextBoxes();
		
		void SetClientAreaAsAuthorized();
		void SetClientAreaAsUnauthorized();
		
		void InitializeMyCurrentReservationsListView();
		void DisplayMyCurrentReservations(IEnumerable<Reservation> myCurrentReservations);
		
		void EnablePrintAndCancelButtons();
		void DisablePrintAndCancelButtons();

		void FillHotelClassComboBox(IEnumerable<String> valueRange);
		void FillHotelComboBox(IEnumerable<String> valueRange);
		void FillRoomClassComboBox(IEnumerable<String> valueRange);
		void FillRoomComboBox(IEnumerable<String> valueRange);

		void SetHotelClassPanelEnabled(Boolean shouldEnable);
		void SetHotelPanelEnabled(Boolean shouldEnable);
		void SetRoomClassPanelEnabled(Boolean shouldEnable);
		void SetRoomPanelEnabled(Boolean shouldEnable);

		void ResetHotelClassComboBoxSelectedIndex();
		void ResetHotelComboBoxSelectedIndex();
		void ResetRoomClassComboBoxSelectedIndex();
		void ResetRoomComboBoxSelectedIndex();

		void SetNoAvailableRoomLabelVisible(Boolean shouldEnable);
		void SetConfirmButtonEnabled(Boolean shouldEnable);

		void RemoveSelectedReservationFromListView(Int32 selectedIndex);

		DialogResult ShowPrintDialog(out PrinterSettings printerSettings);

		String GetSelectedHotelClassStr();
		String GetSelectedHotelStr();
		String GetSelectedRoomClassStr();
		String GetSelectedRoomStr();
	}
}
