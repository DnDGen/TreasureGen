using System;
using EquipmentGen.Common.Goods;
using EquipmentGen.Tests.Integration.Tables.TestAttributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Goods
{
    [TestFixture, PercentileTable("Level16Goods")]
    public class Level16GoodsTests : PercentileTests
    {
        [Test]
        public void Level16EmptyPercentile()
        {
            AssertEmpty(1, 7);
        }

        [Test]
        public void Level16GemPercentile()
        {
            var content = String.Format("{0},4d6", GoodsConstants.Gem);
            AssertContent(content, 8, 64);
        }

        [Test]
        public void Level16ArtPercentile()
        {
            var content = String.Format("{0},2d10", GoodsConstants.Art);
            AssertContent(content, 65, 100);
        }
    }
}