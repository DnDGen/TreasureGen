using System;
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

        public MagicalItemGeneratorFactory(IPercentileResultProvider percentileResultProvider,
            IMagicalItemTraitsGenerator magicalItemTraitsGenerator, IIntelligenceGenerator intelligenceGenerator,
            IAttributesProvider attributesProvider, IChargesGenerator chargesGenerator)
        {
            this.percentileResultProvider = percentileResultProvider;
            this.magicalItemTraitsGenerator = magicalItemTraitsGenerator;
            this.intelligenceGenerator = intelligenceGenerator;
            this.attributesProvider = attributesProvider;
            this.chargesGenerator = chargesGenerator;
        }

        public IMagicalItemGenerator CreateWith(String type)
        {
            switch (type)
            {
                case ItemTypeConstants.Potion: return new PotionGenerator();
                case ItemTypeConstants.Ring: return new RingGenerator();
                case ItemTypeConstants.Rod: return new RodGenerator();
                case ItemTypeConstants.Scroll: return new ScrollGenerator();
                case ItemTypeConstants.Staff: return new StaffGenerator();
                case ItemTypeConstants.Wand: return new WandGenerator();
                case ItemTypeConstants.WondrousItem: return new WondrousItemGenerator(percentileResultProvider,
                    magicalItemTraitsGenerator, intelligenceGenerator, attributesProvider, chargesGenerator);
                default: throw new ArgumentOutOfRangeException(type);
            }
        }
    }
}