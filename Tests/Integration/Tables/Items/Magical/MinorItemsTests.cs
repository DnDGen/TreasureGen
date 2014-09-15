using System;
using EquipmentGen.Common.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical
{
    [TestFixture]
    public class MinorItemsTests : PercentileTests
    {
        protected override String tableName
        {
            get { return "MinorItems"; }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(ItemTypeConstants.Armor, 1, 4)]
        [TestCase(ItemTypeConstants.Weapon, 5, 9)]
        [TestCase(ItemTypeConstants.Potion, 10, 44)]
        [TestCase(ItemTypeConstants.Ring, 45, 46)]
        [TestCase(ItemTypeConstants.Scroll, 47, 81)]
        [TestCase(ItemTypeConstants.Wand, 82, 91)]
        [TestCase(ItemTypeConstants.WondrousItem, 92, 100)]
        public override void Percentile(String content, Int32 lower, Int32 upper)
        {
            base.Percentile(content, lower, upper);
        }
    }
}