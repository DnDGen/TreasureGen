using System;
using D20Dice;
using EquipmentGen.Common.Coins;
using EquipmentGen.Generators.Interfaces.Coins;
using EquipmentGen.Selectors.Interfaces;

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
            var tableName = String.Format("Level{0}Coins", level);
            var roll = dice.Percentile();
            var result = typeAndAmountPercentileSelector.SelectFrom(tableName, roll);

            var coin = new Coin();

            if (String.IsNullOrEmpty(result.Type))
                return coin;

            coin.Currency = result.Type;
            coin.Quantity = dice.Roll(result.AmountToRoll);

            return coin;
        }
    }
}