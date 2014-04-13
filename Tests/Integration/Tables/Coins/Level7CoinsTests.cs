using System;
using EquipmentGen.Common.Coins;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Coins
{
    [TestFixture]
    public class Level7CoinsTests : PercentileTests
    {
        protected override String tableName
        {
            get { return "Level7Coins"; }
        }

        [TestCase(EmptyContent, 1, 11)]
        public void Percentile(String content, Int32 lower, Int32 upper)
        {
            AssertPercentile(content, lower, upper);
        }

        [TestCase(CoinConstants.Copper, "1d10*10000", 12, 18)]
        [TestCase(CoinConstants.Silver, "1d12*1000", 19, 35)]
        [TestCase(CoinConstants.Gold, "2d6*100", 36, 93)]
        [TestCase(CoinConstants.Platinum, "3d4*10", 94, 100)]
        public void Percentile(String coin, String amount, Int32 lower, Int32 upper)
        {
            var result = String.Format("{0},{1}", coin, amount);
            AssertPercentile(result, lower, upper);
        }
    }
}