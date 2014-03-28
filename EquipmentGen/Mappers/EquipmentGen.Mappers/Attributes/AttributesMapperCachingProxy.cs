using System;
using System.Collections.Generic;
using EquipmentGen.Mappers.Interfaces;

namespace EquipmentGen.Mappers.Attributes
{
    public class AttributesMapperCachingProxy : IAttributesMapper
    {
        private Dictionary<String, Dictionary<String, IEnumerable<String>>> tables;
        private IAttributesMapper innerMapper;

        public AttributesMapperCachingProxy(IAttributesMapper innerMapper)
        {
            this.innerMapper = innerMapper;
            tables = new Dictionary<String, Dictionary<String, IEnumerable<String>>>();
        }

        public Dictionary<String, IEnumerable<String>> Map(String tableName)
        {
            if (!tables.ContainsKey(tableName))
                CacheTable(tableName);

            return tables[tableName];
        }

        private void CacheTable(String tableName)
        {
            var table = innerMapper.Map(tableName);
            tables.Add(tableName, table);
        }
    }
}