using System;
using EquipmentGen.Core.Generation.Providers.Objects;

namespace EquipmentGen.Core.Generation.Providers.Interfaces
{
    public interface IGoodPercentileResultProvider
    {
        GoodPercentileResult GetGoodPercentileResult(Int32 level);
        GoodValuePercentileResult GetGoodValuePercentileResult(String goodType);
    }
}