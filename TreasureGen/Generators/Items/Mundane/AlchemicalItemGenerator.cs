using DnDGen.Core.Generators;
using DnDGen.Core.Selectors.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using TreasureGen.Selectors.Percentiles;
using TreasureGen.Tables;
using TreasureGen.Items;
using TreasureGen.Items.Mundane;

namespace TreasureGen.Generators.Items.Mundane
{
    internal class AlchemicalItemGenerator : MundaneItemGenerator
    {
        private readonly ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector;
        private readonly ICollectionSelector collectionsSelector;
        private readonly Generator generator;

        public AlchemicalItemGenerator(ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector, ICollectionSelector collectionsSelector, Generator generator)
        {
            this.typeAndAmountPercentileSelector = typeAndAmountPercentileSelector;
            this.collectionsSelector = collectionsSelector;
            this.generator = generator;
        }

        public Item Generate()
        {
            var result = typeAndAmountPercentileSelector.SelectFrom(TableNameConstants.Percentiles.Set.AlchemicalItems);

            var item = new Item();
            item.Name = result.Type;
            item.Quantity = result.Amount;
            item.ItemType = ItemTypeConstants.AlchemicalItem;
            item.BaseNames = new[] { item.Name };

            return item;
        }

        public Item GenerateFrom(Item template, bool allowRandomDecoration = false)
        {
            var item = template.MundaneClone();
            item.ItemType = ItemTypeConstants.AlchemicalItem;
            item.BaseNames = new[] { item.Name };
            item.Attributes = Enumerable.Empty<string>();

            return item;
        }

        public Item GenerateFrom(IEnumerable<string> subset, params string[] traits)
        {
            if (!subset.Any())
                throw new ArgumentException("Cannot generate from an empty collection subset");

            var item = generator.Generate(
                Generate,
                i => subset.Any(n => i.NameMatches(n)),
                () => GenerateDefaultFrom(subset),
                i => $"{i.Name} is not in subset [{string.Join(", ", subset)}]",
                $"Alchemical item from [{string.Join(", ", subset)}]");

            item.Traits = new HashSet<string>(traits);

            return item;
        }

        private Item GenerateDefaultFrom(IEnumerable<string> subset)
        {
            var template = new Item();
            template.Name = collectionsSelector.SelectRandomFrom(subset);

            var defaultItem = GenerateFrom(template);
            return defaultItem;
        }
    }
}