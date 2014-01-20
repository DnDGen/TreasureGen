using System;
using EquipmentGen.Core.Data.Items;
using EquipmentGen.Core.Generation.Factories.Interfaces;
using EquipmentGen.Core.Generation.Generators;
using EquipmentGen.Core.Generation.Generators.Interfaces;
using EquipmentGen.Core.Generation.Providers.Interfaces;

namespace EquipmentGen.Core.Generation.Factories
{
    public class GearGeneratorFactory : IGearGeneratorFactory
    {
        private IPercentileResultProvider percentileResultProvider;
        private ITypeAndAmountPercentileResultProvider typeAndAmountPercentileResultProvider;

        public GearGeneratorFactory(IPercentileResultProvider percentileResultProvider, ITypeAndAmountPercentileResultProvider typeAndAmountPercentileResultProvider)
        {
            this.percentileResultProvider = percentileResultProvider;
            this.typeAndAmountPercentileResultProvider = typeAndAmountPercentileResultProvider;
        }

        public IGearGenerator CreateWith(String type)
        {
            switch (type)
            {
                case ItemsConstants.ItemTypes.Armor: return new ArmorGenerator(percentileResultProvider, typeAndAmountPercentileResultProvider);
                case ItemsConstants.ItemTypes.Weapon: return new WeaponGenerator();
                default: throw new ArgumentOutOfRangeException();
            }
        }
    }
}