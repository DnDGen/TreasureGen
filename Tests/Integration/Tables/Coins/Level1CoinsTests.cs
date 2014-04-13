using System;
using EquipmentGen.Common.Coins;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Coins
{
    [TestFixture]
    public class Level1CoinsTests : PercentileTests
    {
        protected override String tableName
        {
            get { return "Level1Coins"; }
        }

        [TestCase(EmptyContent, 1, 14)]
        public void Percentile(String content, Int32 lower, Int32 upper)
        {
            AssertPercentile(content, lower, upper);
        }

        [TestCase(CoinConstants.Copper, "1d6*1000", 15, 29)]
        [TestCase(CoinConstants.Silver, "1d8*100", 30, 52)]
        [TestCase(CoinConstants.Gold, "2d8*10", 53, 95)]
        [TestCase(CoinConstants.Platinum, "1d4*10", 96, 100)]
        public void Percentile(String coin, String amount, Int32 lower, Int32 upper)
        {
            var result = String.Format("{0},{1}", coin, amount);
            AssertPercentile(result, lower, upper);
        }
    }
}