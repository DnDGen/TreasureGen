using EquipmentGen.Core.Data.Coins;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Data.Coins
{
    [TestFixture]
    public class CoinConstantsTests
    {
        [Test]
        public void GoldConstant()
        {
            Assert.That(CoinConstants.Gold, Is.EqualTo("Gold"));
        }

        [Test]
        public void PlatinumConstant()
        {
            Assert.That(CoinConstants.Platinum, Is.EqualTo("Platinum"));
        }

        [Test]
        public void SilverConstant()
        {
            Assert.That(CoinConstants.Silver, Is.EqualTo("Silver"));
        }

        [Test]
        public void CopperConstant()
        {
            Assert.That(CoinConstants.Copper, Is.EqualTo("Copper"));
        }
    }
}