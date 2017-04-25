using System;
using System.Collections.Generic;
using System.Linq;
using TreasureGen.Domain.Selectors.Collections;
using TreasureGen.Domain.Selectors.Percentiles;
using TreasureGen.Domain.Tables;
using TreasureGen.Items;
using TreasureGen.Items.Mundane;

namespace TreasureGen.Domain.Generators.Items.Mundane
{
    internal class ToolGenerator : MundaneItemGenerator
    {
        private readonly IPercentileSelector percentileSelector;
        private readonly ICollectionsSelector collectionsSelector;
        private readonly Generator generator;

        public ToolGenerator(IPercentileSelector percentileSelector, ICollectionsSelector collectionsSelector, Generator generator)
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

        public Item GenerateFrom(IEnumerable<string> subset)
        {
            if (!subset.Any())
                throw new ArgumentException("Cannot generate from an empty collection subset");

            var tool = generator.Generate(
                Generate,
                t => subset.Any(n => t.NameMatches(n)),
                () => GenerateDefaultFrom(subset),
                $"Tool from [{string.Join(", ", subset)}]");

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