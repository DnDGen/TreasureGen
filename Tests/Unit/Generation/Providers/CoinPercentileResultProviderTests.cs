using System;
using EquipmentGen.Core.Data.Coins;
using EquipmentGen.Core.Generation.Providers;
using EquipmentGen.Core.Generation.Providers.Interfaces;
using Moq;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Providers
{
    [TestFixture]
    public class CoinPercentileResultProviderTests
    {
        private Mock<IPercentileResultProvider> mockPercentileResultProvider;
        private ICoinPercentileResultProvider coinPercentileResultProvider;

        [SetUp]
        public void Setup()
        {
            mockPercentileResultProvider = new Mock<IPercentileResultProvider>();
            mockPercentileResultProvider.Setup(p => p.GetPercentileResult(It.IsAny<String>()))
                .Returns("Copper,2d4*100");

            coinPercentileResultProvider = new CoinPercentileResultProvider(mockPercentileResultProvider.Object);
        }

        [Test]
        public void AccessesPercentileResultProviderWithTableOfLevelCoin()
        {
            coinPercentileResultProvider.GetCoinPercentileResult(1);
            mockPercentileResultProvider.Verify(p => p.GetPercentileResult("Level1Coins"), Times.Once);
        }

        [Test]
        public void CoinPercentileResultIsEmptyIfPercentileResultIsEmpty()
        {
            mockPercentileResultProvider.Setup(p => p.GetPercentileResult(It.IsAny<String>()))
                .Returns(String.Empty);

            var result = coinPercentileResultProvider.GetCoinPercentileResult(1);
            Assert.That(result.CoinType, Is.EqualTo(String.Empty));
            Assert.That(result.RollToDetermineAmount, Is.EqualTo(String.Empty));
        }

        [Test]
        public void ParsesCurrencyOutOfPercentileResult()
        {
            var result = coinPercentileResultProvider.GetCoinPercentileResult(1);
            Assert.That(result.CoinType, Is.EqualTo(CoinConstants.Copper));
            Assert.That(result.RollToDetermineAmount, Is.EqualTo("2d4*100"));
        }
    }
}