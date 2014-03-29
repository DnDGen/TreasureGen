using System;
using EquipmentGen.Common.Coins;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Coins
{
    [TestFixture]
    public class Level20CoinsTests : PercentileTests
    {
        protected override String GetTableName()
        {
            return "Level20Coins";
        }

        [Test]
        public void Level20EmptyPercentile()
        {
            AssertPercentile(String.Empty, 1, 2);
        }

        [Test]
        public void Level20GoldPercentile()
        {
            var result = String.Format("{0},4d8*1000", CoinConstants.Gold);
            AssertPercentile(result, 3, 65);
        }

        [Test]
        public void Level20PlatinumPercentile()
        {
            var result = String.Format("{0},4d10*100", CoinConstants.Platinum);
            AssertPercentile(result, 66, 100);
        }
    }
}