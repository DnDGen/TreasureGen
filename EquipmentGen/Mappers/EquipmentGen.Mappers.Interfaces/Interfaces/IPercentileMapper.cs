using System;
using System.Collections.Generic;

namespace EquipmentGen.Mappers.Interfaces
{
    public interface IPercentileMapper
    {
        Dictionary<Int32, String> Map(String tableName);
    }
}