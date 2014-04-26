using System;
using System.Collections.Generic;
using D20Dice;
using EquipmentGen.Generators.Interfaces.Items.Magical;
using EquipmentGen.Selectors.Interfaces;

namespace EquipmentGen.Generators.Items.Magical
{
    public class MagicalItemTraitsGenerator : IMagicalItemTraitsGenerator
    {
        private IPercentileSelector percentileSelector;
        private IDice dice;

        public MagicalItemTraitsGenerator(IPercentileSelector percentileSelector, IDice dice)
        {
            this.percentileSelector = percentileSelector;
            this.dice = dice;
        }

        public IEnumerable<String> GenerateFor(String itemType)
        {
            var tableName = String.Format("{0}Traits", itemType);
            var roll = dice.Percentile();
            var result = percentileSelector.SelectFrom(tableName, roll);
            var traits = new List<String>();

            if (String.IsNullOrEmpty(result))
                return traits;

            traits.AddRange(result.Split(','));

            return traits;
        }
    }
}