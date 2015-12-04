using System;
using System.Data.Entity;
using System.Linq;

namespace HotelReservationProjectUpgraded.Model.Repository
{
	public class GenericRepository<TEntity>:
		IGenericRepository<TEntity>
		where TEntity: class
	{
		private HotelReservationDatabaseContext	context;
		private DbSet<TEntity>				dbSet;

		public GenericRepository(HotelReservationDatabaseContext contextParam)
		{
			this.context	= contextParam;
			this.dbSet		= context.Set<TEntity>();
		}

		public IQueryable<TEntity> GetAll()
		{
			return this.dbSet.AsQueryable();
		}

		public virtual TEntity GetById(params Object[] id)
		{
			return this.dbSet.Find(id);
		}


		public virtual void Insert(TEntity entity)
		{
			this.dbSet.Add(entity);
		}

		public virtual void Delete(params Object[] id)
		{
			var entityToDelete = this.dbSet.Find(id);
			this.Delete(entityToDelete);
		}

		public virtual void Delete(TEntity entityToDelete)
		{
			if (this.context.Entry(entityToDelete).State == EntityState.Detached)
			{
				this.dbSet.Attach(entityToDelete);
			}
			this.dbSet.Remove(entityToDelete);
		}

		public virtual void Update(TEntity entityToUpdate)
		{
			this.dbSet.Attach(entityToUpdate);
			this.context.Entry(entityToUpdate).State = EntityState.Modified;
		}
	}
}
