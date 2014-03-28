using System;
using EquipmentGen.Common.Goods;
using EquipmentGen.Tests.Integration.Tables.TestAttributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Goods
{
    [TestFixture, PercentileTable("Level9Goods")]
    public class Level9GoodsTests : PercentileTests
    {
        [Test]
        public void Level9EmptyPercentile()
        {
            AssertPercentile(String.Empty, 1, 40);
        }

        [Test]
        public void Level9GemPercentile()
        {
            var content = String.Format("{0},1d8", GoodsConstants.Gem);
            AssertPercentile(content, 41, 80);
        }

        [Test]
        public void Level9ArtPercentile()
        {
            var content = String.Format("{0},1d4", GoodsConstants.Art);
            AssertPercentile(content, 81, 100);
        }
    }
}