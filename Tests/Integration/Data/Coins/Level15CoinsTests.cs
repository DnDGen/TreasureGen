using System;
using EquipmentGen.Common.Coins;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Coins
{
    [TestFixture]
    public class Level15CoinsTests : PercentileTests
    {
        protected override String GetTableName()
        {
            return "Level15Coins";
        }

        [Test]
        public void Level15EmptyPercentile()
        {
            AssertPercentile(String.Empty, 1, 3);
        }

        [Test]
        public void Level15GoldPercentile()
        {
            var result = String.Format("{0},1d8*1000", CoinConstants.Gold);
            AssertPercentile(result, 4, 74);
        }

        [Test]
        public void Level15PlatinumPercentile()
        {
            var result = String.Format("{0},3d4*100", CoinConstants.Platinum);
            AssertPercentile(result, 75, 100);
        }
    }
}