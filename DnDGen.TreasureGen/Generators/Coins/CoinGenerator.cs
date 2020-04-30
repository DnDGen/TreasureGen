using DnDGen.TreasureGen.Coins;
using DnDGen.TreasureGen.Selectors.Percentiles;
using DnDGen.TreasureGen.Tables;
using System.Threading.Tasks;

namespace DnDGen.TreasureGen.Generators.Coins
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

        public async Task<Coin> GenerateAtLevelAsync(int level) => await Task.Run(() => GenerateAtLevel(level));
    }
}