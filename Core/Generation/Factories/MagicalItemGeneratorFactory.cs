﻿using System;
using D20Dice;
using EquipmentGen.Core.Data.Items.Constants;
using EquipmentGen.Core.Generation.Factories.Interfaces;
using EquipmentGen.Core.Generation.Generators;
using EquipmentGen.Core.Generation.Generators.Interfaces;
using EquipmentGen.Core.Generation.Providers.Interfaces;

namespace EquipmentGen.Core.Generation.Factories
{
    public class MagicalItemGeneratorFactory : IMagicalItemGeneratorFactory
    {
        private IPercentileResultProvider percentileResultProvider;
        private IMagicalItemTraitsGenerator magicalItemTraitsGenerator;
        private IIntelligenceGenerator intelligenceGenerator;
        private IAttributesProvider attributesProvider;
        private IChargesGenerator chargesGenerator;
        private IDice dice;
        private ISpellGenerator spellGenerator;

        public MagicalItemGeneratorFactory(IPercentileResultProvider percentileResultProvider,
            IMagicalItemTraitsGenerator magicalItemTraitsGenerator, IIntelligenceGenerator intelligenceGenerator,
            IAttributesProvider attributesProvider, IChargesGenerator chargesGenerator, IDice dice, ISpellGenerator spellGenerator)
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
                    magicalItemTraitsGenerator, spellGenerator, intelligenceGenerator, chargesGenerator);
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