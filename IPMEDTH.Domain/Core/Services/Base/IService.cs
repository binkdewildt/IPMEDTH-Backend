using IPMEDTH.Domain.Application.Models.Base;

namespace IPMEDTH.Domain.Core.Services.Base
{
    public interface IService<T> where T : Model
    {

        #region Create (C)
        public string Create(T model);
        #endregion


        #region Read (R)
        public IEnumerable<T> GetAll();
        public T? GetById(string id);
        #endregion


        #region Update (U)
        public void Update(T model);
        #endregion


        #region Delete (D)
        public void Delete(T model);
        public void DeleteById(string id);
        #endregion

    }
}
