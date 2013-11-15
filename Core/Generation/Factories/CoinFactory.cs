using System;
using D20Dice;
using EquipmentGen.Core.Data.Coins;
using EquipmentGen.Core.Generation.Providers;

namespace EquipmentGen.Core.Generation.Factories
{
    public static class CoinFactory
    {
        public static Coin CreateWith(IDice dice, Int32 level)
        {
            var CoinProvider = ProviderFactory.CreateCoinProviderWith(dice);
            return CoinProvider.GetCoin(level);
        }
    }
}