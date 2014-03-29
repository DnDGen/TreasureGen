using System;
using EquipmentGen.Common.Goods;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Goods
{
    [TestFixture]
    public class Level6GoodsTests : PercentileTests
    {
        protected override String GetTableName()
        {
            return "Level6Goods";
        }

        [Test]
        public void Level6EmptyPercentile()
        {
            AssertPercentile(String.Empty, 1, 56);
        }

        [Test]
        public void Level6GemPercentile()
        {
            var content = String.Format("{0},1d4", GoodsConstants.Gem);
            AssertPercentile(content, 57, 92);
        }

        [Test]
        public void Level6ArtPercentile()
        {
            var content = String.Format("{0},1d4", GoodsConstants.Art);
            AssertPercentile(content, 93, 100);
        }
    }
}