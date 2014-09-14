using System;
using EquipmentGen.Common.Goods;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Goods
{
    [TestFixture]
    public class Level7GoodsTests : TypeAndAmountPercentileTests
    {
        protected override String tableName
        {
            get { return "Level7Goods"; }
        }

        [TestCase(EmptyContent, 1, 48)]
        public override void Percentile(String content, Int32 lower, Int32 upper)
        {
            base.Percentile(content, lower, upper);
        }

        [TestCase(GoodsConstants.Gem, "1d4", 49, 88)]
        [TestCase(GoodsConstants.Art, "1d4", 89, 100)]
        public override void TypeAndAmountPercentile(String type, String amount, Int32 lower, Int32 upper)
        {
            base.TypeAndAmountPercentile(type, amount, lower, upper);
        }
    }
}