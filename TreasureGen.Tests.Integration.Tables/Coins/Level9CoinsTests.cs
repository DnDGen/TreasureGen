using NUnit.Framework;
using TreasureGen.Coins;
using TreasureGen.Tables;

namespace TreasureGen.Tests.Integration.Tables.Coins
{
    [TestFixture]
    public class Level9CoinsTests : TypeAndAmountPercentileTests
    {
        protected override string tableName
        {
            get { return string.Format(TableNameConstants.Percentiles.Formattable.LevelXCoins, 9); }
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

        [TestCase(CoinConstants.Copper, AmountConstants.Range2d6x10000, 11, 15)]
        [TestCase(CoinConstants.Silver, AmountConstants.Range2d8x1000, 16, 29)]
        [TestCase(CoinConstants.Gold, AmountConstants.Range5d4x100, 30, 85)]
        [TestCase(CoinConstants.Platinum, AmountConstants.Range2d12x10, 86, 100)]
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