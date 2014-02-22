using System;
using EquipmentGen.Core.Data.Items.Constants;
using EquipmentGen.Core.Generation.Factories.Interfaces;
using EquipmentGen.Core.Generation.Generators;
using EquipmentGen.Core.Generation.Generators.Interfaces;
using EquipmentGen.Core.Generation.Providers.Interfaces;

namespace EquipmentGen.Core.Generation.Factories
{
    public class MagicalGearGeneratorFactory : IMagicalGearGeneratorFactory
    {
        private ITypeAndAmountPercentileResultProvider typeAndAmountPercentileProvider;
        private IPercentileResultProvider percentileResultProvider;
        private IAttributesProvider typesProvider;
        private ISpecialAbilitiesGenerator gearSpecialAbilitiesProvider;
        private ISpecialMaterialGenerator materialsProvider;
        private IMagicalItemTraitsGenerator magicItemTraitsGenerator;
        private IIntelligenceGenerator intelligenceGenerator;
        private ISpecificGearGenerator specificGearGenerator;

        public MagicalGearGeneratorFactory(ITypeAndAmountPercentileResultProvider typeAndAmountPercentileProvider,
            IPercentileResultProvider percentileResultProvider, IAttributesProvider typesProvider,
            ISpecialAbilitiesGenerator gearSpecialAbilitiesProvider, ISpecialMaterialGenerator materialsProvider,
            IMagicalItemTraitsGenerator magicItemTraitsGenerator, IIntelligenceGenerator intelligenceGenerator,
            ISpecificGearGenerator specificGearGenerator)
        {
            this.typeAndAmountPercentileProvider = typeAndAmountPercentileProvider;
            this.percentileResultProvider = percentileResultProvider;
            this.typesProvider = typesProvider;
            this.gearSpecialAbilitiesProvider = gearSpecialAbilitiesProvider;
            this.materialsProvider = materialsProvider;
            this.magicItemTraitsGenerator = magicItemTraitsGenerator;
            this.intelligenceGenerator = intelligenceGenerator;
            this.specificGearGenerator = specificGearGenerator;
        }

        public IMagicalGearGenerator CreateWith(String type)
        {
            switch (type)
            {
                case ItemTypeConstants.Armor: return new MagicalArmorGenerator(typeAndAmountPercentileProvider,
                    percentileResultProvider, typesProvider, gearSpecialAbilitiesProvider, materialsProvider,
                    magicItemTraitsGenerator, intelligenceGenerator, specificGearGenerator);
                case ItemTypeConstants.Weapon: return new MagicalWeaponGenerator();
                default: throw new ArgumentOutOfRangeException();
            }
        }
    }
}