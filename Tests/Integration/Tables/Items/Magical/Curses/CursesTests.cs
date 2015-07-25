using System;
using TreasureGen.Common.Items;
using TreasureGen.Tables;
using NUnit.Framework;

namespace TreasureGen.Tests.Integration.Tables.Items.Magical.Curses
{
    [TestFixture]
    public class CursesTests : PercentileTests
    {
        protected override String tableName
        {
            get { return TableNameConstants.Percentiles.Set.Curses; }
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

        [TestCase(CurseConstants.Delusion, 1, 15)]
        [TestCase(CurseConstants.OppositeEffect, 16, 35)]
        [TestCase(CurseConstants.Intermittent, 36, 45)]
        [TestCase(CurseConstants.Requirement, 46, 60)]
        [TestCase(CurseConstants.Drawback, 61, 75)]
        [TestCase(CurseConstants.DifferentEffect, 76, 90)]
        [TestCase(TableNameConstants.Percentiles.Set.SpecificCursedItems, 91, 100)]
        public override void Percentile(String content, Int32 lower, Int32 upper)
        {
            base.Percentile(content, lower, upper);
        }
    }
}