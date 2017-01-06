using NUnit.Framework;
using TreasureGen.Domain.Tables;
using TreasureGen.Goods;

namespace TreasureGen.Tests.Integration.Tables.Goods
{
    [TestFixture]
    public class Level16GoodsTests : TypeAndAmountPercentileTests
    {
        protected override string tableName
        {
            get { return string.Format(TableNameConstants.Percentiles.Formattable.LevelXGoods, 16); }
        }

        [Test]
        public override void ReplacementStringsAreValid()
        {
            AssertReplacementStringsAreValid();
        }

        [TestCase(EmptyContent, 1, 7)]
        public override void Percentile(string content, int lower, int upper)
        {
            base.Percentile(content, lower, upper);
        }

        [TestCase(GoodsConstants.Gem, AmountConstants.Range4d6, 8, 64)]
        [TestCase(GoodsConstants.Art, AmountConstants.Range2d10, 65, 100)]
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