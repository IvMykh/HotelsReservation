using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using HotelReservationProjectUpgraded.Controller;
using HotelReservationProjectUpgraded.Model.DataValidationClasses;
using HotelReservationProjectUpgraded.Model.DataValidationClasses.ExceptionClasses;
using HotelReservationProjectUpgraded.Model.Entities;
using HotelReservationProjectUpgraded.View;

namespace HotelReservationProjectUpgraded.Model
{
	public class ReservationsDataManager
	{
		public readonly String RESERVATION_FILE_PATH = @".\Data\ReservationData.rsrv";
		const Int32 RESERVATION_DATA_ITEMS_IN_ROW = 6;

		List<Reservation> reservations;

		private void WriteReservationData(Reservation reservation, StreamWriter reservationsFileWriter)
		{
			reservationsFileWriter.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}",
				reservation.Client.FirstName,
				reservation.Client.LastName,
				reservation.Client.Email,
				reservation.RequiredDateOfReservation.ToString(RequiredDateOfReservationValidator.PARSING_FORMAT),
				reservation.RoomNumber.ToString(),
				reservation.HotelName);
		}

		private void WriteAllReservationsData()
		{
			using (var reservationsFileStream = File.Create(this.RESERVATION_FILE_PATH))
			{
				using (var writer = new StreamWriter(reservationsFileStream))
				{
					foreach (var hotel in this.reservations)
					{
						this.WriteReservationData(hotel, writer);
					}
				}
			}
		}

		public ReservationsDataManager(String sourceFilePath = null)
		{
			if (sourceFilePath != null)
			{
				this.RESERVATION_FILE_PATH = sourceFilePath;
			}

			this.reservations = new List<Reservation>();
		}

		public IEnumerable<Reservation> Reservations
		{
			get { return this.reservations.AsReadOnly(); }
		}

		public void Read()
		{
			if (!File.Exists(this.RESERVATION_FILE_PATH))
			{
				File.Create(this.RESERVATION_FILE_PATH).Close();
			}
			else
			{
				var hotelsValidator = new HotelsDataValidator();
				var roomValidator = new HotelRoomsDataValidator();
				var clientValidator = new ClientDataValidator();
				var dateValidator = new RequiredDateOfReservationValidator();

				using (var reservationsFileReader = File.OpenText(this.RESERVATION_FILE_PATH))
				{
					while (!reservationsFileReader.EndOfStream)
					{
						String reservationDataLine = reservationsFileReader.ReadLine();
						String[] strReservationDataComponents = reservationDataLine.Split(new Char[] { '\t', ' ' }, StringSplitOptions.RemoveEmptyEntries);


						if (strReservationDataComponents.Length != ReservationsDataManager.RESERVATION_DATA_ITEMS_IN_ROW)
						{
							String message = String.Format("Line \"{0}\" has incorrect format", reservationDataLine);
							throw new DataLineIncorrectFormatException(message);
						}

						var reservation = new Reservation
							{
								Client = new Client
									{
										FirstName	= clientValidator.ValidateFirstName(strReservationDataComponents[0]),
										LastName	= clientValidator.ValidateLastName(strReservationDataComponents[1]),
										Email		= clientValidator.ValidateEmail(strReservationDataComponents[2])
									},
								RequiredDateOfReservation = dateValidator.ValidateDate(strReservationDataComponents[3]),
								RoomNumber = roomValidator.ValidateNumber(strReservationDataComponents[4]),
								HotelName = hotelsValidator.ValidateName(strReservationDataComponents[5])
							};

						this.reservations.Add(reservation);
					}
				}
			}
		}

		public void CreateNew(Reservation reservation)
		{
			using (var reservationsFileStream = File.Open(this.RESERVATION_FILE_PATH, FileMode.Append, FileAccess.Write))
			{
				using (var writer = new StreamWriter(reservationsFileStream))
				{
					this.WriteReservationData(reservation, writer);
					this.reservations.Add(reservation);
				}
			}
		}
		
		public void Update(Reservation reservationToUpdate, Reservation newReservation)
		{
			Int32 reservationToUpdateIndex = this.reservations.FindIndex(reservation => reservation.Equals(reservationToUpdate));
			this.reservations[reservationToUpdateIndex] = newReservation;

			this.WriteAllReservationsData();
		}

		public void Delete(Reservation reservationToRemove)
		{
			Int32 reservationToRemoveIndex = this.reservations.FindIndex(reservation => reservation.Equals(reservationToRemove));
			this.reservations.RemoveAt(reservationToRemoveIndex);

			this.WriteAllReservationsData();
		}

		public IEnumerable<Reservation> GetClientsReservations(String firstName, String lastName, String email)
		{
			var requiredReservations = from reservation in this.reservations
									where	String.CompareOrdinal(reservation.Client.FirstName, firstName) == 0 
										&&	String.CompareOrdinal(reservation.Client.LastName, lastName) == 0 
										&&	String.CompareOrdinal(reservation.Client.Email, email) == 0
									select reservation;
			
			return requiredReservations;
		}

		public Boolean IsRoomFree(String requiredHotelName, Int32 requiredRoomNumber, DateTime requiredDate)
		{
			return !this.reservations.Any(reservation =>
				{
					return String.CompareOrdinal(reservation.HotelName, requiredHotelName) == 0
						&& reservation.RoomNumber == requiredRoomNumber
						&& reservation.RequiredDateOfReservation == requiredDate;

				});
		}
	}
}
