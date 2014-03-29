using System;
using EquipmentGen.Common.Coins;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Coins
{
    [TestFixture]
    public class Level9CoinsTests : PercentileTests
    {
        protected override String GetTableName()
        {
            return "Level9Coins";
        }

        [Test]
        public void Level9EmptyPercentile()
        {
            AssertPercentile(String.Empty, 1, 10);
        }

        [Test]
        public void Level9CopperPercentile()
        {
            var result = String.Format("{0},2d6*10000", CoinConstants.Copper);
            AssertPercentile(result, 11, 15);
        }

        [Test]
        public void Level9SilverPercentile()
        {
            var result = String.Format("{0},2d8*1000", CoinConstants.Silver);
            AssertPercentile(result, 16, 29);
        }

        [Test]
        public void Level9GoldPercentile()
        {
            var result = String.Format("{0},5d4*100", CoinConstants.Gold);
            AssertPercentile(result, 30, 85);
        }

        [Test]
        public void Level9PlatinumPercentile()
        {
            var result = String.Format("{0},2d12*10", CoinConstants.Platinum);
            AssertPercentile(result, 86, 100);
        }
    }
}