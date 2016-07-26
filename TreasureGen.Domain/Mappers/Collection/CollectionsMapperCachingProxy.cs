using System.Collections.Generic;

namespace TreasureGen.Domain.Mappers.Collections
{
    internal class AttributesMapperCachingProxy : ICollectionsMapper
    {
        private Dictionary<string, Dictionary<string, IEnumerable<string>>> tables;
        private ICollectionsMapper innerMapper;

        public AttributesMapperCachingProxy(ICollectionsMapper innerMapper)
        {
            this.innerMapper = innerMapper;
            tables = new Dictionary<string, Dictionary<string, IEnumerable<string>>>();
        }

        public Dictionary<string, IEnumerable<string>> Map(string tableName)
        {
            if (!tables.ContainsKey(tableName))
                CacheTable(tableName);

            return tables[tableName];
        }

        private void CacheTable(string tableName)
        {
            var table = innerMapper.Map(tableName);
            tables.Add(tableName, table);
        }
    }
}