using System;
using System.Collections.Generic;
using System.Linq;
using EquipmentGen.Core.Generation.Providers.Interfaces;
using EquipmentGen.Core.Generation.Xml.Parsers.Interfaces;

namespace EquipmentGen.Core.Generation.Providers
{
    public class AttributesProvider : IAttributesProvider
    {
        private IAttributesXmlParser attributesXmlParser;
        private Dictionary<String, Dictionary<String, IEnumerable<String>>> tables;

        public AttributesProvider(IAttributesXmlParser attributesXmlParser)
        {
            this.attributesXmlParser = attributesXmlParser;
            tables = new Dictionary<String, Dictionary<String, IEnumerable<String>>>();
        }

        public IEnumerable<String> GetAttributesFor(String name, String table)
        {
            if (!tables.ContainsKey(table))
                CacheTable(table);

            if (!tables[table].ContainsKey(name))
                return Enumerable.Empty<String>();

            return tables[table][name];
        }

        private void CacheTable(String tableName)
        {
            var filename = String.Format("{0}.xml", tableName);
            var table = attributesXmlParser.Parse(filename);
            tables.Add(tableName, table);
        }
    }
}