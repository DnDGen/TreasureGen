using System;
using D20Dice;
using EquipmentGen.Core.Data.Coins;
using EquipmentGen.Core.Generation.Factories;
using Moq;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Factories
{
    [TestFixture]
    public class CoinFactoryTests
    {
        private Mock<IDice> mockDice;

        [SetUp]
        public void Setup()
        {
            mockDice = new Mock<IDice>();
        }

        [Test]
        public void CoinFactoryReturnsCoin()
        {
            var coin = CoinFactory.CreateWith(mockDice.Object, 1);
            Assert.That(coin, Is.Not.Null);
        }

        [Test]
        public void GetsCoinFromLevelCoinTable()
        {
            mockDice.Setup(d => d.Percentile(It.IsAny<Int32>())).Returns(20);
            mockDice.Setup(d => d.Roll(It.IsAny<String>())).Returns(2000);

            var coin = CoinFactory.CreateWith(mockDice.Object, 1);
            Assert.That(coin.Currency, Is.EqualTo(CoinConstants.Copper));
            Assert.That(coin.Quantity, Is.EqualTo(2000));
        }
    }
}