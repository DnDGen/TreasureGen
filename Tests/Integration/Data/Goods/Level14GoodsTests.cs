using System;
using EquipmentGen.Core.Data.Goods;
using EquipmentGen.Tests.Integration.Tables.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Goods
{
    [TestFixture, PercentileTable("Level14Goods")]
    public class Level14GoodsTests : PercentileTests
    {
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