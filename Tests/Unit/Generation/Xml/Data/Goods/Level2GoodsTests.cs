using System;
using EquipmentGen.Core.Data.Goods;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Goods
{
    [TestFixture]
    public class Level2GoodsTests : PercentileTests
    {
        [SetUp]
        public void Setup()
        {
            tableName = "Level2Goods";
        }

        [Test]
        public void Level2EmptyPercentile()
        {
            AssertEmpty(1, 81);
        }

        [Test]
        public void Level2GemPercentile()
        {
            var content = String.Format("{0},1d3", GoodsConstants.Gem);
            AssertContent(content, 82, 95);
        }

        [Test]
        public void Level2ArtPercentile()
        {
            var content = String.Format("{0},1d3", GoodsConstants.Art);
            AssertContent(content, 96, 100);
        }
    }
}