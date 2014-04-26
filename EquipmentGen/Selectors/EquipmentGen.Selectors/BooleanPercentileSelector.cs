using System;
using EquipmentGen.Selectors.Interfaces;

namespace EquipmentGen.Selectors
{
    public class BooleanPercentileSelector : IBooleanPercentileSelector
    {
        private IPercentileSelector innerSelector;

        public BooleanPercentileSelector(IPercentileSelector innerSelector)
        {
            this.innerSelector = innerSelector;
        }

        public Boolean SelectFrom(String tableName, Int32 roll)
        {
            var result = innerSelector.SelectFrom(tableName, roll);
            return Convert.ToBoolean(result);
        }
    }
}