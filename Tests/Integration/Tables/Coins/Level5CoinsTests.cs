using NUnit.Framework;
using System;
using TreasureGen.Common.Coins;
using TreasureGen.Tables;

namespace TreasureGen.Tests.Integration.Tables.Coins
{
    [TestFixture]
    public class Level5CoinsTests : TypeAndAmountPercentileTests
    {
        protected override String tableName
        {
            get { return String.Format(TableNameConstants.Percentiles.Formattable.LevelXCoins, 5); }
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

        [TestCase(CoinConstants.Copper, "10000d4", 11, 19)]
        [TestCase(CoinConstants.Silver, "1000d6", 20, 38)]
        [TestCase(CoinConstants.Gold, "100d8", 39, 95)]
        [TestCase(CoinConstants.Platinum, "10d10", 96, 100)]
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