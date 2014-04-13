using System;
using EquipmentGen.Common.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical
{
    [TestFixture]
    public class MajorItemsTests : PercentileTests
    {
        protected override String tableName
        {
            get { return "MajorItems"; }
        }

        [TestCase(ItemTypeConstants.Armor, 1, 10)]
        [TestCase(ItemTypeConstants.Weapon, 11, 20)]
        [TestCase(ItemTypeConstants.Potion, 21, 25)]
        [TestCase(ItemTypeConstants.Ring, 26, 35)]
        [TestCase(ItemTypeConstants.Rod, 36, 45)]
        [TestCase(ItemTypeConstants.Scroll, 46, 55)]
        [TestCase(ItemTypeConstants.Staff, 56, 75)]
        [TestCase(ItemTypeConstants.Wand, 76, 80)]
        [TestCase(ItemTypeConstants.WondrousItem, 81, 100)]
        public void Percentile(String content, Int32 lower, Int32 upper)
        {
            AssertPercentile(content, lower, upper);
        }
    }
}