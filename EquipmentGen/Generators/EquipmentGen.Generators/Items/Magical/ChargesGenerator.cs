using System;
using D20Dice;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Magical;
using EquipmentGen.Selectors.Interfaces;
using EquipmentGen.Tables.Interfaces;

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

            if (name == WondrousItemConstants.DeckOfIllusions)
            {
                var isFullyCharged = booleanPercentileSelector.SelectFrom(TableNameConstants.Percentiles.Set.IsDeckOfIllusionsFullyCharged);

                if (isFullyCharged)
                    name = WondrousItemConstants.FullDeckOfIllusions;
            }

            var result = rangeAttributesSelector.SelectFrom(TableNameConstants.Attributes.Set.ChargeLimits, name);
            var die = result.Maximum - result.Minimum + 1;

            return dice.Roll().d(die) - 1 + result.Minimum;
        }

        private Int32 PercentileCharges()
        {
            var roll = dice.Roll().Percentile();
            return Math.Max(roll / 2, 1);
        }
    }
}