using System;
using EquipmentGen.Common.Items;
using EquipmentGen.Tests.Integration.Tables.TestAttributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.MagicalItems
{
    [TestFixture, PercentileTable("MediumItems")]
    public class MediumItemsTests : PercentileTests
    {
        [TestCase(ItemTypeConstants.Armor, 1, 10)]
        [TestCase(ItemTypeConstants.Weapon, 11, 20)]
        [TestCase(ItemTypeConstants.Potion, 21, 30)]
        [TestCase(ItemTypeConstants.Ring, 31, 40)]
        [TestCase(ItemTypeConstants.Rod, 41, 50)]
        [TestCase(ItemTypeConstants.Scroll, 51, 65)]
        [TestCase(ItemTypeConstants.Staff, 66, 68)]
        [TestCase(ItemTypeConstants.Wand, 69, 83)]
        [TestCase(ItemTypeConstants.WondrousItem, 84, 100)]
        public void Percentile(String content, Int32 lower, Int32 upper)
        {
            AssertPercentile(content, lower, upper);
        }
    }
}