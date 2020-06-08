using DnDGen.TreasureGen.Items;
using DnDGen.TreasureGen.Tables;
using NUnit.Framework;

namespace DnDGen.TreasureGen.Tests.Integration.Tables.Items.Levels
{
    [TestFixture]
    public class Level27ItemsTests : TypeAndAmountPercentileTests
    {
        protected override string tableName
        {
            get { return string.Format(TableNameConstants.Percentiles.Formattable.LevelXItems, 27); }
        }

        [Test]
        public override void ReplacementStringsAreValid()
        {
            AssertReplacementStringsAreValid();
        }

        [TestCase(PowerConstants.Medium, AmountConstants.Range4d12, 1, 19)] //4-48
        [TestCase(PowerConstants.Major, AmountConstants.Range4d10, 20, 72)] //4-40
        [TestCase(PowerConstants.Major, AmountConstants.Range1d3Plus17, 73, 100)] //18-20
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