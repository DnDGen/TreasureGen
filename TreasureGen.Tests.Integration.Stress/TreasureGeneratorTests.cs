using Ninject;
using NUnit.Framework;
using TreasureGen.Generators;

namespace TreasureGen.Tests.Integration.Stress
{
    [TestFixture]
    public class TreasureGeneratorTests : StressTests
    {
        [Inject]
        public ITreasureGenerator TreasureGenerator { get; set; }

        [Test]
        public void StressTreasure()
        {
            Stress(AssertTreasure);
        }

        private void AssertTreasure()
        {
            var level = GetNewLevel();
            var treasure = TreasureGenerator.GenerateAtLevel(level);

            Assert.That(treasure.Coin.Currency, Is.Not.Null, "currency");
            Assert.That(treasure.Coin.Quantity, Is.Not.Negative);
            Assert.That(treasure.Goods, Is.Not.Null, "goods");
            Assert.That(treasure.Items, Is.Not.Null, "items");
        }
    }
}