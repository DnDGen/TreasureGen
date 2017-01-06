using NUnit.Framework;
using TreasureGen.Coins;
using TreasureGen.Domain.Tables;

namespace TreasureGen.Tests.Integration.Tables.Coins
{
    [TestFixture]
    public class Level3CoinsTests : TypeAndAmountPercentileTests
    {
        protected override string tableName
        {
            get { return string.Format(TableNameConstants.Percentiles.Formattable.LevelXCoins, 3); }
        }

        [Test]
        public override void ReplacementStringsAreValid()
        {
            AssertReplacementStringsAreValid();
        }

        [TestCase(EmptyContent, 1, 11)]
        public override void Percentile(string content, int lower, int upper)
        {
            base.Percentile(content, lower, upper);
        }

        [TestCase(CoinConstants.Copper, AmountConstants.Range2d10x1000, 12, 21)]
        [TestCase(CoinConstants.Silver, AmountConstants.Range4d8x100, 22, 41)]
        [TestCase(CoinConstants.Gold, AmountConstants.Range1d4x100, 42, 95)]
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