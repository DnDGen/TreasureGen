using System;
using EquipmentGen.Core.Data.Goods;
using EquipmentGen.Tests.Unit.Generation.Xml.Data.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Goods
{
    [TestFixture, PercentileTable("Level17Goods")]
    public class Level17GoodsTests : PercentileTests
    {
        [Test]
        public void Level17EmptyPercentile()
        {
            AssertEmpty(1, 4);
        }

        [Test]
        public void Level17GemPercentile()
        {
            var content = String.Format("{0},4d8", GoodsConstants.Gem);
            AssertContent(content, 5, 63);
        }

        [Test]
        public void Level17ArtPercentile()
        {
            var content = String.Format("{0},3d8", GoodsConstants.Art);
            AssertContent(content, 64, 100);
        }
    }
}