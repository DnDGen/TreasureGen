using System;
using EquipmentGen.Common.Goods;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Goods
{
    [TestFixture]
    public class Level18GoodsTests : PercentileTests
    {
        protected override String tableName
        {
            get { return "Level18Goods"; }
        }

        [TestCase(EmptyContent, 1, 4)]
        public void Percentile(String content, Int32 lower, Int32 upper)
        {
            AssertPercentile(content, lower, upper);
        }

        [TestCase(GoodsConstants.Gem, "3d12", 5, 54)]
        [TestCase(GoodsConstants.Art, "3d10", 55, 100)]
        public void Percentile(String good, String amount, Int32 lower, Int32 upper)
        {
            var content = String.Format("{0},{1}", good, amount);
            AssertPercentile(content, lower, upper);
        }
    }
}