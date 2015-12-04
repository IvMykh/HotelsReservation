using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace HotelReservationProjectUpgraded.Model.DataValidationClasses.ExceptionClasses
{
	[Serializable]
	public class DataValidationException
		: ApplicationException
	{
		public DataValidationException()
			: base()
		{
		}

		public DataValidationException(String message)
			: base(message)
		{
		}

		public DataValidationException(String message, Exception innerException)
			: base(message, innerException)
		{
		}

		protected DataValidationException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
}
