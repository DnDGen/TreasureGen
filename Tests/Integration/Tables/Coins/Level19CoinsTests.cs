using System;
using EquipmentGen.Common.Coins;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Coins
{
    [TestFixture]
    public class Level19CoinsTests : PercentileTests
    {
        protected override String tableName
        {
            get { return "Level19Coins"; }
        }

        [TestCase(EmptyContent, 1, 2)]
        public void Percentile(String content, Int32 lower, Int32 upper)
        {
            AssertPercentile(content, lower, upper);
        }

        [TestCase(CoinConstants.Gold, "3d8*1000", 3, 65)]
        [TestCase(CoinConstants.Platinum, "3d10*100", 66, 100)]
        public void Percentile(String coin, String amount, Int32 lower, Int32 upper)
        {
            var result = String.Format("{0},{1}", coin, amount);
            AssertPercentile(result, lower, upper);
        }
    }
}