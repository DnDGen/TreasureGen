using System;
using EquipmentGen.Core.Data.Goods;
using EquipmentGen.Tests.Unit.Generation.Xml.Data.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Goods
{
    [TestFixture, PercentileTable("Level20Goods")]
    public class Level20GoodsTests : PercentileTests
    {
        [Test]
        public void Level20EmptyPercentile()
        {
            AssertEmpty(1, 2);
        }

        [Test]
        public void Level20GemPercentile()
        {
            var content = String.Format("{0},4d10", GoodsConstants.Gem);
            AssertContent(content, 3, 38);
        }

        [Test]
        public void Level20ArtPercentile()
        {
            var content = String.Format("{0},7d6", GoodsConstants.Art);
            AssertContent(content, 39, 100);
        }
    }
}