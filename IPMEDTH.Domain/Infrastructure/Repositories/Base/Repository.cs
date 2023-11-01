using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using IPMEDTH.Domain.Core.Entities.Base;
using IPMEDTH.Domain.Infrastructure.Data;
using IPMEDTH.Domain.Core.Repositories.Base;

namespace IPMEDTH.Domain.Infrastructure.Repositories.Base
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected readonly Context _dbContext;

        public Repository(Context dbContext)
        {
            _dbContext = dbContext;
            dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        /// <summary>
        /// Marked as virtual so the GetSet can be overriden, this way a .Include(x => x.x) can be done on specific repositories.
        /// </summary>
        protected virtual IQueryable<T> GetSet()
        {
            return _dbContext.Set<T>();
        }


        #region Create (C)
        public T Create(T entity)
        {
            if (!Guid.TryParse(entity.Id, out Guid guid))
                entity.Id = Guid.NewGuid().ToString();

            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public T CreateIfNotExists(T entity)
        {
            if (Exists(entity))
                return entity;

            return Create(entity);
        }

        public virtual T CreateOrUpdate(T entity)
        {
            if (Exists(entity))
            {
                Update(entity);
                return entity;
            }
            else
            {
                return Create(entity);
            }
        }
        #endregion


        #region Read (R)
        public IEnumerable<T> GetAll()
        {
            return GetSet();
        }
        public T? GetById(string id)
        {
            return GetSet().FirstOrDefault(x => x.Id == id);
        }

        public T? FirstOrDefault(Expression<Func<T, bool>> expression)
        {
            return GetSet().FirstOrDefault(expression);
        }

        public virtual bool Exists(T entity, Expression<Func<T, bool>>? expression = null)
        {
            Expression<Func<T, bool>> exp = expression ?? (e => e.Id == entity.Id);
            return GetSet().Any(exp);
        }

        public int Sum(Expression<Func<T, int>> expression)
        {
            return GetSet().Sum(expression);
        }

        public int Count(Expression<Func<T, bool>>? expression = null)
        {
            if (expression != null)
                return GetSet().Count(expression);

            return GetSet().Count();
        }
        #endregion


        #region Update (U)
        public void Update(T entity)
        {
            _dbContext.ChangeTracker.Clear();
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        #endregion


        #region Delete (D)
        public void Delete(T entity)
        {
            if (!Exists(entity))
                return;

            _dbContext.ChangeTracker.Clear();
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
        }

        public void DeleteById(string id)
        {
            var entity = this.GetById(id);
            if (entity != null)
                this.Delete(entity);
        }
        #endregion

    }
}
