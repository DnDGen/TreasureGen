using System;
using EquipmentGen.Core.Data.Goods;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Goods
{
    [TestFixture]
    public class Level1GoodsTests : PercentileTests
    {
        [SetUp]
        public void Setup()
        {
            tableName = "Level1Goods";
        }

        [Test]
        public void Level1EmptyPercentile()
        {
            AssertEmpty(1, 90);
        }

        [Test]
        public void Level1GemPercentile()
        {
            var content = String.Format("{0},1", GoodsConstants.Gem);
            AssertContent(content, 91, 95);
        }

        [Test]
        public void Level1ArtPercentile()
        {
            var content = String.Format("{0},1", GoodsConstants.Art);
            AssertContent(content, 96, 100);
        }
    }
}