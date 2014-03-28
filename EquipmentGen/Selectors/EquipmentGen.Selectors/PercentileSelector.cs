using System;
using System.Collections.Generic;
using System.Linq;
using EquipmentGen.Mappers.Interfaces;
using EquipmentGen.Selectors.Interfaces;

namespace EquipmentGen.Selectors
{
    public class PercentileSelector : IPercentileSelector
    {
        private IPercentileMapper percentileMapper;
        private Dictionary<String, Dictionary<Int32, String>> cachedTables;

        public PercentileSelector(IPercentileMapper percentileMapper)
        {
            this.percentileMapper = percentileMapper;
            cachedTables = new Dictionary<String, Dictionary<Int32, String>>();
        }

        public String SelectFrom(String tableName, Int32 roll)
        {
            if (!cachedTables.ContainsKey(tableName))
                CacheTable(tableName);

            if (roll < 1 || roll > 100)
                throw new ArgumentException();

            return cachedTables[tableName][roll];
        }

        private void CacheTable(String tableName)
        {
            var table = percentileMapper.Map(tableName);
            cachedTables.Add(tableName, table);
        }

        public IEnumerable<String> SelectAllFrom(String tableName)
        {
            if (!cachedTables.ContainsKey(tableName))
                CacheTable(tableName);

            return cachedTables[tableName].Values.Distinct();
        }
    }
}