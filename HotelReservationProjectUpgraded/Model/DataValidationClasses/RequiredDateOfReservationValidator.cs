using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using HotelReservationProjectUpgraded.Model.DataValidationClasses.ExceptionClasses;

namespace HotelReservationProjectUpgraded.Model.DataValidationClasses
{
	public class RequiredDateOfReservationValidator
	{
		public const String PARSING_FORMAT = "dd.MM.yyyy";

		public DateTime ValidateDate(String strDate)
		{
			if (strDate == null)
			{
				String message = "Date value cannot be null";
				throw new DataValidationException(message);
			}

			if (String.Compare(strDate, String.Empty, StringComparison.Ordinal) == 0)
			{
				String message = "Date cannot be empty";
				throw new DataValidationException(message);
			}

			DateTime date = new DateTime();
			Boolean validationSucceeded = 
				DateTime.TryParseExact(
				strDate, new String[] { RequiredDateOfReservationValidator.PARSING_FORMAT },
 				CultureInfo.InvariantCulture, 
				DateTimeStyles.None, 
				out date);

			if (!validationSucceeded)
			{
				String message = String.Format("\"{0}\": incorrect date format", strDate);
				throw new DataValidationException(message);
			}

			return date;
		}
	}
}
