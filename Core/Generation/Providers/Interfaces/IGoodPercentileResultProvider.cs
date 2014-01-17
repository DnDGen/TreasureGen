using System;
using EquipmentGen.Core.Generation.Providers.Objects;

namespace EquipmentGen.Core.Generation.Providers.Interfaces
{
    public interface IGoodPercentileResultProvider
    {
        GoodValuePercentileResult GetGoodValuePercentileResult(String tableName);
    }
}