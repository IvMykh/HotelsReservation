using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelReservationProjectUpgraded.Model.DataValidationClasses.ExceptionClasses;
using HotelReservationProjectUpgraded.Model.Entities;

namespace HotelReservationProjectUpgraded.Model.DataValidationClasses
{
	public class HotelRoomsDataValidator
	{
		private const Int32 MIN_ROOM_NUMBER = 0;

		public Int32 ValidateNumber(String numberStr)
		{
			if (numberStr == null)
			{
				String message = "Hotel room number value cannot be null";
				throw new DataValidationException(message);
			}

			if (String.Compare(numberStr, String.Empty, StringComparison.Ordinal) == 0)
			{
				String message = "Hotel room number cannot be empty";
				throw new DataValidationException(message);
			}

			Int32 number = 0;
			Boolean isParsedSuccessfully = Int32.TryParse(numberStr, out number);

			if (!isParsedSuccessfully)
			{
				String message =
					String.Format("\"{0}\": room number is not a correct number", numberStr);

				throw new DataValidationException(message);
			}

			if (number < HotelRoomsDataValidator.MIN_ROOM_NUMBER)
			{
				String message =
					String.Format("\"{0}\": room number cannot be less than {1}", number, HotelRoomsDataValidator.MIN_ROOM_NUMBER);

				throw new DataValidationException(message);
			}

			return number;
		}

		public HotelRoomClass ValidateHotelRoomClass(String roomClassStr)
		{
			if (roomClassStr == null)
			{
				String message = "Hotel room class value cannot be null";
				throw new DataValidationException(message);
			}

			if (String.Compare(roomClassStr, String.Empty, StringComparison.Ordinal) == 0)
			{
				String message = "Hotel room class value cannot be empty";
				throw new DataValidationException(message);
			}

			HotelRoomClass hotelRoomClass = HotelRoomClass.None;
			try
			{
				hotelRoomClass = (HotelRoomClass)Enum.Parse(typeof(HotelRoomClass), roomClassStr, true);
			}
			catch (ArgumentException)
			{
				String message =
					String.Format("\"{0}\": unexpected hotel room class value", roomClassStr);

				throw new DataValidationException(message);
			}

			return hotelRoomClass;
		}

		/*public ReservationState ValidateReservationState(String reservationStateStr)
		{
			if (reservationStateStr == null)
			{
				String message = "Reservation state value cannot be null";
				throw new DataValidationException(message);
			}
		
			if (String.Compare(reservationStateStr, String.Empty, StringComparison.Ordinal) == 0)
			{
				String message = "Reservation state value cannot be empty";
				throw new DataValidationException(message);
			}
		
			ReservationState reservationState = ReservationState.None;
			try
			{
				reservationState = (ReservationState)Enum.Parse(typeof(ReservationState), reservationStateStr, true);
			}
			catch (ArgumentException)
			{
				String message =
					String.Format("\"{0}\": unexpected reservation state value", reservationStateStr);
		
				throw new DataValidationException(message);
			}
		
			return reservationState;
		}*/
	}
}
