using IPMEDTH.Domain.Core.Entities;
using IPMEDTH.Domain.Core.Entities.Base;

namespace IPMEDTH.Tests.Domain.Entities
{
    public class EntityBaseTests : BaseTest
    {
        private static readonly TestingEntity _testingEntity = new() { Id = "TestID" };
        private static readonly TestingEntity _testingEntityRef = new();
        private static readonly ScoreEntity _testingEntity3 = new();
        private static readonly TestingEntity _testingEntityTransient = new() { Id = null! };
        private static readonly TestingEntity _testingEntityTransient2 = new() { Id = null! };
        private static TestingEntity _testingEntityCopy
        {
            get
            {
                return new TestingEntity()
                {
                    Id = _testingEntity.Id,
                };
            }
        }


        #region Transient
        [TestCase(null, ExpectedResult = true)]
        [TestCase(default(string), ExpectedResult = true)]
        [TestCase("TestID", ExpectedResult = false)]
        public bool TestTransient(string id)
        {
            TestingEntity entity = new() { Id = id };
            return entity.IsTransient();
        }
        #endregion


        #region Equals
        private static readonly object[] _equalsData =
        {
            new object[] { null!, _testingEntity, false },                                  // [FALSE}  omdat obj null is
            new object[] { "TestID", _testingEntity, false },                               // [FALSE}  omdat obj geen EntityBase is
            new object[] { _testingEntityRef, _testingEntityRef, true },                    // [TRUE}   omdat dezelfde reference hebben
            new object[] { _testingEntity, _testingEntity, true },                          // [TRUE}   omdat GetType wel hetzelfde is
            new object[] { _testingEntity3, _testingEntity, false },                        // [FALSE}  omdat GetType niet hetzelfde is

            new object[] { _testingEntityTransient, _testingEntity, false },                // [FALSE}  omdat obj transient is
            new object[] { _testingEntity, _testingEntityTransient, false },                // [FALSE}  omdat obj2 transient is
            new object[] { _testingEntityTransient, _testingEntityTransient2, false },      // [FALSE}  omdat beide wel transient is
            new object[] { _testingEntity, _testingEntityCopy, false },                     // [FALSE}  omdat beide niet transient en niet ==
        };


        [Test, TestCaseSource(nameof(_equalsData))]
        public void TestEquals(object? obj, TestingEntity entity, bool expectedResult)
        {
            var result = entity.Equals(obj);
            Assert.That(result, Is.EqualTo(expectedResult));
        }
        #endregion


        #region HashCode
        private static IEnumerable<TestCaseData> _hashData
        {
            get
            {
                yield return new TestCaseData(_testingEntity).Returns(_testingEntity.GetHashCode());
                yield return new TestCaseData(_testingEntity).Returns(_testingEntity.Id?.GetHashCode() ^ 31);
                yield return new TestCaseData(_testingEntityTransient).Returns(_testingEntityTransient.GetHashCode());
            }
        }


        [Test, TestCaseSource(nameof(_hashData))]
        public int TestHashCode(EntityBase<string> entity)
        {
            var result = entity.GetHashCode();
            return result;
        }
        #endregion

    }
}
