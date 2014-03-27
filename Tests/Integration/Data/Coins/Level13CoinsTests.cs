using System;
using EquipmentGen.Common.Coins;
using EquipmentGen.Tests.Integration.Tables.TestAttributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Coins
{
    [TestFixture, PercentileTable("Level13Coins")]
    public class Level13CoinTests : PercentileTests
    {
        [Test]
        public void Level13EmptyPercentile()
        {
            AssertEmpty(1, 8);
        }

        [Test]
        public void Level13GoldPercentile()
        {
            var result = String.Format("{0},1d4*1000", CoinConstants.Gold);
            AssertPercentile(result, 9, 75);
        }

        [Test]
        public void Level13PlatinumPercentile()
        {
            var result = String.Format("{0},1d10*100", CoinConstants.Platinum);
            AssertPercentile(result, 76, 100);
        }
    }
}