using System;
using EquipmentGen.Common.Goods;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Goods
{
    [TestFixture]
    public class Level20GoodsTests : TypeAndAmountPercentileTests
    {
        protected override String tableName
        {
            get { return "Level20Goods"; }
        }

        [TestCase(EmptyContent, 1, 2)]
        public override void Percentile(String content, Int32 lower, Int32 upper)
        {
            base.Percentile(content, lower, upper);
        }

        [TestCase(GoodsConstants.Gem, "4d10", 3, 38)]
        [TestCase(GoodsConstants.Art, "7d6", 39, 100)]
        public override void TypeAndAmountPercentile(String type, String amount, Int32 lower, Int32 upper)
        {
            base.TypeAndAmountPercentile(type, amount, lower, upper);
        }
    }
}