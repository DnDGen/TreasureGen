using System;
using EquipmentGen.Common.Goods;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Goods
{
    [TestFixture]
    public class Level2GoodsTests : PercentileTests
    {
        protected override String GetTableName()
        {
            return "Level2Goods";
        }

        [Test]
        public void Level2EmptyPercentile()
        {
            AssertPercentile(String.Empty, 1, 81);
        }

        [Test]
        public void Level2GemPercentile()
        {
            var content = String.Format("{0},1d3", GoodsConstants.Gem);
            AssertPercentile(content, 82, 95);
        }

        [Test]
        public void Level2ArtPercentile()
        {
            var content = String.Format("{0},1d3", GoodsConstants.Art);
            AssertPercentile(content, 96, 100);
        }
    }
}