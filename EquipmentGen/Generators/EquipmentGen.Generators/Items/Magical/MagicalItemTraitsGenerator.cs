using System;
using System.Collections.Generic;
using EquipmentGen.Generators.Interfaces.Items.Magical;
using EquipmentGen.Selectors.Interfaces;

namespace EquipmentGen.Generators.Items.Magical
{
    public class MagicalItemTraitsGenerator : IMagicalItemTraitsGenerator
    {
        private IPercentileSelector percentileSelector;

        public MagicalItemTraitsGenerator(IPercentileSelector percentileSelector)
        {
            this.percentileSelector = percentileSelector;
        }

        public IEnumerable<String> GenerateFor(String itemType)
        {
            var tableName = String.Format("{0}Traits", itemType);
            var result = percentileSelector.SelectFrom(tableName);
            var traits = new List<String>();

            if (String.IsNullOrEmpty(result))
                return traits;

            traits.AddRange(result.Split(','));

            return traits;
        }
    }
}