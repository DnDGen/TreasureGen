using DnDGen.Core.Generators;
using DnDGen.Core.Selectors.Collections;
using System.Collections.Generic;
using System.Linq;
using TreasureGen.Selectors.Percentiles;
using TreasureGen.Tables;
using TreasureGen.Items;
using TreasureGen.Items.Magical;

namespace TreasureGen.Generators.Items.Magical
{
    internal class WandGenerator : MagicalItemGenerator
    {
        private readonly ITreasurePercentileSelector percentileSelector;
        private readonly IChargesGenerator chargesGenerator;
        private readonly Generator generator;
        private readonly ICollectionSelector collectionsSelector;

        public WandGenerator(ITreasurePercentileSelector percentileSelector, IChargesGenerator chargesGenerator, Generator generator, ICollectionSelector collectionsSelector)
        {
            this.percentileSelector = percentileSelector;
            this.chargesGenerator = chargesGenerator;
            this.generator = generator;
            this.collectionsSelector = collectionsSelector;
        }

        public Item GenerateFrom(string power)
        {
            var wand = new Item();
            wand.ItemType = ItemTypeConstants.Wand;
            wand.IsMagical = true;

            var tablename = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Wand);
            var spell = percentileSelector.SelectFrom(tablename);
            wand.Name = $"Wand of {spell}";
            wand.Magic.Charges = chargesGenerator.GenerateFor(wand.ItemType, wand.Name);
            wand.BaseNames = new[] { ItemTypeConstants.Wand };
            wand.Attributes = new[] { AttributeConstants.Charged, AttributeConstants.OneTimeUse };

            return wand;
        }

        public Item GenerateFrom(Item template, bool allowRandomDecoration = false)
        {
            var wand = template.Clone();
            wand.IsMagical = true;
            wand.Quantity = 1;
            wand.BaseNames = new[] { ItemTypeConstants.Wand };
            wand.Attributes = new[] { AttributeConstants.Charged, AttributeConstants.OneTimeUse };
            wand.ItemType = ItemTypeConstants.Wand;

            return wand.SmartClone();
        }

        public Item GenerateFrom(string power, IEnumerable<string> subset, params string[] traits)
        {
            var wand = generator.Generate(
                () => GenerateFrom(power),
                w => subset.Any(n => w.NameMatches(n)),
                () => GenerateDefaultFrom(subset),
                w => $"{w.Name} is not in subset [{string.Join(", ", subset)}]",
                $"Wand from [{string.Join(", ", subset)}]");

            foreach (var trait in traits)
                wand.Traits.Add(trait);

            return wand;
        }

        private Item GenerateDefaultFrom(IEnumerable<string> subset)
        {
            var template = new Item();
            template.Name = collectionsSelector.SelectRandomFrom(subset);
            template.Magic.Charges = chargesGenerator.GenerateFor(ItemTypeConstants.Wand, template.Name);

            var defaultWand = GenerateFrom(template);
            return defaultWand;
        }
    }
}