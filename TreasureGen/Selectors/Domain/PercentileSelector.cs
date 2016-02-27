using RollGen;
using System.Collections.Generic;
using System.Linq;
using TreasureGen.Mappers;

namespace TreasureGen.Selectors.Domain
{
    public class PercentileSelector : IPercentileSelector
    {
        private IPercentileMapper percentileMapper;
        private Dice dice;

        public PercentileSelector(IPercentileMapper percentileMapper, Dice dice)
        {
            this.percentileMapper = percentileMapper;
            this.dice = dice;
        }

        public string SelectFrom(string tableName)
        {
            var roll = dice.Roll().Percentile();
            var table = percentileMapper.Map(tableName);
            return table[roll];
        }

        public IEnumerable<string> SelectAllFrom(string tableName)
        {
            var table = percentileMapper.Map(tableName);
            return table.Values.Distinct();
        }
    }
}