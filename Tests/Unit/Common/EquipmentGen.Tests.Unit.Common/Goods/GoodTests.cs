using EquipmentGen.Common.Goods;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Common.Goods
{
    [TestFixture]
    public class GoodTests
    {
        private Good good;

        [SetUp]
        public void Setup()
        {
            good = new Good();
        }

        [Test]
        public void DescriptionInitialized()
        {
            Assert.That(good.Description, Is.Empty);
        }

        [Test]
        public void ValueInGoldInitialized()
        {
            Assert.That(good.ValueInGold, Is.EqualTo(0));
        }
    }
}