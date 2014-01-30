using System;
using EquipmentGen.Core.Data.Goods;
using EquipmentGen.Tests.Unit.Generation.Xml.Data.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Goods
{
    [TestFixture, PercentileTable("Level13Goods")]
    public class Level13GoodsTests : PercentileTests
    {
        [Test]
        public void Level13EmptyPercentile()
        {
            AssertEmpty(1, 11);
        }

        [Test]
        public void Level13GemPercentile()
        {
            var content = String.Format("{0},1d12", GoodsConstants.Gem);
            AssertContent(content, 12, 66);
        }

        [Test]
        public void Level13ArtPercentile()
        {
            var content = String.Format("{0},1d10", GoodsConstants.Art);
            AssertContent(content, 67, 100);
        }
    }
}