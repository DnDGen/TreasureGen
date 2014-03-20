using System;
using D20Dice;
using EquipmentGen.Generators.Coins;
using EquipmentGen.Generators.Interfaces.Coins;
using EquipmentGen.Selectors.Interfaces;
using EquipmentGen.Selectors.Objects;
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
            result = new TypeAndAmountPercentileResult();
            result.Type = "coin type";
            result.AmountToRoll = "92d66";

            mockDice = new Mock<IDice>();
            mockDice.Setup(d => d.Percentile(1)).Returns(9266);

            mockTypeAndAmountPercentileSelector = new Mock<ITypeAndAmountPercentileSelector>();
            mockTypeAndAmountPercentileSelector.Setup(p => p.SelectFrom(It.IsAny<String>(), 9266))
                .Returns(result);

            generator = new CoinGenerator(mockTypeAndAmountPercentileSelector.Object, mockDice.Object);
        }

        [Test]
        public void ReturnCoinFromSelector()
        {
            generator.GenerateAtLevel(1);
            mockTypeAndAmountPercentileSelector.Verify(p => p.SelectFrom("Level1Coins", 9266), Times.Once);
        }

        [Test]
        public void CoinIsEmptyIfPercentileResultIsEmpty()
        {
            result.Type = String.Empty;

            var coin = generator.GenerateAtLevel(1);
            Assert.That(coin.Currency, Is.EqualTo(String.Empty));
            Assert.That(coin.Quantity, Is.EqualTo(0));
        }

        [Test]
        public void ParsesCurrencyOutOfPercentileResult()
        {
            mockDice.Setup(d => d.Roll(result.AmountToRoll)).Returns(42);

            var coin = generator.GenerateAtLevel(1);
            Assert.That(coin.Currency, Is.EqualTo(result.Type));
            Assert.That(coin.Quantity, Is.EqualTo(42));
        }
    }
}