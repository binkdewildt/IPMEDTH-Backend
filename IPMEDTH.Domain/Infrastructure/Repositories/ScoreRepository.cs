using IPMEDTH.Domain.Core.Entities;
using IPMEDTH.Domain.Core.Repositories;
using IPMEDTH.Domain.Infrastructure.Data;
using IPMEDTH.Domain.Infrastructure.Repositories.Base;

namespace IPMEDTH.Domain.Infrastructure.Repositories
{
    public class ScoreRepository : Repository<ScoreEntity>, IScoreRepository
    {
        public ScoreRepository(Context dbContext) : base(dbContext)
        {
        }


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
