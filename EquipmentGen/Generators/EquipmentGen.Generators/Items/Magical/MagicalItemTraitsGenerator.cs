using System;
using System.Collections.Generic;
using D20Dice;
using EquipmentGen.Core.Generation.Generators.Interfaces;
using EquipmentGen.Core.Generation.Providers.Interfaces;

namespace EquipmentGen.Core.Generation.Generators
{
    public class MagicalItemTraitsGenerator : IMagicalItemTraitsGenerator
    {
        private IPercentileResultProvider percentileResultProvider;
        private IDice dice;

        public MagicalItemTraitsGenerator(IPercentileResultProvider percentileResultProvider, IDice dice)
        {
            this.percentileResultProvider = percentileResultProvider;
            this.dice = dice;
        }

        public IEnumerable<String> GenerateFor(String itemType)
        {
            var traits = new List<String>();
            var tableName = String.Format("{0}Traits", itemType);
            var roll = dice.Percentile();
            var result = percentileResultProvider.GetResultFrom(tableName, roll);

            if (String.IsNullOrEmpty(result))
                return traits;

            traits.AddRange(result.Split(','));

            return traits;
        }
    }
}