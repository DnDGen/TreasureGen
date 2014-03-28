using System;
using EquipmentGen.Common.Coins;
using EquipmentGen.Tests.Integration.Tables.TestAttributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Coins
{
    [TestFixture, PercentileTable("Level3Coins")]
    public class Level3CoinTests : PercentileTests
    {
        [Test]
        public void Level3EmptyPercentile()
        {
            AssertPercentile(String.Empty, 1, 11);
        }

        [Test]
        public void Level3CopperPercentile()
        {
            var result = String.Format("{0},2d10*1000", CoinConstants.Copper);
            AssertPercentile(result, 12, 21);
        }

        [Test]
        public void Level3SilverPercentile()
        {
            var result = String.Format("{0},4d8*100", CoinConstants.Silver);
            AssertPercentile(result, 22, 41);
        }

        [Test]
        public void Level3GoldPercentile()
        {
            var result = String.Format("{0},1d4*100", CoinConstants.Gold);
            AssertPercentile(result, 42, 95);
        }

        [Test]
        public void Level3PlatinumPercentile()
        {
            var result = String.Format("{0},1d10*10", CoinConstants.Platinum);
            AssertPercentile(result, 96, 100);
        }
    }
}