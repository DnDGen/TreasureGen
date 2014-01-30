using System;
using EquipmentGen.Core.Data.Goods;
using EquipmentGen.Tests.Unit.Generation.Xml.Data.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Goods
{
    [TestFixture, PercentileTable("Level12Goods")]
    public class Level12GoodsTests : PercentileTests
    {
        [Test]
        public void Level12EmptyPercentile()
        {
            AssertEmpty(1, 17);
        }

        [Test]
        public void Level12GemPercentile()
        {
            var content = String.Format("{0},1d10", GoodsConstants.Gem);
            AssertContent(content, 18, 70);
        }

        [Test]
        public void Level12ArtPercentile()
        {
            var content = String.Format("{0},1d8", GoodsConstants.Art);
            AssertContent(content, 71, 100);
        }
    }
}