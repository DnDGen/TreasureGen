using System;
using D20Dice;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Decorators;
using EquipmentGen.Generators.Interfaces.Items.Magical;
using EquipmentGen.Generators.Interfaces.Items.Mundane;
using EquipmentGen.Generators.Items.Magical;
using EquipmentGen.Generators.RuntimeFactories.Interfaces;
using EquipmentGen.Selectors.Interfaces;

namespace EquipmentGen.Generators.RuntimeFactories
{
    public class MagicalItemGeneratorFactory : IMagicalItemGeneratorFactory
    {
        private IPercentileSelector percentileSelector;
        private IMagicalItemTraitsGenerator magicalItemTraitsGenerator;
        private IIntelligenceGenerator intelligenceGenerator;
        private IAttributesSelector attributesSelector;
        private IChargesGenerator chargesGenerator;
        private IDice dice;
        private ISpellGenerator spellGenerator;
        private ICurseGenerator curseGenerator;
        private ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector;
        private ISpecialAbilitiesGenerator specialAbilitiesGenerator;
        private ISpecialMaterialGenerator specialMaterialGenerator;
        private IMagicalItemTraitsGenerator magicItemTraitsGenerator;
        private ISpecificGearGenerator specificGearGenerator;

        public MagicalItemGeneratorFactory(IPercentileSelector percentileSelector, IMagicalItemTraitsGenerator magicalItemTraitsGenerator,
            IIntelligenceGenerator intelligenceGenerator, IAttributesSelector attributesSelector, ISpecialAbilitiesGenerator specialAbilitiesGenerator,
            ISpecialMaterialGenerator specialMaterialGenerator, IMagicalItemTraitsGenerator magicItemTraitsGenerator, IChargesGenerator chargesGenerator,
            IDice dice, ISpellGenerator spellGenerator, ICurseGenerator curseGenerator, ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector,
            ISpecificGearGenerator specificGearGenerator)
        {
            this.percentileSelector = percentileSelector;
            this.magicalItemTraitsGenerator = magicalItemTraitsGenerator;
            this.intelligenceGenerator = intelligenceGenerator;
            this.attributesSelector = attributesSelector;
            this.chargesGenerator = chargesGenerator;
            this.dice = dice;
            this.spellGenerator = spellGenerator;
            this.curseGenerator = curseGenerator;
            this.typeAndAmountPercentileSelector = typeAndAmountPercentileSelector;
            this.specialAbilitiesGenerator = specialAbilitiesGenerator;
            this.specialMaterialGenerator = specialMaterialGenerator;
            this.magicItemTraitsGenerator = magicItemTraitsGenerator;
            this.specificGearGenerator = specificGearGenerator;
        }

        public IMagicalItemGenerator CreateGeneratorOf(String itemType)
        {
            var generator = GetGenerator(itemType);
            generator = new MagicalItemGeneratorIntelligenceDecorator(generator, intelligenceGenerator);

            return generator;
        }

        private IMagicalItemGenerator GetGenerator(String itemType)
        {
            switch (itemType)
            {
                case ItemTypeConstants.Potion: return new PotionGenerator(dice, typeAndAmountPercentileSelector,
                    percentileSelector, curseGenerator);
                case ItemTypeConstants.Ring: return new RingGenerator(percentileSelector, attributesSelector,
                    magicalItemTraitsGenerator, spellGenerator, intelligenceGenerator, chargesGenerator, dice,
                    curseGenerator, typeAndAmountPercentileSelector);
                case ItemTypeConstants.Rod: return new RodGenerator();
                case ItemTypeConstants.Scroll: return new ScrollGenerator(dice, spellGenerator, curseGenerator);
                case ItemTypeConstants.Staff: return new StaffGenerator();
                case ItemTypeConstants.Wand: return new WandGenerator();
                case ItemTypeConstants.WondrousItem: return new WondrousItemGenerator(percentileSelector,
                    magicalItemTraitsGenerator, intelligenceGenerator, attributesSelector, chargesGenerator, dice,
                    curseGenerator, spellGenerator);
                case ItemTypeConstants.Armor: return new MagicalArmorGenerator(typeAndAmountPercentileSelector,
                    percentileSelector, attributesSelector, specialAbilitiesGenerator, specialMaterialGenerator,
                    magicItemTraitsGenerator, intelligenceGenerator, specificGearGenerator, dice, curseGenerator);
                case ItemTypeConstants.Weapon: return new MagicalWeaponGenerator();
                default: throw new ArgumentOutOfRangeException(itemType);
            }
        }
    }
}