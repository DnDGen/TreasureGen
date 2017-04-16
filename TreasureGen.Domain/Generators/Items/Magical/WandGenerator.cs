using TreasureGen.Domain.Selectors.Percentiles;
using TreasureGen.Domain.Tables;
using TreasureGen.Items;
using TreasureGen.Items.Magical;

namespace TreasureGen.Domain.Generators.Items.Magical
{
    internal class WandGenerator : MagicalItemGenerator
    {
        private IPercentileSelector percentileSelector;
        private IChargesGenerator chargesGenerator;

        public WandGenerator(IPercentileSelector percentileSelector, IChargesGenerator chargesGenerator)
        {
            this.percentileSelector = percentileSelector;
            this.chargesGenerator = chargesGenerator;
        }

        public Item GenerateAtPower(string power)
        {
            var wand = new Item();
            wand.ItemType = ItemTypeConstants.Wand;
            wand.IsMagical = true;

            var tablename = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, wand.ItemType);
            var spell = percentileSelector.SelectFrom(tablename);
            wand.Magic.Charges = chargesGenerator.GenerateFor(wand.ItemType, spell);
            wand.Name = string.Format("Wand of {0}", spell);
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
    }
}