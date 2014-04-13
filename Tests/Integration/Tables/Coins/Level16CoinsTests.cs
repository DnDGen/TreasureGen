using System;
using EquipmentGen.Common.Coins;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Coins
{
    [TestFixture]
    public class Level16CoinsTests : PercentileTests
    {
        protected override String tableName
        {
            get { return "Level16Coins"; }
        }

        [TestCase(EmptyContent, 1, 3)]
        public void Percentile(String content, Int32 lower, Int32 upper)
        {
            AssertPercentile(content, lower, upper);
        }

        [TestCase(CoinConstants.Gold, "1d12*1000", 4, 74)]
        [TestCase(CoinConstants.Platinum, "3d4*100", 75, 100)]
        public void Percentile(String coin, String amount, Int32 lower, Int32 upper)
        {
            var result = String.Format("{0},{1}", coin, amount);
            AssertPercentile(result, lower, upper);
        }
    }
}