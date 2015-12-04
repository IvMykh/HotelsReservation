using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using HotelReservationProjectUpgraded.Controller;
using HotelReservationProjectUpgraded.Model.DataValidationClasses;
using HotelReservationProjectUpgraded.Model.DataValidationClasses.ExceptionClasses;
using HotelReservationProjectUpgraded.Model.Entities;
using HotelReservationProjectUpgraded.View;

namespace HotelReservationProjectUpgraded.Model.Managers
{
	public class HotelsDataManager
	{
		public readonly		String		HOTEL_FILE_PATH					= @".\Data\HotelsData.htl";
		public const		Int32		HOTEL_DATA_ITEMS_IN_ROW			= 3;
		public const		Int32		HOTEL_ROOM_DATA_ITEMS_IN_ROW	= 2;


		List<Hotel> hotels;

		private void WriteHotelsData(Hotel hotel, StreamWriter hotelsFileWriter)
		{
			hotelsFileWriter.WriteLine("{0}\t{1}\t{2}",
						hotel.Name,
						hotel.HotelClass.ToString(),
						hotel.Rooms.Count.ToString());

			foreach (var room in hotel.Rooms)
			{
				hotelsFileWriter.WriteLine("{0}\t{1}",
					room.Number.ToString(),
					room.RoomClass.ToString());
			}
		}

		private void WriteAllHotelData()
		{
			using (var hotelsFileStream = File.Create(this.HOTEL_FILE_PATH))
			{
				using (var writer = new StreamWriter(hotelsFileStream))
				{
					foreach (var hotel in this.hotels)
					{
						this.WriteHotelsData(hotel, writer);
					}
				}
			}
		}

		public HotelsDataManager(String sourceFilePath = null)
		{
			if (sourceFilePath != null)
			{
				this.HOTEL_FILE_PATH = sourceFilePath;
			}

			this.hotels = new List<Hotel>();
		}

		public IEnumerable<Hotel> Hotels
		{
			get { return this.hotels.AsReadOnly(); }
		}

		public void Read()
		{
			if (!File.Exists(this.HOTEL_FILE_PATH))
			{
				File.Create(this.HOTEL_FILE_PATH).Close();
			}
			else
			{
				var hotelsValidator = new HotelsDataValidator();
				var roomValidator	= new HotelRoomsDataValidator();

				using (var hotelsFileReader = File.OpenText(this.HOTEL_FILE_PATH))
				{
					this.hotels.Clear();

					while (!hotelsFileReader.EndOfStream)
					{
						String hotelDataLine = hotelsFileReader.ReadLine();
						String[] strHotelDataComponents = hotelDataLine.Split(new Char[] { '\t', ' ' }, StringSplitOptions.RemoveEmptyEntries);

						if (strHotelDataComponents.Length != HotelsDataManager.HOTEL_DATA_ITEMS_IN_ROW)
						{
							String message = String.Format("Line \"{0}\" has incorrect format", hotelDataLine);
							throw new DataLineIncorrectFormatException(message);
						}

						var hotel = new Hotel
							{
								Name = hotelsValidator.ValidateName(strHotelDataComponents[0]),
								HotelClass = hotelsValidator.ValidateHotelClass(strHotelDataComponents[1])
							};

						Int32 numberOfRooms = Int32.Parse(strHotelDataComponents[2]);

						for (int i = 0; i < numberOfRooms; i++)
						{
							String roomDataLine = hotelsFileReader.ReadLine();
							String[] strRoomDataComponents = roomDataLine.Split(new Char[] { '\t', ' ' }, StringSplitOptions.RemoveEmptyEntries);

							var newRoom = new HotelRoom
								{
									Number = roomValidator.ValidateNumber(strRoomDataComponents[0]),
									RoomClass = roomValidator.ValidateHotelRoomClass(strRoomDataComponents[1])
								};

							hotel.AddNewRoom(newRoom);
						}

						this.hotels.Add(hotel);
					}
				}
			}
		}

		public void CreateNew(Hotel hotel)
		{
			using (var hotelsFileStream = File.Open(this.HOTEL_FILE_PATH, FileMode.Append, FileAccess.Write))
			{
				using (var writer = new StreamWriter(hotelsFileStream))
				{
					this.WriteHotelsData(hotel, writer);
					this.hotels.Add(hotel);
				}
			}
		}

		public void Update(Hotel updatedHotel)
		{
			int hotelToUpdateIndex = this.hotels.FindIndex(hotel => String.CompareOrdinal(hotel.Name, updatedHotel.Name) == 0);
			this.hotels[hotelToUpdateIndex] = updatedHotel;

			this.WriteAllHotelData();
		}

		public void Delete(Hotel hotelToDelete)
		{
			//this.hotels.Remove(hotel);
			int hotelToUpdateIndex = this.hotels.FindIndex(hotel => String.CompareOrdinal(hotel.Name, hotelToDelete.Name) == 0);
			this.hotels.RemoveAt(hotelToUpdateIndex);
			
			this.WriteAllHotelData();
		}

		public IEnumerable<String> GetAvailableHotelClasses()
		{
			var requiredClasses = (from hotelGroup in
									   (from hotel in this.hotels
										group hotel by hotel.HotelClass into groupByClass
										select groupByClass)
								   orderby hotelGroup.Key ascending
								   select hotelGroup.Key.ToString())
								   .Distinct(StringComparer.Ordinal);

			return requiredClasses;
		}

		public IEnumerable<String> GetAvailableHotelsByClass(HotelClass requiredClass)
		{
			var requiredHotels = from hotel in this.hotels
								 where hotel.HotelClass == requiredClass
								 select hotel.Name;

			return requiredHotels;
		}

		public IEnumerable<String> GetAvailableHotelRoomClasses(String requiredHotelName)
		{
			Hotel requiredHotel = this.hotels.Find(hotel => String.CompareOrdinal(hotel.Name, requiredHotelName) == 0);

			var requiredClasses = (from roomGroup in
									   (from room in requiredHotel.Rooms
										group room by room.RoomClass into groupByClass
										select groupByClass)
								   orderby roomGroup.Key ascending
								   select roomGroup.Key.ToString())
								.Distinct(StringComparer.Ordinal);

			return requiredClasses;
		}

		public IEnumerable<String> GetAvailableHotelRoomNumbers(
			String requiredHotelName, 
			HotelRoomClass requiredRoomClass, 
			DateTime requiredDate, 
			ReservationsDataManager reservationsDataManager)
		{
			Hotel requiredHotel = this.hotels.Find(hotel => String.CompareOrdinal(hotel.Name, requiredHotelName) == 0);

			var requiredRoomNumbers = (from room in requiredHotel.Rooms
									   where	room.RoomClass == requiredRoomClass && 
												reservationsDataManager.IsRoomFree(requiredHotelName, room.Number, requiredDate)
									   orderby room.Number ascending
									   select room.Number.ToString())
									  .Distinct(StringComparer.Ordinal);

			return requiredRoomNumbers;
		}
	}
}
