using System;
using System.Collections.Generic;

namespace TreasureGen.Selectors.Interfaces
{
    public interface IPercentileSelector
    {
        String SelectFrom(String tableName);
        IEnumerable<String> SelectAllFrom(String tableName);
    }
}