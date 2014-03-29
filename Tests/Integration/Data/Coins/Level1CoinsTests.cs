using System;
using EquipmentGen.Common.Coins;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Coins
{
    [TestFixture]
    public class Level1CoinsTests : PercentileTests
    {
        protected override String GetTableName()
        {
            return "Level1Coins";
        }

        [Test]
        public void EmptyPercentile()
        {
            AssertPercentile(String.Empty, 1, 14);
        }

        [Test]
        public void CopperPercentile()
        {
            var result = String.Format("{0},1d6*1000", CoinConstants.Copper);
            AssertPercentile(result, 15, 29);
        }

        [Test]
        public void SilverPercentile()
        {
            var result = String.Format("{0},1d8*100", CoinConstants.Silver);
            AssertPercentile(result, 30, 52);
        }

        [Test]
        public void GoldPercentile()
        {
            var result = String.Format("{0},2d8*10", CoinConstants.Gold);
            AssertPercentile(result, 53, 95);
        }

        [Test]
        public void PlatinumPercentile()
        {
            var result = String.Format("{0},1d4*10", CoinConstants.Platinum);
            AssertPercentile(result, 96, 100);
        }
    }
}