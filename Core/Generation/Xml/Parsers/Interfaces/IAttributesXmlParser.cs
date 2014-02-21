using System;
using System.Collections.Generic;

namespace EquipmentGen.Core.Generation.Xml.Parsers.Interfaces
{
    public interface IAttributesXmlParser
    {
        Dictionary<String, IEnumerable<String>> Parse(String fileName);
    }
}