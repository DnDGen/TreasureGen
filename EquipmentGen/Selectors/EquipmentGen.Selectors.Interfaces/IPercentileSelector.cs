using System;
using System.Collections.Generic;

namespace EquipmentGen.Selectors.Interfaces
{
    public interface IPercentileSelector
    {
        String SelectFrom(String tableName, Int32 roll);
        IEnumerable<String> SelectAllFrom(String tableName);
    }
}