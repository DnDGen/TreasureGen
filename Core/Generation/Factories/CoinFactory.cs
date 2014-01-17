using System;
using D20Dice;
using EquipmentGen.Core.Data.Coins;
using EquipmentGen.Core.Generation.Factories.Interfaces;
using EquipmentGen.Core.Generation.Providers.Interfaces;

namespace EquipmentGen.Core.Generation.Factories
{
    public class CoinFactory : ICoinFactory
    {
        private ITypeAndAmountPercentileResultProvider typeAndAmountPercentileResultProvider;
        private IDice dice;

        public CoinFactory(ITypeAndAmountPercentileResultProvider typeAndAmountPercentileResultProvider, IDice dice)
        {
            this.typeAndAmountPercentileResultProvider = typeAndAmountPercentileResultProvider;
            this.dice = dice;
        }

        public Coin CreateAtLevel(Int32 level)
        {
            var tableName = String.Format("Level{0}Coins", level);
            var result = typeAndAmountPercentileResultProvider.GetTypeAndAmountPercentileResult(tableName);

            var coin = new Coin() { Currency = String.Empty };

            if (String.IsNullOrEmpty(result.Type))
                return coin;

            coin.Currency = result.Type;
            coin.Quantity = dice.Roll(result.RollToDetermineAmount);

            return coin;
        }
    }
}