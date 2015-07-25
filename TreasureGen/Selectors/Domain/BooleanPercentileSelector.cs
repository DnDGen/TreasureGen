using System;
using TreasureGen.Selectors.Interfaces;

namespace TreasureGen.Selectors
{
    public class BooleanPercentileSelector : IBooleanPercentileSelector
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