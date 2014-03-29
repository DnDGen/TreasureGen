using System;
using EquipmentGen.Common.Coins;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Coins
{
    [TestFixture]
    public class Level6CoinsTests : PercentileTests
    {
        protected override String GetTableName()
        {
            return "Level6Coins";
        }

        [Test]
        public void Level6EmptyPercentile()
        {
            AssertPercentile(String.Empty, 1, 10);
        }

        [Test]
        public void Level6CopperPercentile()
        {
            var result = String.Format("{0},1d6*10000", CoinConstants.Copper);
            AssertPercentile(result, 11, 18);
        }

        [Test]
        public void Level6SilverPercentile()
        {
            var result = String.Format("{0},1d8*1000", CoinConstants.Silver);
            AssertPercentile(result, 19, 37);
        }

        [Test]
        public void Level6GoldPercentile()
        {
            var result = String.Format("{0},1d10*100", CoinConstants.Gold);
            AssertPercentile(result, 38, 95);
        }

        [Test]
        public void Level6PlatinumPercentile()
        {
            var result = String.Format("{0},1d12*10", CoinConstants.Platinum);
            AssertPercentile(result, 96, 100);
        }
    }
}