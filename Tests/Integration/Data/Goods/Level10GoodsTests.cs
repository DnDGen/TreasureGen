using System;
using EquipmentGen.Common.Goods;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Goods
{
    [TestFixture]
    public class Level10GoodsTests : PercentileTests
    {
        protected override String GetTableName()
        {
            return "Level10Goods";
        }

        [Test]
        public void Level10EmptyPercentile()
        {
            AssertPercentile(String.Empty, 1, 35);
        }

        [Test]
        public void Level10GemPercentile()
        {
            var content = String.Format("{0},1d8", GoodsConstants.Gem);
            AssertPercentile(content, 36, 79);
        }

        [Test]
        public void Level10ArtPercentile()
        {
            var content = String.Format("{0},1d6", GoodsConstants.Art);
            AssertPercentile(content, 80, 100);
        }
    }
}