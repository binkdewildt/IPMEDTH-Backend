using IPMEDTH.Domain.Application.Mapper;
using IPMEDTH.Domain.Application.Models.Base;
using IPMEDTH.Domain.Core.Entities.Base;
using IPMEDTH.Domain.Core.Repositories.Base;

namespace IPMEDTH.Domain.Core.Services.Base
{
    public class Service<R, M, E> : IService<M>
        where R : IRepository<E>
        where M : Model
        where E : Entity
    {
        internal readonly R _repository;

        public Service(R repository)
        {
            _repository = repository;
        }


        #region Map Helpers
        internal static M MapToModel(E entity)
        {
            return Map<M>(entity);
        }

        internal static E MapToEntity(M model)
        {
            return Map<E>(model);
        }

        internal static T Map<T>(object source)
        {
            return ObjectMapper.Mapper.Map<T>(source);
        }
        #endregion


        #region Create (C)
        public virtual string Create(M model)
        {
            var mapped = MapToEntity(model);
            var result = _repository.Create(mapped);
            model.Id = result.Id;
            return result.Id;
        }
        #endregion


        #region Read (R)
        public virtual IEnumerable<M> GetAll()
        {
            var all = _repository.GetAll();
            var mapped = Map<IEnumerable<M>>(all);
            return mapped;
        }

        public virtual M? GetById(string id)
        {
            E? entity = _repository.GetById(id);
            var mapped = ObjectMapper.Mapper.Map<M?>(entity);
            return mapped;
        }
        #endregion


        #region Update (U)
        public virtual void Update(M model)
        {
            M? m = GetById(model.Id);

            if (m != null)
            {
                var mapped = MapToEntity(model);
                _repository.Update(mapped);
            }
        }

        #endregion


        #region Delete (D)
        public virtual void Delete(M model)
        {
            var mapped = MapToEntity(model);
            _repository.Delete(mapped);
        }

        public virtual void DeleteById(string id)
        {
            _repository.DeleteById(id);
        }
        #endregion

    }
}
