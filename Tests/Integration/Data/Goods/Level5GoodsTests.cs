using System;
using EquipmentGen.Common.Goods;
using EquipmentGen.Tests.Integration.Tables.TestAttributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Goods
{
    [TestFixture, PercentileTable("Level5Goods")]
    public class Level5GoodsTests : PercentileTests
    {
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