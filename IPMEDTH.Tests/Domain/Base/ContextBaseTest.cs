using IPMEDTH.Domain.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;


namespace IPMEDTH.Tests.Domain.Base
{
    public class ContextBaseTest : BaseTest
    {
        protected Context _context { get; set; } = null!;


        [SetUp]
        public virtual void Setup()
        {
            CreateContext();

            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        [TearDown]
        public virtual void TearDown()
        {
        }


        #region Context
        private void CreateContext()
        {
            var options = GetDbContextOptions();
            _context = new(options);
        }

        protected void ResetContext()
        {
            _context?.Database.EnsureDeleted();

            CreateContext();
        }

        protected void RefreshContext()
        {
            CreateContext();
        }

        private static DbContextOptions<Context> GetDbContextOptions()
        {
            return new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
        }
        #endregion

    }
}
