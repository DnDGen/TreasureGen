using System;
using EquipmentGen.Core.Data.Goods;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Goods
{
    [TestFixture]
    public class Level14GoodsTests : PercentileTests
    {
        [SetUp]
        public void Setup()
        {
            tableName = "Level14Goods";
        }

        [Test]
        public void Level14EmptyPercentile()
        {
            AssertEmpty(1, 11);
        }

        [Test]
        public void Level14GemPercentile()
        {
            var content = String.Format("{0},2d8", GoodsConstants.Gem);
            AssertContent(content, 12, 66);
        }

        [Test]
        public void Level14ArtPercentile()
        {
            var content = String.Format("{0},2d6", GoodsConstants.Art);
            AssertContent(content, 67, 100);
        }
    }
}