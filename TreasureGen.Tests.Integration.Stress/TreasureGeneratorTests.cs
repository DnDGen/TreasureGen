using Ninject;
using NUnit.Framework;
using System.Linq;
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
            stressor.Stress(GenerateAndAssertTreasure);
        }

        private void GenerateAndAssertTreasure()
        {
            var level = GetNewLevel();
            var treasure = GenerateTreasure(level);
            Assert.That(treasure.Coin.Currency, Is.Not.Null, "currency");
            Assert.That(treasure.Coin.Quantity, Is.Not.Negative);
            Assert.That(treasure.Goods, Is.Not.Null, "goods");
            Assert.That(treasure.Items, Is.Not.Null, "items");

            if (level > 20)
            {
                Assert.That(treasure.Items, Is.Not.Empty, "epic items");
                Assert.That(treasure.Items, Is.All.Not.Null, "epic items");
                Assert.That(treasure.Items, Is.Unique, "epic items");
            }
        }

        private Treasure GenerateTreasure(int level = 0)
        {
            if (level == 0)
                level = GetNewLevel();

            var treasure = TreasureGenerator.GenerateAtLevel(level);

            return treasure;
        }

        [Test]
        public void TreasureHappens()
        {
            var treasure = stressor.GenerateOrFail(() => GenerateTreasure(), t => t.IsAny);
            Assert.That(treasure.IsAny, Is.True);
        }

        [Test]
        public void TreasureDoesNotHappen()
        {
            var treasure = stressor.GenerateOrFail(() => GenerateTreasure(), t => !t.IsAny);
            Assert.That(treasure.IsAny, Is.False);
        }

        [Test]
        public void CoinHappens()
        {
            var treasure = stressor.GenerateOrFail(() => GenerateTreasure(), t => t.Coin.Quantity > 0);
            Assert.That(treasure.Coin.Quantity, Is.Positive);
            Assert.That(treasure.Coin.Currency, Is.Not.Empty);
        }

        [Test]
        public void GoodsHappen()
        {
            var treasure = stressor.GenerateOrFail(() => GenerateTreasure(), t => t.Goods.Any());
            Assert.That(treasure.Goods, Is.Not.Empty);
            Assert.That(treasure.Goods, Is.All.Not.Null);
            Assert.That(treasure.Goods, Is.Unique);
        }

        [Test]
        public void ItemsHappen()
        {
            var treasure = stressor.GenerateOrFail(() => GenerateTreasure(), t => t.Items.Any());
            Assert.That(treasure.Items, Is.Not.Empty);
            Assert.That(treasure.Items, Is.All.Not.Null);
            Assert.That(treasure.Items, Is.Unique);
        }
    }
}