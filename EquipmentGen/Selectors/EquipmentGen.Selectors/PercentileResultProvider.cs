using System;
using System.Collections.Generic;
using System.Linq;
using EquipmentGen.Selectors.Interfaces;
using EquipmentGen.Mappers.Interfaces;
using EquipmentGen.Mappers.Objects;

namespace EquipmentGen.Selectors
{
    public class PercentileResultProvider : IPercentileResultProvider
    {
        private IPercentileXmlParser percentileXmlParser;
        private Dictionary<String, IEnumerable<PercentileObject>> cachedTables;

        public PercentileResultProvider(IPercentileXmlParser percentileXmlParser)
        {
            this.percentileXmlParser = percentileXmlParser;
            cachedTables = new Dictionary<String, IEnumerable<PercentileObject>>();
        }

        public String GetResultFrom(String tableName, Int32 roll)
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
            var table = percentileXmlParser.Parse(filename);
            cachedTables.Add(tableName, table);
        }

        private Boolean RollIsInRange(Int32 roll, PercentileObject percentileObject)
        {
            return percentileObject.LowerLimit <= roll && roll <= percentileObject.UpperLimit;
        }

        public IEnumerable<String> GetAllResultsFrom(String tableName)
        {
            if (!cachedTables.ContainsKey(tableName))
                CacheTable(tableName);

            return cachedTables[tableName].Select(o => o.Content);
        }
    }
}