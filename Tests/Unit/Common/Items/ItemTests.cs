using EquipmentGen.Common.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Common.Items
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
        public void NameInitialized()
        {
            Assert.That(item.Name, Is.Empty);
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