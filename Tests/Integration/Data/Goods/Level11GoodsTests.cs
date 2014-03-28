using System;
using EquipmentGen.Common.Goods;
using EquipmentGen.Tests.Integration.Tables.TestAttributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Goods
{
    [TestFixture, PercentileTable("Level11Goods")]
    public class Level11GoodsTests : PercentileTests
    {
        [Test]
        public void Level11EmptyPercentile()
        {
            AssertPercentile(String.Empty, 1, 24);
        }

        [Test]
        public void Level11GemPercentile()
        {
            var content = String.Format("{0},1d10", GoodsConstants.Gem);
            AssertPercentile(content, 25, 74);
        }

        [Test]
        public void Level11ArtPercentile()
        {
            var content = String.Format("{0},1d6", GoodsConstants.Art);
            AssertPercentile(content, 75, 100);
        }
    }
}