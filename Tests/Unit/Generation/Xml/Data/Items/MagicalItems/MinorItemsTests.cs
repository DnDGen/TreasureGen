using EquipmentGen.Core.Data.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Items.MagicalItems
{
    [TestFixture]
    public class MinorItemsTests : PercentileTests
    {
        [SetUp]
        public void Setup()
        {
            tableName = "MinorItems";
        }

        [Test]
        public void MinorArmorPercentile()
        {
            AssertContent(ItemsConstants.ItemTypes.Armor, 1, 4);
        }

        [Test]
        public void MinorWeaponPercentile()
        {
            AssertContent(ItemsConstants.ItemTypes.Weapon, 5, 9);
        }

        [Test]
        public void MinorPotionPercentile()
        {
            AssertContent(ItemsConstants.ItemTypes.Potion, 10, 44);
        }

        [Test]
        public void MinorRingPercentile()
        {
            AssertContent(ItemsConstants.ItemTypes.Ring, 45, 46);
        }

        [Test]
        public void MinorScrollPercentile()
        {
            AssertContent(ItemsConstants.ItemTypes.Scroll, 47, 81);
        }

        [Test]
        public void MinorWandPercentile()
        {
            AssertContent(ItemsConstants.ItemTypes.Wand, 82, 91);
        }

        [Test]
        public void MinorWondrousItemPercentile()
        {
            AssertContent(ItemsConstants.ItemTypes.WondrousItem, 92, 100);
        }
    }
}