using System;
using System.Collections.Generic;

namespace TreasureGen.Mappers.Interfaces
{
    public interface IAttributesMapper
    {
        Dictionary<String, IEnumerable<String>> Map(String tableName);
    }
}