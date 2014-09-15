using System;
using EquipmentGen.Common.Coins;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Coins
{
    [TestFixture]
    public class Level1CoinsTests : TypeAndAmountPercentileTests
    {
        protected override String tableName
        {
            get { return "Level1Coins"; }
        }

        [TestCase(EmptyContent, 1, 14)]
        public override void Percentile(String content, Int32 lower, Int32 upper)
        {
            base.Percentile(content, lower, upper);
        }

        [TestCase(CoinConstants.Copper, "1d6*1000", 15, 29)]
        [TestCase(CoinConstants.Silver, "1d8*100", 30, 52)]
        [TestCase(CoinConstants.Gold, "2d8*10", 53, 95)]
        [TestCase(CoinConstants.Platinum, "1d4*10", 96, 100)]
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