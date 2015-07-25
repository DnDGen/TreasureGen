using System;

namespace TreasureGen.Selectors.Interfaces
{
    public interface IBooleanPercentileSelector
    {
        Boolean SelectFrom(String tableName);
    }
}