using System;
using D20Dice;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Mundane;
using EquipmentGen.Generators.RuntimeFactories.Interfaces;
using EquipmentGen.Selectors.Interfaces;

namespace EquipmentGen.Generators.Items.Mundane
{
    public class MundaneItemGenerator : IMundaneItemGenerator
    {
        private IPercentileSelector percentileSelector;
        private IAlchemicalItemGenerator alchemicalItemGenerator;
        private IMundaneGearGeneratorFactory mundaneGearGeneratorFactory;
        private IToolGenerator toolGenerator;
        private IDice dice;

        public MundaneItemGenerator(IPercentileSelector percentileSelector, IAlchemicalItemGenerator alchemicalItemGenerator,
            IMundaneGearGeneratorFactory mundaneGearGeneratorFactory, IToolGenerator toolGenerator, IDice dice)
        {
            this.percentileSelector = percentileSelector;
            this.alchemicalItemGenerator = alchemicalItemGenerator;
            this.mundaneGearGeneratorFactory = mundaneGearGeneratorFactory;
            this.toolGenerator = toolGenerator;
            this.dice = dice;
        }

        public Item Generate()
        {
            var roll = dice.Percentile();
            var type = percentileSelector.SelectFrom("MundaneItems", roll);
            return GetItem(type);
        }

        private Item GetItem(String type)
        {
            switch (type)
            {
                case ItemTypeConstants.AlchemicalItem: return alchemicalItemGenerator.Generate();
                case ItemTypeConstants.Armor:
                case ItemTypeConstants.Weapon: return GenerateGear(type);
                case ItemTypeConstants.Tool: return toolGenerator.Generate();
                default: throw new ArgumentOutOfRangeException();
            }
        }

        private Item GenerateGear(String type)
        {
            var generator = mundaneGearGeneratorFactory.CreateWith(type);
            return generator.Generate();
        }
    }
}