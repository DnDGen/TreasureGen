using System;
using TreasureGen.Selectors.Results;

namespace TreasureGen.Selectors
{
    public interface ISpecialAbilityAttributesSelector
    {
        SpecialAbilityAttributesResult SelectFrom(String tableName, String name);
    }
}