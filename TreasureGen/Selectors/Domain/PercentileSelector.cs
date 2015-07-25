using RollGen;
using System;
using System.Collections.Generic;
using System.Linq;
using TreasureGen.Mappers;

namespace TreasureGen.Selectors.Domain
{
    public class PercentileSelector : IPercentileSelector
    {
        private IPercentileMapper percentileMapper;
        private IDice dice;

        public PercentileSelector(IPercentileMapper percentileMapper, IDice dice)
        {
            this.percentileMapper = percentileMapper;
            this.dice = dice;
        }

        public String SelectFrom(String tableName)
        {
            var roll = dice.Roll().Percentile();
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