using System;
using System.Collections.Generic;
using D20Dice;
using EquipmentGen.Generators.Interfaces.Items.Magical;
using EquipmentGen.Selectors.Interfaces;

namespace EquipmentGen.Generators.Items.Magical
{
    public class MagicalItemTraitsGenerator : IMagicalItemTraitsGenerator
    {
        private IPercentileSelector percentileResultProvider;
        private IDice dice;

        public MagicalItemTraitsGenerator(IPercentileSelector percentileResultProvider, IDice dice)
        {
            this.percentileResultProvider = percentileResultProvider;
            this.dice = dice;
        }

        public IEnumerable<String> GenerateFor(String itemType)
        {
            var traits = new List<String>();
            var tableName = String.Format("{0}Traits", itemType);
            var roll = dice.Percentile();
            var result = percentileResultProvider.SelectFrom(tableName, roll);

            if (String.IsNullOrEmpty(result))
                return traits;

            traits.AddRange(result.Split(','));

            return traits;
        }
    }
}