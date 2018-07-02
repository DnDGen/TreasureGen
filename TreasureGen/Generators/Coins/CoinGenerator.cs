using TreasureGen.Coins;
using TreasureGen.Selectors.Percentiles;
using TreasureGen.Tables;

namespace TreasureGen.Generators.Coins
{
    internal class CoinGenerator : ICoinGenerator
    {
        private readonly ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector;

        public CoinGenerator(ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector)
        {
            this.typeAndAmountPercentileSelector = typeAndAmountPercentileSelector;
        }

        public Coin GenerateAtLevel(int level)
        {
            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.LevelXCoins, level);
            var result = typeAndAmountPercentileSelector.SelectFrom(tableName);
            var coin = new Coin();

            if (string.IsNullOrEmpty(result.Type))
                return coin;

            coin.Currency = result.Type;
            coin.Quantity = result.Amount;

            return coin;
        }
    }
}