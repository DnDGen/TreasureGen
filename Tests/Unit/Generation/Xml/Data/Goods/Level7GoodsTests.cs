using System;
using EquipmentGen.Core.Data.Goods;
using EquipmentGen.Tests.Unit.Generation.Xml.Data.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Goods
{
    [TestFixture, PercentileTable("Level7Goods")]
    public class Level7GoodsTests : PercentileTests
    {
        [Test]
        public void Level7EmptyPercentile()
        {
            AssertEmpty(1, 48);
        }

        [Test]
        public void Level7GemPercentile()
        {
            var content = String.Format("{0},1d4", GoodsConstants.Gem);
            AssertContent(content, 49, 88);
        }

        [Test]
        public void Level7ArtPercentile()
        {
            var content = String.Format("{0},1d4", GoodsConstants.Art);
            AssertContent(content, 89, 100);
        }
    }
}