using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HotelReservationProjectUpgraded.Model.Entities
{
	/*public enum HotelClass
	{
		None,
		OneStar,
		TwoStar,
		ThreeStar,
		FourStar,
		FiveStar
	}

	public class Hotel
	{
		private String name;
		private HotelClass hotelClass;
		private List<HotelRoom> rooms;

		public Hotel()
		{
			this.rooms = new List<HotelRoom>();
		}

		public String Name
		{
			get { return this.name; }
			set { this.name = value; }
		}

		public HotelClass HotelClass
		{
			get { return this.hotelClass; }
			set { this.hotelClass = value; }
		}

		public ReadOnlyCollection<HotelRoom> Rooms
		{
			get { return this.rooms.AsReadOnly(); }
		}

		public void AddNewRoom(HotelRoom roomToAdd)
		{
			this.rooms.Add(roomToAdd);
		}
	}*/

	public enum HotelClass
	{
		None,
		OneStar,
		TwoStar,
		ThreeStar,
		FourStar,
		FiveStar
	}

	public class Hotel
	{
		[Key]
		public String Name { get; set; }
		public HotelClass HotelClass { get; set; }
	}
}
