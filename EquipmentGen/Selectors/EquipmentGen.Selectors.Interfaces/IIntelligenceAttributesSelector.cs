using System;
using EquipmentGen.Selectors.Interfaces.Objects;

namespace EquipmentGen.Selectors.Interfaces
{
    public interface IIntelligenceAttributesSelector
    {
        IntelligenceAttributesResult SelectFrom(String tableName, String name);
    }
}