using System;
using EquipmentGen.Common.Goods;
using EquipmentGen.Tests.Integration.Tables.TestAttributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Goods
{
    [TestFixture, PercentileTable("Level19Goods")]
    public class Level19GoodsTests : PercentileTests
    {
        [Test]
        public void Level19EmptyPercentile()
        {
            AssertPercentile(String.Empty, 1, 3);
        }

        [Test]
        public void Level19GemPercentile()
        {
            var content = String.Format("{0},6d6", GoodsConstants.Gem);
            AssertPercentile(content, 4, 50);
        }

        [Test]
        public void Level19ArtPercentile()
        {
            var content = String.Format("{0},6d6", GoodsConstants.Art);
            AssertPercentile(content, 51, 100);
        }
    }
}