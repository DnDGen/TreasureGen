using System;
using TreasureGen.Common.Goods;
using TreasureGen.Tables;
using NUnit.Framework;

namespace TreasureGen.Tests.Integration.Tables.Goods.Gems
{
    [TestFixture]
    public class GemValuesTests : TypeAndAmountPercentileTests
    {
        protected override String tableName
        {
            get { return String.Format(TableNameConstants.Percentiles.Formattable.GOODTYPEValues, GoodsConstants.Gem); }
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

        [TestCase("4d4", 1, 25)]
        [TestCase("2d4*10", 26, 50)]
        [TestCase("4d4*10", 51, 70)]
        [TestCase("2d4*100", 71, 90)]
        [TestCase("4d4*100", 91, 99)]
        public override void TypeAndAmountPercentile(String value, Int32 lower, Int32 upper)
        {
            base.TypeAndAmountPercentile(value, value, lower, upper);
        }

        [TestCase("2d4*1000", 100)]
        public void TypeAndAmountPercentile(String value, Int32 roll)
        {
            TypeAndAmountPercentile(value, value, roll);
        }
    }
}