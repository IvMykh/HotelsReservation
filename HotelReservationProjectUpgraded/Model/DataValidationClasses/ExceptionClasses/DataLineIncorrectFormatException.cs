using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace HotelReservationProjectUpgraded.Model.DataValidationClasses.ExceptionClasses
{
	[Serializable]
	public class DataLineIncorrectFormatException
		: ApplicationException
	{
		public DataLineIncorrectFormatException()
			: base()
		{
		}

		public DataLineIncorrectFormatException(String message)
			: base(message)
		{
		}

		public DataLineIncorrectFormatException(String message, Exception innerException)
			: base(message, innerException)
		{
		}

		protected DataLineIncorrectFormatException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
}
