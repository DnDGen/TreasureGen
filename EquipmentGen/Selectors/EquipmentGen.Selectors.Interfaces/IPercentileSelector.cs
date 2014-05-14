using System;
using System.Collections.Generic;

namespace EquipmentGen.Selectors.Interfaces
{
    public interface IPercentileSelector
    {
        String SelectFrom(String tableName);
        IEnumerable<String> SelectAllFrom(String tableName);
    }
}