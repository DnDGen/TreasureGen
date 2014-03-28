using System;
using EquipmentGen.Common.Coins;
using EquipmentGen.Tests.Integration.Tables.TestAttributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Coins
{
    [TestFixture, PercentileTable("Level8Coins")]
    public class Level8CoinTests : PercentileTests
    {
        [Test]
        public void Level8EmptyPercentile()
        {
            AssertPercentile(String.Empty, 1, 10);
        }

        [Test]
        public void Level8CopperPercentile()
        {
            var result = String.Format("{0},1d12*10000", CoinConstants.Copper);
            AssertPercentile(result, 11, 15);
        }

        [Test]
        public void Level8SilverPercentile()
        {
            var result = String.Format("{0},2d6*1000", CoinConstants.Silver);
            AssertPercentile(result, 16, 29);
        }

        [Test]
        public void Level8GoldPercentile()
        {
            var result = String.Format("{0},2d8*100", CoinConstants.Gold);
            AssertPercentile(result, 30, 87);
        }

        [Test]
        public void Level8PlatinumPercentile()
        {
            var result = String.Format("{0},3d6*10", CoinConstants.Platinum);
            AssertPercentile(result, 88, 100);
        }
    }
}