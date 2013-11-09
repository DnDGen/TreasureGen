using D20Dice;
using EquipmentGen.Core.Data.Moneys;
using EquipmentGen.Core.Generation.Providers;
using EquipmentGen.Core.Generation.Providers.Interfaces;
using Moq;
using NUnit.Framework;
using System;

namespace EquipmentGen.Tests.Generation.Providers
{
    [TestFixture]
    public class MoneyProviderTests
    {
        private Mock<IPercentileResultProvider> mockPercentileResultProvider;
        private Mock<IDice> mockDice;
        private IMoneyProvider moneyProvider;

        [SetUp]
        public void Setup()
        {
            mockPercentileResultProvider = new Mock<IPercentileResultProvider>();
            mockDice = new Mock<IDice>();
            moneyProvider = new MoneyProvider(mockPercentileResultProvider.Object);
        }

        [Test]
        public void AccessesPercentileResultProviderWithTableOfLevelMoney()
        {
            moneyProvider.GetMoney(1);
            mockPercentileResultProvider.Verify(p => p.GetPercentileResult("Level1Money"), Times.Once);
        }

        [Test]
        public void ParsesCurrencyOutOfPercentileResult()
        {
            mockPercentileResultProvider.Setup(p => p.GetPercentileResult(It.IsAny<String>()))
                .Returns("Copper,2d4,100");

            var money = moneyProvider.GetMoney(1);
            Assert.That(money.Currency, Is.EqualTo(MoneyConstants.Copper));
        }

        [Test]
        public void ParsesD2OutOfPercentileResult()
        {
            mockPercentileResultProvider.Setup(p => p.GetPercentileResult(It.IsAny<String>()))
                .Returns("Copper,1d2,100");

            moneyProvider.GetMoney(1);
            mockDice.Verify(d => d.d2(1), Times.Once);
        }

        [Test]
        public void ParsesD3OutOfPercentileResult()
        {
            mockPercentileResultProvider.Setup(p => p.GetPercentileResult(It.IsAny<String>()))
                .Returns("Copper,1d3,100");

            moneyProvider.GetMoney(1);
            mockDice.Verify(d => d.d3(1), Times.Once);
        }

        [Test]
        public void ParsesD4OutOfPercentileResult()
        {
            mockPercentileResultProvider.Setup(p => p.GetPercentileResult(It.IsAny<String>()))
                .Returns("Copper,1d4,100");

            moneyProvider.GetMoney(1);
            mockDice.Verify(d => d.d4(1), Times.Once);
        }

        [Test]
        public void ParsesD6OutOfPercentileResult()
        {
            mockPercentileResultProvider.Setup(p => p.GetPercentileResult(It.IsAny<String>()))
                .Returns("Copper,1d6,100");

            moneyProvider.GetMoney(1);
            mockDice.Verify(d => d.d6(1), Times.Once);
        }

        [Test]
        public void ParsesD8OutOfPercentileResult()
        {
            mockPercentileResultProvider.Setup(p => p.GetPercentileResult(It.IsAny<String>()))
                .Returns("Copper,1d8,100");

            moneyProvider.GetMoney(1);
            mockDice.Verify(d => d.d8(1), Times.Once);
        }

        [Test]
        public void ParsesD10OutOfPercentileResult()
        {
            mockPercentileResultProvider.Setup(p => p.GetPercentileResult(It.IsAny<String>()))
                .Returns("Copper,1d10,100");

            moneyProvider.GetMoney(1);
            mockDice.Verify(d => d.d10(1), Times.Once);
        }

        [Test]
        public void ParsesD12OutOfPercentileResult()
        {
            mockPercentileResultProvider.Setup(p => p.GetPercentileResult(It.IsAny<String>()))
                .Returns("Copper,1d12,100");

            moneyProvider.GetMoney(1);
            mockDice.Verify(d => d.d12(1), Times.Once);
        }

        [Test]
        public void ParsesD20OutOfPercentileResult()
        {
            mockPercentileResultProvider.Setup(p => p.GetPercentileResult(It.IsAny<String>()))
                .Returns("Copper,1d20,100");

            moneyProvider.GetMoney(1);
            mockDice.Verify(d => d.d4(1), Times.Once);
        }

        [Test]
        public void ParsesPercentileOutOfPercentileResult()
        {
            mockPercentileResultProvider.Setup(p => p.GetPercentileResult(It.IsAny<String>()))
                .Returns("Copper,1d100,100");

            moneyProvider.GetMoney(1);
            mockDice.Verify(d => d.Percentile(1), Times.Once);
        }

        [Test]
        public void RollNumberOfTimesParsedFromPercentileResult()
        {
            for (var rolls = 1; rolls <= 10; rolls++)
            {
                var result = String.Format("Copper,{0}d6,1", rolls);
                mockPercentileResultProvider.Setup(p => p.GetPercentileResult(It.IsAny<String>())).Returns(result);

                moneyProvider.GetMoney(1);
                mockDice.Verify(d => d.d6(rolls), Times.Once);
            }
        }

        [Test]
        public void ReturnsParsedRoll()
        {
            mockPercentileResultProvider.Setup(p => p.GetPercentileResult(It.IsAny<String>()))
                .Returns("Copper,1d4,1");
            mockDice.Setup(d => d.d4(It.IsAny<Int32>())).Returns(2);

            var money = moneyProvider.GetMoney(1);
            Assert.That(money.Quantity, Is.EqualTo(2));
        }

        [Test]
        public void AppliesMultiplierFromPercentileResult()
        {
            mockPercentileResultProvider.Setup(p => p.GetPercentileResult(It.IsAny<String>()))
                .Returns("Copper,1d4,10");
            mockDice.Setup(d => d.d4(It.IsAny<Int32>())).Returns(2);

            var money = moneyProvider.GetMoney(1);
            Assert.That(money.Quantity, Is.EqualTo(20));
        }
    }
}