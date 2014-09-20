using System;
using D20Dice;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Decorators;
using EquipmentGen.Generators.Interfaces.Items.Mundane;
using EquipmentGen.Generators.Items.Mundane;
using EquipmentGen.Generators.RuntimeFactories.Interfaces;
using EquipmentGen.Selectors.Interfaces;

namespace EquipmentGen.Generators.RuntimeFactories
{
    public class MundaneItemGeneratorFactory : IMundaneItemGeneratorFactory
    {
        private IPercentileSelector percentileSelector;
        private ISpecialMaterialGenerator materialGenerator;
        private IAttributesSelector attributesSelector;
        private IDice dice;
        private ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector;
        private IAmmunitionGenerator ammunitionGenerator;

        public MundaneItemGeneratorFactory(IPercentileSelector percentileSelector, ISpecialMaterialGenerator materialGenerator, IAttributesSelector attributesSelector,
            IDice dice, ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector, IAmmunitionGenerator ammunitionGenerator)
        {
            this.percentileSelector = percentileSelector;
            this.materialGenerator = materialGenerator;
            this.attributesSelector = attributesSelector;
            this.dice = dice;
            this.typeAndAmountPercentileSelector = typeAndAmountPercentileSelector;
            this.ammunitionGenerator = ammunitionGenerator;
        }

        public IMundaneItemGenerator CreateGeneratorOf(String itemType)
        {
            var generator = GetGenerator(itemType);
            generator = new MundaneItemGeneratorSpecialMaterialDecorator(generator, materialGenerator);

            return generator;
        }

        private IMundaneItemGenerator GetGenerator(String itemType)
        {
            switch (itemType)
            {
                case ItemTypeConstants.Armor: return new MundaneArmorGenerator(percentileSelector, attributesSelector);
                case ItemTypeConstants.Weapon: return new MundaneWeaponGenerator(percentileSelector, ammunitionGenerator, attributesSelector);
                case ItemTypeConstants.AlchemicalItem: return new AlchemicalItemGenerator(typeAndAmountPercentileSelector);
                case ItemTypeConstants.Tool: return new ToolGenerator(percentileSelector);
                default: throw new ArgumentException(itemType);
            }
        }
    }
}