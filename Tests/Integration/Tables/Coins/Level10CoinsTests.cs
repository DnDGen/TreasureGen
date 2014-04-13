using System;
using EquipmentGen.Common.Coins;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Coins
{
    [TestFixture]
    public class Level10CoinsTests : PercentileTests
    {
        protected override String tableName
        {
            get { return "Level10Coins"; }
        }

        [TestCase(EmptyContent, 1, 10)]
        public void Percentile(String content, Int32 lower, Int32 upper)
        {
            AssertPercentile(content, lower, upper);
        }

        [TestCase(CoinConstants.Silver, "2d10*1000", 11, 24)]
        [TestCase(CoinConstants.Gold, "6d4*100", 25, 79)]
        [TestCase(CoinConstants.Platinum, "5d6*10", 80, 100)]
        public void Percentile(String coin, String amount, Int32 lower, Int32 upper)
        {
            var result = String.Format("{0},{1}", coin, amount);
            AssertPercentile(result, lower, upper);
        }
    }
}