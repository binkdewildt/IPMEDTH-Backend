using IPMEDTH.Domain.Core.Entities;
using IPMEDTH.Domain.Core.Entities.Base;
using IPMEDTH.Domain.Infrastructure.Repositories;
using IPMEDTH.Tests.Domain.Base;

namespace IPMEDTH.Tests.Domain.Repositories
{
    public class ScoreRepositoryTests : RepositoryTest<ScoreRepository, ScoreEntity>
    {

        #region Testing Values
        public override void Setup()
        {
            entity1 = new ScoreEntity() { Score = 1 };
            entity2 = new ScoreEntity() { Score = 2 };
            entity3 = new ScoreEntity() { Score = 3 };
            entityNonExistant = new ScoreEntity() { Score = 4 };

            base.Setup();
        }
        #endregion


        #region Create (C)
        #endregion


        #region Read (R)
        #endregion


        #region Update (U)
        #endregion


        #region Delete (D)
        #endregion

    }
}
