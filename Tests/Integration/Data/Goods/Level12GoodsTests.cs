using System;
using EquipmentGen.Common.Goods;
using EquipmentGen.Tests.Integration.Tables.TestAttributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Goods
{
    [TestFixture, PercentileTable("Level12Goods")]
    public class Level12GoodsTests : PercentileTests
    {
        [Test]
        public void Level12EmptyPercentile()
        {
            AssertPercentile(String.Empty, 1, 17);
        }

        [Test]
        public void Level12GemPercentile()
        {
            var content = String.Format("{0},1d10", GoodsConstants.Gem);
            AssertPercentile(content, 18, 70);
        }

        [Test]
        public void Level12ArtPercentile()
        {
            var content = String.Format("{0},1d8", GoodsConstants.Art);
            AssertPercentile(content, 71, 100);
        }
    }
}