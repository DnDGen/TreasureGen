using D20Dice;
using EquipmentGen.Core.Generation.Providers.Interfaces;
using EquipmentGen.Core.Generation.Xml.Parsers.Interfaces;
using EquipmentGen.Core.Generation.Xml.Parsers.Objects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EquipmentGen.Core.Generation.Providers
{
    public class PercentileResultProvider : IPercentileResultProvider
    {
        private IPercentileXmlParser percentileXmlParser;
        private IDice dice;
        private Dictionary<String, IEnumerable<PercentileObject>> cachedTables;

        public PercentileResultProvider(IPercentileXmlParser percentileXmlParser, IDice dice)
        {
            this.percentileXmlParser = percentileXmlParser;
            this.dice = dice;
            cachedTables = new Dictionary<String, IEnumerable<PercentileObject>>();
        }

        public String GetPercentileResult(String tableName)
        {
            if (!cachedTables.ContainsKey(tableName))
                CacheTable(tableName);

            var percentileObject = GetPercentileObject(tableName);

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

        private PercentileObject GetPercentileObject(String tableName)
        {
            var roll = dice.Percentile();
            return cachedTables[tableName].FirstOrDefault(o => RollIsInRange(roll, o));
        }

        private Boolean RollIsInRange(Int32 roll, PercentileObject percentileObject)
        {
            return percentileObject.LowerLimit <= roll && roll <= percentileObject.UpperLimit;
        }

        public IEnumerable<String> GetAllResults(String tableName)
        {
            if (!cachedTables.ContainsKey(tableName))
                CacheTable(tableName);

            var results = new List<String>();

            foreach (var percentileObject in cachedTables[tableName])
                results.Add(percentileObject.Content);

            if (!CompleteTable(cachedTables[tableName]))
                results.Add(String.Empty);

            return results;
        }

        private Boolean CompleteTable(IEnumerable<PercentileObject> table)
        {
            if (!table.Any())
                return false;

            var percentileRolls = new List<Int32>();
            for (var i = 1; i <= 100; i++)
                percentileRolls.Add(i);

            return percentileRolls.All(r => table.Any(p => RollIsInRange(r, p)));
        }
    }
}