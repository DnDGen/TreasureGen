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
        private IMaterialsProvider materialsProvider;
        private IGearTypesProvider gearTypesProvider;

        public MundaneGearGeneratorFactory(IPercentileResultProvider percentileResultProvider, IAmmunitionGenerator ammunitionGenerator,
            IMaterialsProvider materialsProvider, IGearTypesProvider gearTypesProvider)
        {
            this.percentileResultProvider = percentileResultProvider;
            this.ammunitionGenerator = ammunitionGenerator;
            this.materialsProvider = materialsProvider;
            this.gearTypesProvider = gearTypesProvider;
        }

        public IMundaneGearGenerator CreateWith(String type)
        {
            switch (type)
            {
                case ItemsConstants.ItemTypes.Armor: return new MundaneArmorGenerator(percentileResultProvider, materialsProvider,
                    gearTypesProvider);
                case ItemsConstants.ItemTypes.Weapon: return new MundaneWeaponGenerator(percentileResultProvider, ammunitionGenerator, 
                    materialsProvider, gearTypesProvider);
                default: throw new ArgumentOutOfRangeException();
            }
        }
    }
}