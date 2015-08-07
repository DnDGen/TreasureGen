using NUnit.Framework;
using System;
using TreasureGen.Common.Goods;
using TreasureGen.Tables;

namespace TreasureGen.Tests.Integration.Tables.Goods.Art
{
    [TestFixture]
    public class ArtValuesTests : TypeAndAmountPercentileTests
    {
        protected override String tableName
        {
            get { return String.Format(TableNameConstants.Percentiles.Formattable.GOODTYPEValues, GoodsConstants.Art); }
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

        [TestCase("10d10", 1, 10)]
        [TestCase("30d6", 11, 25)]
        [TestCase("100d6", 26, 40)]
        [TestCase("100d10", 41, 50)]
        [TestCase("200d6", 51, 60)]
        [TestCase("300d6", 61, 70)]
        [TestCase("400d6", 71, 80)]
        [TestCase("500d6", 81, 85)]
        [TestCase("1000d4", 86, 90)]
        [TestCase("1000d6", 91, 95)]
        [TestCase("2000d4", 96, 99)]
        public override void TypeAndAmountPercentile(String value, Int32 lower, Int32 upper)
        {
            base.TypeAndAmountPercentile(value, value, lower, upper);
        }

        [TestCase("2000d6", 100)]
        public void TypeAndAmountPercentile(String value, Int32 roll)
        {
            TypeAndAmountPercentile(value, value, roll);
        }
    }
}