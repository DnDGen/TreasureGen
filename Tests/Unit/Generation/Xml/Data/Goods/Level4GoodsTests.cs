using System;
using EquipmentGen.Core.Data.Goods;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Goods
{
    [TestFixture]
    public class Level4GoodsTests : PercentileTests
    {
        [SetUp]
        public void Setup()
        {
            tableName = "Level4Goods";
        }

        [Test]
        public void Level4EmptyPercentile()
        {
            AssertEmpty(1, 70);
        }

        [Test]
        public void Level4GemPercentile()
        {
            var content = String.Format("{0},1d4", GoodsConstants.Gem);
            AssertContent(content, 71, 95);
        }

        [Test]
        public void Level4ArtPercentile()
        {
            var content = String.Format("{0},1d3", GoodsConstants.Art);
            AssertContent(content, 96, 100);
        }
    }
}