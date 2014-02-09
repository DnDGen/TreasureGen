using EquipmentGen.Core.Data.Items;
using EquipmentGen.Core.Data.Items.Constants;
using EquipmentGen.Tests.Unit.Generation.Xml.Data.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Items.MundaneItems
{
    [TestFixture, PercentileTable("MundaneItems")]
    public class MundaneItemsTests : PercentileTests
    {
        [Test]
        public void AlchemicalItemPercentile()
        {
            AssertContent(ItemTypeConstants.AlchemicalItem, 1, 17);
        }

        [Test]
        public void ArmorPercentile()
        {
            AssertContent(ItemTypeConstants.Armor, 18, 50);
        }

        [Test]
        public void WeaponPercentile()
        {
            AssertContent(ItemTypeConstants.Weapon, 51, 83);
        }

        [Test]
        public void ToolPercentile()
        {
            AssertContent(ItemTypeConstants.Tool, 84, 100);
        }
    }
}