using System;
using EquipmentGen.Core.Data.Items;
using EquipmentGen.Core.Generation.Factories.Interfaces;
using EquipmentGen.Core.Generation.Generators.Interfaces;
using EquipmentGen.Core.Generation.Providers.Interfaces;

namespace EquipmentGen.Core.Generation.Generators
{
    public class MundaneItemGenerator : IPowerItemGenerator
    {
        private IPercentileResultProvider percentileResultProvider;
        private IAlchemicalItemGenerator alchemicalItemFactory;
        private IGearGeneratorFactory gearFactoryFactory;
        private IToolGenerator toolGenerator;

        public MundaneItemGenerator(IPercentileResultProvider percentileResultProvider, IAlchemicalItemGenerator alchemicalItemFactory,
            IGearGeneratorFactory gearFactoryFactory, IToolGenerator toolGenerator)
        {
            this.percentileResultProvider = percentileResultProvider;
            this.alchemicalItemFactory = alchemicalItemFactory;
            this.gearFactoryFactory = gearFactoryFactory;
            this.toolGenerator = toolGenerator;
        }

        public Item Generate()
        {
            var type = percentileResultProvider.GetPercentileResult("MundaneItems");
            return GetItem(type);
        }

        private Item GetItem(String type)
        {
            switch (type)
            {
                case ItemsConstants.ItemTypes.AlchemicalItem: return alchemicalItemFactory.Generate();
                case ItemsConstants.ItemTypes.Armor:
                case ItemsConstants.ItemTypes.Weapon: return CreateGear(type);
                case ItemsConstants.ItemTypes.Tool: return toolGenerator.Generate();
                default: throw new ArgumentOutOfRangeException();
            }
        }

        private Item CreateGear(String type)
        {
            var factory = gearFactoryFactory.CreateWith(type);
            return factory.GenerateAtPower(ItemsConstants.Power.Mundane);
        }
    }
}