using System;
using EquipmentGen.Core.Data.Coins;
using EquipmentGen.Tests.Integration.Tables.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Coins
{
    [TestFixture, PercentileTable("Level2Coins")]
    public class Level2CoinTests : PercentileTests
    {
        [Test]
        public void Level2EmptyPercentile()
        {
            AssertEmpty(1, 13);
        }

        [Test]
        public void Level2CopperPercentile()
        {
            var result = String.Format("{0},1d10*1000", CoinConstants.Copper);
            AssertContent(result, 14, 23);
        }

        [Test]
        public void Level2SilverPercentile()
        {
            var result = String.Format("{0},2d10*100", CoinConstants.Silver);
            AssertContent(result, 24, 43);
        }

        [Test]
        public void Level2GoldPercentile()
        {
            var result = String.Format("{0},4d10*10", CoinConstants.Gold);
            AssertContent(result, 44, 95);
        }

        [Test]
        public void Level2PlatinumPercentile()
        {
            var result = String.Format("{0},2d8*10", CoinConstants.Platinum);
            AssertContent(result, 96, 100);
        }
    }
}