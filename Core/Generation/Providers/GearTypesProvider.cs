using System;
using System.Collections.Generic;
using EquipmentGen.Core.Generation.Exceptions;
using EquipmentGen.Core.Generation.Providers.Interfaces;
using EquipmentGen.Core.Generation.Xml.Parsers.Interfaces;

namespace EquipmentGen.Core.Generation.Providers
{
    public class GearTypesProvider : IGearTypesProvider
    {
        private ITypesXmlParser gearTypesXmlParser;

        private Dictionary<String, IEnumerable<String>> table;

        public GearTypesProvider(ITypesXmlParser gearTypesXmlParser)
        {
            this.gearTypesXmlParser = gearTypesXmlParser;
        }

        public IEnumerable<String> GetGearTypesFor(String gearName)
        {
            if (table == null)
                table = gearTypesXmlParser.Parse("GearTypes.xml");

            if (!table.ContainsKey(gearName))
                throw new ItemNotFoundException(gearName);

            return table[gearName];
        }
    }
}