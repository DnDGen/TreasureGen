using System;
using TreasureGen.Common.Coins;
using TreasureGen.Tables;
using NUnit.Framework;

namespace TreasureGen.Tests.Integration.Tables.Coins
{
    [TestFixture]
    public class Level2CoinsTests : TypeAndAmountPercentileTests
    {
        protected override String tableName
        {
            get { return String.Format(TableNameConstants.Percentiles.Formattable.LevelXCoins, 2); }
        }

        [Test]
        public override void ReplacementStringsAreValid()
        {
            AssertReplacementStringsAreValid();
        }

        [TestCase(EmptyContent, 1, 13)]
        public override void Percentile(String content, Int32 lower, Int32 upper)
        {
            base.Percentile(content, lower, upper);
        }

        [TestCase(CoinConstants.Copper, "1d10*1000", 14, 23)]
        [TestCase(CoinConstants.Silver, "2d10*100", 24, 43)]
        [TestCase(CoinConstants.Gold, "4d10*10", 44, 95)]
        [TestCase(CoinConstants.Platinum, "2d8*10", 96, 100)]
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