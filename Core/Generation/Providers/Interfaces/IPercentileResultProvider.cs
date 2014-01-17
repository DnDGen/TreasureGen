using System;

namespace EquipmentGen.Core.Generation.Providers.Interfaces
{
    public interface IPercentileResultProvider
    {
        String GetPercentileResult(String tableName);
    }
}