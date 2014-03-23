using System;
using System.Collections.Generic;
using EquipmentGen.Mappers.Objects;

namespace EquipmentGen.Mappers.Interfaces
{
    public interface ISpecialAbilityDataMapper
    {
        Dictionary<String, SpecialAbilityDataObject> Map(String tableName);
    }
}