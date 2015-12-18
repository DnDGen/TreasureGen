using RollGen;
using System;
using TreasureGen.Common.Items;
using TreasureGen.Generators.Domain.Decorators;
using TreasureGen.Generators.Domain.Items.Mundane;
using TreasureGen.Generators.Items.Mundane;
using TreasureGen.Selectors;

namespace TreasureGen.Generators.Domain.RuntimeFactories.Domain
{
    public class MundaneItemGeneratorFactory : IMundaneItemGeneratorFactory
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

        public MundaneItemGenerator CreateGeneratorOf(String itemType)
        {
            var generator = GetGenerator(itemType);
            generator = new MundaneItemGeneratorSpecialMaterialDecorator(generator, materialGenerator);

            return generator;
        }

        private MundaneItemGenerator GetGenerator(String itemType)
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