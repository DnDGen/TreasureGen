using System;
using EquipmentGen.Common.Goods;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Goods
{
    [TestFixture]
    public class Level7GoodsTests : PercentileTests
    {
        protected override String GetTableName()
        {
            return "Level7Goods";
        }

        [Test]
        public void Level7EmptyPercentile()
        {
            AssertPercentile(String.Empty, 1, 48);
        }

        [Test]
        public void Level7GemPercentile()
        {
            var content = String.Format("{0},1d4", GoodsConstants.Gem);
            AssertPercentile(content, 49, 88);
        }

        [Test]
        public void Level7ArtPercentile()
        {
            var content = String.Format("{0},1d4", GoodsConstants.Art);
            AssertPercentile(content, 89, 100);
        }
    }
}