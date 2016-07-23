using Ninject;
using NUnit.Framework;
using TreasureGen.Coins;

namespace TreasureGen.Tests.Integration.Stress.Coins
{
    [TestFixture]
    public class CoinGeneratorTests : StressTests
    {
        [Inject]
        public ICoinGenerator CoinGenerator { get; set; }

        [Test]
        public void StressCoins()
        {
            Stress(AssertCoins);
        }

        private void AssertCoins()
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
            var coin = GenerateOrFail(GenerateCoin, c => string.IsNullOrEmpty(c.Currency) == false);
            Assert.That(coin.Currency, Is.Not.Empty);
            Assert.That(coin.Quantity, Is.Positive);
        }

        [Test]
        public void CurrencyDoesNotHappen()
        {
            var coin = GenerateOrFail(GenerateCoin, c => string.IsNullOrEmpty(c.Currency));
            Assert.That(coin.Currency, Is.Empty);
            Assert.That(coin.Quantity, Is.EqualTo(0));
        }
    }
}