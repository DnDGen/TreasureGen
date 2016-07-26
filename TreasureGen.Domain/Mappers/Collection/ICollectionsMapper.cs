using System;
using System.Collections.Generic;

namespace TreasureGen.Domain.Mappers.Collections
{
    internal interface ICollectionsMapper
    {
        Dictionary<string, IEnumerable<string>> Map(string tableName);
    }
}