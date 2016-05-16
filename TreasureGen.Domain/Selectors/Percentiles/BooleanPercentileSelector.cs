using System;

namespace TreasureGen.Domain.Selectors.Percentiles
{
    internal class BooleanPercentileSelector : IBooleanPercentileSelector
    {
        private IPercentileSelector innerSelector;

        public BooleanPercentileSelector(IPercentileSelector innerSelector)
        {
            this.innerSelector = innerSelector;
        }

        public Boolean SelectFrom(String tableName)
        {
            var result = innerSelector.SelectFrom(tableName);
            return Convert.ToBoolean(result);
        }
    }
}