using System;
using EquipmentGen.Common.Coins;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Coins
{
    [TestFixture]
    public class Level5CoinsTests : PercentileTests
    {
        protected override String GetTableName()
        {
            return "Level5Coins";
        }

        [Test]
        public void Level5EmptyPercentile()
        {
            AssertPercentile(String.Empty, 1, 10);
        }

        [Test]
        public void Level5CopperPercentile()
        {
            var result = String.Format("{0},1d4*10000", CoinConstants.Copper);
            AssertPercentile(result, 11, 19);
        }

        [Test]
        public void Level5SilverPercentile()
        {
            var result = String.Format("{0},1d6*1000", CoinConstants.Silver);
            AssertPercentile(result, 20, 38);
        }

        [Test]
        public void Level5GoldPercentile()
        {
            var result = String.Format("{0},1d8*100", CoinConstants.Gold);
            AssertPercentile(result, 39, 95);
        }

        [Test]
        public void Level5PlatinumPercentile()
        {
            var result = String.Format("{0},1d10*10", CoinConstants.Platinum);
            AssertPercentile(result, 96, 100);
        }
    }
}