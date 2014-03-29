using System;
using EquipmentGen.Common.Coins;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Coins
{
    [TestFixture]
    public class Level16CoinsTests : PercentileTests
    {
        protected override String GetTableName()
        {
            return "Level16Coins";
        }

        [Test]
        public void Level16EmptyPercentile()
        {
            AssertPercentile(String.Empty, 1, 3);
        }

        [Test]
        public void Level16GoldPercentile()
        {
            var result = String.Format("{0},1d12*1000", CoinConstants.Gold);
            AssertPercentile(result, 4, 74);
        }

        [Test]
        public void Level16PlatinumPercentile()
        {
            var result = String.Format("{0},3d4*100", CoinConstants.Platinum);
            AssertPercentile(result, 75, 100);
        }
    }
}