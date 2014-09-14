using System;
using EquipmentGen.Common.Goods;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Goods
{
    [TestFixture]
    public class Level6GoodsTests : TypeAndAmountPercentileTests
    {
        protected override String tableName
        {
            get { return "Level6Goods"; }
        }

        [TestCase(EmptyContent, 1, 56)]
        public override void Percentile(String content, Int32 lower, Int32 upper)
        {
            base.Percentile(content, lower, upper);
        }

        [TestCase(GoodsConstants.Gem, "1d4", 57, 92)]
        [TestCase(GoodsConstants.Art, "1d4", 93, 100)]
        public override void TypeAndAmountPercentile(String type, String amount, Int32 lower, Int32 upper)
        {
            base.TypeAndAmountPercentile(type, amount, lower, upper);
        }
    }
}