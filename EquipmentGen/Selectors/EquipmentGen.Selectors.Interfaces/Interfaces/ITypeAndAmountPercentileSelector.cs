using System;
using EquipmentGen.Selectors.Objects;

namespace EquipmentGen.Selectors.Interfaces
{
    public interface ITypeAndAmountPercentileSelector
    {
        TypeAndAmountPercentileResult SelectFrom(String tableName, Int32 roll);
    }
}