using System;
using System.Collections.Generic;
using System.Linq;
using EquipmentGen.Mappers.Interfaces;
using EquipmentGen.Mappers.Objects;
using EquipmentGen.Selectors.Interfaces;

namespace EquipmentGen.Selectors
{
    public class PercentileSelector : IPercentileSelector
    {
        private IPercentileMapper percentileMapper;
        private Dictionary<String, IEnumerable<PercentileObject>> cachedTables;

        public PercentileSelector(IPercentileMapper percentileMapper)
        {
            this.percentileMapper = percentileMapper;
            cachedTables = new Dictionary<String, IEnumerable<PercentileObject>>();
        }

        public String SelectFrom(String tableName, Int32 roll)
        {
            if (!cachedTables.ContainsKey(tableName))
                CacheTable(tableName);

            var percentileObject = cachedTables[tableName].FirstOrDefault(o => RollIsInRange(roll, o));

            if (percentileObject == null)
                return String.Empty;

            return percentileObject.Content;
        }

        private void CacheTable(String tableName)
        {
            var filename = tableName + ".xml";
            var table = percentileMapper.Map(filename);
            cachedTables.Add(tableName, table);
        }

        private Boolean RollIsInRange(Int32 roll, PercentileObject percentileObject)
        {
            return percentileObject.LowerLimit <= roll && roll <= percentileObject.UpperLimit;
        }

        public IEnumerable<String> SelectAllFrom(String tableName)
        {
            if (!cachedTables.ContainsKey(tableName))
                CacheTable(tableName);

            return cachedTables[tableName].Select(o => o.Content);
        }
    }
}