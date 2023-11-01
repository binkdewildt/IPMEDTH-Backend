using IPMEDTH.Domain.Application.Models;
using IPMEDTH.Domain.Application.Services;
using IPMEDTH.Domain.Core.Entities;
using IPMEDTH.Domain.Core.Repositories;
using IPMEDTH.Domain.Core.Services.Base;

namespace IPMEDTH.Domain.Core.Services
{
    public class ScoreService : Service<IScoreRepository, ScoreModel, ScoreEntity>, IScoreService
    {
        public ScoreService(IScoreRepository repository) : base(repository)
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
