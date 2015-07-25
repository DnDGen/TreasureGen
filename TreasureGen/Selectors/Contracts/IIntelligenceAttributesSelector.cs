using System;
using TreasureGen.Selectors.Interfaces.Objects;

namespace TreasureGen.Selectors.Interfaces
{
    public interface IIntelligenceAttributesSelector
    {
        IntelligenceAttributesResult SelectFrom(String tableName, String name);
    }
}