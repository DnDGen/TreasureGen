using System;
using System.Collections.Generic;

namespace EquipmentGen.Core.Generation.Providers.Interfaces
{
    public interface IPercentileResultProvider
    {
        String GetResultFrom(String tableName);
        IEnumerable<String> GetAllResultsFrom(String tableName);
    }
}