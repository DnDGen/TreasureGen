using System;
using EquipmentGen.Common.Coins;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Coins
{
    [TestFixture]
    public class Level14CoinsTests : TypeAndAmountPercentileTests
    {
        protected override String tableName
        {
            get { return "Level14Coins"; }
        }

        [TestCase(EmptyContent, 1, 8)]
        public override void Percentile(String content, Int32 lower, Int32 upper)
        {
            base.Percentile(content, lower, upper);
        }

        [TestCase(CoinConstants.Gold, "1d6*1000", 9, 75)]
        [TestCase(CoinConstants.Platinum, "1d12*100", 76, 100)]
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