using System;
using EquipmentGen.Core.Data.Items;
using EquipmentGen.Core.Generation.Factories.Interfaces;
using EquipmentGen.Core.Generation.Generators.Interfaces;
using EquipmentGen.Core.Generation.Providers.Interfaces;

namespace EquipmentGen.Core.Generation.Generators
{
    public class MundaneItemGenerator : IMundaneItemGenerator
    {
        private IPercentileResultProvider percentileResultProvider;
        private IAlchemicalItemGenerator alchemicalItemFactory;
        private IMundaneGearGeneratorFactory gearGeneratorFactory;
        private IToolGenerator toolGenerator;

        public MundaneItemGenerator(IPercentileResultProvider percentileResultProvider, IAlchemicalItemGenerator alchemicalItemFactory,
            IMundaneGearGeneratorFactory gearGeneratorFactory, IToolGenerator toolGenerator)
        {
            this.percentileResultProvider = percentileResultProvider;
            this.alchemicalItemFactory = alchemicalItemFactory;
            this.gearGeneratorFactory = gearGeneratorFactory;
            this.toolGenerator = toolGenerator;
        }

        public Item Generate()
        {
            var type = percentileResultProvider.GetResultFrom("MundaneItems");
            return GetItem(type);
        }

        private Item GetItem(String type)
        {
            switch (type)
            {
                case ItemsConstants.ItemTypes.AlchemicalItem: return alchemicalItemFactory.Generate();
                case ItemsConstants.ItemTypes.Armor:
                case ItemsConstants.ItemTypes.Weapon: return GenerateGear(type);
                case ItemsConstants.ItemTypes.Tool: return toolGenerator.Generate();
                default: throw new ArgumentOutOfRangeException();
            }
        }

        private Item GenerateGear(String type)
        {
            var generator = gearGeneratorFactory.CreateWith(type);
            return generator.Generate();
        }
    }
}