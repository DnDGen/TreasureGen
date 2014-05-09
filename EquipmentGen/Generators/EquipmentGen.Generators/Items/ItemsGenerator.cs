using System;
using System.Collections.Generic;
using D20Dice;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items;
using EquipmentGen.Generators.RuntimeFactories.Interfaces;
using EquipmentGen.Selectors.Interfaces;

namespace EquipmentGen.Generators.Items
{
    public class ItemsGenerator : IItemsGenerator
    {
        private ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector;
        private IPercentileSelector percentileSelector;
        private IMundaneItemGeneratorFactory mundaneItemGeneratorFactory;
        private IMagicalItemGeneratorFactory magicalItemGeneratorFactory;
        private IDice dice;

        public ItemsGenerator(ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector, IMundaneItemGeneratorFactory mundaneItemGeneratorFactory,
            IPercentileSelector percentileSelector, IMagicalItemGeneratorFactory magicalItemGeneratorFactory, IDice dice)
        {
            this.typeAndAmountPercentileSelector = typeAndAmountPercentileSelector;
            this.mundaneItemGeneratorFactory = mundaneItemGeneratorFactory;
            this.percentileSelector = percentileSelector;
            this.magicalItemGeneratorFactory = magicalItemGeneratorFactory;
            this.dice = dice;
        }

        public IEnumerable<Item> GenerateAtLevel(Int32 level)
        {
            var roll = dice.Percentile();
            var tableName = String.Format("Level{0}Items", level);
            var typeAndAmountResult = typeAndAmountPercentileSelector.SelectFrom(tableName, roll);
            var items = new List<Item>();

            if (String.IsNullOrEmpty(typeAndAmountResult.Type))
                return items;

            var amount = dice.Roll(typeAndAmountResult.Amount);

            while (amount-- > 0)
            {
                var item = GenerateAtPower(typeAndAmountResult.Type);
                items.Add(item);
            }

            return items;
        }

        private Item GenerateAtPower(String power)
        {
            if (power == PowerConstants.Mundane)
                return GenerateMundaneItem();

            return GenerateMagicalItemAtPower(power);
        }

        private Item GenerateMundaneItem()
        {
            var tableName = String.Format("{0}Items", PowerConstants.Mundane);
            var roll = dice.Percentile();
            var itemType = percentileSelector.SelectFrom(tableName, roll);
            var generator = mundaneItemGeneratorFactory.CreateGeneratorOf(itemType);

            return generator.Generate();
        }

        private Item GenerateMagicalItemAtPower(String power)
        {
            var tableName = String.Format("{0}Items", power);
            var roll = dice.Percentile();
            var itemType = percentileSelector.SelectFrom(tableName, roll);
            var magicalItemGenerator = magicalItemGeneratorFactory.CreateGeneratorOf(itemType);

            return magicalItemGenerator.GenerateAtPower(power);
        }
    }
}