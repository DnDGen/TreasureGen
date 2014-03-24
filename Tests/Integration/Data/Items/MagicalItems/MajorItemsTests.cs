using System;
using EquipmentGen.Common.Items;
using EquipmentGen.Tests.Integration.Tables.TestAttributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.MagicalItems
{
    [TestFixture, PercentileTable("MajorItems")]
    public class MajorItemsTests : PercentileTests
    {
        [TestCase(ItemTypeConstants.Armor, 1, 10)]
        [TestCase(ItemTypeConstants.Weapon, 11, 20)]
        [TestCase(ItemTypeConstants.Potion, 21, 25)]
        [TestCase(ItemTypeConstants.Ring, 26, 35)]
        [TestCase(ItemTypeConstants.Rod, 36, 45)]
        [TestCase(ItemTypeConstants.Scroll, 46, 55)]
        [TestCase(ItemTypeConstants.Staff, 56, 75)]
        [TestCase(ItemTypeConstants.Wand, 76, 80)]
        [TestCase(ItemTypeConstants.WondrousItem, 81, 100)]
        public void MinorItemsPercentile(String content, Int32 lower, Int32 upper)
        {
            AssertContent(content, lower, upper);
        }
    }
}