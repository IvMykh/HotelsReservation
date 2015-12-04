using HotelReservationProjectUpgraded.Model.Entities;
using HotelReservationProjectUpgraded.Model.Repository;

namespace HotelReservationProjectUpgraded.Model.UnitOfWork
{
	public interface IUnitOfWork
	{
		GenericRepository<Client>		ClientRepository		{ get; }
		GenericRepository<Hotel>		HotelRepository			{ get; }
		GenericRepository<HotelRoom>	HotelRoomRepository		{ get; }
		GenericRepository<Reservation>	ReservationRepository	{ get; }
	}
}
