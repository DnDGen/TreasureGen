using System;
using EquipmentGen.Common.Coins;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Coins
{
    [TestFixture]
    public class Level10CoinsTests : PercentileTests
    {
        protected override String GetTableName()
        {
            return "Level10Coins";
        }

        [Test]
        public void Level10EmptyPercentile()
        {
            AssertPercentile(String.Empty, 1, 10);
        }

        [Test]
        public void Level10SilverPercentile()
        {
            var result = String.Format("{0},2d10*1000", CoinConstants.Silver);
            AssertPercentile(result, 11, 24);
        }

        [Test]
        public void Level10GoldPercentile()
        {
            var result = String.Format("{0},6d4*100", CoinConstants.Gold);
            AssertPercentile(result, 25, 79);
        }

        [Test]
        public void Level10PlatinumPercentile()
        {
            var result = String.Format("{0},5d6*10", CoinConstants.Platinum);
            AssertPercentile(result, 80, 100);
        }
    }
}