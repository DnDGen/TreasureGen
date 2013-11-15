using System;
using D20Dice;
using EquipmentGen.Core.Data.Coins;
using EquipmentGen.Core.Generation.Providers.Interfaces;

namespace EquipmentGen.Core.Generation.Providers
{
    public class CoinProvider : ICoinProvider
    {
        private IPercentileResultProvider percentileResultProvider;
        private IDice dice;

        public CoinProvider(IPercentileResultProvider percentileResultProvider, IDice dice)
        {
            this.percentileResultProvider = percentileResultProvider;
            this.dice = dice;
        }

        public Coin GetCoin(Int32 level)
        {
            var tableName = String.Format("Level{0}Coins", level);
            var percentileResult = percentileResultProvider.GetPercentileResult(tableName);

            var Coin = new Coin();
            if (String.IsNullOrEmpty(percentileResult))
                return Coin;

            var parsedResult = percentileResult.Split(',');

            Coin.Currency = parsedResult[0];
            Coin.Quantity = dice.Roll(parsedResult[1]);

            return Coin;
        }
    }
}