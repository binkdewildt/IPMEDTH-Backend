using IPMEDTH.Domain.Application.Models.Testing;

namespace IPMEDTH.Tests.Domain.Models.Base
{
    public class TestingModelTests : BaseTest
    {
        private readonly TestingModel model = new() { Id = Guid.NewGuid().ToString() };


        #region Equals

        [TestCase(1, false)]
        [TestCase(new string[0], false)]
        [TestCase(1.0, false)]
        [TestCase("", false)]
        public void TestEqualsOther(object? a, bool equals = false)
        {
            Assert.That(model.Equals(a), Is.EqualTo(equals));
        }


        [Test]
        public void TestEqualsModels()
        {
            TestingModel test = new() { Id = Guid.NewGuid().ToString() };
            Assert.Multiple(() =>
            {
                Assert.That(model.Equals(test), Is.False);
                Assert.That(model.Equals(model), Is.True);
            });
        }
        #endregion


        #region HashCode
        [Test]
        public void TestHashCode()
        {
            var hash = model.GetHashCode();
            Assert.That(model.GetHashCode(), Is.EqualTo(hash));
        }
        #endregion
    }
}
