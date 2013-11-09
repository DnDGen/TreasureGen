using D20Dice;
using EquipmentGen.Core.Data.Moneys;
using EquipmentGen.Core.Generation.Factories;
using Moq;
using NUnit.Framework;
using System;

namespace EquipmentGen.Tests.Generation.Factories
{
    [TestFixture]
    public class MoneyFactoryTests
    {
        private Mock<IDice> mockDice;

        [SetUp]
        public void Setup()
        {
            mockDice = new Mock<IDice>();
        }

        [Test]
        public void MoneyFactoryReturnsMoney()
        {
            var money = MoneyFactory.CreateWith(mockDice.Object, 0);
            Assert.That(money, Is.Not.Null);
        }

        [Test]
        public void GetsMoneyFromLevelMoneyTable()
        {
            mockDice.Setup(d => d.Percentile(It.IsAny<Int32>())).Returns(20);
            mockDice.Setup(d => d.d6(It.IsAny<Int32>())).Returns(2);

            var money = MoneyFactory.CreateWith(mockDice.Object, 1);
            Assert.That(money.Currency, Is.EqualTo(MoneyConstants.Copper));
            Assert.That(money.Quantity, Is.EqualTo(2000));
        }
    }
}