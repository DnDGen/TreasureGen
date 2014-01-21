using System;
using EquipmentGen.Core.Data.Items;
using EquipmentGen.Core.Generation.Factories.Interfaces;
using EquipmentGen.Core.Generation.Generators;
using EquipmentGen.Core.Generation.Generators.Interfaces;
using EquipmentGen.Core.Generation.Providers.Interfaces;

namespace EquipmentGen.Core.Generation.Factories
{
    public class MundaneGearGeneratorFactory : IMundaneGearGeneratorFactory
    {
        private IPercentileResultProvider percentileResultProvider;
        private IAmmunitionGenerator ammunitionGenerator;

        public MundaneGearGeneratorFactory(IPercentileResultProvider percentileResultProvider, IAmmunitionGenerator ammunitionGenerator)
        {
            this.percentileResultProvider = percentileResultProvider;
            this.ammunitionGenerator = ammunitionGenerator;
        }

        public IMundaneGearGenerator CreateWith(String type)
        {
            switch (type)
            {
                case ItemsConstants.ItemTypes.Armor: return new MundaneArmorGenerator(percentileResultProvider);
                case ItemsConstants.ItemTypes.Weapon: return new MundaneWeaponGenerator(percentileResultProvider, ammunitionGenerator);
                default: throw new ArgumentOutOfRangeException();
            }
        }
    }
}