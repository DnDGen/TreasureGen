﻿using System;
using System.Collections.Generic;
using TreasureGen.Common.Items;
using TreasureGen.Generators.Domain.RuntimeFactories;
using TreasureGen.Generators.Items;
using TreasureGen.Selectors;
using TreasureGen.Tables;

namespace TreasureGen.Generators.Domain.Items
{
    public class ItemsGenerator : IItemsGenerator
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

        public IEnumerable<Item> GenerateAtLevel(Int32 level)
        {
            var tableName = String.Format(TableNameConstants.Percentiles.Formattable.LevelXItems, level);
            var result = typeAndAmountPercentileSelector.SelectFrom(tableName);
            var items = new List<Item>();

            if (String.IsNullOrEmpty(result.Type))
                return items;

            while (result.Amount-- > 0)
            {
                var item = GenerateAtPower(result.Type);
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
            var tableName = String.Format(TableNameConstants.Percentiles.Formattable.POWERItems, PowerConstants.Mundane);
            var itemType = percentileSelector.SelectFrom(tableName);
            var generator = mundaneItemGeneratorFactory.CreateGeneratorOf(itemType);

            return generator.Generate();
        }

        private Item GenerateMagicalItemAtPower(String power)
        {
            var tableName = String.Format(TableNameConstants.Percentiles.Formattable.POWERItems, power);
            var itemType = percentileSelector.SelectFrom(tableName);
            var magicalItemGenerator = magicalItemGeneratorFactory.CreateGeneratorOf(itemType);

            return magicalItemGenerator.GenerateAtPower(power);
        }
    }
}