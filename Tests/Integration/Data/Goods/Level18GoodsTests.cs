using System;
using EquipmentGen.Common.Goods;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Goods
{
    [TestFixture]
    public class Level18GoodsTests : PercentileTests
    {
        protected override String GetTableName()
        {
            return "Level18Goods";
        }

        [Test]
        public void Level18EmptyPercentile()
        {
            AssertPercentile(String.Empty, 1, 4);
        }

        [Test]
        public void Level18GemPercentile()
        {
            var content = String.Format("{0},3d12", GoodsConstants.Gem);
            AssertPercentile(content, 5, 54);
        }

        [Test]
        public void Level18ArtPercentile()
        {
            var content = String.Format("{0},3d10", GoodsConstants.Art);
            AssertPercentile(content, 55, 100);
        }
    }
}