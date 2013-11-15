using System;
using D20Dice;
using EquipmentGen.Core.Data.Moneys;
using EquipmentGen.Core.Generation.Providers;
using EquipmentGen.Core.Generation.Providers.Interfaces;
using Moq;
using NUnit.Framework;

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
            mockPercentileResultProvider.Setup(p => p.GetPercentileResult(It.IsAny<String>()))
                .Returns("Copper,2d4*100");

            mockDice = new Mock<IDice>();
            moneyProvider = new MoneyProvider(mockPercentileResultProvider.Object, mockDice.Object);
        }

        [Test]
        public void AccessesPercentileResultProviderWithTableOfLevelMoney()
        {
            moneyProvider.GetMoney(1);
            mockPercentileResultProvider.Verify(p => p.GetPercentileResult("Level1Money"), Times.Once);
        }

        [Test]
        public void MoneyIsEmptyIfPercentileResultIsEmpty()
        {
            mockPercentileResultProvider.Setup(p => p.GetPercentileResult(It.IsAny<String>()))
                .Returns(String.Empty);

            var money = moneyProvider.GetMoney(1);
            Assert.That(money.ToString(), Is.EqualTo(String.Empty));
        }

        [Test]
        public void ParsesCurrencyOutOfPercentileResult()
        {
            var money = moneyProvider.GetMoney(1);
            Assert.That(money.Currency, Is.EqualTo(MoneyConstants.Copper));
        }

        [Test]
        public void ParsesRollOutOfPercentileResults()
        {
            var roll = "1d2*100";
            mockPercentileResultProvider.Setup(p => p.GetPercentileResult(It.IsAny<String>())).Returns("Copper," + roll);
            mockDice.Setup(d => d.Roll(roll)).Returns(9266);

            var money = moneyProvider.GetMoney(1);
            Assert.That(money.Quantity, Is.EqualTo(9266));
        }
    }
}