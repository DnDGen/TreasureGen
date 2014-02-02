using System;
using EquipmentGen.Core.Generation.Providers.Objects;

namespace EquipmentGen.Core.Generation.Providers.Interfaces
{
    public interface ISpecialAbilityPercentileResultProvider
    {
        SpecialAbilityPercentileResult GetResultFrom(String tableName);
    }
}