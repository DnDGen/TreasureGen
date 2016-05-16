using System.Collections.Generic;

namespace TreasureGen.Domain.Mappers.Percentile
{
    internal class PercentileMapperCachingProxy : IPercentileMapper
    {
        private Dictionary<string, Dictionary<int, string>> tables;
        private IPercentileMapper innerMapper;

        public PercentileMapperCachingProxy(IPercentileMapper innerMapper)
        {
            this.innerMapper = innerMapper;
            tables = new Dictionary<string, Dictionary<int, string>>();
        }

        public Dictionary<int, string> Map(string tableName)
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