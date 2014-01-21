using EquipmentGen.Core.Data.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Items.MagicalItems
{
    [TestFixture]
    public class MajorItemsTests : PercentileTests
    {
        [SetUp]
        public void Setup()
        {
            tableName = "MajorItems";
        }

        [Test]
        public void MajorArmorPercentile()
        {
            AssertContent(ItemsConstants.ItemTypes.Armor, 1, 10);
        }

        [Test]
        public void MajorWeaponPercentile()
        {
            AssertContent(ItemsConstants.ItemTypes.Weapon, 11, 20);
        }

        [Test]
        public void MajorPotionPercentile()
        {
            AssertContent(ItemsConstants.ItemTypes.Potion, 21, 25);
        }

        [Test]
        public void MajorRingPercentile()
        {
            AssertContent(ItemsConstants.ItemTypes.Ring, 26, 35);
        }

        [Test]
        public void MajorRodPercentile()
        {
            AssertContent(ItemsConstants.ItemTypes.Rod, 36, 45);
        }

        [Test]
        public void MajorScrollPercentile()
        {
            AssertContent(ItemsConstants.ItemTypes.Scroll, 46, 55);
        }

        [Test]
        public void MajorStaffPercentile()
        {
            AssertContent(ItemsConstants.ItemTypes.Staff, 56, 75);
        }

        [Test]
        public void MajorWandPercentile()
        {
            AssertContent(ItemsConstants.ItemTypes.Wand, 76, 80);
        }

        [Test]
        public void MajorWondrousItemPercentile()
        {
            AssertContent(ItemsConstants.ItemTypes.WondrousItem, 81, 100);
        }
    }
}
