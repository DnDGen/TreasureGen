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

        public MundaneItemGeneratorFactory(IPercentileSelector percentileSelector, ISpecialMaterialGenerator materialGenerator, IAttributesSelector attributesSelector,
            IDice dice, ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector)
        {
            this.percentileSelector = percentileSelector;
            this.materialGenerator = materialGenerator;
            this.attributesSelector = attributesSelector;
            this.dice = dice;
            this.typeAndAmountPercentileSelector = typeAndAmountPercentileSelector;
        }

        public IMundaneItemGenerator CreateGeneratorOf(String type)
        {
            var generator = GetGenerator(type);
            generator = new MundaneItemGeneratorSpecialMaterialDecorator(generator, materialGenerator);

            return generator;
        }

        private IMundaneItemGenerator GetGenerator(String type)
        {
            switch (type)
            {
                case ItemTypeConstants.Armor: return new MundaneArmorGenerator(percentileSelector, attributesSelector);
                case ItemTypeConstants.Weapon: return GetWeaponGenerator();
                case ItemTypeConstants.AlchemicalItem: return new AlchemicalItemGenerator(typeAndAmountPercentileSelector, dice);
                case ItemTypeConstants.Tool: return new ToolGenerator(percentileSelector);
                default: throw new ArgumentOutOfRangeException();
            }
        }

        private IMundaneItemGenerator GetWeaponGenerator()
        {
            var ammunitionGenerator = new AmmunitionGenerator(percentileSelector, dice, attributesSelector);
            return new MundaneWeaponGenerator(percentileSelector, ammunitionGenerator, attributesSelector);
        }
    }
}