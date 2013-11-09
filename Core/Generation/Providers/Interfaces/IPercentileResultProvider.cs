using System;
using System.Collections.Generic;

namespace EquipmentGen.Core.Generation.Providers.Interfaces
{
    public interface IPercentileResultProvider
    {
        String GetPercentileResult(String tableName);
        IEnumerable<String> GetAllResults(String tableName);
    }
}