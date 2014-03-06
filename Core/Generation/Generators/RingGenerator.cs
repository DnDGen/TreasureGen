using System;
using EquipmentGen.Core.Data.Items;
using EquipmentGen.Core.Generation.Generators.Interfaces;
using EquipmentGen.Core.Generation.Providers.Interfaces;

namespace EquipmentGen.Core.Generation.Generators
{
    public class RingGenerator : IMagicalItemGenerator
    {
        private IPercentileResultProvider percentileResultProvider;
        private IAttributesProvider attributesProvider;
        private IMagicalItemTraitsGenerator traitsGenerator;

        public RingGenerator(IPercentileResultProvider percentileResultProvider, IAttributesProvider attributesProvider,
            IMagicalItemTraitsGenerator traitsGenerator)
        {
            this.percentileResultProvider = percentileResultProvider;
            this.attributesProvider = attributesProvider;
            this.traitsGenerator = traitsGenerator;
        }

        public Item GenerateAtPower(String power)
        {
            throw new NotImplementedException();
        }
    }
}