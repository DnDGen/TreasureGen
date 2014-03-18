using EquipmentGen.Core.Data.Items.Constants;
using EquipmentGen.Tests.Integration.Tables.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.MagicalItems
{
    [TestFixture, PercentileTable("MajorItems")]
    public class MajorItemsTests : PercentileTests
    {
        [Test]
        public void MajorArmorPercentile()
        {
            AssertContent(ItemTypeConstants.Armor, 1, 10);
        }

        [Test]
        public void MajorWeaponPercentile()
        {
            AssertContent(ItemTypeConstants.Weapon, 11, 20);
        }

        [Test]
        public void MajorPotionPercentile()
        {
            AssertContent(ItemTypeConstants.Potion, 21, 25);
        }

        [Test]
        public void MajorRingPercentile()
        {
            AssertContent(ItemTypeConstants.Ring, 26, 35);
        }

        [Test]
        public void MajorRodPercentile()
        {
            AssertContent(ItemTypeConstants.Rod, 36, 45);
        }

        [Test]
        public void MajorScrollPercentile()
        {
            AssertContent(ItemTypeConstants.Scroll, 46, 55);
        }

        [Test]
        public void MajorStaffPercentile()
        {
            AssertContent(ItemTypeConstants.Staff, 56, 75);
        }

        [Test]
        public void MajorWandPercentile()
        {
            AssertContent(ItemTypeConstants.Wand, 76, 80);
        }

        [Test]
        public void MajorWondrousItemPercentile()
        {
            AssertContent(ItemTypeConstants.WondrousItem, 81, 100);
        }
    }
}
