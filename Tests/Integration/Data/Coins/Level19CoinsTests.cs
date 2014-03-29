using System;
using EquipmentGen.Common.Coins;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Coins
{
    [TestFixture]
    public class Level19CoinsTests : PercentileTests
    {
        protected override String GetTableName()
        {
            return "Level19Coins";
        }

        [Test]
        public void Level19EmptyPercentile()
        {
            AssertPercentile(String.Empty, 1, 2);
        }

        [Test]
        public void Level19GoldPercentile()
        {
            var result = String.Format("{0},3d8*1000", CoinConstants.Gold);
            AssertPercentile(result, 3, 65);
        }

        [Test]
        public void Level19PlatinumPercentile()
        {
            var result = String.Format("{0},3d10*100", CoinConstants.Platinum);
            AssertPercentile(result, 66, 100);
        }
    }
}