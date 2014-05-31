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
        private ISpecificGearGenerator specificGearGenerator;
        private IAmmunitionGenerator ammunitionGenerator;
        private IBooleanPercentileSelector booleanPercentileSelector;

        public MagicalItemGeneratorFactory(IPercentileSelector percentileSelector, IMagicalItemTraitsGenerator magicalItemTraitsGenerator,
            IIntelligenceGenerator intelligenceGenerator, IAttributesSelector attributesSelector, ISpecialAbilitiesGenerator specialAbilitiesGenerator,
            ISpecialMaterialGenerator specialMaterialGenerator, IMagicalItemTraitsGenerator magicItemTraitsGenerator, IChargesGenerator chargesGenerator,
            IDice dice, ISpellGenerator spellGenerator, ICurseGenerator curseGenerator, ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector,
            ISpecificGearGenerator specificGearGenerator, IAmmunitionGenerator ammunitionGenerator, IBooleanPercentileSelector booleanPercentileSelector)
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
            this.specificGearGenerator = specificGearGenerator;
            this.ammunitionGenerator = ammunitionGenerator;
            this.booleanPercentileSelector = booleanPercentileSelector;
        }

        public IMagicalItemGenerator CreateGeneratorOf(String itemType)
        {
            var generator = GetGenerator(itemType);
            generator = new MagicalItemGeneratorIntelligenceDecorator(generator, intelligenceGenerator);
            generator = new MagicalItemGeneratorCurseDecorator(generator, curseGenerator);
            generator = new MagicalItemGeneratorMundaneProxy(generator);
            generator = new MagicalItemGeneratorSpecialMaterialDecorator(generator, specialMaterialGenerator);
            generator = new MagicalItemGeneratorTraitsDecorator(generator, magicalItemTraitsGenerator);

            return generator;
        }

        private IMagicalItemGenerator GetGenerator(String itemType)
        {
            switch (itemType)
            {
                case ItemTypeConstants.Potion: return new PotionGenerator(typeAndAmountPercentileSelector, percentileSelector);
                case ItemTypeConstants.Ring: return new RingGenerator(percentileSelector, attributesSelector, spellGenerator, chargesGenerator, typeAndAmountPercentileSelector);
                case ItemTypeConstants.Rod: return new RodGenerator(typeAndAmountPercentileSelector);
                case ItemTypeConstants.Scroll: return new ScrollGenerator(dice, spellGenerator);
                case ItemTypeConstants.Staff: return new StaffGenerator();
                case ItemTypeConstants.Wand: return new WandGenerator(percentileSelector, chargesGenerator);
                case ItemTypeConstants.WondrousItem: return new WondrousItemGenerator(percentileSelector, attributesSelector, chargesGenerator, dice, spellGenerator, typeAndAmountPercentileSelector);
                case ItemTypeConstants.Armor: return new MagicalArmorGenerator(typeAndAmountPercentileSelector, percentileSelector, attributesSelector, specialAbilitiesGenerator, specificGearGenerator);
                case ItemTypeConstants.Weapon: return new MagicalWeaponGenerator(attributesSelector, percentileSelector, ammunitionGenerator, specialAbilitiesGenerator, specificGearGenerator, booleanPercentileSelector, spellGenerator, dice);
                default: throw new ArgumentException(itemType);
            }
        }
    }
}