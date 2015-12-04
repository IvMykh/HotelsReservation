using System;
using HotelReservationProjectUpgraded.Controller;
using HotelReservationProjectUpgraded.View;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelReservationProjectUpgraded.Model.Entities
{
	/*public class Reservation
	{
		private Client client;
		private DateTime requiredDateOfReservation;
		private String hotelName;
		private Int32 roomNumber;

		public Client Client
		{
			get { return this.client; }
			set { this.client = value; }
		}

		public DateTime RequiredDateOfReservation
		{
			get { return this.requiredDateOfReservation; }
			set { this.requiredDateOfReservation = value; }
		}

		public String HotelName
		{
			get { return this.hotelName; }
			set { this.hotelName = value; }
		}

		public Int32 RoomNumber
		{
			get { return this.roomNumber; }
			set { this.roomNumber = value; }
		}

		public override bool Equals(Object obj)
		{
			if (obj == null)
			{
				return false;
			}

			if (obj.GetType() != this.GetType())
			{
				return false;
			}

			var reservationObj = obj as Reservation;

			return String.CompareOrdinal(this.Client.FirstName, reservationObj.Client.FirstName) == 0
				&& String.CompareOrdinal(this.Client.LastName, reservationObj.Client.LastName) == 0
				&& String.CompareOrdinal(this.Client.Email, reservationObj.Client.Email) == 0
				&& DateTime.Compare(this.RequiredDateOfReservation, reservationObj.RequiredDateOfReservation) == 0
				&& this.RoomNumber.CompareTo(reservationObj.RoomNumber) == 0
				&& String.CompareOrdinal(this.HotelName, reservationObj.HotelName) == 0;
		}

		public Reservation Clone()
		{
			return new Reservation
				{
					Client = new Client { FirstName = this.Client.FirstName, LastName = this.Client.LastName, Email = this.Client.Email },
					RequiredDateOfReservation = this.RequiredDateOfReservation,
					RoomNumber = this.RoomNumber,
					HotelName = this.HotelName
				};
		}
	}*/

	public class Reservation
	{
		[ForeignKey("ClientEmail")]
		public virtual Client Client { get; set; }
		//
		//[ForeignKey("RoomNumber")]
		//public virtual Hotel Hotel { get; set; }
		//
		//[ForeignKey("RoomNumber")]
		//[ForeignKey("HotelName")]
		//public virtual HotelRoom HotelRoom { get; set; }


		public String ClientEmail { get; set; }

		[Key, Column(Order = 0)]
		public DateTime RequiredDateOfReservation { get; set; }

		[Key, Column(Order = 1)]
		public String HotelName { get; set; }

		[Key, Column(Order = 2)]
		public Int32 RoomNumber { get; set; }
	}
}
