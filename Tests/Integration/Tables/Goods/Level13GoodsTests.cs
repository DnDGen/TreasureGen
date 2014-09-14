using System;
using EquipmentGen.Common.Goods;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Goods
{
    [TestFixture]
    public class Level13GoodsTests : TypeAndAmountPercentileTests
    {
        protected override String tableName
        {
            get { return "Level13Goods"; }
        }

        [TestCase(EmptyContent, 1, 11)]
        public override void Percentile(String content, Int32 lower, Int32 upper)
        {
            base.Percentile(content, lower, upper);
        }

        [TestCase(GoodsConstants.Gem, "1d12", 12, 66)]
        [TestCase(GoodsConstants.Art, "1d10", 67, 100)]
        public override void TypeAndAmountPercentile(String type, String amount, Int32 lower, Int32 upper)
        {
            base.TypeAndAmountPercentile(type, amount, lower, upper);
        }
    }
}