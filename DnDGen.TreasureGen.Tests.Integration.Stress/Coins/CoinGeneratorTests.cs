using DnDGen.TreasureGen.Coins;
using Ninject;
using NUnit.Framework;

namespace DnDGen.TreasureGen.Tests.Integration.Stress.Coins
{
    [TestFixture]
    public class CoinGeneratorTests : StressTests
    {
        [Inject]
        public ICoinGenerator CoinGenerator { get; set; }

        [Test]
        public void StressCoins()
        {
            stressor.Stress(GenerateAndAssertCoins);
        }

        private void GenerateAndAssertCoins()
        {
            var coin = GenerateCoin();
            Assert.That(coin.Currency, Is.Not.Null);
            Assert.That(coin.Quantity, Is.Not.Negative);
        }

        private Coin GenerateCoin()
        {
            var level = GetNewLevel();
            return CoinGenerator.GenerateAtLevel(level);
        }

        [Test]
        public void CurrencyHappens()
        {
            var coin = stressor.GenerateOrFail(GenerateCoin, c => !string.IsNullOrEmpty(c.Currency));
            Assert.That(coin.Currency, Is.Not.Empty);
            Assert.That(coin.Quantity, Is.Positive);
        }

        [Test]
        public void CurrencyDoesNotHappen()
        {
            var coin = stressor.GenerateOrFail(GenerateCoin, c => string.IsNullOrEmpty(c.Currency));
            Assert.That(coin.Currency, Is.Empty);
            Assert.That(coin.Quantity, Is.EqualTo(0));
        }
    }
}