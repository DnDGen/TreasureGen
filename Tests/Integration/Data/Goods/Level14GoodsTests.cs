using System;
using EquipmentGen.Common.Goods;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Goods
{
    [TestFixture]
    public class Level14GoodsTests : PercentileTests
    {
        protected override String GetTableName()
        {
            return "Level14Goods";
        }

        [Test]
        public void Level14EmptyPercentile()
        {
            AssertPercentile(String.Empty, 1, 11);
        }

        [Test]
        public void Level14GemPercentile()
        {
            var content = String.Format("{0},2d8", GoodsConstants.Gem);
            AssertPercentile(content, 12, 66);
        }

        [Test]
        public void Level14ArtPercentile()
        {
            var content = String.Format("{0},2d6", GoodsConstants.Art);
            AssertPercentile(content, 67, 100);
        }
    }
}