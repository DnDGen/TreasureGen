using DnDGen.TreasureGen.Items;
using DnDGen.TreasureGen.Items.Magical;
using DnDGen.TreasureGen.Selectors.Percentiles;
using DnDGen.TreasureGen.Tables;

namespace DnDGen.TreasureGen.Generators.Items.Magical
{
    internal class WandGenerator : MagicalItemGenerator
    {
        private readonly ITreasurePercentileSelector percentileSelector;
        private readonly IChargesGenerator chargesGenerator;

        public WandGenerator(ITreasurePercentileSelector percentileSelector, IChargesGenerator chargesGenerator)
        {
            this.percentileSelector = percentileSelector;
            this.chargesGenerator = chargesGenerator;
        }

        public Item GenerateFrom(string power)
        {
            var tablename = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Wand);
            var spell = percentileSelector.SelectFrom(tablename);
            var name = $"Wand of {spell}";

            return GenerateWand(name);
        }

        private Item GenerateWand(string name)
        {
            var wand = new Item();
            wand.ItemType = ItemTypeConstants.Wand;
            wand.IsMagical = true;
            wand.Name = name;
            wand.Magic.Charges = chargesGenerator.GenerateFor(ItemTypeConstants.Wand, name);
            wand.BaseNames = new[] { ItemTypeConstants.Wand };
            wand.Attributes = new[] { AttributeConstants.Charged, AttributeConstants.OneTimeUse };

            return wand;
        }

        public Item GenerateFrom(string power, string itemName)
        {
            return GenerateWand(itemName);
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

        public bool IsItemOfPower(string itemName, string power)
        {
            return true;
        }
    }
}