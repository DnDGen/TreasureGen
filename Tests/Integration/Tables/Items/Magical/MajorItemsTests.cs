using System;
using TreasureGen.Common.Items;
using TreasureGen.Tables.Interfaces;
using NUnit.Framework;

namespace TreasureGen.Tests.Integration.Tables.Items.Magical
{
    [TestFixture]
    public class MajorItemsTests : PercentileTests
    {
        protected override String tableName
        {
            get { return String.Format(TableNameConstants.Percentiles.Formattable.POWERItems, PowerConstants.Major); }
        }

        [Test]
        public override void ReplacementStringsAreValid()
        {
            AssertReplacementStringsAreValid();
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
        public override void Percentile(String content, Int32 lower, Int32 upper)
        {
            base.Percentile(content, lower, upper);
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }
    }
}