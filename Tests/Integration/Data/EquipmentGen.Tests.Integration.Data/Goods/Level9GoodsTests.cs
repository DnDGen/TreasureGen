using System;
using EquipmentGen.Core.Data.Goods;
using EquipmentGen.Tests.Integration.Data.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Data.Goods
{
    [TestFixture, PercentileTable("Level9Goods")]
    public class Level9GoodsTests : PercentileTests
    {
        [Test]
        public void Level9EmptyPercentile()
        {
            AssertEmpty(1, 40);
        }

        [Test]
        public void Level9GemPercentile()
        {
            var content = String.Format("{0},1d8", GoodsConstants.Gem);
            AssertContent(content, 41, 80);
        }

        [Test]
        public void Level9ArtPercentile()
        {
            var content = String.Format("{0},1d4", GoodsConstants.Art);
            AssertContent(content, 81, 100);
        }
    }
}