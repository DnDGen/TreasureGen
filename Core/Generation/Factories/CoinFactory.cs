using System;
using EquipmentGen.Core.Data.Coins;
using EquipmentGen.Core.Generation.Factories.Interfaces;
using EquipmentGen.Core.Generation.Providers.Interfaces;

namespace EquipmentGen.Core.Generation.Factories
{
    public class CoinFactory : ICoinFactory
    {
        private ICoinProvider coinProvider;

        public CoinFactory(ICoinProvider coinProvider)
        {
            this.coinProvider = coinProvider;
        }

        public Coin CreateWith(Int32 level)
        {
            return coinProvider.GetCoin(level);
        }
    }
}