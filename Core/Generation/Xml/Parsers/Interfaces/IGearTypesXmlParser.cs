using System;
using System.Collections.Generic;

namespace EquipmentGen.Core.Generation.Xml.Parsers.Interfaces
{
    public interface IGearTypesXmlParser
    {
        Dictionary<String, IEnumerable<String>> Parse(String fileName);
    }
}