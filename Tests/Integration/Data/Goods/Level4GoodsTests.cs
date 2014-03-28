using System;
using EquipmentGen.Common.Goods;
using EquipmentGen.Tests.Integration.Tables.TestAttributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Goods
{
    [TestFixture, PercentileTable("Level4Goods")]
    public class Level4GoodsTests : PercentileTests
    {
        [Test]
        public void Level4EmptyPercentile()
        {
            AssertPercentile(String.Empty, 1, 70);
        }

        [Test]
        public void Level4GemPercentile()
        {
            var content = String.Format("{0},1d4", GoodsConstants.Gem);
            AssertPercentile(content, 71, 95);
        }

        [Test]
        public void Level4ArtPercentile()
        {
            var content = String.Format("{0},1d3", GoodsConstants.Art);
            AssertPercentile(content, 96, 100);
        }
    }
}