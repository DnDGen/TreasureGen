using System;
using TreasureGen.Selectors.Interfaces.Objects;

namespace TreasureGen.Selectors.Interfaces
{
    public interface IRangeAttributesSelector
    {
        RangeAttributesResult SelectFrom(String tableName, String name);
    }
}