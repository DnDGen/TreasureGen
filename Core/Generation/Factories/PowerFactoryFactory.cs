using System;
using EquipmentGen.Core.Data.Items;
using EquipmentGen.Core.Generation.Factories.Interfaces;
using EquipmentGen.Core.Generation.Providers.Interfaces;

namespace EquipmentGen.Core.Generation.Factories
{
    public class PowerFactoryFactory : IPowerFactoryFactory
    {
        private IPercentileResultProvider percentileResultProvider;
        private IAlchemicalItemFactory alchemicalItemFactory;
        private IGearFactory armorFactory;
        private IGearFactory weaponFactory;
        private IToolFactory toolFactory;

        public PowerFactoryFactory(IPercentileResultProvider percentileResultProvider, IAlchemicalItemFactory alchemicalItemFactory,
            IGearFactory armorFactory, IGearFactory weaponFactory, IToolFactory toolFactory)
        {
            this.percentileResultProvider = percentileResultProvider;
            this.alchemicalItemFactory = alchemicalItemFactory;
            this.armorFactory = armorFactory;
            this.weaponFactory = weaponFactory;
            this.toolFactory = toolFactory;
        }

        public IPowerFactory CreateWith(String power)
        {
            switch (power)
            {
                case ItemsConstants.Power.Mundane: return CreateMundaneItemFactory();
                case ItemsConstants.Power.Minor: return new MinorItemFactory();
                case ItemsConstants.Power.Medium: return new MediumItemFactory();
                case ItemsConstants.Power.Major: return new MajorItemFactory();
                default: throw new ArgumentOutOfRangeException();
            }
        }

        private IPowerFactory CreateMundaneItemFactory()
        {
            return new MundaneItemFactory(percentileResultProvider, alchemicalItemFactory, armorFactory, weaponFactory, toolFactory);
        }
    }
}