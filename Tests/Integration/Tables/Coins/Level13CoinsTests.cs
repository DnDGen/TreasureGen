using System;
using EquipmentGen.Common.Coins;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Coins
{
    [TestFixture]
    public class Level13CoinsTests : PercentileTests
    {
        protected override String tableName
        {
            get { return "Level13Coins"; }
        }

        [TestCase(EmptyContent, 1, 8)]
        public void Percentile(String content, Int32 lower, Int32 upper)
        {
            AssertPercentile(content, lower, upper);
        }

        [TestCase(CoinConstants.Gold, "1d4*1000", 9, 75)]
        [TestCase(CoinConstants.Platinum, "1d10*100", 76, 100)]
        public void Percentile(String coin, String amount, Int32 lower, Int32 upper)
        {
            var result = String.Format("{0},{1}", coin, amount);
            AssertPercentile(result, lower, upper);
        }
    }
}