using IPMEDTH.Domain.Application.Models.Testing;
using IPMEDTH.Domain.Core.Entities.Base;
using IPMEDTH.Domain.Core.Services.Testing;
using IPMEDTH.Domain.Infrastructure.Repositories.Testing;
using IPMEDTH.Tests.Domain.Base;

namespace IPMEDTH.Tests.Domain.Services.Base
{
    public class BaseServiceTests : ServiceTest<TestingService, TestingModel, TestingRepository, TestingEntity>
    {

        #region Testing Values
        public override void Setup()
        {
            model1 = new TestingModel() { Integer = 1 };
            model2 = new TestingModel() { Integer = 2 };
            model3 = new TestingModel() { Integer = 3 };
            modelNonExistant = new TestingModel() { Integer = 4 };

            base.Setup();
        }
        #endregion


        #region Create (C)
        [Test]
        public void TestCreate()
        {
            _service.Create(modelNonExistant);
            Assert.That(_service.GetAll().Count(), Is.EqualTo(models.Count + 1));
        }
        #endregion


        #region Read (R)
        [Test]
        public void TestGetAll()
        {
            var all = _service.GetAll();
            Assert.That(all.Count(), Is.EqualTo(models.Count));
        }

        [Test]
        public void TestGetById()
        {
            Assert.That(_service.GetById(model1.Id), Is.Not.Null);
            Assert.That(_service.GetById(modelNonExistant.Id), Is.Null);
        }
        #endregion


        #region Update (U)
        [Test]
        public void TestUpdate()
        {
            int n = 10;
            var newModel = model1;
            newModel.Integer = n;
            _service.Update(newModel);

            Assert.That(_service.GetById(newModel.Id), Is.Not.Null);
            Assert.That(_service.GetById(newModel.Id).Integer, Is.EqualTo(n));

        }
        #endregion


        #region Delete (D)
        [Test]
        public void TestDelete()
        {
            _service.Delete(model1);
            Assert.That(_service.GetAll().Count(), Is.EqualTo(models.Count - 1));
        }

        [Test]
        public void TestDeleteById()
        {
            _service.DeleteById(model1.Id);
            Assert.That(_service.GetAll().Count(), Is.EqualTo(models.Count - 1));
        }
        #endregion
    }
}
