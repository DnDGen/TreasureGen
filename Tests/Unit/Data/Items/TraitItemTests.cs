using EquipmentGen.Core.Data.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Data.Items
{
    [TestFixture]
    public class TraitItemTests
    {
        private TraitItem item;

        [SetUp]
        public void Setup()
        {
            item = new TraitItem();
        }

        [Test]
        public void TraitsInitialized()
        {
            Assert.That(item.Traits, Is.Not.Null);
        }

        [Test]
        public void TypesInitialized()
        {
            Assert.That(item.Types, Is.Not.Null);
        }

        [Test]
        public void IntelligenceInitialized()
        {
            Assert.That(item.Intelligence, Is.Not.Null);
        }
    }
}