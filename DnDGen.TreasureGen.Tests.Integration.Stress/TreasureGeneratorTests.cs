using DnDGen.TreasureGen.Coins;
using DnDGen.TreasureGen.Generators;
using DnDGen.TreasureGen.Tests.Unit.Generators.Items;
using Ninject;
using NUnit.Framework;
using System.Threading.Tasks;

namespace DnDGen.TreasureGen.Tests.Integration.Stress
{
    [TestFixture]
    public class TreasureGeneratorTests : StressTests
    {
        [Inject]
        public ITreasureGenerator TreasureGenerator { get; set; }

        private ItemVerifier itemVerifier;

        [SetUp]
        public void Setup()
        {
            itemVerifier = new ItemVerifier();
        }

        [Test]
        public void StressTreasure()
        {
            stressor.Stress(GenerateAndAssertTreasure);
        }

        private void GenerateAndAssertTreasure()
        {
            var level = GetNewLevel();
            var treasure = TreasureGenerator.GenerateAtLevel(level);

            if (string.IsNullOrEmpty(treasure.Coin.Currency))
            {
                Assert.That(treasure.Coin.Currency, Is.Empty);
                Assert.That(treasure.Coin.Quantity, Is.Zero);
            }
            else
            {
                Assert.That(treasure.Coin.Currency, Is.EqualTo(CoinConstants.Copper)
                    .Or.EqualTo(CoinConstants.Gold)
                    .Or.EqualTo(CoinConstants.Platinum)
                    .Or.EqualTo(CoinConstants.Silver));
                Assert.That(treasure.Coin.Quantity, Is.Positive);
            }

            Assert.That(treasure.Goods, Is.Not.Null, "goods");

            foreach (var good in treasure.Goods)
            {
                Assert.That(good.Description, Is.Not.Empty);
                Assert.That(good.ValueInGold, Is.Positive);
            }

            Assert.That(treasure.Items, Is.Not.Null, "items");

            if (level > 20)
                Assert.That(treasure.Items, Is.Not.Empty, $"Level {level}");

            foreach (var item in treasure.Items)
                itemVerifier.AssertItem(item);
        }

        [Test]
        public async Task StressTreasureAsync()
        {
            await stressor.StressAsync(GenerateAndAssertTreasureAsync);
        }

        private async Task GenerateAndAssertTreasureAsync()
        {
            var level = GetNewLevel();
            var treasure = await TreasureGenerator.GenerateAtLevelAsync(level);

            if (string.IsNullOrEmpty(treasure.Coin.Currency))
            {
                Assert.That(treasure.Coin.Currency, Is.Empty);
                Assert.That(treasure.Coin.Quantity, Is.Zero);
            }
            else
            {
                Assert.That(treasure.Coin.Currency, Is.EqualTo(CoinConstants.Copper)
                    .Or.EqualTo(CoinConstants.Gold)
                    .Or.EqualTo(CoinConstants.Platinum)
                    .Or.EqualTo(CoinConstants.Silver));
                Assert.That(treasure.Coin.Quantity, Is.Positive);
            }

            Assert.That(treasure.Goods, Is.Not.Null, "goods");

            foreach (var good in treasure.Goods)
            {
                Assert.That(good.Description, Is.Not.Empty);
                Assert.That(good.ValueInGold, Is.Positive);
            }

            Assert.That(treasure.Items, Is.Not.Null, "items");

            if (level > 20)
                Assert.That(treasure.Items, Is.Not.Empty, $"Level {level}");

            foreach (var item in treasure.Items)
                itemVerifier.AssertItem(item);
        }
    }
}