using EquipmentGen.Core.Data.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Data.Items
{
    [TestFixture]
    public class ItemTests
    {
        private Item item;

        [SetUp]
        public void Setup()
        {
            item = new Item();
        }

        [Test]
        public void AttributesInitialized()
        {
            Assert.That(item.Attributes, Is.Empty);
        }

        [Test]
        public void MagicInitialized()
        {
            Assert.That(item.Magic, Is.Empty);
        }

        [Test]
        public void QuantityInitialized()
        {
            Assert.That(item.Quantity, Is.EqualTo(1));
        }

        [Test]
        public void TraitsInitialized()
        {
            Assert.That(item.Traits, Is.Empty);
        }
    }
}