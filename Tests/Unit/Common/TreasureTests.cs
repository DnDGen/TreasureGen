using EquipmentGen.Common;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Common
{
    [TestFixture]
    public class TreasureTests
    {
        private Treasure treasure;

        [SetUp]
        public void Setup()
        {
            treasure = new Treasure();
        }

        [Test]
        public void TreasureInitialized()
        {
            Assert.That(treasure.Coin, Is.Not.Null);
            Assert.That(treasure.Goods, Is.Empty);
            Assert.That(treasure.Items, Is.Empty);
        }
    }
}