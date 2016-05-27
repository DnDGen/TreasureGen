﻿using System.Collections.Generic;
using TreasureGen.Domain.Generators.Items.Magical;
using TreasureGen.Domain.Generators.Items.Mundane;
using TreasureGen.Domain.Selectors.Percentiles;
using TreasureGen.Domain.Tables;
using TreasureGen.Items;

namespace TreasureGen.Domain.Generators.Items
{
    internal class ItemsGenerator : IItemsGenerator
    {
        private ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector;
        private IPercentileSelector percentileSelector;
        private IMundaneItemGeneratorFactory mundaneItemGeneratorFactory;
        private IMagicalItemGeneratorFactory magicalItemGeneratorFactory;

        public ItemsGenerator(ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector, IMundaneItemGeneratorFactory mundaneItemGeneratorFactory, IPercentileSelector percentileSelector, IMagicalItemGeneratorFactory magicalItemGeneratorFactory)
        {
            this.typeAndAmountPercentileSelector = typeAndAmountPercentileSelector;
            this.mundaneItemGeneratorFactory = mundaneItemGeneratorFactory;
            this.percentileSelector = percentileSelector;
            this.magicalItemGeneratorFactory = magicalItemGeneratorFactory;
        }

        public IEnumerable<Item> GenerateAtLevel(int level)
        {
            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.LevelXItems, level);
            var result = typeAndAmountPercentileSelector.SelectFrom(tableName);
            var items = new List<Item>();

            if (string.IsNullOrEmpty(result.Type))
                return items;

            while (result.Amount-- > 0)
            {
                var item = GenerateAtPower(result.Type);
                items.Add(item);
            }

            return items;
        }

        private Item GenerateAtPower(string power)
        {
            if (power == PowerConstants.Mundane)
                return GenerateMundaneItem();

            return GenerateMagicalItemAtPower(power);
        }

        private Item GenerateMundaneItem()
        {
            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERItems, PowerConstants.Mundane);
            var itemType = percentileSelector.SelectFrom(tableName);
            var generator = mundaneItemGeneratorFactory.CreateGeneratorOf(itemType);

            return generator.Generate();
        }

        private Item GenerateMagicalItemAtPower(string power)
        {
            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERItems, power);
            var itemType = percentileSelector.SelectFrom(tableName);
            var magicalItemGenerator = magicalItemGeneratorFactory.CreateGeneratorOf(itemType);

            return magicalItemGenerator.GenerateAtPower(power);
        }
    }
}