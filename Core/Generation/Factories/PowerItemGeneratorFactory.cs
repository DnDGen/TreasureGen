using System;
using EquipmentGen.Core.Data.Items;
using EquipmentGen.Core.Generation.Factories.Interfaces;
using EquipmentGen.Core.Generation.Generators;
using EquipmentGen.Core.Generation.Generators.Interfaces;
using EquipmentGen.Core.Generation.Providers.Interfaces;

namespace EquipmentGen.Core.Generation.Factories
{
    public class PowerItemGeneratorFactory : IPowerItemGeneratorFactory
    {
        private IPercentileResultProvider percentileResultProvider;
        private IAlchemicalItemGenerator alchemicalItemGenerator;
        private IGearGeneratorFactory gearGeneratorFactory;
        private IToolGenerator toolGenerator;

        public PowerItemGeneratorFactory(IPercentileResultProvider percentileResultProvider, IAlchemicalItemGenerator alchemicalItemGenerator,
            IGearGeneratorFactory gearGeneratorFactory, IToolGenerator toolGenerator)
        {
            this.percentileResultProvider = percentileResultProvider;
            this.alchemicalItemGenerator = alchemicalItemGenerator;
            this.gearGeneratorFactory = gearGeneratorFactory;
            this.toolGenerator = toolGenerator;
        }

        public IPowerItemGenerator CreateWith(String power)
        {
            switch (power)
            {
                case ItemsConstants.Power.Mundane: return CreateMundaneItemGenerator();
                case ItemsConstants.Power.Minor: return new MinorItemGenerator();
                case ItemsConstants.Power.Medium: return new MediumItemGenerator();
                case ItemsConstants.Power.Major: return new MajorItemGenerator();
                default: throw new ArgumentOutOfRangeException();
            }
        }

        private IPowerItemGenerator CreateMundaneItemGenerator()
        {
            return new MundaneItemGenerator(percentileResultProvider, alchemicalItemGenerator, gearGeneratorFactory, toolGenerator);
        }
    }
}