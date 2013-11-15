using System;
using D20Dice;
using EquipmentGen.Core.Data.Coins;
using EquipmentGen.Core.Generation.Providers;
using EquipmentGen.Core.Generation.Providers.Interfaces;
using Moq;
using NUnit.Framework;

namespace EquipmentGen.Tests.Generation.Providers
{
    [TestFixture]
    public class CoinProviderTests
    {
        private Mock<IPercentileResultProvider> mockPercentileResultProvider;
        private Mock<IDice> mockDice;
        private ICoinProvider coinProvider;

        [SetUp]
        public void Setup()
        {
            mockPercentileResultProvider = new Mock<IPercentileResultProvider>();
            mockPercentileResultProvider.Setup(p => p.GetPercentileResult(It.IsAny<String>()))
                .Returns("Copper,2d4*100");

            mockDice = new Mock<IDice>();
            coinProvider = new CoinProvider(mockPercentileResultProvider.Object, mockDice.Object);
        }

        [Test]
        public void AccessesPercentileResultProviderWithTableOfLevelCoin()
        {
            coinProvider.GetCoin(1);
            mockPercentileResultProvider.Verify(p => p.GetPercentileResult("Level1Coins"), Times.Once);
        }

        [Test]
        public void CoinIsEmptyIfPercentileResultIsEmpty()
        {
            mockPercentileResultProvider.Setup(p => p.GetPercentileResult(It.IsAny<String>()))
                .Returns(String.Empty);

            var coin = coinProvider.GetCoin(1);
            Assert.That(coin.ToString(), Is.EqualTo(String.Empty));
        }

        [Test]
        public void ParsesCurrencyOutOfPercentileResult()
        {
            var coin = coinProvider.GetCoin(1);
            Assert.That(coin.Currency, Is.EqualTo(CoinConstants.Copper));
        }

        [Test]
        public void ParsesRollOutOfPercentileResults()
        {
            var roll = "1d2*100";
            mockPercentileResultProvider.Setup(p => p.GetPercentileResult(It.IsAny<String>())).Returns("Copper," + roll);
            mockDice.Setup(d => d.Roll(roll)).Returns(9266);

            var coin = coinProvider.GetCoin(1);
            Assert.That(coin.Quantity, Is.EqualTo(9266));
        }
    }
}