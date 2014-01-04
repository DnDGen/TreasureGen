using System;
using EquipmentGen.Core.Data.Coins;
using NUnit.Framework;

namespace EquipmentGen.Tests.Data.Coins
{
    [TestFixture]
    public class CoinTests
    {
        private Coin Coin;

        [SetUp]
        public void Setup()
        {
            Coin = new Coin();
        }

        [Test]
        public void EmptyCoinIsEmptyString()
        {
            Assert.That(Coin.ToString(), Is.EqualTo(String.Empty));
        }

        [Test]
        public void CoinIsComboOfCurrencyAndQuantity()
        {
            Coin.Currency = "currency";
            Coin.Quantity = 1;

            Assert.That(Coin.ToString(), Is.EqualTo("1 currency"));
        }
    }
}