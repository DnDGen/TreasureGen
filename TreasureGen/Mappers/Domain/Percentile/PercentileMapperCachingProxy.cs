using System;
using System.Collections.Generic;

namespace TreasureGen.Mappers.Domain.Percentile
{
    public class PercentileMapperCachingProxy : IPercentileMapper
    {
        private Dictionary<String, Dictionary<Int32, String>> tables;
        private IPercentileMapper innerMapper;

        public PercentileMapperCachingProxy(IPercentileMapper innerMapper)
        {
            this.innerMapper = innerMapper;
            tables = new Dictionary<String, Dictionary<Int32, String>>();
        }

        public Dictionary<Int32, String> Map(String tableName)
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