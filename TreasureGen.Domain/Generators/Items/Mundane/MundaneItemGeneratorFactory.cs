using RollGen;
using System;
using TreasureGen.Domain.Items.Mundane;
using TreasureGen.Domain.Selectors.Attributes;
using TreasureGen.Domain.Selectors.Percentiles;
using TreasureGen.Items;
using TreasureGen.Items.Mundane;

namespace TreasureGen.Domain.Generators.Items.Mundane
{
    internal class MundaneItemGeneratorFactory : IMundaneItemGeneratorFactory
    {
        private IPercentileSelector percentileSelector;
        private ISpecialMaterialGenerator materialGenerator;
        private IAttributesSelector attributesSelector;
        private Dice dice;
        private ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector;
        private IAmmunitionGenerator ammunitionGenerator;
        private IBooleanPercentileSelector booleanPercentileSelector;

        public MundaneItemGeneratorFactory(IPercentileSelector percentileSelector, ISpecialMaterialGenerator materialGenerator, IAttributesSelector attributesSelector,
            Dice dice, ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector, IAmmunitionGenerator ammunitionGenerator, IBooleanPercentileSelector booleanPercentileSelector)
        {
            this.percentileSelector = percentileSelector;
            this.materialGenerator = materialGenerator;
            this.attributesSelector = attributesSelector;
            this.dice = dice;
            this.typeAndAmountPercentileSelector = typeAndAmountPercentileSelector;
            this.ammunitionGenerator = ammunitionGenerator;
            this.booleanPercentileSelector = booleanPercentileSelector;
        }

        public MundaneItemGenerator CreateGeneratorOf(string itemType)
        {
            var generator = GetGenerator(itemType);
            generator = new MundaneItemGeneratorSpecialMaterialDecorator(generator, materialGenerator);

            return generator;
        }

        private MundaneItemGenerator GetGenerator(string itemType)
        {
            switch (itemType)
            {
                case ItemTypeConstants.Armor: return new MundaneArmorGenerator(percentileSelector, attributesSelector, booleanPercentileSelector);
                case ItemTypeConstants.Weapon: return new MundaneWeaponGenerator(percentileSelector, ammunitionGenerator, attributesSelector, booleanPercentileSelector, dice);
                case ItemTypeConstants.AlchemicalItem: return new AlchemicalItemGenerator(typeAndAmountPercentileSelector);
                case ItemTypeConstants.Tool: return new ToolGenerator(percentileSelector);
                default: throw new ArgumentException(itemType);
            }
        }
    }
}