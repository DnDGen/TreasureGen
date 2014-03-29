using System;
using EquipmentGen.Common.Coins;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Coins
{
    [TestFixture]
    public class Level13CoinsTests : PercentileTests
    {
        protected override String GetTableName()
        {
            return "Level13Coins";
        }

        [Test]
        public void Level13EmptyPercentile()
        {
            AssertPercentile(String.Empty, 1, 8);
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