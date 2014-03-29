using System;
using EquipmentGen.Common.Coins;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Coins
{
    [TestFixture]
    public class Level14CoinsTests : PercentileTests
    {
        protected override String GetTableName()
        {
            return "Level14Coins";
        }

        [Test]
        public void Level14EmptyPercentile()
        {
            AssertPercentile(String.Empty, 1, 8);
        }

        [Test]
        public void Level14GoldPercentile()
        {
            var result = String.Format("{0},1d6*1000", CoinConstants.Gold);
            AssertPercentile(result, 9, 75);
        }

        [Test]
        public void Level14PlatinumPercentile()
        {
            var result = String.Format("{0},1d12*100", CoinConstants.Platinum);
            AssertPercentile(result, 76, 100);
        }
    }
}