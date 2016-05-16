using NUnit.Framework;
using System;
using TreasureGen.Goods;
using TreasureGen.Domain.Tables;

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

        [TestCase("1d10*10", "1d91+9", 1, 10)]
        [TestCase("3d6*10", "3d51+27", 11, 25)]
        [TestCase("1d6*100", "1d501+99", 26, 40)]
        [TestCase("1d10*100", "1d901+99", 41, 50)]
        [TestCase("2d6*100", "2d501+198", 51, 60)]
        [TestCase("3d6*100", "3d501+297", 61, 70)]
        [TestCase("4d6*100", "4d501+396", 71, 80)]
        [TestCase("5d6*100", "5d501+495", 81, 85)]
        [TestCase("1d4*1000", "1d3001+999", 86, 90)]
        [TestCase("1d6*1000", "1d5001+999", 91, 95)]
        [TestCase("2d4*1000", "2d3001+1998", 96, 99)]
        public override void TypeAndAmountPercentile(String type, String value, Int32 lower, Int32 upper)
        {
            base.TypeAndAmountPercentile(type, value, lower, upper);
        }

        [TestCase("2d6*1000", "2d5001+1998", 100)]
        public override void TypeAndAmountPercentile(String type, String value, Int32 roll)
        {
            base.TypeAndAmountPercentile(type, value, roll);
        }
    }
}