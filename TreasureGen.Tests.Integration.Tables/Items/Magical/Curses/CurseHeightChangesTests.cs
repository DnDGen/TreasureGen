using NUnit.Framework;
using TreasureGen.Tables;

namespace TreasureGen.Tests.Integration.Tables.Items.Magical.Curses
{
    [TestFixture]
    public class CurseHeightChangesTests : PercentileTests
    {
        protected override string tableName
        {
            get { return TableNameConstants.Percentiles.Set.CurseHeightChanges; }
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

        [TestCase("shrink", 1, 50)]
        [TestCase("grow", 51, 100)]
        public override void Percentile(string content, int lower, int upper)
        {
            base.Percentile(content, lower, upper);
        }
    }
}