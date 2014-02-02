using System;
using System.Collections.Generic;
using EquipmentGen.Core.Generation.Exceptions;
using EquipmentGen.Core.Generation.Providers.Interfaces;
using EquipmentGen.Core.Generation.Xml.Parsers.Interfaces;

namespace EquipmentGen.Core.Generation.Providers
{
    public class TypesProvider : ITypesProvider
    {
        private ITypesXmlParser typesXmlParser;
        private Dictionary<String, Dictionary<String, IEnumerable<String>>> tables;

        public TypesProvider(ITypesXmlParser typesXmlParser)
        {
            this.typesXmlParser = typesXmlParser;
            tables = new Dictionary<String, Dictionary<String, IEnumerable<String>>>();
        }

        public IEnumerable<String> GetTypesFor(String name, String table)
        {
            if (!tables.ContainsKey(table))
                CacheTable(table);

            if (!tables[table].ContainsKey(name))
                throw new ItemNotFoundException(name);

            return tables[table][name];
        }

        private void CacheTable(String tableName)
        {
            var filename = String.Format("{0}.xml", tableName);
            var table = typesXmlParser.Parse(filename);
            tables.Add(tableName, table);
        }
    }
}