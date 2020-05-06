using DnDGen.Infrastructure.Generators;
using DnDGen.TreasureGen.Items;
using DnDGen.TreasureGen.Items.Magical;
using DnDGen.TreasureGen.Items.Mundane;
using DnDGen.TreasureGen.Selectors.Collections;
using DnDGen.TreasureGen.Selectors.Percentiles;
using DnDGen.TreasureGen.Tables;
using System.Collections.Generic;

namespace DnDGen.TreasureGen.Generators.Items
{
    internal class ItemsGenerator : IItemsGenerator
    {
        private readonly ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector;
        private readonly ITreasurePercentileSelector percentileSelector;
        private readonly JustInTimeFactory justInTimeFactory;
        private readonly IRangeDataSelector rangeDataSelector;

        public ItemsGenerator(
            ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector,
            JustInTimeFactory justInTimeFactory,
            ITreasurePercentileSelector percentileSelector,
            IRangeDataSelector rangeDataSelector)
        {
            this.typeAndAmountPercentileSelector = typeAndAmountPercentileSelector;
            this.justInTimeFactory = justInTimeFactory;
            this.percentileSelector = percentileSelector;
            this.rangeDataSelector = rangeDataSelector;
        }

        public IEnumerable<Item> GenerateRandomAtLevel(int level)
        {
            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.LevelXItems, level);
            var result = typeAndAmountPercentileSelector.SelectFrom(tableName);
            var items = new List<Item>();

            while (result.Amount-- > 0)
            {
                var item = GenerateRandomAtPower(result.Type);
                items.Add(item);
            }

            var epicItems = GetEpicItems(level);
            items.AddRange(epicItems);

            return items;
        }

        private IEnumerable<Item> GetEpicItems(int level)
        {
            var epicItems = new List<Item>();
            var majorItemQuantity = rangeDataSelector.SelectFrom(TableNameConstants.Collections.Set.EpicItems, level.ToString()).Minimum;

            while (majorItemQuantity-- > 0)
            {
                var epicItem = GenerateRandomAtPower(PowerConstants.Major);
                epicItems.Add(epicItem);
            }

            return epicItems;
        }

        private Item GenerateRandomAtPower(string power)
        {
            if (power == PowerConstants.Mundane)
                return GenerateRandomMundaneItem();

            return GenerateRandomMagicalItemAtPower(power);
        }

        private Item GenerateRandomMundaneItem()
        {
            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERItems, PowerConstants.Mundane);
            var itemType = percentileSelector.SelectFrom(tableName);

            return GenerateMundaneItem(itemType);
        }

        private Item GenerateRandomMagicalItemAtPower(string power)
        {
            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERItems, power);
            var itemType = percentileSelector.SelectFrom(tableName);

            return GenerateMagicalItemAtPower(power, itemType);
        }

        public Item GenerateAtLevel(int level, string itemType, string itemName, params string[] traits)
        {
            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.LevelXItems, level);
            var result = typeAndAmountPercentileSelector.SelectFrom(tableName);
            var power = result.Type;

            if (power == PowerConstants.Mundane)
                return GenerateMundaneItem(itemType, itemName, traits);

            return GenerateMagicalItemAtPower(power, itemType, itemName, traits);
        }

        private Item GenerateMundaneItem(string itemType, string itemName = null, params string[] traits)
        {
            var generator = justInTimeFactory.Build<MundaneItemGenerator>(itemType);

            if (string.IsNullOrEmpty(itemName))
                return generator.GenerateRandom();

            return generator.Generate(itemName, traits);
        }

        private Item GenerateMagicalItemAtPower(string power, string itemType, string itemName = null, params string[] traits)
        {
            var magicalItemGenerator = justInTimeFactory.Build<MagicalItemGenerator>(itemType);

            if (string.IsNullOrEmpty(itemName))
                return magicalItemGenerator.GenerateRandom(power);

            return magicalItemGenerator.Generate(power, itemName, traits);
        }
    }
}