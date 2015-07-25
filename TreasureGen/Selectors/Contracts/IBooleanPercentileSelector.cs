using System;

namespace TreasureGen.Selectors
{
    public interface IBooleanPercentileSelector
    {
        Boolean SelectFrom(String tableName);
    }
}