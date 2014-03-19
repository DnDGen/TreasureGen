using EquipmentGen.Common.Coins;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Common.Coins
{
    [TestFixture]
    public class CoinTests
    {
        private Coin coin;

        [SetUp]
        public void Setup()
        {
            coin = new Coin();
        }

        [Test]
        public void CurrencyInitialized()
        {
            Assert.That(coin.Currency, Is.Empty);
        }

        [Test]
        public void QuantityIsInitialized()
        {
            Assert.That(coin.Quantity, Is.EqualTo(0));
        }
    }
}