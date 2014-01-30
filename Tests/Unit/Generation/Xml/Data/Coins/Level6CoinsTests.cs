using System;
using EquipmentGen.Core.Data.Coins;
using EquipmentGen.Tests.Unit.Generation.Xml.Data.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Coins
{
    [TestFixture, PercentileTable("Level6Coins")]
    public class Level6CoinTests : PercentileTests
    {
        [Test]
        public void Level6EmptyPercentile()
        {
            AssertEmpty(1, 10);
        }

        [Test]
        public void Level6CopperPercentile()
        {
            var result = String.Format("{0},1d6*10000", CoinConstants.Copper);
            AssertContent(result, 11, 18);
        }

        [Test]
        public void Level6SilverPercentile()
        {
            var result = String.Format("{0},1d8*1000", CoinConstants.Silver);
            AssertContent(result, 19, 37);
        }

        [Test]
        public void Level6GoldPercentile()
        {
            var result = String.Format("{0},1d10*100", CoinConstants.Gold);
            AssertContent(result, 38, 95);
        }

        [Test]
        public void Level6PlatinumPercentile()
        {
            var result = String.Format("{0},1d12*10", CoinConstants.Platinum);
            AssertContent(result, 96, 100);
        }
    }
}