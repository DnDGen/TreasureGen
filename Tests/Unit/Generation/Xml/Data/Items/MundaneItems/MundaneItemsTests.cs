using EquipmentGen.Core.Data.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Items.MundaneItems
{
    [TestFixture]
    public class MundaneItemsTests : PercentileTests
    {
        [SetUp]
        public void Setup()
        {
            tableName = "MundaneItems";
        }

        [Test]
        public void AlchemicalItemPercentile()
        {
            AssertContent(ItemsConstants.ItemTypes.AlchemicalItem, 1, 17);
        }

        [Test]
        public void ArmorPercentile()
        {
            AssertContent(ItemsConstants.ItemTypes.Armor, 18, 50);
        }

        [Test]
        public void WeaponPercentile()
        {
            AssertContent(ItemsConstants.ItemTypes.Weapon, 51, 83);
        }

        [Test]
        public void ToolPercentile()
        {
            AssertContent(ItemsConstants.ItemTypes.Tool, 84, 100);
        }
    }
}