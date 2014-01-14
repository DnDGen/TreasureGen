using System;
using EquipmentGen.Core.Generation.Providers.Objects;

namespace EquipmentGen.Core.Generation.Providers.Interfaces
{
    public interface ICoinPercentileResultProvider
    {
        CoinPercentileResult GetCoinPercentileResult(Int32 level);
    }
}