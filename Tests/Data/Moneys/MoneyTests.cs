using EquipmentGen.Core.Data.Moneys;
using NUnit.Framework;
using System;

namespace EquipmentGen.Tests.Data.Moneys
{
    [TestFixture]
    public class MoneyTests
    {
        private Money money;

        [SetUp]
        public void Setup()
        {
            money = new Money();
        }

        [Test]
        public void EmptyMoneyIsEmptyString()
        {
            Assert.That(money.ToString(), Is.EqualTo(String.Empty));
        }

        [Test]
        public void MoneyIsComboOfCurrencyAndQuantity()
        {
            money.Currency = "currency";
            money.Quantity = 1;

            Assert.That(money.ToString(), Is.EqualTo("1 currency"));
        }
    }
}