using System;
using EquipmentGen.Selectors.Interfaces.Objects;

namespace EquipmentGen.Selectors.Interfaces
{
    public interface IRangeAttributesSelector
    {
        RangeAttributesResult SelectFrom(String tableName, String name);
    }
}