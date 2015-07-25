using System;
using System.Collections.Generic;

namespace TreasureGen.Mappers
{
    public interface IPercentileMapper
    {
        Dictionary<Int32, String> Map(String tableName);
    }
}