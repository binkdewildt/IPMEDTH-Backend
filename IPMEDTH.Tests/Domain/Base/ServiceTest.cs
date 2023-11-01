using IPMEDTH.Domain.Application.Models.Base;
using IPMEDTH.Domain.Core.Entities.Base;
using IPMEDTH.Domain.Core.Repositories.Base;
using IPMEDTH.Domain.Core.Services.Base;

namespace IPMEDTH.Tests.Domain.Base
{
    [FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
    public class ServiceTest<S, M, R, E> : RepositoryTest<R, E>
            where S : IService<M>
            where M : Model, new()
            where R : IRepository<E>
            where E : Entity, new()
    {
        internal S _service { get; private set; } = default!;


        public override void Setup()
        {
            entity1 = null!;
            entity2 = null!;
            entity3 = null!;

            base.Setup();

            _service = (S)Activator.CreateInstance(typeof(S), _repository)!;
            foreach (var model in models)
            {
                var index = models.FindIndex(x => x.Id == model.Id);
                var newId = _service.Create(model);
                models[index].Id = newId;
            }
        }



        #region Testing Values
        internal M model1 = new();
        internal M model2 = new();
        internal M model3 = new();
        internal M modelNonExistant = new();
        internal List<M> models
        {
            get
            {
                List<M> res = new()
                {
                    model1,
                    model2,
                    model3,
                };
                return res.Where(x => x != null).ToList();
            }
        }
        #endregion

    }
}
