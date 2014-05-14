using System;
using EquipmentGen.Selectors.Interfaces.Objects;

namespace EquipmentGen.Selectors.Interfaces
{
    public interface ITypeAndAmountPercentileSelector
    {
        TypeAndAmountPercentileResult SelectFrom(String tableName);
    }
}