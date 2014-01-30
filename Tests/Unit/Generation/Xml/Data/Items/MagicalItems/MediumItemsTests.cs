using EquipmentGen.Core.Data.Items;
using EquipmentGen.Tests.Unit.Generation.Xml.Data.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Items.MagicalItems
{
    [TestFixture, PercentileTable("MediumItems")]
    public class MediumItemsTests : PercentileTests
    {
        [Test]
        public void MediumArmorPercentile()
        {
            AssertContent(ItemsConstants.ItemTypes.Armor, 1, 10);
        }

        [Test]
        public void MediumWeaponPercentile()
        {
            AssertContent(ItemsConstants.ItemTypes.Weapon, 11, 20);
        }

        [Test]
        public void MediumPotionPercentile()
        {
            AssertContent(ItemsConstants.ItemTypes.Potion, 21, 30);
        }

        [Test]
        public void MediumRingPercentile()
        {
            AssertContent(ItemsConstants.ItemTypes.Ring, 31, 40);
        }

        [Test]
        public void MediumRodPercentile()
        {
            AssertContent(ItemsConstants.ItemTypes.Rod, 41, 50);
        }

        [Test]
        public void MediumScrollPercentile()
        {
            AssertContent(ItemsConstants.ItemTypes.Scroll, 51, 65);
        }

        [Test]
        public void MediumStaffPercentile()
        {
            AssertContent(ItemsConstants.ItemTypes.Staff, 66, 68);
        }

        [Test]
        public void MediumWandPercentile()
        {
            AssertContent(ItemsConstants.ItemTypes.Wand, 69, 83);
        }

        [Test]
        public void MediumWondrousItemPercentile()
        {
            AssertContent(ItemsConstants.ItemTypes.WondrousItem, 84, 100);
        }
    }
}
