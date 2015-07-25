using System;
using TreasureGen.Selectors.Results;

namespace TreasureGen.Selectors
{
    public interface IIntelligenceAttributesSelector
    {
        IntelligenceAttributesResult SelectFrom(String tableName, String name);
    }
}