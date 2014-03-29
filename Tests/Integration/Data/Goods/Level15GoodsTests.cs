using System;
using EquipmentGen.Common.Goods;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Goods
{
    [TestFixture]
    public class Level15GoodsTests : PercentileTests
    {
        protected override String GetTableName()
        {
            return "Level15Goods";
        }

        [Test]
        public void Level15EmptyPercentile()
        {
            AssertPercentile(String.Empty, 1, 9);
        }

        [Test]
        public void Level15GemPercentile()
        {
            var content = String.Format("{0},2d10", GoodsConstants.Gem);
            AssertPercentile(content, 10, 65);
        }

        [Test]
        public void Level15ArtPercentile()
        {
            var content = String.Format("{0},2d8", GoodsConstants.Art);
            AssertPercentile(content, 66, 100);
        }
    }
}