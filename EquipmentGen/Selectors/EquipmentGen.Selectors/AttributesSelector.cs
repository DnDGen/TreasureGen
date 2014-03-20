using System;
using System.Collections.Generic;
using System.Linq;
using EquipmentGen.Mappers.Interfaces;
using EquipmentGen.Selectors.Interfaces;

namespace EquipmentGen.Selectors
{
    public class AttributesSelector : IAttributesSelector
    {
        private IAttributesMapper attributesMapper;
        private Dictionary<String, Dictionary<String, IEnumerable<String>>> tables;

        public AttributesSelector(IAttributesMapper attributesMapper)
        {
            this.attributesMapper = attributesMapper;
            tables = new Dictionary<String, Dictionary<String, IEnumerable<String>>>();
        }

        public IEnumerable<String> SelectFrom(String name, String table)
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
            var table = attributesMapper.Map(filename);
            tables.Add(tableName, table);
        }
    }
}