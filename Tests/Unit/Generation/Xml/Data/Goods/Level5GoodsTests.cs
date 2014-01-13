using System;
using EquipmentGen.Core.Data.Goods;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Goods
{
    [TestFixture]
    public class Level5GoodsTests : PercentileTests
    {
        [SetUp]
        public void Setup()
        {
            tableName = "Level5Goods";
        }

        [Test]
        public void Level5EmptyPercentile()
        {
            AssertEmpty(1, 60);
        }

        [Test]
        public void Level5GemPercentile()
        {
            var content = String.Format("{0},1d4", GoodsConstants.Gem);
            AssertContent(content, 61, 95);
        }

        [Test]
        public void Level5ArtPercentile()
        {
            var content = String.Format("{0},1d4", GoodsConstants.Art);
            AssertContent(content, 96, 100);
        }
    }
}