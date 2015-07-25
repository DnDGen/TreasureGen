using RollGen;
using System;
using TreasureGen.Common.Coins;
using TreasureGen.Generators.Coins;
using TreasureGen.Selectors.Interfaces;
using TreasureGen.Tables.Interfaces;

namespace TreasureGen.Generators.Domain.Coins
{
    public class CoinGenerator : ICoinGenerator
    {
        private ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector;
        private IDice dice;

        public CoinGenerator(ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector, IDice dice)
        {
            this.typeAndAmountPercentileSelector = typeAndAmountPercentileSelector;
            this.dice = dice;
        }

        public Coin GenerateAtLevel(Int32 level)
        {
            var tableName = String.Format(TableNameConstants.Percentiles.Formattable.LevelXCoins, level);
            var result = typeAndAmountPercentileSelector.SelectFrom(tableName);
            var coin = new Coin();

            if (String.IsNullOrEmpty(result.Type))
                return coin;

            coin.Currency = result.Type;
            coin.Quantity = result.Amount;

            return coin;
        }
    }
}