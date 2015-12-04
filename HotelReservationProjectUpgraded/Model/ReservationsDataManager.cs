using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace HotelReservation
{
	public class ReservationsDataManager
	{
		const String RESERVATION_FILE_PATH = @"D:\VS 2013\HotelReservation\HotelReservation\Data\ReservationData.rsrv";
		const Int32 RESERVATION_DATA_ITEMS_IN_ROW = 5;

		List<Reservation> reservations;

		private void WriteReservationData(Reservation reservation, StreamWriter reservationsFileWriter)
		{
			reservationsFileWriter.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}",
				reservation.Client.FirstName,
				reservation.Client.LastName,
				reservation.RequiredDateOfReservation.ToString(RequiredDateOfReservationValidator.PARSING_FORMAT),
				reservation.RoomNumber.ToString(),
				reservation.HotelName);
		}

		private void WriteAllReservationsData()
		{
			using (var reservationsFileStream = File.Create(ReservationsDataManager.RESERVATION_FILE_PATH))
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

		public ReservationsDataManager()
		{
			this.reservations = new List<Reservation>();
		}

		public void Read()
		{
			if (!File.Exists(ReservationsDataManager.RESERVATION_FILE_PATH))
			{
				File.Create(ReservationsDataManager.RESERVATION_FILE_PATH).Close();
			}
			else
			{
				var hotelsValidator = new HotelsDataValidator();
				var roomValidator = new HotelRoomsDataValidator();
				var clientValidator = new ClientDataValidator();
				var dateValidator = new RequiredDateOfReservationValidator();

				using (var reservationsFileReader = File.OpenText(ReservationsDataManager.RESERVATION_FILE_PATH))
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
										FirstName = clientValidator.ValidateFirstName(strReservationDataComponents[0]),
										LastName = clientValidator.ValidateLastName(strReservationDataComponents[1])
									},
								RequiredDateOfReservation = dateValidator.ValidateDate(strReservationDataComponents[2]),
								RoomNumber = roomValidator.ValidateNumber(strReservationDataComponents[3]),
								HotelName = hotelsValidator.ValidateName(strReservationDataComponents[4])
							};

						this.reservations.Add(reservation);
					}
				}
			}
		}

		public void CreateNew(Reservation reservation)
		{
			using (var reservationsFileStream = File.Open(ReservationsDataManager.RESERVATION_FILE_PATH, FileMode.Append, FileAccess.Write))
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

		public void Delete(Reservation reservation)
		{
			this.reservations.Remove(reservation);
			this.WriteAllReservationsData();
		}


		public void Print()
		{
			foreach (var reservation in this.reservations)
			{
				Console.WriteLine("{0}\t {1}\t {2}\t {3}\t {4}",
					reservation.Client.FirstName,
					reservation.Client.LastName,
					reservation.RequiredDateOfReservation.ToString(RequiredDateOfReservationValidator.PARSING_FORMAT),
					reservation.RoomNumber.ToString(),
					reservation.HotelName);
			}
		}
	}
}
