using System;
using EquipmentGen.Common.Coins;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Coins
{
    [TestFixture]
    public class Level5CoinsTests : TypeAndAmountPercentileTests
    {
        protected override String tableName
        {
            get { return "Level5Coins"; }
        }

        [TestCase(EmptyContent, 1, 10)]
        public override void Percentile(String content, Int32 lower, Int32 upper)
        {
            base.Percentile(content, lower, upper);
        }

        [TestCase(CoinConstants.Copper, "1d4*10000", 11, 19)]
        [TestCase(CoinConstants.Silver, "1d6*1000", 20, 38)]
        [TestCase(CoinConstants.Gold, "1d8*100", 39, 95)]
        [TestCase(CoinConstants.Platinum, "1d10*10", 96, 100)]
        public override void TypeAndAmountPercentile(String type, String amount, Int32 lower, Int32 upper)
        {
            base.TypeAndAmountPercentile(type, amount, lower, upper);
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }
    }
}