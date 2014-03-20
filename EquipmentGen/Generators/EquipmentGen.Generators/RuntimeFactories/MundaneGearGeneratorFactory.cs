using System;
using D20Dice;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Mundane;
using EquipmentGen.Generators.Items.Mundane;
using EquipmentGen.Generators.RuntimeFactories.Interfaces;
using EquipmentGen.Selectors.Interfaces;

namespace EquipmentGen.Generators.RuntimeFactories
{
    public class MundaneGearGeneratorFactory : IMundaneGearGeneratorFactory
    {
        private IPercentileSelector percentileSelector;
        private IAmmunitionGenerator ammunitionGenerator;
        private ISpecialMaterialGenerator materialsSelector;
        private IAttributesSelector attributesSelector;
        private IDice dice;

        public MundaneGearGeneratorFactory(IPercentileSelector percentileSelector, IAmmunitionGenerator ammunitionGenerator,
            ISpecialMaterialGenerator materialsSelector, IAttributesSelector attributesSelector, IDice dice)
        {
            this.percentileSelector = percentileSelector;
            this.ammunitionGenerator = ammunitionGenerator;
            this.materialsSelector = materialsSelector;
            this.attributesSelector = attributesSelector;
            this.dice = dice;
        }

        public IMundaneGearGenerator CreateWith(String type)
        {
            switch (type)
            {
                case ItemTypeConstants.Armor: return new MundaneArmorGenerator(percentileSelector, materialsSelector,
                    attributesSelector, dice);
                case ItemTypeConstants.Weapon: return new MundaneWeaponGenerator(percentileSelector, ammunitionGenerator,
                    materialsSelector, attributesSelector, dice);
                default: throw new ArgumentOutOfRangeException();
            }
        }
    }
}