using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HotelReservationProjectUpgraded.Model.DataValidationClasses.ExceptionClasses;

namespace HotelReservationProjectUpgraded.Model.DataValidationClasses
{
	public class ClientDataValidator
	{
		public String ValidateFirstName(String firstName)
		{
			if (firstName == null)
			{
				String message = "Client's first name value cannot be null";
				throw new DataValidationException(message);
			}

			if (String.Compare(firstName, String.Empty, StringComparison.Ordinal) == 0)
			{
				String message = "Client's first name cannot be empty";
				throw new DataValidationException(message);
			}

			return firstName;
		}

		public String ValidateLastName(String lastName)
		{
			if (lastName == null)
			{
				String message = "Client's last name value cannot be null";
				throw new DataValidationException(message);
			}

			if (String.Compare(lastName, String.Empty, StringComparison.Ordinal) == 0)
			{
				String message = "Client's last name cannot be empty";
				throw new DataValidationException(message);
			}

			return lastName;
		}

		public String ValidateEmail(String email)
		{
			if (email == null)
			{
				String message = "Client's email value cannot be null";
				throw new DataValidationException(message);
			}

			if (String.Compare(email, String.Empty, StringComparison.Ordinal) == 0)
			{
				String message = "Client's email cannot be empty";
				throw new DataValidationException(message);
			}

			return email;
		}
	}
}
