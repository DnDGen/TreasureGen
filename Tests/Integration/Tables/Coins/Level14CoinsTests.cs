using System;
using EquipmentGen.Common.Coins;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Coins
{
    [TestFixture]
    public class Level14CoinsTests : PercentileTests
    {
        protected override String tableName
        {
            get { return "Level14Coins"; }
        }

        [TestCase(EmptyContent, 1, 8)]
        public void Percentile(String content, Int32 lower, Int32 upper)
        {
            AssertPercentile(content, lower, upper);
        }

        [TestCase(CoinConstants.Gold, "1d6*1000", 9, 75)]
        [TestCase(CoinConstants.Platinum, "1d12*100", 76, 100)]
        public void Percentile(String coin, String amount, Int32 lower, Int32 upper)
        {
            var result = String.Format("{0},{1}", coin, amount);
            AssertPercentile(result, lower, upper);
        }
    }
}