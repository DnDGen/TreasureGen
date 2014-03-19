using System;
using System.Collections.Generic;
using EquipmentGen.Mappers.Objects;

namespace EquipmentGen.Mappers.Interfaces
{
    public interface IPercentileXmlParser
    {
        IEnumerable<PercentileObject> Parse(String filename);
    }
}