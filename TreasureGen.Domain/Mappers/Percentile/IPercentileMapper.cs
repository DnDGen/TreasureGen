using System.Collections.Generic;

namespace TreasureGen.Domain.Mappers.Percentile
{
    internal interface IPercentileMapper
    {
        Dictionary<int, string> Map(string tableName);
    }
}