using System;
using D20Dice;
using EquipmentGen.Core.Data.Coins;
using EquipmentGen.Core.Generation.Factories.Interfaces;
using EquipmentGen.Core.Generation.Providers.Interfaces;

namespace EquipmentGen.Core.Generation.Factories
{
    public class CoinFactory : ICoinFactory
    {
        private ICoinPercentileResultProvider coinProvider;
        private IDice dice;

        public CoinFactory(ICoinPercentileResultProvider coinProvider, IDice dice)
        {
            this.coinProvider = coinProvider;
            this.dice = dice;
        }

        public Coin CreateAtLevel(Int32 level)
        {
            var result = coinProvider.GetCoinPercentileResult(level);

            var coin = new Coin();

            coin.Currency = result.CoinType;
            coin.Quantity = dice.Roll(result.RollToDetermineAmount);

            return coin;
        }
    }
}