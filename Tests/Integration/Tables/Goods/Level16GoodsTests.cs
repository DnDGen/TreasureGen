using System;
using EquipmentGen.Common.Goods;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Goods
{
    [TestFixture]
    public class Level16GoodsTests : PercentileTests
    {
        protected override String tableName
        {
            get { return "Level16Goods"; }
        }

        [TestCase(EmptyContent, 1, 7)]
        public void Percentile(String content, Int32 lower, Int32 upper)
        {
            AssertPercentile(content, lower, upper);
        }

        [TestCase(GoodsConstants.Gem, "4d6", 8, 64)]
        [TestCase(GoodsConstants.Art, "2d10", 65, 100)]
        public void Percentile(String good, String amount, Int32 lower, Int32 upper)
        {
            var content = String.Format("{0},{1}", good, amount);
            AssertPercentile(content, lower, upper);
        }
    }
}