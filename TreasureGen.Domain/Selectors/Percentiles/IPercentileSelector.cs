using System.Collections.Generic;

namespace TreasureGen.Domain.Selectors.Percentiles
{
    internal interface IPercentileSelector
    {
        string SelectFrom(string tableName);
        IEnumerable<string> SelectAllFrom(string tableName);
    }
}