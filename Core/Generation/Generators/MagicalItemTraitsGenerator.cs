using System;
using System.Collections.Generic;
using EquipmentGen.Core.Generation.Generators.Interfaces;
using EquipmentGen.Core.Generation.Providers.Interfaces;

namespace EquipmentGen.Core.Generation.Generators
{
    public class MagicalItemTraitsGenerator : IMagicalItemTraitsGenerator
    {
        private IPercentileResultProvider percentileResultProvider;

        public MagicalItemTraitsGenerator(IPercentileResultProvider percentileResultProvider)
        {
            this.percentileResultProvider = percentileResultProvider;
        }

        public IEnumerable<String> GenerateFor(String itemType)
        {
            var traits = new List<String>();
            var tableName = String.Format("{0}Traits", itemType);
            var result = percentileResultProvider.GetResultFrom(tableName);

            if (String.IsNullOrEmpty(result))
                return traits;

            traits.AddRange(result.Split(','));

            return traits;
        }
    }
}