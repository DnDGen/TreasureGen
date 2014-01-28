using System;
using D20Dice;
using EquipmentGen.Core.Generation.Generators;
using EquipmentGen.Core.Generation.Generators.Interfaces;
using EquipmentGen.Core.Generation.Providers.Interfaces;
using EquipmentGen.Core.Generation.Providers.Objects;
using Moq;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Generators
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

            mockTypeAndAmountPercentileResultProvider = new Mock<ITypeAndAmountPercentileResultProvider>();
            mockTypeAndAmountPercentileResultProvider.Setup(p => p.GetTypeAndAmountPercentileResult(It.IsAny<String>()))
                .Returns(result);

            mockDice = new Mock<IDice>();
            generator = new CoinGenerator(mockTypeAndAmountPercentileResultProvider.Object, mockDice.Object);
        }

        [Test]
        public void CoinGeneratorReturnsCoinFromCoinPercentileResultProvider()
        {
            generator.GenerateAtLevel(1);
            mockTypeAndAmountPercentileResultProvider.Verify(p => p.GetTypeAndAmountPercentileResult("Level1Coins"), Times.Once);
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
            var coin = generator.GenerateAtLevel(1);
            Assert.That(coin.Currency, Is.EqualTo(result.Type));
            Assert.That(coin.Quantity, Is.EqualTo(result.Amount));
        }
    }
}