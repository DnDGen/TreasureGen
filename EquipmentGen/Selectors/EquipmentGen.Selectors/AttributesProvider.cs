using System;
using System.Collections.Generic;
using System.Linq;
using EquipmentGen.Selectors.Interfaces;
using EquipmentGen.Mappers.Interfaces;

namespace EquipmentGen.Selectors
{
    public class AttributesProvider : IAttributesProvider
    {
        private IAttributesMapper attributesXmlParser;
        private Dictionary<String, Dictionary<String, IEnumerable<String>>> tables;

        public AttributesProvider(IAttributesMapper attributesXmlParser)
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