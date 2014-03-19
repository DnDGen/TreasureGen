using System;
using D20Dice;
using EquipmentGen.Common.Items;
using EquipmentGen.Selectors.Interfaces;
using EquipmentGen.Generators.Interfaces;
using EquipmentGen.Generators.Interfaces.Items.Magical;
using EquipmentGen.Generators.Interfaces.Items.Mundane;
using EquipmentGen.Generators.Items.Magical;
using EquipmentGen.Generators.RuntimeFactories.Interfaces;

namespace EquipmentGen.Generators.RuntimeFactories
{
    public class MagicalGearGeneratorFactory : IMagicalGearGeneratorFactory
    {
        private ITypeAndAmountPercentileResultProvider typeAndAmountPercentileProvider;
        private IPercentileResultProvider percentileResultProvider;
        private IAttributesProvider attributesProvider;
        private ISpecialAbilitiesGenerator specialAbilitiesProvider;
        private ISpecialMaterialGenerator materialsProvider;
        private IMagicalItemTraitsGenerator magicItemTraitsGenerator;
        private IIntelligenceGenerator intelligenceGenerator;
        private ISpecificGearGenerator specificGearGenerator;
        private IDice dice;

        public MagicalGearGeneratorFactory(ITypeAndAmountPercentileResultProvider typeAndAmountPercentileProvider,
            IPercentileResultProvider percentileResultProvider, IAttributesProvider attributesProvider,
            ISpecialAbilitiesGenerator specialAbilitiesProvider, ISpecialMaterialGenerator materialsProvider,
            IMagicalItemTraitsGenerator magicItemTraitsGenerator, IIntelligenceGenerator intelligenceGenerator,
            ISpecificGearGenerator specificGearGenerator, IDice dice)
        {
            this.typeAndAmountPercentileProvider = typeAndAmountPercentileProvider;
            this.percentileResultProvider = percentileResultProvider;
            this.attributesProvider = attributesProvider;
            this.specialAbilitiesProvider = specialAbilitiesProvider;
            this.materialsProvider = materialsProvider;
            this.magicItemTraitsGenerator = magicItemTraitsGenerator;
            this.intelligenceGenerator = intelligenceGenerator;
            this.specificGearGenerator = specificGearGenerator;
            this.dice = dice;
        }

        public IMagicalGearGenerator CreateWith(String type)
        {
            switch (type)
            {
                case ItemTypeConstants.Armor: return new MagicalArmorGenerator(typeAndAmountPercentileProvider,
                    percentileResultProvider, attributesProvider, specialAbilitiesProvider, materialsProvider,
                    magicItemTraitsGenerator, intelligenceGenerator, specificGearGenerator, dice);
                case ItemTypeConstants.Weapon: return new MagicalWeaponGenerator();
                default: throw new ArgumentOutOfRangeException();
            }
        }
    }
}