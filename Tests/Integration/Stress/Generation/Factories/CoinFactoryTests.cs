using EquipmentGen.Core.Generation.Factories.Interfaces;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Stress.Generation.Factories
{
    [TestFixture]
    public class CoinFactoryTests : StressTest
    {
        [Inject]
        public ICoinFactory CoinFactory { get; set; }

        [SetUp]
        public void Setup()
        {
            StartTest();
        }

        [TearDown]
        public void TearDown()
        {
            StopTest();
        }

        [Test]
        public void CoinFactoryReturnsCoin()
        {
            while (TestShouldKeepRunning())
            {
                var level = GetNewLevel();
                var coin = CoinFactory.CreateAtLevel(level);

                Assert.That(coin, Is.Not.Null, "coin");
                Assert.That(coin.Currency, Is.Not.Null, "currency");
                Assert.That(coin.Quantity, Is.GreaterThanOrEqualTo(0));
            }

            AssertIterations();
        }
    }
}