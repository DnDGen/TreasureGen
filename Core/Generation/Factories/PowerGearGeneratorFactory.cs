﻿using System;
using EquipmentGen.Core.Data.Items;
using EquipmentGen.Core.Generation.Factories.Interfaces;
using EquipmentGen.Core.Generation.Generators;
using EquipmentGen.Core.Generation.Generators.Interfaces;
using EquipmentGen.Core.Generation.Providers.Interfaces;

namespace EquipmentGen.Core.Generation.Factories
{
    public class PowerGearGeneratorFactory : IPowerGearGeneratorFactory
    {
        private ITypeAndAmountPercentileResultProvider typeAndAmountPercentileProvider;
        private IPercentileResultProvider percentileResultProvider;
        private IGearTypesProvider gearTypesProvider;
        private IGearSpecialAbilitiesGenerator gearSpecialAbilitiesProvider;
        private IMaterialsProvider materialsProvider;

        public PowerGearGeneratorFactory(ITypeAndAmountPercentileResultProvider typeAndAmountPercentileProvider,
            IPercentileResultProvider percentileResultProvider, IGearTypesProvider gearTypesProvider,
            IGearSpecialAbilitiesGenerator gearSpecialAbilitiesProvider, IMaterialsProvider materialsProvider)
        {
            this.typeAndAmountPercentileProvider = typeAndAmountPercentileProvider;
            this.percentileResultProvider = percentileResultProvider;
            this.gearTypesProvider = gearTypesProvider;
            this.gearSpecialAbilitiesProvider = gearSpecialAbilitiesProvider;
            this.materialsProvider = materialsProvider;
        }

        public IPowerGearGenerator CreateWith(String type)
        {
            switch (type)
            {
                case ItemsConstants.ItemTypes.Armor: return new PowerArmorGenerator(typeAndAmountPercentileProvider,
                    percentileResultProvider, gearTypesProvider, gearSpecialAbilitiesProvider, materialsProvider);
                case ItemsConstants.ItemTypes.Weapon: return new PowerWeaponGenerator();
                default: throw new ArgumentOutOfRangeException();
            }
        }
    }
}