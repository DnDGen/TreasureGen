using NUnit.Framework;
using System;
using TreasureGen.Common.Goods;
using TreasureGen.Tables;

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
        [TestCase("20d4", 26, 50)]
        [TestCase("40d4", 51, 70)]
        [TestCase("200d4", 71, 90)]
        [TestCase("400d4", 91, 99)]
        public override void TypeAndAmountPercentile(String value, Int32 lower, Int32 upper)
        {
            base.TypeAndAmountPercentile(value, value, lower, upper);
        }

        [TestCase("2000d4", 100)]
        public void TypeAndAmountPercentile(String value, Int32 roll)
        {
            TypeAndAmountPercentile(value, value, roll);
        }
    }
}