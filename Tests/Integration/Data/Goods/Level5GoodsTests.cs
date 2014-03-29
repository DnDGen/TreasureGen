using System;
using EquipmentGen.Common.Goods;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Goods
{
    [TestFixture]
    public class Level5GoodsTests : PercentileTests
    {
        protected override String GetTableName()
        {
            return "Level5Goods";
        }

        [Test]
        public void Level5EmptyPercentile()
        {
            AssertPercentile(String.Empty, 1, 60);
        }

        [Test]
        public void Level5GemPercentile()
        {
            var content = String.Format("{0},1d4", GoodsConstants.Gem);
            AssertPercentile(content, 61, 95);
        }

        [Test]
        public void Level5ArtPercentile()
        {
            var content = String.Format("{0},1d4", GoodsConstants.Art);
            AssertPercentile(content, 96, 100);
        }
    }
}