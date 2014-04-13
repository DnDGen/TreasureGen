using System;
using EquipmentGen.Common.Coins;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Coins
{
    [TestFixture]
    public class Level5CoinsTests : PercentileTests
    {
        protected override String tableName
        {
            get { return "Level5Coins"; }
        }

        [TestCase(EmptyContent, 1, 10)]
        public void Percentile(String content, Int32 lower, Int32 upper)
        {
            AssertPercentile(content, lower, upper);
        }

        [TestCase(CoinConstants.Copper, "1d4*10000", 11, 19)]
        [TestCase(CoinConstants.Silver, "1d6*1000", 20, 38)]
        [TestCase(CoinConstants.Gold, "1d8*100", 39, 95)]
        [TestCase(CoinConstants.Platinum, "1d10*10", 96, 100)]
        public void Percentile(String coin, String amount, Int32 lower, Int32 upper)
        {
            var result = String.Format("{0},{1}", coin, amount);
            AssertPercentile(result, lower, upper);
        }
    }
}