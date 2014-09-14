using System;
using EquipmentGen.Common.Goods;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Goods
{
    [TestFixture]
    public class Level17GoodsTests : TypeAndAmountPercentileTests
    {
        protected override String tableName
        {
            get { return "Level17Goods"; }
        }

        [TestCase(EmptyContent, 1, 4)]
        public override void Percentile(String content, Int32 lower, Int32 upper)
        {
            base.Percentile(content, lower, upper);
        }

        [TestCase(GoodsConstants.Gem, "4d8", 5, 63)]
        [TestCase(GoodsConstants.Art, "3d8", 64, 100)]
        public override void TypeAndAmountPercentile(String type, String amount, Int32 lower, Int32 upper)
        {
            base.TypeAndAmountPercentile(type, amount, lower, upper);
        }
    }
}