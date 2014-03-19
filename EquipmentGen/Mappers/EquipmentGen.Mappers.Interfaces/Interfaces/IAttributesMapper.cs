using System;
using System.Collections.Generic;

namespace EquipmentGen.Mappers.Interfaces
{
    public interface IAttributesMapper
    {
        Dictionary<String, IEnumerable<String>> Parse(String fileName);
    }
}