using System;
using EquipmentGen.Common.Goods;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Goods
{
    [TestFixture]
    public class Level17GoodsTests : PercentileTests
    {
        protected override String GetTableName()
        {
            return "Level17Goods";
        }

        [Test]
        public void Level17EmptyPercentile()
        {
            AssertPercentile(String.Empty, 1, 4);
        }

        [Test]
        public void Level17GemPercentile()
        {
            var content = String.Format("{0},4d8", GoodsConstants.Gem);
            AssertPercentile(content, 5, 63);
        }

        [Test]
        public void Level17ArtPercentile()
        {
            var content = String.Format("{0},3d8", GoodsConstants.Art);
            AssertPercentile(content, 64, 100);
        }
    }
}