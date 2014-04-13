using System;
using EquipmentGen.Common.Goods;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Goods
{
    [TestFixture]
    public class Level19GoodsTests : PercentileTests
    {
        protected override String tableName
        {
            get { return "Level19Goods"; }
        }

        [TestCase(EmptyContent, 1, 3)]
        public void Percentile(String content, Int32 lower, Int32 upper)
        {
            AssertPercentile(content, lower, upper);
        }

        [TestCase(GoodsConstants.Gem, "6d6", 4, 50)]
        [TestCase(GoodsConstants.Art, "6d6", 51, 100)]
        public void Percentile(String good, String amount, Int32 lower, Int32 upper)
        {
            var content = String.Format("{0},{1}", good, amount);
            AssertPercentile(content, lower, upper);
        }
    }
}