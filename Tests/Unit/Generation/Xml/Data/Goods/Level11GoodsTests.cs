using System;
using EquipmentGen.Core.Data.Goods;
using EquipmentGen.Tests.Unit.Generation.Xml.Data.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Goods
{
    [TestFixture, PercentileTable("Level11Goods")]
    public class Level11GoodsTests : PercentileTests
    {
        [Test]
        public void Level11EmptyPercentile()
        {
            AssertEmpty(1, 24);
        }

        [Test]
        public void Level11GemPercentile()
        {
            var content = String.Format("{0},1d10", GoodsConstants.Gem);
            AssertContent(content, 25, 74);
        }

        [Test]
        public void Level11ArtPercentile()
        {
            var content = String.Format("{0},1d6", GoodsConstants.Art);
            AssertContent(content, 75, 100);
        }
    }
}