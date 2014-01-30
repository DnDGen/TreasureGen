using System;
using EquipmentGen.Core.Data.Goods;
using EquipmentGen.Tests.Unit.Generation.Xml.Data.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Goods
{
    [TestFixture, PercentileTable("Level19Goods")]
    public class Level19GoodsTests : PercentileTests
    {
        [Test]
        public void Level19EmptyPercentile()
        {
            AssertEmpty(1, 3);
        }

        [Test]
        public void Level19GemPercentile()
        {
            var content = String.Format("{0},6d6", GoodsConstants.Gem);
            AssertContent(content, 4, 50);
        }

        [Test]
        public void Level19ArtPercentile()
        {
            var content = String.Format("{0},6d6", GoodsConstants.Art);
            AssertContent(content, 51, 100);
        }
    }
}