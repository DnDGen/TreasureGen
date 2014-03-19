using System;
using D20Dice;
using EquipmentGen.Generators;
using EquipmentGen.Generators.Interfaces;
using EquipmentGen.Selectors.Interfaces;
using EquipmentGen.Selectors.Objects;
using Moq;
using NUnit.Framework;
using EquipmentGen.Generators.Coins;
using EquipmentGen.Generators.Interfaces.Coins;

namespace EquipmentGen.Tests.Unit.Generators.Coins
{
    [TestFixture]
    public class CoinGeneratorTests
    {
        private Mock<ITypeAndAmountPercentileResultProvider> mockTypeAndAmountPercentileResultProvider;
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

            mockTypeAndAmountPercentileResultProvider = new Mock<ITypeAndAmountPercentileResultProvider>();
            mockTypeAndAmountPercentileResultProvider.Setup(p => p.GetResultFrom(It.IsAny<String>(), 9266))
                .Returns(result);

            generator = new CoinGenerator(mockTypeAndAmountPercentileResultProvider.Object, mockDice.Object);
        }

        [Test]
        public void CoinGeneratorReturnsCoinFromCoinPercentileResultProvider()
        {
            generator.GenerateAtLevel(1);
            mockTypeAndAmountPercentileResultProvider.Verify(p => p.GetResultFrom("Level1Coins", 9266), Times.Once);
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