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
        private IPercentileSelector percentileResultProvider;
        private IMagicalItemTraitsGenerator magicalItemTraitsGenerator;
        private IIntelligenceGenerator intelligenceGenerator;
        private IAttributesSelector attributesProvider;
        private IChargesGenerator chargesGenerator;
        private IDice dice;
        private ISpellGenerator spellGenerator;

        public MagicalItemGeneratorFactory(IPercentileSelector percentileResultProvider,
            IMagicalItemTraitsGenerator magicalItemTraitsGenerator, IIntelligenceGenerator intelligenceGenerator,
            IAttributesSelector attributesProvider, IChargesGenerator chargesGenerator, IDice dice, ISpellGenerator spellGenerator)
        {
            this.percentileResultProvider = percentileResultProvider;
            this.magicalItemTraitsGenerator = magicalItemTraitsGenerator;
            this.intelligenceGenerator = intelligenceGenerator;
            this.attributesProvider = attributesProvider;
            this.chargesGenerator = chargesGenerator;
            this.dice = dice;
            this.spellGenerator = spellGenerator;
        }

        public IMagicalItemGenerator CreateWith(String type)
        {
            switch (type)
            {
                case ItemTypeConstants.Potion: return new PotionGenerator();
                case ItemTypeConstants.Ring: return new RingGenerator(percentileResultProvider, attributesProvider,
                    magicalItemTraitsGenerator, spellGenerator, intelligenceGenerator, chargesGenerator, dice);
                case ItemTypeConstants.Rod: return new RodGenerator();
                case ItemTypeConstants.Scroll: return new ScrollGenerator();
                case ItemTypeConstants.Staff: return new StaffGenerator();
                case ItemTypeConstants.Wand: return new WandGenerator();
                case ItemTypeConstants.WondrousItem: return new WondrousItemGenerator(percentileResultProvider,
                    magicalItemTraitsGenerator, intelligenceGenerator, attributesProvider, chargesGenerator, dice);
                default: throw new ArgumentOutOfRangeException(type);
            }
        }
    }
}