using NUnit.Framework;
using TreasureGen.Coins;
using TreasureGen.Tables;

namespace TreasureGen.Tests.Integration.Tables.Coins
{
    [TestFixture]
    public class Level2CoinsTests : TypeAndAmountPercentileTests
    {
        protected override string tableName
        {
            get { return string.Format(TableNameConstants.Percentiles.Formattable.LevelXCoins, 2); }
        }

        [Test]
        public override void ReplacementStringsAreValid()
        {
            AssertReplacementStringsAreValid();
        }

        [TestCase(EmptyContent, 1, 13)]
        public override void Percentile(string content, int lower, int upper)
        {
            base.Percentile(content, lower, upper);
        }

        [TestCase(CoinConstants.Copper, AmountConstants.Range1d10x1000, 14, 23)]
        [TestCase(CoinConstants.Silver, AmountConstants.Range2d10x100, 24, 43)]
        [TestCase(CoinConstants.Gold, AmountConstants.Range4d10x10, 44, 95)]
        [TestCase(CoinConstants.Platinum, AmountConstants.Range2d8x10, 96, 100)]
        public override void TypeAndAmountPercentile(string type, string amount, int lower, int upper)
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