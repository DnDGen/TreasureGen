using System;
using EquipmentGen.Common.Goods;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Goods
{
    [TestFixture]
    public class Level16GoodsTests : PercentileTests
    {
        protected override String GetTableName()
        {
            return "Level16Goods";
        }

        [Test]
        public void Level16EmptyPercentile()
        {
            AssertPercentile(String.Empty, 1, 7);
        }

        [Test]
        public void Level16GemPercentile()
        {
            var content = String.Format("{0},4d6", GoodsConstants.Gem);
            AssertPercentile(content, 8, 64);
        }

        [Test]
        public void Level16ArtPercentile()
        {
            var content = String.Format("{0},2d10", GoodsConstants.Art);
            AssertPercentile(content, 65, 100);
        }
    }
}