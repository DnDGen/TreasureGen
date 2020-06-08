using DnDGen.TreasureGen.Items;
using DnDGen.TreasureGen.Tables;
using NUnit.Framework;

namespace DnDGen.TreasureGen.Tests.Integration.Tables.Items.Levels
{
    [TestFixture]
    public class Level30ItemsTests : TypeAndAmountPercentileTests
    {
        protected override string tableName
        {
            get { return string.Format(TableNameConstants.Percentiles.Formattable.LevelXItems, 30); }
        }

        [Test]
        public override void ReplacementStringsAreValid()
        {
            AssertReplacementStringsAreValid();
        }

        [TestCase(PowerConstants.Medium, AmountConstants.Range2d100, 1, 16)] //2-200
        [TestCase(PowerConstants.Major, AmountConstants.Range1d100, 17, 69)] //1-100
        [TestCase(PowerConstants.Major, AmountConstants.Range1d3Plus42, 70, 100)] //43-45
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