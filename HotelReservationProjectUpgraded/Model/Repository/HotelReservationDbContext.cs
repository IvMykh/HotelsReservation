using System.Data.Entity;
using HotelReservationProjectUpgraded.Model.Entities;

namespace HotelReservationProjectUpgraded.Model.Repository
{
	public class HotelReservationDatabaseContext
		: DbContext
	{
		public DbSet<Client>		Clients			{ get; set; }
		public DbSet<Hotel>			Hotels			{ get; set; }
		public DbSet<HotelRoom>		HotelRooms		{ get; set; }
		public DbSet<Reservation>	Reservations	{ get; set; }
	}
}
