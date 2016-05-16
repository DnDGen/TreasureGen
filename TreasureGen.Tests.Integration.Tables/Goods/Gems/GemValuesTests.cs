using NUnit.Framework;
using System;
using TreasureGen.Goods;
using TreasureGen.Domain.Tables;

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

        [TestCase("4d4", "4d4", 1, 25)]
        [TestCase("2d4*10", "2d31+18", 26, 50)]
        [TestCase("4d4*10", "4d31+36", 51, 70)]
        [TestCase("2d4*100", "2d301+198", 71, 90)]
        [TestCase("4d4*100", "4d301+396", 91, 99)]
        public override void TypeAndAmountPercentile(String type, String value, Int32 lower, Int32 upper)
        {
            base.TypeAndAmountPercentile(type, value, lower, upper);
        }

        [TestCase("2d4*1000", "2d3001+1998", 100)]
        public override void TypeAndAmountPercentile(String type, String value, Int32 roll)
        {
            base.TypeAndAmountPercentile(type, value, roll);
        }
    }
}