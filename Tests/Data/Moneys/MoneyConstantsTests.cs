using EquipmentGen.Core.Data.Moneys;
using NUnit.Framework;

namespace EquipmentGen.Tests.Data.Moneys
{
    [TestFixture]
    public class MoneyConstantsTests
    {
        [Test]
        public void GoldConstant()
        {
            Assert.That(MoneyConstants.Gold, Is.EqualTo("Gold"));
        }

        [Test]
        public void PlatinumConstant()
        {
            Assert.That(MoneyConstants.Platinum, Is.EqualTo("Platinum"));
        }

        [Test]
        public void SilverConstant()
        {
            Assert.That(MoneyConstants.Silver, Is.EqualTo("Silver"));
        }

        [Test]
        public void CopperConstant()
        {
            Assert.That(MoneyConstants.Copper, Is.EqualTo("Copper"));
        }
    }
}