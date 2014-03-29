using System;
using EquipmentGen.Common.Coins;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Coins
{
    [TestFixture]
    public class Level11CoinsTests : PercentileTests
    {
        protected override String GetTableName()
        {
            return "Level11Coins";
        }

        [Test]
        public void Level11EmptyPercentile()
        {
            AssertPercentile(String.Empty, 1, 8);
        }

        [Test]
        public void Level11SilverPercentile()
        {
            var result = String.Format("{0},3d10*1000", CoinConstants.Silver);
            AssertPercentile(result, 9, 14);
        }

        [Test]
        public void Level11GoldPercentile()
        {
            var result = String.Format("{0},4d8*100", CoinConstants.Gold);
            AssertPercentile(result, 15, 75);
        }

        [Test]
        public void Level11PlatinumPercentile()
        {
            var result = String.Format("{0},4d10*10", CoinConstants.Platinum);
            AssertPercentile(result, 76, 100);
        }
    }
}