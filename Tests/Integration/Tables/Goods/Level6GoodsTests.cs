using System;
using EquipmentGen.Common.Goods;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Goods
{
    [TestFixture]
    public class Level6GoodsTests : PercentileTests
    {
        protected override String tableName
        {
            get { return "Level6Goods"; }
        }

        [TestCase(EmptyContent, 1, 56)]
        public void Percentile(String content, Int32 lower, Int32 upper)
        {
            AssertPercentile(content, lower, upper);
        }

        [TestCase(GoodsConstants.Gem, "1d4", 57, 92)]
        [TestCase(GoodsConstants.Art, "1d4", 93, 100)]
        public void Percentile(String good, String amount, Int32 lower, Int32 upper)
        {
            var content = String.Format("{0},{1}", good, amount);
            AssertPercentile(content, lower, upper);
        }
    }
}