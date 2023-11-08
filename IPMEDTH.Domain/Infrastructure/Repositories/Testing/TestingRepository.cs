using IPMEDTH.Domain.Core.Entities.Base;
using IPMEDTH.Domain.Core.Repositories.Testing;
using IPMEDTH.Domain.Infrastructure.Data;
using IPMEDTH.Domain.Infrastructure.Repositories.Base;

namespace IPMEDTH.Domain.Infrastructure.Repositories.Testing
{
    public class TestingRepository : Repository<TestingEntity>, ITestingRepository
    {
        public TestingRepository(Context dbContext) : base(dbContext)
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
