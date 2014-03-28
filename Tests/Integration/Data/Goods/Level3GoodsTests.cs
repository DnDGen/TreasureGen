using System;
using EquipmentGen.Common.Goods;
using EquipmentGen.Tests.Integration.Tables.TestAttributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Goods
{
    [TestFixture, PercentileTable("Level3Goods")]
    public class Level3GoodsTests : PercentileTests
    {
        [Test]
        public void Level3EmptyPercentile()
        {
            AssertPercentile(String.Empty, 1, 77);
        }

        [Test]
        public void Level3GemPercentile()
        {
            var content = String.Format("{0},1d3", GoodsConstants.Gem);
            AssertPercentile(content, 78, 95);
        }

        [Test]
        public void Level3ArtPercentile()
        {
            var content = String.Format("{0},1d3", GoodsConstants.Art);
            AssertPercentile(content, 96, 100);
        }
    }
}