using System;
using System.Collections.Generic;

namespace EquipmentGen.Core.Generation.Providers.Interfaces
{
    public interface IPercentileResultProvider
    {
        String GetResultFrom(String tableName, Int32 roll);
        IEnumerable<String> GetAllResultsFrom(String tableName);
    }
}