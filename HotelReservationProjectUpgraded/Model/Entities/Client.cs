using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HotelReservationProjectUpgraded.Model.Entities
{
	/*public class Client
	{
		private String firstName;
		private String lastName;
		private String email;

		public String FirstName
		{
			get { return this.firstName; }
			set { this.firstName = value; }
		}

		public String LastName
		{
			get { return lastName; }
			set { this.lastName = value; }
		}

		public String Email
		{
			get { return this.email; }
			set { this.email = value; }
		}
	}*/

	public class Client
	{
		public String FirstName { get; set; }
		public String LastName { get; set; }

		[Key]
		public String Email { get; set; }
	}
}
