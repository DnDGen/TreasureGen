using System;
using EquipmentGen.Core.Data.Items;
using EquipmentGen.Core.Data.Items.Constants;
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
        private ISpecialMaterialGenerator materialsProvider;
        private IAttributesProvider typesProvider;

        public MundaneGearGeneratorFactory(IPercentileResultProvider percentileResultProvider, IAmmunitionGenerator ammunitionGenerator,
            ISpecialMaterialGenerator materialsProvider, IAttributesProvider typesProvider)
        {
            this.percentileResultProvider = percentileResultProvider;
            this.ammunitionGenerator = ammunitionGenerator;
            this.materialsProvider = materialsProvider;
            this.typesProvider = typesProvider;
        }

        public IMundaneGearGenerator CreateWith(String type)
        {
            switch (type)
            {
                case ItemTypeConstants.Armor: return new MundaneArmorGenerator(percentileResultProvider, materialsProvider,
                    typesProvider);
                case ItemTypeConstants.Weapon: return new MundaneWeaponGenerator(percentileResultProvider, ammunitionGenerator,
                    materialsProvider, typesProvider);
                default: throw new ArgumentOutOfRangeException();
            }
        }
    }
}