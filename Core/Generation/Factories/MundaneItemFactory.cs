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
        private IGearFactory armorFactory;
        private IGearFactory weaponFactory;
        private IToolFactory toolFactory;

        public MundaneItemFactory(IPercentileResultProvider percentileResultProvider, IAlchemicalItemFactory alchemicalItemFactory,
            IGearFactory armorFactory, IGearFactory weaponFactory, IToolFactory toolFactory)
        {
            this.percentileResultProvider = percentileResultProvider;
            this.alchemicalItemFactory = alchemicalItemFactory;
            this.armorFactory = armorFactory;
            this.weaponFactory = weaponFactory;
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
                case ItemsConstants.ItemTypes.Armor: return armorFactory.CreateWith(ItemsConstants.Power.Mundane);
                case ItemsConstants.ItemTypes.Weapon: return weaponFactory.CreateWith(ItemsConstants.Power.Mundane);
                case ItemsConstants.ItemTypes.Tool: return toolFactory.Create();
                default: throw new ArgumentOutOfRangeException();
            }
        }
    }
}