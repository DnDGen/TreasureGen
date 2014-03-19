using System;
using EquipmentGen.Selectors.Objects;

namespace EquipmentGen.Selectors.Interfaces
{
    public interface ITypeAndAmountPercentileResultProvider
    {
        TypeAndAmountPercentileResult GetResultFrom(String tableName, Int32 roll);
    }
}