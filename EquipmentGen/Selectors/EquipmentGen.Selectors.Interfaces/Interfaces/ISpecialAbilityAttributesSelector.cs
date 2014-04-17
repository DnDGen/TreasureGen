using System;
using EquipmentGen.Selectors.Interfaces.Objects;

namespace EquipmentGen.Selectors.Interfaces
{
    public interface ISpecialAbilityAttributesSelector
    {
        SpecialAbilityAttributesResult SelectFrom(String tableName, String name);
    }
}