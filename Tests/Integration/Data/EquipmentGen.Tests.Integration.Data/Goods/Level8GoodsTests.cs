using System;
using EquipmentGen.Core.Data.Goods;
using EquipmentGen.Tests.Integration.Data.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Data.Goods
{
    [TestFixture, PercentileTable("Level8Goods")]
    public class Level8GoodsTests : PercentileTests
    {
        [Test]
        public void Level8EmptyPercentile()
        {
            AssertEmpty(1, 45);
        }

        [Test]
        public void Level8GemPercentile()
        {
            var content = String.Format("{0},1d6", GoodsConstants.Gem);
            AssertContent(content, 46, 85);
        }

        [Test]
        public void Level8ArtPercentile()
        {
            var content = String.Format("{0},1d4", GoodsConstants.Art);
            AssertContent(content, 86, 100);
        }
    }
}