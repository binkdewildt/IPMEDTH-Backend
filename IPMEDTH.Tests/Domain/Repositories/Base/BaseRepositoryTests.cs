using IPMEDTH.Domain.Core.Entities.Base;
using IPMEDTH.Domain.Infrastructure.Repositories.Base;
using IPMEDTH.Tests.Domain.Base;

namespace IPMEDTH.Tests.Domain.Repositories.Base
{
    public class BaseRepositoryTests : RepositoryTest<Repository<TestingEntity>, TestingEntity>
    {
        #region Create (C)
        [Test]
        public void TestCreate()
        {
            var result = _repository.Create(entityNonExistant);
            var oldCount = entities.Count;

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.InstanceOf<TestingEntity>());
                Assert.That(_repository.Count(), Is.EqualTo(oldCount + 1));
            });
        }

        [Test]
        public void TestCreateIfNotExists()
        {
            var resultExistant = _repository.CreateIfNotExists(entity1);
            var resultNew = _repository.CreateIfNotExists(entityNonExistant);

            Assert.Multiple(() =>
            {
                Assert.That(resultExistant, Is.InstanceOf<TestingEntity>());
                Assert.That(resultNew, Is.InstanceOf<TestingEntity>());
                Assert.That(resultExistant.Id, Is.EqualTo(entity1.Id));
                Assert.That(resultNew.Id, Is.EqualTo(entityNonExistant.Id));
            });
        }

        [Test]
        public void TestCreateOrUpdate()
        {
            entity1.Integer = 1;

            var resultExistant = _repository.CreateOrUpdate(entity1);
            var resultNew = _repository.CreateOrUpdate(entityNonExistant);

            Assert.Multiple(() =>
            {
                Assert.That(resultExistant, Is.InstanceOf<TestingEntity>());
                Assert.That(resultNew, Is.InstanceOf<TestingEntity>());
                Assert.That(resultExistant.Id, Is.EqualTo(entity1.Id));
                Assert.That(_repository.FirstOrDefault(x => x.Id == resultExistant.Id), Is.Not.Null);
                Assert.That(_repository.FirstOrDefault(x => x.Id == resultExistant.Id)?.Integer, Is.EqualTo(entity1.Integer));
                Assert.That(resultNew.Id, Is.EqualTo(entityNonExistant.Id));
            });
        }
        #endregion


        #region Read (R)
        [Test]
        public void TestGetAll()
        {
            Assert.That(_repository.GetAll().Count, Is.EqualTo(entities.Count));
        }


        [Test]
        public void TestFind()
        {
            Assert.Multiple(() =>
            {
                Assert.That(_repository.FirstOrDefault(x => x.Id == entity1.Id), Is.Not.Null);               // Existant
                Assert.That(_repository.FirstOrDefault(x => x.Id == entityNonExistant.Id), Is.Null);         // Non-existant
            });
        }

        [Test]
        public void TestExists()
        {
            Assert.Multiple(() =>
            {
                Assert.That(_repository.Exists(entity1), Is.True);                   // Existant
                Assert.That(_repository.Exists(entityNonExistant), Is.False);        // Non-existant
            });
        }

        [Test]
        public void TestCount()
        {
            Assert.Multiple(() =>
            {
                Assert.That(_repository.Count(), Is.EqualTo(entities.Count));
                Assert.That(_repository.Count(x => x.Integer == 0), Is.EqualTo(entities.Count));
            });
        }

        [Test]
        public void TestSum()
        {
            Assert.That(_repository.Sum(x => x.Integer), Is.EqualTo(0));
        }
        #endregion


        #region Update (U)
        [Test]
        public void TestUpdate()
        {
            entity1.Integer = 1;
            _repository.Update(entity1);
            Assert.That(_repository.FirstOrDefault(x => x.Id == entity1.Id)?.Integer, Is.EqualTo(1));
        }
        #endregion


        #region Delete (D)
        [Test]
        public void TestDelete()
        {
            _repository.Delete(entity1);
            _repository.DeleteById(entity2.Id);

            var oldCount = entities.Count;
            Assert.That(_repository.Count(), Is.EqualTo(oldCount - 2));
        }
        #endregion
    }
}
