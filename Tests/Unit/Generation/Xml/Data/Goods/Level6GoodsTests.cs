using System;
using EquipmentGen.Core.Data.Goods;
using NUnit.Framework;

namespace EquipmentGen.Tests.Generation.Xml.Data.Goods
{
    [TestFixture]
    public class Level6GoodsTests : PercentileTests
    {
        [SetUp]
        public void Setup()
        {
            tableName = "Level6Goods";
        }

        [Test]
        public void Level6EmptyPercentile()
        {
            AssertEmpty(1, 56);
        }

        [Test]
        public void Level6GemPercentile()
        {
            var content = String.Format("{0},1d4", GoodsConstants.Gem);
            AssertContent(content, 57, 92);
        }

        [Test]
        public void Level6ArtPercentile()
        {
            var content = String.Format("{0},1d4", GoodsConstants.Art);
            AssertContent(content, 93, 100);
        }
    }
}