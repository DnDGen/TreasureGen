using System;
using D20Dice;
using EquipmentGen.Core.Data.Coins;
using EquipmentGen.Core.Generation.Generators.Interfaces;
using EquipmentGen.Core.Generation.Providers.Interfaces;

namespace EquipmentGen.Core.Generation.Generators
{
    public class CoinGenerator : ICoinGenerator
    {
        private ITypeAndAmountPercentileResultProvider typeAndAmountPercentileResultProvider;
        private IDice dice;

        public CoinGenerator(ITypeAndAmountPercentileResultProvider typeAndAmountPercentileResultProvider, IDice dice)
        {
            this.typeAndAmountPercentileResultProvider = typeAndAmountPercentileResultProvider;
            this.dice = dice;
        }

        public Coin GenerateAtLevel(Int32 level)
        {
            var tableName = String.Format("Level{0}Coins", level);
            var roll = dice.Percentile();
            var result = typeAndAmountPercentileResultProvider.GetResultFrom(tableName, roll);

            var coin = new Coin();

            if (String.IsNullOrEmpty(result.Type))
                return coin;

            coin.Currency = result.Type;
            coin.Quantity = dice.Roll(result.AmountToRoll);

            return coin;
        }
    }
}