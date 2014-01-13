using System;
using EquipmentGen.Core.Data.Goods;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Goods
{
    [TestFixture]
    public class Level16GoodsTests : PercentileTests
    {
        [SetUp]
        public void Setup()
        {
            tableName = "Level16Goods";
        }

        [Test]
        public void Level16EmptyPercentile()
        {
            AssertEmpty(1, 7);
        }

        [Test]
        public void Level16GemPercentile()
        {
            var content = String.Format("{0},4d6", GoodsConstants.Gem);
            AssertContent(content, 8, 64);
        }

        [Test]
        public void Level16ArtPercentile()
        {
            var content = String.Format("{0},2d10", GoodsConstants.Art);
            AssertContent(content, 65, 100);
        }
    }
}