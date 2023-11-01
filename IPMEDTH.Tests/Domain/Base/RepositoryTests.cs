using IPMEDTH.Domain.Core.Entities.Base;
using IPMEDTH.Domain.Core.Repositories.Base;

namespace IPMEDTH.Tests.Domain.Base
{
    [FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
    public abstract class RepositoryTest<R, E> : ContextBaseTest
        where R : IRepository<E>
        where E : Entity, new()
    {
        internal R _repository { get; private set; } = default!;

        public override void Setup()
        {
            base.Setup();
            _repository = (R)Activator.CreateInstance(typeof(R), _context)!;

            foreach (var entity in entities)
            {
                var index = entities.FindIndex(x => x.Id == entity.Id);
                var newEntity = _repository.Create(entity);
                entities[index].Id = newEntity.Id;
            }
        }


        #region Testing Values
        internal E entity1 { get; set; } = new();
        internal E entity2 { get; set; } = new();
        internal E entity3 { get; set; } = new();
        internal E entityNonExistant { get; set; } = new();
        internal List<E> entities
        {
            get
            {
                List<E> res = new()
                {
                    entity1,
                    entity2,
                    entity3,
                };
                return res.Where(x => x != null).ToList();
            }
        }
        #endregion


    }
}
