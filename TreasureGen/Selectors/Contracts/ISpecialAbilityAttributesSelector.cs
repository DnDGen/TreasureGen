using System;
using TreasureGen.Selectors.Interfaces.Objects;

namespace TreasureGen.Selectors.Interfaces
{
    public interface ISpecialAbilityAttributesSelector
    {
        SpecialAbilityAttributesResult SelectFrom(String tableName, String name);
    }
}