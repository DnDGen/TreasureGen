using System;
using EquipmentGen.Common.Goods;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Goods
{
    [TestFixture]
    public class Level15GoodsTests : TypeAndAmountPercentileTests
    {
        protected override String tableName
        {
            get { return "Level15Goods"; }
        }

        [TestCase(EmptyContent, 1, 9)]
        public override void Percentile(String content, Int32 lower, Int32 upper)
        {
            base.Percentile(content, lower, upper);
        }

        [TestCase(GoodsConstants.Gem, "2d10", 10, 65)]
        [TestCase(GoodsConstants.Art, "2d8", 66, 100)]
        public override void TypeAndAmountPercentile(String type, String amount, Int32 lower, Int32 upper)
        {
            base.TypeAndAmountPercentile(type, amount, lower, upper);
        }
    }
}