using System;
using EquipmentGen.Core.Generation.Providers.Objects;

namespace EquipmentGen.Core.Generation.Providers.Interfaces
{
    public interface ITypeAndAmountPercentileResultProvider
    {
        TypeAndAmountPercentileResult GetTypeAndAmountPercentileResult(String tableName);
    }
}