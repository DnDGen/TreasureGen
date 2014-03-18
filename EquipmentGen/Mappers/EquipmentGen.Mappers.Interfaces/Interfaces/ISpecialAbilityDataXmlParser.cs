using System;
using System.Collections.Generic;
using EquipmentGen.Core.Generation.Xml.Parsers.Objects;

namespace EquipmentGen.Core.Generation.Xml.Parsers.Interfaces
{
    public interface ISpecialAbilityDataXmlParser
    {
        Dictionary<String, SpecialAbilityDataObject> Parse(String fileName);
    }
}