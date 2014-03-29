using System;
using EquipmentGen.Common.Goods;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Goods
{
    [TestFixture]
    public class Level8GoodsTests : PercentileTests
    {
        protected override String GetTableName()
        {
            return "Level8Goods";
        }

        [Test]
        public void Level8EmptyPercentile()
        {
            AssertPercentile(String.Empty, 1, 45);
        }

        [Test]
        public void Level8GemPercentile()
        {
            var content = String.Format("{0},1d6", GoodsConstants.Gem);
            AssertPercentile(content, 46, 85);
        }

        [Test]
        public void Level8ArtPercentile()
        {
            var content = String.Format("{0},1d4", GoodsConstants.Art);
            AssertPercentile(content, 86, 100);
        }
    }
}