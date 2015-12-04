using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using HotelReservationProjectUpgraded.Model.DataValidationClasses;
using HotelReservationProjectUpgraded.Model.DataValidationClasses.ExceptionClasses;
using HotelReservationProjectUpgraded.Model.Entities;
using HotelReservationProjectUpgraded.Model.UnitOfWork;
//using HotelReservationProjectUpgraded.Model.Managers;
using HotelReservationProjectUpgraded.Model.Utility;
using HotelReservationProjectUpgraded.View;


namespace HotelReservationProjectUpgraded.Controller
{
	public class ApplicationController
		:IDisposable
	{
		static ClientDataValidator clientDataValidator;

		static ApplicationController()
		{
			ApplicationController.clientDataValidator = new ClientDataValidator();
		}

		const String				PRINTING_FILE_PATH = @".\Printing\File.txt";
			
		private	Font				printFont;
		private StreamReader		streamToPrint;

		IView						view;
		//HotelsDataManager			hotelsDataManager;
		//ReservationsDataManager	reservationsDataManager;

		UnitOfWork					unitOfWork;

		Client						authorizedClient;
		List<Reservation>			clientsReservations;

		DateTime					selectedDate;
		HotelClass					selectedHotelClass;
		String						selectedHotel;
		HotelRoomClass				selectedRoomClass;
		Int32						selectedRoomNumber;

		Int32						currentSelectedListViewItem;

		public DateTime				SelectedDate
		{
			get { return this.selectedDate; }
		}

		public HotelClass			SelectedHotelClass
		{
			get { return this.selectedHotelClass; }
		}

		public String				SelectedHotel
		{
			get { return this.selectedHotel; }
		}

		public HotelRoomClass		SelectedRoomClass
		{
			get { return this.selectedRoomClass; }
		}

		public Int32				SelectedRoomNumber
		{
			get { return this.selectedRoomNumber; }
		}

		public ApplicationController(IView viewParam)
		{
			this.view						= viewParam;
			//this.hotelsDataManager		= new HotelsDataManager();
			//this.reservationsDataManager	= new ReservationsDataManager();
			
			this.unitOfWork					= new UnitOfWork();

			this.authorizedClient			= null;
			this.clientsReservations		= null;

			this.selectedDate		= new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 0, 0, 0);
			this.selectedHotel		= null;
			this.selectedHotelClass	= HotelClass.None;
			this.selectedRoomClass	= HotelRoomClass.None;
			this.selectedRoomNumber = 0;

			this.Initialize();
		}

		private void Initialize()
		{
			this.printFont		= null;
			this.streamToPrint	= null;

			this.view.SetController(this);

			//this.hotelsDataManager.Read();
			//this.reservationsDataManager.Read();

			this.view.InitializeClientArea();
		}

		private void ResetClientReservationInput()
		{
			IEnumerable<String> availableHotelClassNames = 
				(from hotelGroup in
					(from hotel in this.unitOfWork.HotelRepository.GetAll()
					 group hotel by hotel.HotelClass into groupByClass
					 select groupByClass)
				orderby hotelGroup.Key ascending
				select hotelGroup.Key.ToString())
				.Distinct();
			//this.hotelsDataManager.GetAvailableHotelClasses();
			
			this.view.SetHotelClassPanelEnabled(true);
			this.view.FillHotelClassComboBox(availableHotelClassNames);

			this.view.SetHotelPanelEnabled(false);
			this.view.SetRoomClassPanelEnabled(false);
			this.view.SetRoomPanelEnabled(false);
			this.view.SetNoAvailableRoomLabelVisible(false);

			this.view.ResetHotelClassComboBoxSelectedIndex();
			this.view.ResetHotelComboBoxSelectedIndex();
			this.view.ResetRoomClassComboBoxSelectedIndex();
			this.view.ResetRoomComboBoxSelectedIndex();

			this.selectedHotelClass = HotelClass.None;
			this.selectedHotel = null;
			this.selectedRoomClass = HotelRoomClass.None;
			this.selectedRoomNumber = 0;

			this.currentSelectedListViewItem = -1;

			this.view.SetConfirmButtonEnabled(false);
			this.view.SetNoAvailableRoomLabelVisible(false);
		}

		private void CreateFileForPrinting()
		{
			using (var stream = new FileStream(ApplicationController.PRINTING_FILE_PATH, FileMode.Create))
			{
				Reservation reservation = this.clientsReservations[this.currentSelectedListViewItem];
				using (var writer = new StreamWriter(stream))
				{
					writer.WriteLine("Client first name: {0}", this.authorizedClient.FirstName);
					writer.WriteLine("Client last name: {0}", this.authorizedClient.LastName);
					writer.WriteLine("Client email: {0}", this.authorizedClient.Email);
					writer.WriteLine("Hotel: {0}", reservation.HotelName);
					writer.WriteLine("Room number: {0}", reservation.RoomNumber.ToString());
					writer.WriteLine("Required date: {0}", reservation.RequiredDateOfReservation.ToShortDateString());
				}
			}

		}

		private void DeleteFileForPrinting()
		{
			File.Delete(ApplicationController.PRINTING_FILE_PATH);
		}

		public Client AuthorizedClient
		{
			get { return this.authorizedClient; }
		}

		public void AuthorizeUser(UserAuthorizationInput userAuthorizationInput)
		{
			try
			{
				String clientFirstName = ApplicationController.clientDataValidator.ValidateFirstName(userAuthorizationInput.FirstName);
				String clientLastName = ApplicationController.clientDataValidator.ValidateLastName(userAuthorizationInput.LastName);
				String clientEmail = ApplicationController.clientDataValidator.ValidateEmail(userAuthorizationInput.Email);

				this.authorizedClient = new Client { FirstName = clientFirstName, LastName = clientLastName, Email = clientEmail };


				this.clientsReservations =
					//this.reservationsDataManager.GetClientsReservations(this.authorizedClient.FirstName, this.authorizedClient.LastName, this.authorizedClient.Email).ToList();
					(from reservation in this.unitOfWork.ReservationRepository.GetAll()
					 where String.Compare(reservation.Client.FirstName, this.authorizedClient.FirstName) == 0
						&& String.Compare(reservation.Client.LastName, this.authorizedClient.LastName) == 0
						&& String.Compare(reservation.Client.Email, this.authorizedClient.Email) == 0
					select reservation)
					.ToList();
				
				this.view.InitializeMyCurrentReservationsListView();
				this.view.DisplayMyCurrentReservations(clientsReservations);
				
				this.view.SetClientAreaAsAuthorized();
				this.view.DisablePrintAndCancelButtons();

				this.ResetClientReservationInput();

			}
			catch(DataValidationException ex)
			{
				String caption = "Data validation error!";

				this.view.ReportError(ex.Message, caption);
				this.view.ClearUserAuthorizationTextBoxes();
			}
		}

		public void UnauthorizeUser()
		{
			this.authorizedClient = null; // added while testing;

			this.view.ClearUserAuthorizationTextBoxes();
			this.view.SetClientAreaAsUnauthorized();
		}

		public void HandleNewDateSelected(DateTime newDate)
		{
			this.selectedDate = newDate;

			this.ResetClientReservationInput();
		}

		public void HandleNewHotelClassSelected()
		{
			String newHotelClassStr = this.view.GetSelectedHotelClassStr();

			if (newHotelClassStr != null)
			{
				this.selectedHotelClass = (HotelClass)Enum.Parse(typeof(HotelClass), newHotelClassStr);
				IEnumerable<String> availableHotelNames = //this.hotelsDataManager.GetAvailableHotelsByClass(this.selectedHotelClass);
					from hotel in this.unitOfWork.HotelRepository.GetAll()
					where hotel.HotelClass == this.selectedHotelClass
					select hotel.Name;

				this.view.SetHotelPanelEnabled(true);
				this.view.FillHotelComboBox(availableHotelNames);

				this.view.SetRoomClassPanelEnabled(false);
				this.view.SetRoomPanelEnabled(false);

				this.view.ResetRoomClassComboBoxSelectedIndex();
				this.view.ResetRoomComboBoxSelectedIndex();

				this.view.SetConfirmButtonEnabled(false);
				this.view.SetNoAvailableRoomLabelVisible(false);

				this.selectedRoomClass = HotelRoomClass.None;
				this.selectedRoomNumber = 0;
			}
		}

		public void HandleNewHotelSelected()
		{
			String newHotelStr = this.view.GetSelectedHotelStr();

			if (newHotelStr != null)
			{
				this.selectedHotel = newHotelStr;

				IEnumerable<String> availableRoomClassNames = //this.hotelsDataManager.GetAvailableHotelRoomClasses(this.selectedHotel);
					(from room in this.unitOfWork.HotelRoomRepository.GetAll()
					where String.Compare(room.HotelName, this.selectedHotel) == 0
					select room.RoomClass.ToString())
					.Distinct();

				this.view.SetRoomClassPanelEnabled(true);
				this.view.FillRoomClassComboBox(availableRoomClassNames);

				this.view.SetRoomPanelEnabled(false);

				this.view.ResetRoomComboBoxSelectedIndex();

				this.view.SetConfirmButtonEnabled(false);
				this.view.SetNoAvailableRoomLabelVisible(false);

				this.selectedRoomNumber = 0;
			}
		}

		public void HandleNewRoomClassSelected()
		{
			String newRoomClassStr = this.view.GetSelectedRoomClassStr();

			if (newRoomClassStr != null)
			{
				this.selectedRoomClass = (HotelRoomClass)Enum.Parse(typeof(HotelRoomClass), newRoomClassStr);


				var rooms			= this.unitOfWork.HotelRoomRepository.GetAll();
				var reservations	= this.unitOfWork.ReservationRepository.GetAll();

				IEnumerable<String> availableRoomNumbers = //this.hotelsDataManager.GetAvailableHotelRoomNumbers(this.selectedHotel, this.selectedRoomClass, this.selectedDate, this.reservationsDataManager);
					(from room in rooms
					let t = (from reservation in reservations
							where	String.Compare(reservation.HotelName, room.HotelName) == 0 &&
									reservation.RoomNumber == room.Number &&
									reservation.RequiredDateOfReservation.CompareTo(this.SelectedDate) == 0
							select reservation.RoomNumber)
					where	String.Compare(room.HotelName, this.selectedHotel) == 0 &&
							room.RoomClass == this.selectedRoomClass &&
							!t.Any(r => r == room.Number)
					select room.Number.ToString())
					.Distinct();


				this.view.SetRoomPanelEnabled(true);
				this.view.FillRoomComboBox(availableRoomNumbers);

				this.view.SetConfirmButtonEnabled(false);
				this.view.SetNoAvailableRoomLabelVisible(false);

				if (availableRoomNumbers.Count() == 0)
				{
					this.view.SetNoAvailableRoomLabelVisible(true);
				}
			}
		}

		public void HandleNewRoomSelected()
		{
			String newRoomNumberStr = this.view.GetSelectedRoomStr();

			if (newRoomNumberStr != null)
			{
				this.selectedRoomNumber = Int32.Parse(newRoomNumberStr);

				this.view.SetConfirmButtonEnabled(true);
			}
		}

		public void AddNewReservation()
		{
			if (this.selectedHotelClass == HotelClass.None)
			{
				String message = "Hotel class not selected";
				String caption = "Reservation confirmation error!";

				this.view.ReportError(message, caption);
				return;
			}

			if (this.selectedHotel == String.Empty)
			{
				String message = "Hotel not selected";
				String caption = "Reservation confirmation error!";

				this.view.ReportError(message, caption);
				return;
			}

			if (this.selectedRoomClass == HotelRoomClass.None)
			{
				String message = "Hotel room class not selected";
				String caption = "Reservation confirmation error!";

				this.view.ReportError(message, caption);
				return;
			}

			if (this.selectedRoomNumber == 0)
			{
				String message = "Hotel room not selected";
				String caption = "Reservation confirmation error!";

				this.view.ReportError(message, caption);
				return;
			}

			if (!this.unitOfWork.ClientRepository.GetAll().Any(client => String.Compare(client.Email, this.authorizedClient.Email) == 0))
			{
				this.unitOfWork.ClientRepository.Insert(new Client
					{
						FirstName = this.authorizedClient.FirstName,
						LastName = this.authorizedClient.LastName,
						Email = this.authorizedClient.Email
					});
			}

			var newReservation = new Reservation
				{
					ClientEmail = this.authorizedClient.Email,
					HotelName = this.selectedHotel,
					RequiredDateOfReservation = this.selectedDate,
					RoomNumber = this.selectedRoomNumber
				};

			//this.reservationsDataManager.CreateNew(newReservation);

			this.unitOfWork.ReservationRepository.Insert(newReservation);
			this.unitOfWork.Save();
			
			this.clientsReservations.Add(newReservation);

			this.view.DisplayMyCurrentReservations(this.clientsReservations);
			this.ResetClientReservationInput();
		}

		public void HandleItemSelection(Int32 selectedIndex)
		{
			this.currentSelectedListViewItem = selectedIndex;

			if (this.currentSelectedListViewItem != -1)
			{
				this.view.EnablePrintAndCancelButtons();
			}
			else
			{
				this.view.DisablePrintAndCancelButtons();
			}
		}

		public void CancelSelectedReservation()
		{
			Reservation reservationToDelete = this.clientsReservations[this.currentSelectedListViewItem];

			this.clientsReservations.RemoveAt(this.currentSelectedListViewItem);
			this.view.RemoveSelectedReservationFromListView(this.currentSelectedListViewItem);

			//this.reservationsDataManager.Delete(reservationToDelete);
			this.unitOfWork.ReservationRepository.Delete( 
					reservationToDelete.RequiredDateOfReservation, 
					reservationToDelete.HotelName, 
					reservationToDelete.RoomNumber 
				);
			this.unitOfWork.Save();
		}

		public void PrintSelectedReservation(String printerName, String printFileName)
		{
			PrintDocument printDoc = new PrintDocument();

			printDoc.PrinterSettings.PrinterName = printerName;
			printDoc.PrinterSettings.PrintToFile = true;
			printDoc.PrinterSettings.PrintFileName = printFileName;

			this.PerformPrinting(printDoc);
		}

		public void PrintSelectedReservation()
		{
			PrinterSettings printerSettings = null;

			if (this.view.ShowPrintDialog(out printerSettings) == DialogResult.OK)
			{
				PrintDocument printDoc = new PrintDocument();
				printDoc.PrinterSettings = printerSettings;

				this.PerformPrinting(printDoc);
			}
		}

		private void PerformPrinting(PrintDocument printDoc)
		{
			this.CreateFileForPrinting();

			try
			{
				using (this.streamToPrint = new StreamReader(ApplicationController.PRINTING_FILE_PATH))
				{
					this.printFont = new Font("Arial", 10);

					printDoc.PrintPage += new PrintPageEventHandler(this.PrintDocPrintPage);
					printDoc.Print();
				}
			}
			catch (Exception ex)
			{
				this.view.ReportError(ex.Message, "Printing error!");
			}

			this.DeleteFileForPrinting();
		}

		private void PrintDocPrintPage(object sender, PrintPageEventArgs e)
		{
			Single linesPerPage = 0;
			Single yPos = 0;
			Int32 count = 0;
			Single leftMargin = e.MarginBounds.Left;
			Single topMargin = e.MarginBounds.Top;
			String line = null;

			// Calculate the number of lines per page.
			linesPerPage = e.MarginBounds.Height / printFont.GetHeight(e.Graphics);

			// Print each line of the file.
			while (count < linesPerPage && ((line = streamToPrint.ReadLine()) != null))
			{
				yPos = topMargin + (count * printFont.GetHeight(e.Graphics));
				e.Graphics.DrawString(line, printFont, Brushes.Black, leftMargin, yPos, new StringFormat());
				count++;
			}

			// If more lines exist, print another page.
			if (line != null)
				e.HasMorePages = true;
			else
			{
				e.HasMorePages = false;
			}
		}

		public void Dispose()
		{
			if (this.unitOfWork != null)
			{
				this.unitOfWork.Dispose();
			}
		}
	}
}
