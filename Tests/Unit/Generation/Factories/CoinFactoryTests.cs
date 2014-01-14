using System;
using D20Dice;
using EquipmentGen.Core.Generation.Factories;
using EquipmentGen.Core.Generation.Factories.Interfaces;
using EquipmentGen.Core.Generation.Providers.Interfaces;
using EquipmentGen.Core.Generation.Providers.Objects;
using Moq;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Factories
{
    [TestFixture]
    public class CoinFactoryTests
    {
        private Mock<ICoinPercentileResultProvider> mockCoinProvider;
        private Mock<IDice> mockDice;
        private ICoinFactory factory;

        private CoinPercentileResult result;

        [SetUp]
        public void Setup()
        {
            result = new CoinPercentileResult();
            mockCoinProvider = new Mock<ICoinPercentileResultProvider>();
            mockCoinProvider.Setup(p => p.GetCoinPercentileResult(It.IsAny<Int32>())).Returns(result);

            mockDice = new Mock<IDice>();
            factory = new CoinFactory(mockCoinProvider.Object, mockDice.Object);
        }

        [Test]
        public void CoinFactoryReturnsCoinFromCoinPercentileResultProvider()
        {
            factory.CreateAtLevel(1);
            mockCoinProvider.Verify(p => p.GetCoinPercentileResult(1), Times.Once);
        }

        [Test]
        public void CoinIsEmptyIfPercentileResultIsEmpty()
        {
            var coin = factory.CreateAtLevel(1);
            Assert.That(coin.ToString(), Is.EqualTo(String.Empty));
        }

        [Test]
        public void ParsesCurrencyOutOfPercentileResult()
        {
            result.CoinType = "coin type";
            var coin = factory.CreateAtLevel(1);
            Assert.That(coin.Currency, Is.EqualTo(result.CoinType));
        }

        [Test]
        public void ParsesRollOutOfPercentileResults()
        {
            result.RollToDetermineAmount = "1d2*100";
            mockDice.Setup(d => d.Roll(result.RollToDetermineAmount)).Returns(9266);

            var coin = factory.CreateAtLevel(1);
            Assert.That(coin.Quantity, Is.EqualTo(9266));
        }
    }
}