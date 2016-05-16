using NUnit.Framework;
using TreasureGen.Goods;

namespace TreasureGen.Tests.Unit.Generators.Goods
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