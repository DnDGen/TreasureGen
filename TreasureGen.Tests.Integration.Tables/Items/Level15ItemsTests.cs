using NUnit.Framework;
using TreasureGen.Tables;
using TreasureGen.Items;

namespace TreasureGen.Tests.Integration.Tables.Items
{
    [TestFixture]
    public class Level15ItemsTests : TypeAndAmountPercentileTests
    {
        protected override string tableName
        {
            get { return string.Format(TableNameConstants.Percentiles.Formattable.LevelXItems, 15); }
        }

        [Test]
        public override void ReplacementStringsAreValid()
        {
            AssertReplacementStringsAreValid();
        }

        [TestCase(EmptyContent, 1, 11)]
        public override void Percentile(string content, int lower, int upper)
        {
            base.Percentile(content, lower, upper);
        }

        [TestCase(PowerConstants.Minor, AmountConstants.Range1d10, 12, 46)]
        [TestCase(PowerConstants.Medium, AmountConstants.Range1, 47, 90)]
        [TestCase(PowerConstants.Major, AmountConstants.Range1, 91, 100)]
        public override void TypeAndAmountPercentile(string type, string amount, int lower, int upper)
        {
            base.TypeAndAmountPercentile(type, amount, lower, upper);
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }
    }
}