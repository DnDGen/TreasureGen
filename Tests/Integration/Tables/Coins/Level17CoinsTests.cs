using System;
using EquipmentGen.Common.Coins;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Coins
{
    [TestFixture]
    public class Level17CoinsTests : PercentileTests
    {
        protected override String tableName
        {
            get { return "Level17Coins"; }
        }

        [TestCase(EmptyContent, 1, 3)]
        public void Percentile(String content, Int32 lower, Int32 upper)
        {
            AssertPercentile(content, lower, upper);
        }

        [TestCase(CoinConstants.Gold, "3d4*1000", 4, 68)]
        [TestCase(CoinConstants.Platinum, "2d10*100", 69, 100)]
        public void Percentile(String coin, String amount, Int32 lower, Int32 upper)
        {
            var result = String.Format("{0},{1}", coin, amount);
            AssertPercentile(result, lower, upper);
        }
    }
}