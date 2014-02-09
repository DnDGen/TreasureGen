using EquipmentGen.Core.Data.Items;
using EquipmentGen.Core.Data.Items.Constants;
using EquipmentGen.Tests.Unit.Generation.Xml.Data.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Items.MagicalItems
{
    [TestFixture, PercentileTable("MinorItems")]
    public class MinorItemsTests : PercentileTests
    {
        [Test]
        public void MinorArmorPercentile()
        {
            AssertContent(ItemTypeConstants.Armor, 1, 4);
        }

        [Test]
        public void MinorWeaponPercentile()
        {
            AssertContent(ItemTypeConstants.Weapon, 5, 9);
        }

        [Test]
        public void MinorPotionPercentile()
        {
            AssertContent(ItemTypeConstants.Potion, 10, 44);
        }

        [Test]
        public void MinorRingPercentile()
        {
            AssertContent(ItemTypeConstants.Ring, 45, 46);
        }

        [Test]
        public void MinorScrollPercentile()
        {
            AssertContent(ItemTypeConstants.Scroll, 47, 81);
        }

        [Test]
        public void MinorWandPercentile()
        {
            AssertContent(ItemTypeConstants.Wand, 82, 91);
        }

        [Test]
        public void MinorWondrousItemPercentile()
        {
            AssertContent(ItemTypeConstants.WondrousItem, 92, 100);
        }
    }
}