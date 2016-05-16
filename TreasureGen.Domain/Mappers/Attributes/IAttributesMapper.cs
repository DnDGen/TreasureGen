using System;
using System.Collections.Generic;

namespace TreasureGen.Domain.Mappers.Attributes
{
    internal interface IAttributesMapper
    {
        Dictionary<string, IEnumerable<string>> Map(string tableName);
    }
}