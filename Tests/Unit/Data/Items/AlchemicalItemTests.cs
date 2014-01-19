using EquipmentGen.Core.Data.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Data.Items
{
    [TestFixture]
    public class AlchemicalItemTests
    {
        private Item alchemicalItem;

        [SetUp]
        public void Setup()
        {
            alchemicalItem = new AlchemicalItem() { Name = "name", Quantity = 3 };
        }

        [Test]
        public void AlchemicalItemToStringIsOverridden()
        {
            var toString = alchemicalItem.ToString();
            Assert.That(toString, Is.EqualTo("name (x3)"));
        }
    }
}