using System;
using System.Collections.Generic;
using System.Linq;
using TreasureGen.Domain.Selectors.Attributes;
using TreasureGen.Domain.Selectors.Percentiles;
using TreasureGen.Domain.Tables;
using TreasureGen.Items;
using TreasureGen.Items.Mundane;

namespace TreasureGen.Domain.Generators.Items.Mundane
{
    internal class AlchemicalItemGenerator : MundaneItemGenerator
    {
        private readonly ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector;
        private readonly ICollectionsSelector collectionsSelector;
        private readonly Generator generator;

        public AlchemicalItemGenerator(ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector, ICollectionsSelector collectionsSelector, Generator generator)
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

        public Item Generate(Item template, bool allowRandomDecoration = false)
        {
            var item = template.MundaneClone();
            item.ItemType = ItemTypeConstants.AlchemicalItem;
            item.BaseNames = new[] { item.Name };

            return item;
        }

        public Item GenerateFromSubset(IEnumerable<string> subset)
        {
            if (!subset.Any())
                throw new ArgumentException("Cannot generate from an empty collection subset");

            var item = generator.Generate(
                Generate,
                i => subset.Any(n => i.NameMatches(n)),
                () => GenerateDefaultFrom(subset),
                $"Alchemical item from [{string.Join(", ", subset)}]");

            return item;
        }

        private Item GenerateDefaultFrom(IEnumerable<string> subset)
        {
            var template = new Item();
            template.Name = collectionsSelector.SelectRandomFrom(subset);

            var defaultItem = Generate(template);
            return defaultItem;
        }
    }
}