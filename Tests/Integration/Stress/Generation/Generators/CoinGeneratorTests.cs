using EquipmentGen.Core.Generation.Generators.Interfaces;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Stress.Generation.Generators
{
    [TestFixture]
    public class CoinGeneratorTests : StressTest
    {
        [Inject]
        public ICoinGenerator CoinGenerator { get; set; }

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
        public void StressedCoinGenerator()
        {
            while (TestShouldKeepRunning())
            {
                var level = GetNewLevel();
                var coin = CoinGenerator.GenerateAtLevel(level);

                Assert.That(coin.Currency, Is.Not.Null);
                Assert.That(coin.Quantity, Is.GreaterThanOrEqualTo(0));
            }

            AssertIterations();
        }
    }
}