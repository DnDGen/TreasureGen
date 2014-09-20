using System;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Magical;
using EquipmentGen.Selectors.Interfaces;
using EquipmentGen.Tables.Interfaces;

namespace EquipmentGen.Generators.Items.Magical
{
    public class WandGenerator : IMagicalItemGenerator
    {
        private IPercentileSelector percentileSelector;
        private IChargesGenerator chargesGenerator;

        public WandGenerator(IPercentileSelector percentileSelector, IChargesGenerator chargesGenerator)
        {
            this.percentileSelector = percentileSelector;
            this.chargesGenerator = chargesGenerator;
        }

        public Item GenerateAtPower(String power)
        {
            var wand = new Item();
            wand.ItemType = ItemTypeConstants.Wand;
            wand.IsMagical = true;

            var tablename = String.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, wand.ItemType);
            var spell = percentileSelector.SelectFrom(tablename);
            wand.Magic.Charges = chargesGenerator.GenerateFor(wand.ItemType, spell);
            wand.Name = String.Format("Wand of {0}", spell);
            wand.Attributes = new[] { AttributeConstants.Charged, AttributeConstants.OneTimeUse };

            return wand;
        }
    }
}