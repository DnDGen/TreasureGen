using System;

namespace EquipmentGen.Selectors.Interfaces
{
    public interface IBooleanPercentileSelector
    {
        Boolean SelectFrom(String tableName, Int32 roll);
    }
}