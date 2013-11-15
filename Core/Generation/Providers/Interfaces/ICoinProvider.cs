using System;
using EquipmentGen.Core.Data.Coins;

namespace EquipmentGen.Core.Generation.Providers.Interfaces
{
    public interface ICoinProvider
    {
        Coin GetCoin(Int32 level);
    }
}