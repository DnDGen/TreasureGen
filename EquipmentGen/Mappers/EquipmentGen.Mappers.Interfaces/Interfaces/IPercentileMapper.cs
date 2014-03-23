using System;
using System.Collections.Generic;
using EquipmentGen.Mappers.Objects;

namespace EquipmentGen.Mappers.Interfaces
{
    public interface IPercentileMapper
    {
        IEnumerable<PercentileObject> Map(String tableName);
    }
}