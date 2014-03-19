using EquipmentGen.Common.Items;
using EquipmentGen.Tests.Integration.Tables.TestAttributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.MundaneItems
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