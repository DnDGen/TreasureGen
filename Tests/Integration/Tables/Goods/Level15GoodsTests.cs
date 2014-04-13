using System;
using EquipmentGen.Common.Goods;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Goods
{
    [TestFixture]
    public class Level15GoodsTests : PercentileTests
    {
        protected override String tableName
        {
            get { return "Level15Goods"; }
        }

        [TestCase(EmptyContent, 1, 9)]
        public void Percentile(String content, Int32 lower, Int32 upper)
        {
            AssertPercentile(content, lower, upper);
        }

        [TestCase(GoodsConstants.Gem, "2d10", 10, 65)]
        [TestCase(GoodsConstants.Art, "2d8", 66, 100)]
        public void Percentile(String good, String amount, Int32 lower, Int32 upper)
        {
            var content = String.Format("{0},{1}", good, amount);
            AssertPercentile(content, lower, upper);
        }
    }
}