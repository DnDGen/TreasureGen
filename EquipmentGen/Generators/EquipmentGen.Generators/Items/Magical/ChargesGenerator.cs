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
        private IBooleanPercentileSelector booleanPercentileSelector;

        public ChargesGenerator(IDice dice, IRangeAttributesSelector rangeAttributesSelector,
            IBooleanPercentileSelector booleanPercentileSelector)
        {
            this.dice = dice;
            this.rangeAttributesSelector = rangeAttributesSelector;
            this.booleanPercentileSelector = booleanPercentileSelector;
        }

        public Int32 GenerateFor(String itemType, String name)
        {
            if (itemType == ItemTypeConstants.Wand || itemType == ItemTypeConstants.Staff)
                return PercentileCharges();

            if (name == "Deck of illusions")
            {
                var roll = dice.Percentile();
                var isFullyCharged = booleanPercentileSelector.SelectFrom("IsDeckOfIllusionsFullyCharged", roll);

                if (isFullyCharged)
                    name = "Full deck of illusions";
            }

            var rangeAttributesResult = rangeAttributesSelector.SelectFrom("ChargeLimits", name);
            var die = rangeAttributesResult.Maximum - rangeAttributesResult.Minimum + 1;
            var toRoll = String.Format("1d{0}", die);

            return dice.Roll(toRoll) + rangeAttributesResult.Minimum - 1;
        }

        private Int32 PercentileCharges()
        {
            var roll = dice.Percentile();
            return Math.Max(roll / 2, 1);
        }
    }
}