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
            item = new BasicItem();
            item.Name = "shiny item";
        }

        [Test]
        public void ItemToStringIsItemName()
        {
            Assert.That(item.ToString(), Is.EqualTo(item.Name));
        }
    }
}