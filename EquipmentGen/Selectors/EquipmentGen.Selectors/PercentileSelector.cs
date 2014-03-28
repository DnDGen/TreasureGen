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

        public PercentileSelector(IPercentileMapper percentileMapper)
        {
            this.percentileMapper = percentileMapper;
        }

        public String SelectFrom(String tableName, Int32 roll)
        {
            if (roll < 1 || roll > 100)
                throw new ArgumentException();

            var table = percentileMapper.Map(tableName);
            return table[roll];
        }

        public IEnumerable<String> SelectAllFrom(String tableName)
        {
            var table = percentileMapper.Map(tableName);
            return table.Values.Distinct();
        }
    }
}