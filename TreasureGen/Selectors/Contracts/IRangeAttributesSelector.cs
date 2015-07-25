using System;
using TreasureGen.Selectors.Results;

namespace TreasureGen.Selectors
{
    public interface IRangeAttributesSelector
    {
        RangeAttributesResult SelectFrom(String tableName, String name);
    }
}