using System;
using EquipmentGen.Core.Data.Coins;
using EquipmentGen.Tests.Integration.Data.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Data.Coins
{
    [TestFixture, PercentileTable("Level12Coins")]
    public class Level12CoinTests : PercentileTests
    {
        [Test]
        public void Level12EmptyPercentile()
        {
            AssertEmpty(1, 8);
        }

        [Test]
        public void Level12SilverPercentile()
        {
            var result = String.Format("{0},3d12*1000", CoinConstants.Silver);
            AssertContent(result, 9, 14);
        }

        [Test]
        public void Level12GoldPercentile()
        {
            var result = String.Format("{0},1d4*1000", CoinConstants.Gold);
            AssertContent(result, 15, 75);
        }

        [Test]
        public void Level12PlatinumPercentile()
        {
            var result = String.Format("{0},1d4*100", CoinConstants.Platinum);
            AssertContent(result, 76, 100);
        }
    }
}