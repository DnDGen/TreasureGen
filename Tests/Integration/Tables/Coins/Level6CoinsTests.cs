using NUnit.Framework;
using System;
using TreasureGen.Common.Coins;
using TreasureGen.Tables;

namespace TreasureGen.Tests.Integration.Tables.Coins
{
    [TestFixture]
    public class Level6CoinsTests : TypeAndAmountPercentileTests
    {
        protected override String tableName
        {
            get { return String.Format(TableNameConstants.Percentiles.Formattable.LevelXCoins, 6); }
        }

        [Test]
        public override void ReplacementStringsAreValid()
        {
            AssertReplacementStringsAreValid();
        }

        [TestCase(EmptyContent, 1, 10)]
        public override void Percentile(String content, Int32 lower, Int32 upper)
        {
            base.Percentile(content, lower, upper);
        }

        [TestCase(CoinConstants.Copper, "10000d6", 11, 18)]
        [TestCase(CoinConstants.Silver, "1000d8", 19, 37)]
        [TestCase(CoinConstants.Gold, "100d10", 38, 95)]
        [TestCase(CoinConstants.Platinum, "10d12", 96, 100)]
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