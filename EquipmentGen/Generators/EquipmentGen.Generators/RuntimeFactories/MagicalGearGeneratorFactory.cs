using System;
using D20Dice;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Magical;
using EquipmentGen.Generators.Interfaces.Items.Mundane;
using EquipmentGen.Generators.Items.Magical;
using EquipmentGen.Generators.RuntimeFactories.Interfaces;
using EquipmentGen.Selectors.Interfaces;

namespace EquipmentGen.Generators.RuntimeFactories
{
    public class MagicalGearGeneratorFactory : IMagicalGearGeneratorFactory
    {
        private ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector;
        private IPercentileSelector percentileSelector;
        private IAttributesSelector attributesSelector;
        private ISpecialAbilitiesGenerator specialAbilitiesSelector;
        private ISpecialMaterialGenerator materialsSelector;
        private IMagicalItemTraitsGenerator magicItemTraitsGenerator;
        private IIntelligenceGenerator intelligenceGenerator;
        private ISpecificGearGenerator specificGearGenerator;
        private IDice dice;

        public MagicalGearGeneratorFactory(ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector,
            IPercentileSelector percentileSelector, IAttributesSelector attributesSelector,
            ISpecialAbilitiesGenerator specialAbilitiesSelector, ISpecialMaterialGenerator materialsSelector,
            IMagicalItemTraitsGenerator magicItemTraitsGenerator, IIntelligenceGenerator intelligenceGenerator,
            ISpecificGearGenerator specificGearGenerator, IDice dice)
        {
            this.typeAndAmountPercentileSelector = typeAndAmountPercentileSelector;
            this.percentileSelector = percentileSelector;
            this.attributesSelector = attributesSelector;
            this.specialAbilitiesSelector = specialAbilitiesSelector;
            this.materialsSelector = materialsSelector;
            this.magicItemTraitsGenerator = magicItemTraitsGenerator;
            this.intelligenceGenerator = intelligenceGenerator;
            this.specificGearGenerator = specificGearGenerator;
            this.dice = dice;
        }

        public IMagicalGearGenerator CreateWith(String type)
        {
            switch (type)
            {
                case ItemTypeConstants.Armor: return new MagicalArmorGenerator(typeAndAmountPercentileSelector,
                    percentileSelector, attributesSelector, specialAbilitiesSelector, materialsSelector,
                    magicItemTraitsGenerator, intelligenceGenerator, specificGearGenerator, dice);
                case ItemTypeConstants.Weapon: return new MagicalWeaponGenerator();
                default: throw new ArgumentOutOfRangeException();
            }
        }
    }
}