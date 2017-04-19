using System.Collections.Generic;
using System.Linq;
using TreasureGen.Domain.Selectors.Attributes;
using TreasureGen.Domain.Selectors.Percentiles;
using TreasureGen.Domain.Tables;
using TreasureGen.Items;
using TreasureGen.Items.Magical;

namespace TreasureGen.Domain.Generators.Items.Magical
{
    internal class WandGenerator : MagicalItemGenerator
    {
        private readonly IPercentileSelector percentileSelector;
        private readonly IChargesGenerator chargesGenerator;
        private readonly Generator generator;
        private readonly ICollectionsSelector collectionsSelector;

        public WandGenerator(IPercentileSelector percentileSelector, IChargesGenerator chargesGenerator, Generator generator, ICollectionsSelector collectionsSelector)
        {
            this.percentileSelector = percentileSelector;
            this.chargesGenerator = chargesGenerator;
            this.generator = generator;
            this.collectionsSelector = collectionsSelector;
        }

        public Item GenerateAtPower(string power)
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

        public Item Generate(Item template, bool allowRandomDecoration = false)
        {
            var wand = template.Clone();
            wand.IsMagical = true;
            wand.Quantity = 1;
            wand.BaseNames = new[] { ItemTypeConstants.Wand };
            wand.Attributes = new[] { AttributeConstants.Charged, AttributeConstants.OneTimeUse };
            wand.ItemType = ItemTypeConstants.Wand;

            return wand.SmartClone();
        }

        public Item GenerateFromSubset(string power, IEnumerable<string> subset)
        {
            var wand = generator.Generate(
                () => GenerateAtPower(power),
                w => subset.Any(n => w.NameMatches(n)),
                () => GenerateDefaultFrom(subset),
                $"Wand from [{string.Join(", ", subset)}]");

            return wand;
        }

        private Item GenerateDefaultFrom(IEnumerable<string> subset)
        {
            var template = new Item();
            template.Name = collectionsSelector.SelectRandomFrom(subset);
            template.Magic.Charges = chargesGenerator.GenerateFor(ItemTypeConstants.Wand, template.Name);

            var defaultWand = Generate(template);
            return defaultWand;
        }
    }
}