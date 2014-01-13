using System;
using EquipmentGen.Core.Data.Goods;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Goods
{
    [TestFixture]
    public class Level11GoodsTests : PercentileTests
    {
        [SetUp]
        public void Setup()
        {
            tableName = "Level11Goods";
        }

        [Test]
        public void Level11EmptyPercentile()
        {
            AssertEmpty(1, 24);
        }

        [Test]
        public void Level11GemPercentile()
        {
            var content = String.Format("{0},1d10", GoodsConstants.Gem);
            AssertContent(content, 25, 74);
        }

        [Test]
        public void Level11ArtPercentile()
        {
            var content = String.Format("{0},1d6", GoodsConstants.Art);
            AssertContent(content, 75, 100);
        }
    }
}