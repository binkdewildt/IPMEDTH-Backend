using IPMEDTH.Domain.Core.Entities.Base;
using System.Linq.Expressions;

namespace IPMEDTH.Domain.Core.Repositories.Base
{
    public interface IRepository<T> where T : Entity
    {

        #region Create (C)
        T Create(T entity);
        T CreateIfNotExists(T entity);
        T CreateOrUpdate(T entity);
        #endregion


        #region Read (R)
        IEnumerable<T> GetAll();
        T? GetById(string id);

        T? FirstOrDefault(Expression<Func<T, bool>> predicate);
        bool Exists(T entity, Expression<Func<T, bool>>? predicate = null);
        int Sum(Expression<Func<T, int>> predicate);
        int Count(Expression<Func<T, bool>>? predicate = null);
        #endregion


        #region Update (U)
        void Update(T entity);
        #endregion


        #region Delete (D)
        void Delete(T entity);
        void DeleteById(string id);
        #endregion    

    }
}
