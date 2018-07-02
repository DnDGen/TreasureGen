using NUnit.Framework;
using TreasureGen.Coins;
using TreasureGen.Tables;

namespace TreasureGen.Tests.Integration.Tables.Coins
{
    [TestFixture]
    public class Level5CoinsTests : TypeAndAmountPercentileTests
    {
        protected override string tableName
        {
            get { return string.Format(TableNameConstants.Percentiles.Formattable.LevelXCoins, 5); }
        }

        [Test]
        public override void ReplacementStringsAreValid()
        {
            AssertReplacementStringsAreValid();
        }

        [TestCase(EmptyContent, 1, 10)]
        public override void Percentile(string content, int lower, int upper)
        {
            base.Percentile(content, lower, upper);
        }

        [TestCase(CoinConstants.Copper, AmountConstants.Range1d4x10000, 11, 19)]
        [TestCase(CoinConstants.Silver, AmountConstants.Range1d6x1000, 20, 38)]
        [TestCase(CoinConstants.Gold, AmountConstants.Range1d8x100, 39, 95)]
        [TestCase(CoinConstants.Platinum, AmountConstants.Range1d10x10, 96, 100)]
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