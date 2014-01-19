using System;
using EquipmentGen.Core.Data.Items;
using EquipmentGen.Core.Generation.Factories.Interfaces;
using EquipmentGen.Core.Generation.Providers.Interfaces;

namespace EquipmentGen.Core.Generation.Factories
{
    public class MundaneItemFactory : IPowerFactory
    {
        private IPercentileResultProvider percentileResultProvider;
        private IAlchemicalItemFactory alchemicalItemFactory;
        private IGearFactoryFactory gearFactoryFactory;
        private IToolFactory toolFactory;

        public MundaneItemFactory(IPercentileResultProvider percentileResultProvider, IAlchemicalItemFactory alchemicalItemFactory,
            IGearFactoryFactory gearFactoryFactory, IToolFactory toolFactory)
        {
            this.percentileResultProvider = percentileResultProvider;
            this.alchemicalItemFactory = alchemicalItemFactory;
            this.gearFactoryFactory = gearFactoryFactory;
            this.toolFactory = toolFactory;
        }

        public Item Create()
        {
            var type = percentileResultProvider.GetPercentileResult("MundaneItems");
            return GetItem(type);
        }

        private Item GetItem(String type)
        {
            switch (type)
            {
                case ItemsConstants.ItemTypes.AlchemicalItem: return alchemicalItemFactory.Create();
                case ItemsConstants.ItemTypes.Armor:
                case ItemsConstants.ItemTypes.Weapon: return CreateGear(type);
                case ItemsConstants.ItemTypes.Tool: return toolFactory.Create();
                default: throw new ArgumentOutOfRangeException();
            }
        }

        private Item CreateGear(String type)
        {
            var factory = gearFactoryFactory.CreateWith(type);
            return factory.CreateWith(ItemsConstants.Power.Mundane);
        }
    }
}