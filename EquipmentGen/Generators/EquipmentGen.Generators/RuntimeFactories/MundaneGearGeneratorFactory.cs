using System;
using D20Dice;
using EquipmentGen.Common.Items;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.RuntimeFactories.Interfaces;
using EquipmentGen.Generators;
using EquipmentGen.Generators.Interfaces;
using EquipmentGen.Selectors.Interfaces;
using EquipmentGen.Generators.Items.Mundane;
using EquipmentGen.Generators.Interfaces.Items.Mundane;

namespace EquipmentGen.Generators.RuntimeFactories
{
    public class MundaneGearGeneratorFactory : IMundaneGearGeneratorFactory
    {
        private IPercentileResultProvider percentileResultProvider;
        private IAmmunitionGenerator ammunitionGenerator;
        private ISpecialMaterialGenerator materialsProvider;
        private IAttributesProvider attributesProvider;
        private IDice dice;

        public MundaneGearGeneratorFactory(IPercentileResultProvider percentileResultProvider, IAmmunitionGenerator ammunitionGenerator,
            ISpecialMaterialGenerator materialsProvider, IAttributesProvider attributesProvider, IDice dice)
        {
            this.percentileResultProvider = percentileResultProvider;
            this.ammunitionGenerator = ammunitionGenerator;
            this.materialsProvider = materialsProvider;
            this.attributesProvider = attributesProvider;
            this.dice = dice;
        }

        public IMundaneGearGenerator CreateWith(String type)
        {
            switch (type)
            {
                case ItemTypeConstants.Armor: return new MundaneArmorGenerator(percentileResultProvider, materialsProvider,
                    attributesProvider, dice);
                case ItemTypeConstants.Weapon: return new MundaneWeaponGenerator(percentileResultProvider, ammunitionGenerator,
                    materialsProvider, attributesProvider, dice);
                default: throw new ArgumentOutOfRangeException();
            }
        }
    }
}