using System;
using EquipmentGen.Common.Coins;
using EquipmentGen.Tests.Integration.Tables.TestAttributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Coins
{
    [TestFixture, PercentileTable("Level7Coins")]
    public class Level7CoinTests : PercentileTests
    {
        [Test]
        public void Level7EmptyPercentile()
        {
            AssertEmpty(1, 11);
        }

        [Test]
        public void Level7CopperPercentile()
        {
            var result = String.Format("{0},1d10*10000", CoinConstants.Copper);
            AssertPercentile(result, 12, 18);
        }

        [Test]
        public void Level7SilverPercentile()
        {
            var result = String.Format("{0},1d12*1000", CoinConstants.Silver);
            AssertPercentile(result, 19, 35);
        }

        [Test]
        public void Level7GoldPercentile()
        {
            var result = String.Format("{0},2d6*100", CoinConstants.Gold);
            AssertPercentile(result, 36, 93);
        }

        [Test]
        public void Level7PlatinumPercentile()
        {
            var result = String.Format("{0},3d4*10", CoinConstants.Platinum);
            AssertPercentile(result, 94, 100);
        }
    }
}