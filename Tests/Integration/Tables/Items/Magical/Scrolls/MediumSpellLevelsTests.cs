using System;
using TreasureGen.Common.Items;
using TreasureGen.Tables.Interfaces;
using NUnit.Framework;

namespace TreasureGen.Tests.Integration.Tables.Items.Magical.Scrolls
{
    [TestFixture]
    public class MediumSpellLevelsTests : PercentileTests
    {
        protected override String tableName
        {
            get { return String.Format(TableNameConstants.Percentiles.Formattable.POWERSpellLevels, PowerConstants.Medium); }
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

        [TestCase("2", 1, 5)]
        [TestCase("3", 6, 65)]
        [TestCase("4", 66, 95)]
        [TestCase("5", 96, 100)]
        public override void Percentile(String content, Int32 lower, Int32 upper)
        {
            base.Percentile(content, lower, upper);
        }
    }
}