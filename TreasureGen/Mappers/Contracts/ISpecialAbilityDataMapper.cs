using System;
using System.Collections.Generic;
using TreasureGen.Mappers.Models;

namespace TreasureGen.Mappers
{
    public interface ISpecialAbilityDataMapper
    {
        Dictionary<String, SpecialAbilityDataModel> Map(String tableName);
    }
}