using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelReservationProjectUpgraded.Model.Entities
{
	/*public enum ReservationState
	{
		None,
		Free,
		Reserved
	}

	public enum HotelRoomClass
	{
		None,
		EconomyClass,
		ApartmentClass,
		BusinessClass,
		LuxClass
	}

	public class HotelRoom
	{
		private Int32 number;
		private HotelRoomClass roomClass;
		private ReservationState reservationState;

		public Int32 Number
		{
			get { return this.number; }
			set { this.number = value; }
		}

		public HotelRoomClass RoomClass 
		{
			get { return this.roomClass; }
			set { this.roomClass = value; }
		}

		public ReservationState ReservationState
		{
			get { return this.reservationState; }
			set { this.reservationState = value; }
		}
	}*/

	public enum HotelRoomClass
	{
		None,
		EconomyClass,
		ApartmentClass,
		BusinessClass,
		LuxClass
	}

	public class HotelRoom
	{
		[Key, Column(Order = 0)]
		public Int32 Number { get; set; }
		public HotelRoomClass RoomClass { get; set; }

		[Key, Column(Order = 1)]
		public String HotelName { get; set; }

		[ForeignKey("HotelName")]
		public virtual Hotel Hotel { get; set; }
	}
}
