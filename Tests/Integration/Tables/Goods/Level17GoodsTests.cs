using System;
using EquipmentGen.Common.Goods;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Goods
{
    [TestFixture]
    public class Level17GoodsTests : PercentileTests
    {
        protected override String tableName
        {
            get { return "Level17Goods"; }
        }

        [TestCase(EmptyContent, 1, 4)]
        public void Percentile(String content, Int32 lower, Int32 upper)
        {
            AssertPercentile(content, lower, upper);
        }

        [TestCase(GoodsConstants.Gem, "4d8", 5, 63)]
        [TestCase(GoodsConstants.Art, "3d8", 64, 100)]
        public void Percentile(String good, String amount, Int32 lower, Int32 upper)
        {
            var content = String.Format("{0},{1}", good, amount);
            AssertPercentile(content, lower, upper);
        }
    }
}