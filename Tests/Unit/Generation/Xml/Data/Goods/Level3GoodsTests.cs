using System;
using EquipmentGen.Core.Data.Goods;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Goods
{
    [TestFixture]
    public class Level3GoodsTests : PercentileTests
    {
        [SetUp]
        public void Setup()
        {
            tableName = "Level3Goods";
        }

        [Test]
        public void Level3EmptyPercentile()
        {
            AssertEmpty(1, 77);
        }

        [Test]
        public void Level3GemPercentile()
        {
            var content = String.Format("{0},1d3", GoodsConstants.Gem);
            AssertContent(content, 78, 95);
        }

        [Test]
        public void Level3ArtPercentile()
        {
            var content = String.Format("{0},1d3", GoodsConstants.Art);
            AssertContent(content, 96, 100);
        }
    }
}