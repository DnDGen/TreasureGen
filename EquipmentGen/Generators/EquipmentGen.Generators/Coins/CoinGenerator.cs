using System;
using D20Dice;
using EquipmentGen.Common.Coins;
using EquipmentGen.Generators.Interfaces.Coins;
using EquipmentGen.Selectors.Interfaces;
using EquipmentGen.Tables.Interfaces;

namespace EquipmentGen.Generators.Coins
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