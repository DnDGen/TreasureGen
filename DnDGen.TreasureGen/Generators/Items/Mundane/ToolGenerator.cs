using DnDGen.Infrastructure.Generators;
using DnDGen.Infrastructure.Selectors.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using DnDGen.TreasureGen.Selectors.Percentiles;
using DnDGen.TreasureGen.Tables;
using DnDGen.TreasureGen.Items;
using DnDGen.TreasureGen.Items.Mundane;

namespace DnDGen.TreasureGen.Generators.Items.Mundane
{
    internal class ToolGenerator : MundaneItemGenerator
    {
        private readonly ITreasurePercentileSelector percentileSelector;
        private readonly ICollectionSelector collectionsSelector;
        private readonly Generator generator;

        public ToolGenerator(ITreasurePercentileSelector percentileSelector, ICollectionSelector collectionsSelector, Generator generator)
        {
            this.percentileSelector = percentileSelector;
            this.collectionsSelector = collectionsSelector;
            this.generator = generator;
        }

        public Item Generate()
        {
            var tool = new Item();
            tool.Name = percentileSelector.SelectFrom(TableNameConstants.Percentiles.Set.Tools);
            tool.ItemType = ItemTypeConstants.Tool;
            tool.BaseNames = new[] { tool.Name };

            return tool;
        }

        public Item GenerateFrom(Item template, bool allowRandomDecoration = false)
        {
            var tool = template.MundaneClone();
            tool.ItemType = ItemTypeConstants.Tool;
            tool.Quantity = 1;
            tool.BaseNames = new[] { tool.Name };
            tool.Attributes = Enumerable.Empty<string>();

            return tool;
        }

        public Item GenerateFrom(IEnumerable<string> subset, params string[] traits)
        {
            if (!subset.Any())
                throw new ArgumentException("Cannot generate from an empty collection subset");

            var tool = generator.Generate(
                Generate,
                t => subset.Any(n => t.NameMatches(n)),
                () => GenerateDefaultFrom(subset),
                t => $"{t.Name} is not in subset [{string.Join(", ", subset)}]",
                $"Tool from [{string.Join(", ", subset)}]");

            tool.Traits = new HashSet<string>(traits);

            return tool;
        }

        private Item GenerateDefaultFrom(IEnumerable<string> subset)
        {
            var template = new Item();
            template.Name = collectionsSelector.SelectRandomFrom(subset);

            var defaultTool = GenerateFrom(template);
            return defaultTool;
        }
    }
}