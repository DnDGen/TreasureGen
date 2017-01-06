using NUnit.Framework;
using TreasureGen.Domain.Tables;
using TreasureGen.Goods;

namespace TreasureGen.Tests.Integration.Tables.Goods.Gems
{
    [TestFixture]
    public class GemValuesTests : TypeAndAmountPercentileTests
    {
        protected override string tableName
        {
            get { return string.Format(TableNameConstants.Percentiles.Formattable.GOODTYPEValues, GoodsConstants.Gem); }
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

        [TestCase(AmountConstants.Range4d4, AmountConstants.Range4d4, 1, 25)]
        [TestCase(AmountConstants.Range2d4x10, AmountConstants.Range2d4x10, 26, 50)]
        [TestCase(AmountConstants.Range4d4x10, AmountConstants.Range4d4x10, 51, 70)]
        [TestCase(AmountConstants.Range2d4x100, AmountConstants.Range2d4x100, 71, 90)]
        [TestCase(AmountConstants.Range4d4x100, AmountConstants.Range4d4x100, 91, 99)]
        public override void TypeAndAmountPercentile(string type, string value, int lower, int upper)
        {
            base.TypeAndAmountPercentile(type, value, lower, upper);
        }

        [TestCase(AmountConstants.Range2d4x1000, AmountConstants.Range2d4x1000, 100)]
        public override void TypeAndAmountPercentile(string type, string value, int roll)
        {
            base.TypeAndAmountPercentile(type, value, roll);
        }
    }
}