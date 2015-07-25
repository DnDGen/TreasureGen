using System;
using TreasureGen.Common.Items;
using TreasureGen.Tables.Interfaces;
using NUnit.Framework;

namespace TreasureGen.Tests.Integration.Tables.Items.Mundane
{
    [TestFixture]
    public class MundaneItemsTests : PercentileTests
    {
        protected override String tableName
        {
            get { return String.Format(TableNameConstants.Percentiles.Formattable.POWERItems, PowerConstants.Mundane); }
        }

        [Test]
        public override void ReplacementStringsAreValid()
        {
            AssertReplacementStringsAreValid();
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(ItemTypeConstants.AlchemicalItem, 1, 17)]
        [TestCase(ItemTypeConstants.Armor, 18, 50)]
        [TestCase(ItemTypeConstants.Weapon, 51, 83)]
        [TestCase(ItemTypeConstants.Tool, 84, 100)]
        public override void Percentile(String content, Int32 lower, Int32 upper)
        {
            base.Percentile(content, lower, upper);
        }
    }
}