using IPMEDTH.Domain.Application.Models.Testing;
using IPMEDTH.Domain.Application.Services.Testing;
using IPMEDTH.Domain.Core.Entities.Base;
using IPMEDTH.Domain.Core.Repositories.Testing;
using IPMEDTH.Domain.Core.Services.Base;

namespace IPMEDTH.Domain.Core.Services.Testing
{
    public class TestingService : Service<ITestingRepository, TestingModel, TestingEntity>, ITestingService
    {
        public TestingService(ITestingRepository repository) : base(repository)
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
