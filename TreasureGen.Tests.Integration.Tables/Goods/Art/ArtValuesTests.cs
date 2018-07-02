using NUnit.Framework;
using TreasureGen.Tables;
using TreasureGen.Goods;

namespace TreasureGen.Tests.Integration.Tables.Goods.Art
{
    [TestFixture]
    public class ArtValuesTests : TypeAndAmountPercentileTests
    {
        protected override string tableName
        {
            get { return string.Format(TableNameConstants.Percentiles.Formattable.GOODTYPEValues, GoodsConstants.Art); }
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

        [TestCase(AmountConstants.Range1d10x10, AmountConstants.Range1d10x10, 1, 10)]
        [TestCase(AmountConstants.Range3d6x10, AmountConstants.Range3d6x10, 11, 25)]
        [TestCase(AmountConstants.Range1d6x100, AmountConstants.Range1d6x100, 26, 40)]
        [TestCase(AmountConstants.Range1d10x100, AmountConstants.Range1d10x100, 41, 50)]
        [TestCase(AmountConstants.Range2d6x100, AmountConstants.Range2d6x100, 51, 60)]
        [TestCase(AmountConstants.Range3d6x100, AmountConstants.Range3d6x100, 61, 70)]
        [TestCase(AmountConstants.Range4d6x100, AmountConstants.Range4d6x100, 71, 80)]
        [TestCase(AmountConstants.Range5d6x100, AmountConstants.Range5d6x100, 81, 85)]
        [TestCase(AmountConstants.Range1d4x1000, AmountConstants.Range1d4x1000, 86, 90)]
        [TestCase(AmountConstants.Range1d6x1000, AmountConstants.Range1d6x1000, 91, 95)]
        [TestCase(AmountConstants.Range2d4x1000, AmountConstants.Range2d4x1000, 96, 99)]
        public override void TypeAndAmountPercentile(string type, string value, int lower, int upper)
        {
            base.TypeAndAmountPercentile(type, value, lower, upper);
        }

        [TestCase(AmountConstants.Range2d6x1000, AmountConstants.Range2d6x1000, 100)]
        public override void TypeAndAmountPercentile(string type, string value, int roll)
        {
            base.TypeAndAmountPercentile(type, value, roll);
        }
    }
}