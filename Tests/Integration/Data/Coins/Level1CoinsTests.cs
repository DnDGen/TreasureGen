using System;
using EquipmentGen.Common.Coins;
using EquipmentGen.Tests.Integration.Tables.TestAttributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Coins
{
    [TestFixture, PercentileTable("Level1Coins")]
    public class Level1CoinTests : PercentileTests
    {
        [Test]
        public void Level1EmptyPercentile()
        {
            AssertPercentile(String.Empty, 1, 14);
        }

        [Test]
        public void Level1CopperPercentile()
        {
            var result = String.Format("{0},1d6*1000", CoinConstants.Copper);
            AssertPercentile(result, 15, 29);
        }

        [Test]
        public void Level1SilverPercentile()
        {
            var result = String.Format("{0},1d8*100", CoinConstants.Silver);
            AssertPercentile(result, 30, 52);
        }

        [Test]
        public void Level1GoldPercentile()
        {
            var result = String.Format("{0},2d8*10", CoinConstants.Gold);
            AssertPercentile(result, 53, 95);
        }

        [Test]
        public void Level1PlatinumPercentile()
        {
            var result = String.Format("{0},1d4*10", CoinConstants.Platinum);
            AssertPercentile(result, 96, 100);
        }
    }
}