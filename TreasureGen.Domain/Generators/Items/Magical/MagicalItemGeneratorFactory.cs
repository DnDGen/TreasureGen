using RollGen;
using System;
using TreasureGen.Domain.Generators.Items.Mundane;
using TreasureGen.Domain.Items.Mundane;
using TreasureGen.Domain.Selectors.Attributes;
using TreasureGen.Domain.Selectors.Percentiles;
using TreasureGen.Items;
using TreasureGen.Items.Magical;

namespace TreasureGen.Domain.Generators.Items.Magical
{
    internal class MagicalItemGeneratorFactory : IMagicalItemGeneratorFactory
    {
        private IPercentileSelector percentileSelector;
        private IMagicalItemTraitsGenerator magicalItemTraitsGenerator;
        private IIntelligenceGenerator intelligenceGenerator;
        private IAttributesSelector attributesSelector;
        private IChargesGenerator chargesGenerator;
        private Dice dice;
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
            Dice dice, ISpellGenerator spellGenerator, ICurseGenerator curseGenerator, ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector,
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

        public MagicalItemGenerator CreateGeneratorOf(string itemType)
        {
            var generator = GetGenerator(itemType);
            generator = new MagicalItemGeneratorCurseDecorator(generator, curseGenerator);
            generator = new MagicalItemGeneratorIntelligenceDecorator(generator, intelligenceGenerator);
            generator = new MagicalItemGeneratorMundaneProxy(generator);
            generator = new MagicalItemGeneratorSpecialMaterialDecorator(generator, specialMaterialGenerator);
            generator = new MagicalItemGeneratorTraitsDecorator(generator, magicalItemTraitsGenerator);

            return generator;
        }

        private MagicalItemGenerator GetGenerator(string itemType)
        {
            switch (itemType)
            {
                case ItemTypeConstants.Potion: return new PotionGenerator(typeAndAmountPercentileSelector, percentileSelector);
                case ItemTypeConstants.Ring: return new RingGenerator(percentileSelector, attributesSelector, spellGenerator, chargesGenerator, typeAndAmountPercentileSelector);
                case ItemTypeConstants.Rod: return new RodGenerator(typeAndAmountPercentileSelector, attributesSelector, chargesGenerator, booleanPercentileSelector);
                case ItemTypeConstants.Scroll: return new ScrollGenerator(dice, spellGenerator);
                case ItemTypeConstants.Staff: return new StaffGenerator(percentileSelector, chargesGenerator, attributesSelector);
                case ItemTypeConstants.Wand: return new WandGenerator(percentileSelector, chargesGenerator);
                case ItemTypeConstants.WondrousItem: return new WondrousItemGenerator(percentileSelector, attributesSelector, chargesGenerator, dice, spellGenerator, typeAndAmountPercentileSelector);
                case ItemTypeConstants.Armor: return new MagicalArmorGenerator(typeAndAmountPercentileSelector, percentileSelector, attributesSelector, specialAbilitiesGenerator, specificGearGenerator);
                case ItemTypeConstants.Weapon: return new MagicalWeaponGenerator(attributesSelector, percentileSelector, ammunitionGenerator, specialAbilitiesGenerator, specificGearGenerator, booleanPercentileSelector, spellGenerator, dice);
                default: throw new ArgumentException(itemType);
            }
        }
    }
}