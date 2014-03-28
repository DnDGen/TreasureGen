using System;
using EquipmentGen.Common.Items;
using EquipmentGen.Tests.Integration.Tables.TestAttributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.MagicalItems
{
    [TestFixture, PercentileTable("MinorItems")]
    public class MinorItemsTests : PercentileTests
    {
        [TestCase(ItemTypeConstants.Armor, 1, 4)]
        [TestCase(ItemTypeConstants.Weapon, 5, 9)]
        [TestCase(ItemTypeConstants.Potion, 10, 44)]
        [TestCase(ItemTypeConstants.Ring, 45, 46)]
        [TestCase(ItemTypeConstants.Scroll, 47, 81)]
        [TestCase(ItemTypeConstants.Wand, 82, 91)]
        [TestCase(ItemTypeConstants.WondrousItem, 92, 100)]
        public void Percentile(String content, Int32 lower, Int32 upper)
        {
            AssertPercentile(content, lower, upper);
        }
    }
}