using System;
using HotelReservationProjectUpgraded.Model.Entities;
using HotelReservationProjectUpgraded.Model.Repository;

namespace HotelReservationProjectUpgraded.Model.UnitOfWork
{
	public class UnitOfWork
		:IUnitOfWork, IDisposable
	{
		private HotelReservationDatabaseContext	context;
		private Boolean							disposed;

		private GenericRepository<Client>		clientRepository;
		private GenericRepository<Hotel>		hotelRepository;
		private GenericRepository<HotelRoom>	hotelRoomRepository;
		private GenericRepository<Reservation>	reservationRepository;

		public UnitOfWork()
		{
			this.context	= new HotelReservationDatabaseContext();
			this.disposed	= false;
		}

		public GenericRepository<Client> ClientRepository 
		{
			get
			{
				if (this.clientRepository == null)
				{
					this.clientRepository = new GenericRepository<Client>(this.context);
				}

				return this.clientRepository;
			} 
		}

		public GenericRepository<Hotel> HotelRepository 
		{
			get 
			{
				if (this.hotelRepository == null)
				{
					this.hotelRepository = new GenericRepository<Hotel>(this.context);
				}

				return this.hotelRepository;
			}
		}

		public GenericRepository<HotelRoom> HotelRoomRepository 
		{
			get
			{
				if (this.hotelRoomRepository == null)
				{
					this.hotelRoomRepository = new GenericRepository<HotelRoom>(this.context);
				}

				return this.hotelRoomRepository;
			}
		}
		public GenericRepository<Reservation> ReservationRepository 
		{
			get
			{
				if (this.reservationRepository == null)
				{
					this.reservationRepository = new GenericRepository<Reservation>(this.context);
				}

				return this.reservationRepository;
			}
		}

		public void Save()
		{
			this.context.SaveChanges();
		}


		protected virtual void Dispose(Boolean disposing)
		{
			if (!this.disposed)
			{
				if (disposing)
				{
					context.Dispose();
				}
			}

			this.disposed = true;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}
