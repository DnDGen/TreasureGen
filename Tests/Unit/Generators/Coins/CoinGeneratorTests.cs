using System;
using D20Dice;
using EquipmentGen.Generators.Coins;
using EquipmentGen.Generators.Interfaces.Coins;
using EquipmentGen.Selectors.Interfaces;
using EquipmentGen.Selectors.Interfaces.Objects;
using Moq;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generators.Coins
{
    [TestFixture]
    public class CoinGeneratorTests
    {
        private Mock<ITypeAndAmountPercentileSelector> mockTypeAndAmountPercentileSelector;
        private Mock<IDice> mockDice;
        private ICoinGenerator generator;

        private TypeAndAmountPercentileResult result;

        [SetUp]
        public void Setup()
        {
            mockDice = new Mock<IDice>();
            mockTypeAndAmountPercentileSelector = new Mock<ITypeAndAmountPercentileSelector>();
            generator = new CoinGenerator(mockTypeAndAmountPercentileSelector.Object, mockDice.Object);
            result = new TypeAndAmountPercentileResult();

            result.Type = "coin type";
            result.Amount = 9266;
            mockTypeAndAmountPercentileSelector.Setup(p => p.SelectFrom(It.IsAny<String>())).Returns(result);

        }

        [Test]
        public void ReturnCoinFromSelector()
        {
            generator.GenerateAtLevel(1);
            mockTypeAndAmountPercentileSelector.Verify(p => p.SelectFrom("Level1Coins"), Times.Once);
        }

        [Test]
        public void CoinIsEmptyIfResultIsEmpty()
        {
            result.Type = String.Empty;

            var coin = generator.GenerateAtLevel(1);
            Assert.That(coin.Currency, Is.EqualTo(String.Empty));
            Assert.That(coin.Quantity, Is.EqualTo(0));
        }

        [Test]
        public void GetCurrencyAmount()
        {
            var coin = generator.GenerateAtLevel(1);
            Assert.That(coin.Currency, Is.EqualTo(result.Type));
            Assert.That(coin.Quantity, Is.EqualTo(9266));
        }
    }
}