using System;
using System.Linq;

namespace HotelReservationProjectUpgraded.Model.Repository
{
	public interface IGenericRepository<TEntity> 
		where TEntity: class
	{
		IQueryable<TEntity> GetAll();

		TEntity GetById(params Object[] id);

		void Insert(TEntity entity);
		void Delete(params Object[] id);
		void Delete(TEntity entityToDelete);
		void Update(TEntity entityToUpdate);
	}
}
