using System;
using EquipmentGen.Common.Coins;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Coins
{
    [TestFixture]
    public class Level7CoinsTests : PercentileTests
    {
        protected override String GetTableName()
        {
            return "Level7Coins";
        }

        [Test]
        public void Level7EmptyPercentile()
        {
            AssertPercentile(String.Empty, 1, 11);
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