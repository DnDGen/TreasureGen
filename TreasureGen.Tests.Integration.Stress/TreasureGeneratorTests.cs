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
            Stress(AssertTreasure);
        }

        private void AssertTreasure()
        {
            var treasure = GenerateTreasure();

            Assert.That(treasure.Coin.Currency, Is.Not.Null, "currency");
            Assert.That(treasure.Coin.Quantity, Is.Not.Negative);
            Assert.That(treasure.Goods, Is.Not.Null, "goods");
            Assert.That(treasure.Items, Is.Not.Null, "items");
        }

        private Treasure GenerateTreasure()
        {
            var level = GetNewLevel();
            var treasure = TreasureGenerator.GenerateAtLevel(level);

            return treasure;
        }

        [Test]
        public void TreasureHappens()
        {
            var treasure = GenerateOrFail(GenerateTreasure, t => t.IsAny);
            Assert.That(treasure.IsAny, Is.True);
        }

        [Test]
        public void TreasureDoesNotHappen()
        {
            var treasure = GenerateOrFail(GenerateTreasure, t => t.IsAny == false);
            Assert.That(treasure.IsAny, Is.False);
        }

        [Test]
        public void CoinHappens()
        {
            var treasure = GenerateOrFail(GenerateTreasure, t => t.Coin.Quantity > 0);
            Assert.That(treasure.Coin.Quantity, Is.Positive);
            Assert.That(treasure.Coin.Currency, Is.Not.Empty);
        }

        [Test]
        public void GoodsHappen()
        {
            var treasure = GenerateOrFail(GenerateTreasure, t => t.Goods.Any());
            Assert.That(treasure.Goods, Is.Not.Empty);
            Assert.That(treasure.Goods, Is.All.Not.Null);
        }

        [Test]
        public void ItemsHappen()
        {
            var treasure = GenerateOrFail(GenerateTreasure, t => t.Items.Any());
            Assert.That(treasure.Items, Is.Not.Empty);
            Assert.That(treasure.Items, Is.All.Not.Null);
        }
    }
}