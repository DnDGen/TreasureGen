using System;
using EquipmentGen.Common.Coins;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Coins
{
    [TestFixture]
    public class Level9CoinsTests : PercentileTests
    {
        protected override String tableName
        {
            get { return "Level9Coins"; }
        }

        [TestCase(EmptyContent, 1, 10)]
        public void Percentile(String content, Int32 lower, Int32 upper)
        {
            AssertPercentile(content, lower, upper);
        }

        [TestCase(CoinConstants.Copper, "2d6*10000", 11, 15)]
        [TestCase(CoinConstants.Silver, "2d8*1000", 16, 29)]
        [TestCase(CoinConstants.Gold, "5d4*100", 30, 85)]
        [TestCase(CoinConstants.Platinum, "2d12*10", 86, 100)]
        public void Percentile(String coin, String amount, Int32 lower, Int32 upper)
        {
            var result = String.Format("{0},{1}", coin, amount);
            AssertPercentile(result, lower, upper);
        }
    }
}