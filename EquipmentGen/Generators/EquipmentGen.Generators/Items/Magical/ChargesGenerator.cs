using System;
using D20Dice;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Magical;
using EquipmentGen.Selectors.Interfaces;

namespace EquipmentGen.Generators.Items.Magical
{
    public class ChargesGenerator : IChargesGenerator
    {
        private IDice dice;
        private IRangeAttributesSelector rangeAttributesSelector;

        public ChargesGenerator(IDice dice, IRangeAttributesSelector rangeAttributesSelector)
        {
            this.dice = dice;
            this.rangeAttributesSelector = rangeAttributesSelector;
        }

        public Int32 GenerateFor(String itemType, String name)
        {
            if (itemType == ItemTypeConstants.Wand || itemType == ItemTypeConstants.Staff)
                return PercentileCharges();

            if (name == "Deck of illusions" && dice.Percentile() <= 90)
                return 34;

            var rangeAttributesResult = rangeAttributesSelector.SelectFrom("ChargeLimits", name);
            var die = rangeAttributesResult.Maximum - rangeAttributesResult.Minimum + 1;
            var roll = String.Format("1d{0}", die);

            return dice.Roll(roll) + rangeAttributesResult.Minimum - 1;
        }

        private Int32 PercentileCharges()
        {
            var roll = dice.Percentile();
            return Math.Max(roll / 2, 1);
        }
    }
}