using NUnit.Framework;
using TreasureGen.Domain.Tables;
using TreasureGen.Goods;

namespace TreasureGen.Tests.Integration.Tables.Goods
{
    [TestFixture]
    public class Level7GoodsTests : TypeAndAmountPercentileTests
    {
        protected override string tableName
        {
            get { return string.Format(TableNameConstants.Percentiles.Formattable.LevelXGoods, 7); }
        }

        [Test]
        public override void ReplacementStringsAreValid()
        {
            AssertReplacementStringsAreValid();
        }

        [TestCase(EmptyContent, 1, 48)]
        public override void Percentile(string content, int lower, int upper)
        {
            base.Percentile(content, lower, upper);
        }

        [TestCase(GoodsConstants.Gem, AmountConstants.Range1d4, 49, 88)]
        [TestCase(GoodsConstants.Art, AmountConstants.Range1d4, 89, 100)]
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