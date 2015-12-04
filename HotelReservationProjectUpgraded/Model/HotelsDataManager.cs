using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace HotelReservation
{
	public class HotelsDataManager
	{
		const String	HOTEL_FILE_PATH					= @"D:\VS 2013\HotelReservation\HotelReservation\Data\HotelsData.htl";
		const Int32		HOTEL_DATA_ITEMS_IN_ROW			= 3;
		const Int32		HOTEL_ROOM_DATA_ITEMS_IN_ROW	= 3;


		List<Hotel> hotels;

		private void WriteHotelsData(Hotel hotel, StreamWriter hotelsFileWriter)
		{
			hotelsFileWriter.WriteLine("{0}\t{1}\t{2}",
						hotel.Name,
						hotel.HotelClass.ToString(),
						hotel.Rooms.Count.ToString());

			foreach (var room in hotel.Rooms)
			{
				hotelsFileWriter.WriteLine("{0}\t{1}\t{2}",
					room.Number.ToString(),
					room.RoomClass.ToString(),
					room.ReservationState.ToString());
			}
		}

		private void WriteAllHotelData()
		{
			using (var hotelsFileStream = File.Create(HotelsDataManager.HOTEL_FILE_PATH))
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

		public HotelsDataManager()
		{
			this.hotels = new List<Hotel>();
		}

		public void Read()
		{
			if (!File.Exists(HotelsDataManager.HOTEL_FILE_PATH))
			{
				File.Create(HotelsDataManager.HOTEL_FILE_PATH).Close();
			}
			else
			{
				var hotelsValidator = new HotelsDataValidator();
				var roomValidator	= new HotelRoomsDataValidator();

				using (var hotelsFileReader = File.OpenText(HotelsDataManager.HOTEL_FILE_PATH))
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
									RoomClass = roomValidator.ValidateHotelRoomClass(strRoomDataComponents[1]),
									ReservationState = roomValidator.ValidateReservationState(strRoomDataComponents[2])
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
			using (var hotelsFileStream = File.Open(HotelsDataManager.HOTEL_FILE_PATH, FileMode.Append, FileAccess.Write))
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

		public void Delete(Hotel hotel)
		{
			this.hotels.Remove(hotel);
			this.WriteAllHotelData();
		}


		public void Print()
		{
			foreach (var hotel in this.hotels)
			{
				Console.WriteLine("{0}\t {1}\nRooms:", hotel.Name, hotel.HotelClass.ToString());
				foreach (var room in hotel.Rooms)
				{
					Console.WriteLine("{0}\t {1}\t {2}", 
						room.Number.ToString(), 
						room.RoomClass.ToString(), 
						room.ReservationState.ToString());
				}
			}
		}
	}
}
