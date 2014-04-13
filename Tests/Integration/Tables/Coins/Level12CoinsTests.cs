using System;
using EquipmentGen.Common.Coins;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Coins
{
    [TestFixture]
    public class Level12CoinsTests : PercentileTests
    {
        protected override String tableName
        {
            get { return "Level12Coins"; }
        }

        [TestCase(EmptyContent, 1, 8)]
        public void Percentile(String content, Int32 lower, Int32 upper)
        {
            AssertPercentile(content, lower, upper);
        }

        [TestCase(CoinConstants.Silver, "3d12*1000", 9, 14)]
        [TestCase(CoinConstants.Gold, "1d4*1000", 15, 75)]
        [TestCase(CoinConstants.Platinum, "1d4*100", 76, 100)]
        public void Percentile(String coin, String amount, Int32 lower, Int32 upper)
        {
            var result = String.Format("{0},{1}", coin, amount);
            AssertPercentile(result, lower, upper);
        }
    }
}