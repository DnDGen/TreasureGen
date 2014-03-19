using System;
using System.Collections.Generic;
using EquipmentGen.Mappers.Objects;

namespace EquipmentGen.Mappers.Interfaces
{
    public interface ISpecialAbilityDataXmlParser
    {
        Dictionary<String, SpecialAbilityDataObject> Parse(String fileName);
    }
}