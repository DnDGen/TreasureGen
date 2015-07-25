using System;
using System.Collections.Generic;
using TreasureGen.Mappers.Objects;

namespace TreasureGen.Mappers.Interfaces
{
    public interface ISpecialAbilityDataMapper
    {
        Dictionary<String, SpecialAbilityDataObject> Map(String tableName);
    }
}