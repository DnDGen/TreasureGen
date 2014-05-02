using System;
using D20Dice;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Magical;
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

        public MagicalItemGeneratorFactory(IPercentileSelector percentileSelector,
            IMagicalItemTraitsGenerator magicalItemTraitsGenerator, IIntelligenceGenerator intelligenceGenerator,
            IAttributesSelector attributesSelector, IChargesGenerator chargesGenerator, IDice dice, ISpellGenerator spellGenerator,
            ICurseGenerator curseGenerator, ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector)
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
        }

        public IMagicalItemGenerator CreateGeneratorOf(String type)
        {
            switch (type)
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
                default: throw new ArgumentOutOfRangeException(type);
            }
        }
    }
}