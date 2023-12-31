using IPMEDTH.Domain.Application.Models;
using IPMEDTH.Domain.Core.Entities;
using IPMEDTH.Domain.Core.Services;
using IPMEDTH.Domain.Infrastructure.Repositories;
using IPMEDTH.Tests.Domain.Base;

namespace IPMEDTH.Tests.Domain.Services
{
    [TestFixture]
    public class ScoreServiceTests : ServiceTest<ScoreService, ScoreModel, ScoreRepository, ScoreEntity>
    {

        #region Testing Values
        [SetUp]
        public override void Setup()
        {
            model1 = new ScoreModel() { Score = 1 };
            model2 = new ScoreModel() { Score = 2 };
            model3 = new ScoreModel() { Score = 3 };
            modelNonExistant = new ScoreModel() { Score = 4 };

            base.Setup();
        }
        #endregion


        #region Create (C)
        #endregion


        #region Read (R)
        [Test]
        public void TestGetAll()
        {
            var all = _service.GetAll();
            Assert.That(all.Count(), Is.EqualTo(models.Count));
        }
        #endregion


        #region Update (U)
        #endregion


        #region Delete (D)
        #endregion

    }
}
