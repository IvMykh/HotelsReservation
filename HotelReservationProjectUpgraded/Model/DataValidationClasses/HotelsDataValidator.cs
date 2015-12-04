using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelReservationProjectUpgraded.Model.DataValidationClasses.ExceptionClasses;
using HotelReservationProjectUpgraded.Model.Entities;

namespace HotelReservationProjectUpgraded.Model.DataValidationClasses
{
	public class HotelsDataValidator
	{
		public String ValidateName(String name)
		{
			if (name == null)
			{
				String message = "Hotel name value cannot be null";
				throw new DataValidationException(message);
			}

			if (String.Compare(name, String.Empty, StringComparison.Ordinal) == 0)
			{
				String message = "Hotel name cannot be empty";
				throw new DataValidationException(message);
			}

			return name;
		}

		public HotelClass ValidateHotelClass(String hotelClassStr)
		{
			if (hotelClassStr == null)
			{
				String message = "Hotel class value cannot be null";
				throw new DataValidationException(message);
			}

			if (String.Compare(hotelClassStr, String.Empty, StringComparison.Ordinal) == 0)
			{
				String message = "Hotel class value cannot be empty";
				throw new DataValidationException(message);
			}

			HotelClass hotelClass = HotelClass.None;
			try
			{
				hotelClass = (HotelClass)Enum.Parse(typeof(HotelClass), hotelClassStr, true);
			}
			catch (ArgumentException)
			{
				String message =
					String.Format("\"{0}\": unexpected hotel class value", hotelClassStr);

				throw new DataValidationException(message);
			}

			return hotelClass;
		}
	}
}
